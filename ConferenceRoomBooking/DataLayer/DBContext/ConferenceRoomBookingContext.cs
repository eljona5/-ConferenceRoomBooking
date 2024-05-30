using ConferenceRoomBooking.DataLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ConferenceRoomBooking.DataLayer.DBContext
{
    public class ConferenceRoomBookingContext : DbContext
    {
        public ConferenceRoomBookingContext(DbContextOptions<ConferenceRoomBookingContext> options)
        : base(options)
        {
        }

        public DbSet<ConferenceRoom> ConferenceRooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ReservationHolder> ReservationHolders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UnavailabilityPeriod> UnavailabilityPeriods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany()
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Restrict); // Or Cascade depending on your requirements

            modelBuilder.Entity<ReservationHolder>()
                .HasOne(rh => rh.Booking)
                .WithMany()
                .HasForeignKey(rh => rh.BookingId)
                .OnDelete(DeleteBehavior.Cascade); // Or Restrict depending on your requirements
        }
    }
}
