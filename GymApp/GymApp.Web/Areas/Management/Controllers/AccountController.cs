using GymApp.Web.Areas.Management.Models;
using GymApp.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GymApp.Web.Areas.Management.Controllers
{
    public class AccountController : Controller
    {
        GymDbContext db = new GymDbContext();
        public IActionResult Login()
        {
			ViewBag.Message = "";
			return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password 
                                                                               && u.Status 
                                                                               && u.Deleted == false);

                if (user == null)
                {
                    ViewBag.Message = "Böyle Bir Kullanıcı Bulunamadı";
					return View(model);
				}
				var claims = new List<Claim>
					{
						new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
						new Claim(ClaimTypes.Name, user.FullName),
						new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Email, "email"),
                        new Claim("Phone", user.Phone),
                    };
				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				var authProperties = new AuthenticationProperties
				{
					IssuedUtc = DateTime.UtcNow,
					ExpiresUtc = DateTime.UtcNow.AddHours(6),
				};
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
												  new ClaimsPrincipal(claimsIdentity),
												  authProperties);
				return RedirectToAction("Index", "Dashboard");
			}
			ViewBag.Message = "Bilgilerinizi Eksiksiz Doldurun";
			return View(model);
		}
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Login");
		}
	}
}
