namespace ConferenceRoomBooking.Controllers
{
    using ConferenceRoomBooking.DataLayer.DBContext;
    using ConferenceRoomBooking.DataLayer.Entities;
    using ConferenceRoomBooking.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class ReservationHoldersController : Controller
    {
        private readonly ConferenceRoomBookingContext _context;

        public ReservationHoldersController(ConferenceRoomBookingContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reservationHolders = await _context.ReservationHolders.Include(r => r.Booking).ToListAsync();
            return View(reservationHolders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationHolder reservationHolder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationHolder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservationHolder);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationHolder = await _context.ReservationHolders.FindAsync(id);
            if (reservationHolder == null)
            {
                return NotFound();
            }
            return View(reservationHolder);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ReservationHolder reservationHolder)
        {
            if (id != reservationHolder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationHolder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationHolderExists(reservationHolder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservationHolder);
        }

        private bool ReservationHolderExists(int id)
        {
            return _context.ReservationHolders.Any(e => e.Id == id);
        }
    }

}