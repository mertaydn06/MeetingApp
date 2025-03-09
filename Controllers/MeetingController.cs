using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class MeetingController : Controller
    {
        public IActionResult Apply() // Formu GET ile kullanıcının karşına getirdik.
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(UserInfo model) // Formdan gelen veri burada karşılanır.
        {
            if (ModelState.IsValid) // Form Validations'lar sağlanmışsa kişi kaydedilir.
            {
                Repository.CreateUser(model); // Formdan gelen kişiyi kaydettik.
                ViewBag.UserCount = Repository.Users.Where(info => info.WillAttend == true).Count();  // Katılanların sayısını aldık.
                return View("Thanks", model); // Başvuruya katılıp katılmama durumu belirlendikten sonra "Thanks" view'ına model ile birlikte yönlendirme yaptık.
            }
            else
            {
                return View(model); // Doğrulama yüzünden kaydedilemeyen kişiyi tekrardan View'e gönderiyoruz ve boş yerlere yeniden yazılıyor.
            }
        }

        public IActionResult List()
        {
            return View(Repository.Users);
        }

        public IActionResult Details(int id)
        {
            return View(Repository.GetById(id)); // Parametre olarak alınan id, sistemdeki bir id ile eşleşirse kullanıcının bilgilerini View'e gönderir.
        }
    }
}
