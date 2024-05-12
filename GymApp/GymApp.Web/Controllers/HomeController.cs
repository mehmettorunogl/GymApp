using GymApp.Web.Helpers;
using GymApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GymApp.Web.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        GymDbContext db = new GymDbContext();

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            var mainpage = db.MainPages.FirstOrDefault();
            return View(mainpage);
        }

        public IActionResult About() {
            var about = db.Abouts.FirstOrDefault();
            return View(about);
        }
        public IActionResult Contact() {
            var contact = db.Contacts.FirstOrDefault();
            return View(contact);  
        }
        public IActionResult Privacy() {
            return View();
        }



		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ContactMessage(ContactMessage model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					model.Status = true;
					model.CreatedDate = DateTime.Now;
					model.CreatedBy = 0;
					model.Deleted = false;
					db.ContactMessages.Add(model);
					db.SaveChanges();

					//mail göndemre

					MailSender.SendMail(model.FullName, new List<string> { model.Email }, model.Title,model.Message);

					return RedirectToAction(nameof(Index));
				}
				return View(model);
			}
			catch
			{
				return View(model);
			}

		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
