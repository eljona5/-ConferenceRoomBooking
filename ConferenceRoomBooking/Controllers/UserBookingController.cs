using Microsoft.AspNetCore.Mvc;

namespace ConferenceRoomBooking.Controllers
{
    public class UserBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
