using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;

            ViewData["Selamlama"] = saat > 12 ? "�yi G�nler" : "G�nayd�n"; // Saat bilgisine g�re selamlamay� model ile g�ndermek yerine ViewData ile View'e g�nderdik.

            int UserCount = Repository.Users.Where(info => info.WillAttend == true).Count();

            var meetingInfo = new MeetingInfo() // Olu�turdu�umuz "MeetingInfo" s�n�f�ndan nesne tan�mlad�k.
            {
                ID = 1,
                Location = "Ankara, �ankaya Kongre Merkezi",
                Date = new DateTime(2024, 01, 20),
                NumberOfPeople = UserCount
            };

            return View(meetingInfo); // Olu�turdu�umuz de�erleri nesne ile View'e g�nderdik.
        }
    }
}
