using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;

            ViewData["Selamlama"] = saat > 12 ? "Ýyi Günler" : "Günaydýn"; // Saat bilgisine göre selamlamayý model ile göndermek yerine ViewData ile View'e gönderdik.

            int UserCount = Repository.Users.Where(info => info.WillAttend == true).Count();

            var meetingInfo = new MeetingInfo() // Oluþturduðumuz "MeetingInfo" sýnýfýndan nesne tanýmladýk.
            {
                ID = 1,
                Location = "Ankara, Çankaya Kongre Merkezi",
                Date = new DateTime(2024, 01, 20),
                NumberOfPeople = UserCount
            };

            return View(meetingInfo); // Oluþturduðumuz deðerleri nesne ile View'e gönderdik.
        }
    }
}
