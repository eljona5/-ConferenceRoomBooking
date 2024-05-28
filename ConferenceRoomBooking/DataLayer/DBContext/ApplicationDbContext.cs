using ConferenceRoomBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ConferenceRoomBooking.DataLayer.DBContext
{
    using ConferenceRoomBooking.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<ConferenceRoom> ConferenceRooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ReservationHolder> ReservationHolders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UnavailabilityPeriod> UnavailabilityPeriods { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }

}

