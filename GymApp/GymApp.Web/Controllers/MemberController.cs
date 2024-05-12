using GymApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Web.Controllers
{
    public class MemberController : Controller
    {
        GymDbContext db = new GymDbContext();   
        public IActionResult Index()
        {
            // kayıt formu
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User model) {

            //todo: kayıt formu
            //todo: kullanıcı üyeliği alınacak
            return View();
        }

        public IActionResult Pricing(){
            var pricing = db.Pricings
                .Where(c => c.Status && c.Deleted == false).ToList();
            return View();  
        }
    }
}
