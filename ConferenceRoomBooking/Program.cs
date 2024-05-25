using ConferenceRoomBooking.DataLayer.DBContext;
using ConferenceRoomBooking.DataLayer.Repositories;
using ConferenceRoomBooking.Services;
using ConferenceRoomBooking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ConferenceRoomBookingContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Library"));
});


#region 
//dependecy injection
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IReservationHolderRepository, ReservationHolderRepository>();
builder.Services.AddScoped<IConferenceRoomRepository, ConferenceRoomRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnavailabilityPeriodRepository, UnavailabilityPeriodRepository>();


builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IReservationHolderService, ReservationHolderService>();
builder.Services.AddScoped<IConferenceRoomService, ConferenceRoomService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnavailabilityPeriodService, UnavailabilityPeriodService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
