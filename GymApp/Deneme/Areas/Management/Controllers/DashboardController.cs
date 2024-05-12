using Microsoft.AspNetCore.Mvc;

namespace Deneme.Areas.Management.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
