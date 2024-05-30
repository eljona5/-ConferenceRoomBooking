using Microsoft.AspNetCore.Mvc;

namespace ConferenceRoomBooking.Controllers
{
    using ConferenceRoomBooking.DataLayer.DBContext;
    using ConferenceRoomBooking.DataLayer.Entities;
    using ConferenceRoomBooking.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class UnavailabilityPeriodsController : Controller
    {
        private readonly ConferenceRoomBookingContext _context;

        public UnavailabilityPeriodsController(ConferenceRoomBookingContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.UnavailabilityPeriods.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UnavailabilityPeriod unavailabilityPeriod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unavailabilityPeriod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unavailabilityPeriod);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unavailabilityPeriod = await _context.UnavailabilityPeriods.FindAsync(id);
            if (unavailabilityPeriod == null)
            {
                return NotFound();
            }
            return View(unavailabilityPeriod);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UnavailabilityPeriod unavailabilityPeriod)
        {
            if (id != unavailabilityPeriod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unavailabilityPeriod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnavailabilityPeriodExists(unavailabilityPeriod.Id))
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
            return View(unavailabilityPeriod);
        }

        private bool UnavailabilityPeriodExists(int id)
        {
            return _context.UnavailabilityPeriods.Any(e => e.Id == id);
        }
    }

}