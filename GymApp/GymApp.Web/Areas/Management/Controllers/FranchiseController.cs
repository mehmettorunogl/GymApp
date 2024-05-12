using GymApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Versioning;

namespace GymApp.Web.Areas.Management.Controllers
{
	public class FranchiseController : Controller
	{
		// GET: FranchiseController
		GymDbContext db = new GymDbContext();
		public ActionResult Index()
		{
			var Franchise = db.Franchises
				.Where(c => c.Deleted == false) //silinmemiş olanları getirmek için kullanılıyor. 
				.ToList();
			return View(Franchise);
		}

		// GET: FranchiseController/Details/5
		public ActionResult Details(int id)
		{
			var franchise = db.Franchises.Find(id);
			// findda indexlenmiş idsiyle birlikte arama yapıyor
			if (franchise == null)
			{
				return RedirectToAction("Index");
				//böyle bir menü yoksa anasayfaya yönlendir demek
				//return RedirectToAction("Index","Dashboard");
				//böyle bir menü yoksa başka controllera yönlendir demek

			}
			return View(franchise);
		}

		// GET: FranchiseController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: FranchiseController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Franchise model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					model.Status = true;
					model.CreatedDate = DateTime.Now;
					model.CreatedBy = 0;
					model.Deleted = false;
					db.Franchises.Add(model);
					db.SaveChanges();
					return RedirectToAction(nameof(Index));
				}
				return View(model);
			}
			catch
			{
				return View(model);
			}
		}

		// GET: FranchiseController/Edit/5
		public ActionResult Edit(int id)
		{
			var franchise = db.Franchises.Find(id);
			// findda indexlenmiş idsiyle birlikte arama yapıyor
			if (franchise == null)
			{
				return RedirectToAction("Index");
				//böyle bir menü yoksa anasayfaya yönlendir demek
				//return RedirectToAction("Index","Dashboard");
				//böyle bir menü yoksa başka controllera yönlendir demek

			}
			return View(franchise);
		}

		// POST: FranchiseController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Franchise model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var editFranchise = db.Franchises.Find(model.Id);
					if (editFranchise == null)
					{
						return RedirectToAction(nameof(Index));
					}
					editFranchise.Email = model.Email;
					editFranchise.Phone = model.Phone;
					editFranchise.WorkingTime = model.WorkingTime;
					editFranchise.UpdatedBy = 0;
					editFranchise.UpdatedDate = DateTime.Now;
					db.SaveChanges();
					return RedirectToAction(nameof(Index));
				}
				return View(model);
			}
			catch
			{
				return View(model);
			}
		}

		// GET: FranchiseController/Delete/5
		public ActionResult Delete(int id)
		{
			var franchise = db.Franchises.Find(id);
			// findda indexlenmiş idsiyle birlikte arama yapıyor
			if (franchise == null)
			{
				return RedirectToAction("Index");
				//böyle bir menü yoksa anasayfaya yönlendir demek
				//return RedirectToAction("Index","Dashboard");
				//böyle bir menü yoksa başka controllera yönlendir demek

			}
			return View(franchise);
		}

		// POST: FranchiseController/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			try
			{


				var franchise = db.Franchises.Find(id);
				if (franchise == null)
				{
					return RedirectToAction(nameof(Index));
				}
				//soft delete
				franchise.Deleted = true;
				franchise.UpdatedDate = DateTime.Now;
				franchise.UpdatedBy = 0;
				db.SaveChanges();

				//hard delete
				//db.Franchises.Remove(franchise);
				//db.SaveChanges();
				return RedirectToAction(nameof(Index));

			}
			catch
			{
				return RedirectToAction(nameof(Index));
			}
		}
	}
}
