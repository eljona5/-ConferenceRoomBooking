using Microsoft.AspNetCore.Mvc;

namespace ConferenceRoomBooking.Controllers
{
    using ConferenceRoomBooking.DataLayer.DBContext;
    using ConferenceRoomBooking.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class ConferenceRoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConferenceRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ConferenceRooms.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConferenceRoom conferenceRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conferenceRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conferenceRoom);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conferenceRoom = await _context.ConferenceRooms.FindAsync(id);
            if (conferenceRoom == null)
            {
                return NotFound();
            }
            return View(conferenceRoom);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ConferenceRoom conferenceRoom)
        {
            if (id != conferenceRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conferenceRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConferenceRoomExists(conferenceRoom.Id))
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
            return View(conferenceRoom);
        }

        private bool ConferenceRoomExists(int id)
        {
            return _context.ConferenceRooms.Any(e => e.Id == id);
        }
    }

}
