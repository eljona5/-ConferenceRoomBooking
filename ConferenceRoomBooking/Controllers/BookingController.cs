using ConferenceRoomBooking.DataLayer.DBContext;
using ConferenceRoomBooking.DataLayer.Entities;
using ConferenceRoomBooking.Models;

using ConferenceRoomBooking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceRoomBooking
{
    public class BookingController : Controller
    {
        private readonly ConferenceRoomBookingContext _conferenceRoomBookingContext;
        public BookingController(ConferenceRoomBookingContext conferenceRoomBookingContext)
        {
            _conferenceRoomBookingContext = conferenceRoomBookingContext;
        }

        public IActionResult Index(string filterTerm)
        {
            var bookings = _conferenceRoomBookingContext.Bookings;
            //.Where(p => (p.IsConfirmed == false || p.IsConfirmed == null))
            //.OrderBy(p => p.Code).ThenBy(p => p.StartDate)
            //.ThenBy(p => p.EndDate)
            //.ToList();

            //if (!string.IsNullOrEmpty(filterTerm))
            //{
            //    bookings = bookings.Where(p => p.Code.Contains(filterTerm)).ToList();

            //}
            return View(bookings);
        }
        public IActionResult Details(int id)
        {
            var bookings = _conferenceRoomBookingContext.Bookings
                .Where(p => p.Id == id)
                .FirstOrDefault();
            return View(bookings);
        }
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create([Bind("Code,StartDate,EndDate,Room")] Booking booking)
        {


            if (ModelState.IsValid)
            {
                var roomExists = _conferenceRoomBookingContext.Bookings
                     .Where(p => p.Id == booking.RoomId
                     && p.IsConfirmed != false
                     && p.IsDeleted != true)
                .FirstOrDefault();

                if (roomExists == null)
                {
                    return StatusCode(500, "Record does not existst");
                }
                booking.StartDate = DateTime.Now;
                _conferenceRoomBookingContext.Bookings.Add(booking);
                _conferenceRoomBookingContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return StatusCode(500, "Information is invalid");
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromQuery] int id)
        {
            var book = _conferenceRoomBookingContext.Bookings
                .Where(p => p.Id == id)
                .FirstOrDefault();
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update([Bind("Title, Description, AuthorID, Category,Id")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.StartDate = DateTime.Now;
                _conferenceRoomBookingContext.Bookings.Update(booking);
                _conferenceRoomBookingContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return StatusCode(500, "Information is invalid");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int Id)
        {
            var booking = _conferenceRoomBookingContext.Bookings
                .Where(p => p.Id == Id)
                .FirstOrDefault();
            //Soft Delete
            booking.IsDeleted = true;
            //book.UpdateDate = DateTime.Now;
            //Hard Delete
            //_onlineLibraryDbContext.Authors.Remove(author);
            _conferenceRoomBookingContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        private readonly ConferenceRoomBookingContext _context;

        [BindProperty]
        public Booking Booking { get; set; }

        public SelectList Rooms { get; set; }
        public SelectList ReservationHolders { get; set; }

        public IActionResult OnGet()
        {
            Rooms = new SelectList(_context.ConferenceRooms, "Id", "Code");
            ReservationHolders = new SelectList(_context.ReservationHolders, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Rooms = new SelectList(_context.ConferenceRooms, "Id", "Code");
                ReservationHolders = new SelectList(_context.ReservationHolders, "Id", "Name");
                return View();

            }

            var room = await _context.ConferenceRooms.FindAsync(Booking.RoomId);
            if (room == null)
            {
                ModelState.AddModelError(string.Empty, "Selected room does not exist.");
                return View();

            }

            if (Booking.NumberOfPeople > room.MaximumCapacity)
            {
                ModelState.AddModelError(string.Empty, "Number of people exceeds the maximum capacity.");
                return View();

            }

            var overlappingBooking = _context.Bookings
                .Where(b => b.RoomId == Booking.RoomId && b.IsConfirmed && !b.IsDeleted)
                .FirstOrDefault(b => b.StartDate < Booking.EndDate && b.EndDate > Booking.StartDate);

            if (overlappingBooking != null)
            {
                ModelState.AddModelError(string.Empty, "The room is already booked for the given time slot.");
                return View();

            }

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            Booking.Code = $"{Booking.StartDate:yyyyMMdd}-{Booking.StartDate:HHmm}-{Booking.EndDate:HHmm}-C{Booking.RoomId:D3}";
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }

}

