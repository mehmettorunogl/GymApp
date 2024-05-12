using GymApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Web.Areas.Management.Controllers
{
	public class CategoryController : Controller
	{
		GymDbContext db = new GymDbContext();

		// GET: CategorysController
		public ActionResult Index()
		{
			var category = db.Categories
				.Where(c => c.Deleted == false) //silinmemiş olanları getirmek için kullanılıyor. 
				.ToList();
			return View(category);
		}

		// GET: CategorysController/Details/5
		public ActionResult Details(int id)
		{
            var category = db.Categories
                .Include("Courses")
                .FirstOrDefault(c => c.Id == id);
            // findda indexlenmiş idsiyle birlikte arama yapıyor
            if (category == null)
            {
                return RedirectToAction("Index");
                //böyle bir menü yoksa anasayfaya yönlendir demek
                //return RedirectToAction("Index","Dashboard");
                //böyle bir menü yoksa başka controllera yönlendir demek

            }
            return View(category);
        }

		// GET: CategorysController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CategorysController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Category model)
		{
            try
            {
                if (ModelState.IsValid)
                {
                    model.Status = true;
                    model.CreatedDate = DateTime.Now;
                    model.CreatedBy = 0;
                    model.Deleted = false;
                    db.Categories.Add(model);
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

		// GET: CategorysController/Edit/5
		public ActionResult Edit(int id)
		{
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

		// POST: CategorysController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Category model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var editCategory = db.Categories.Find(model.Id);
					if (editCategory == null)
					{
						return RedirectToAction(nameof(Index));
					}
                    editCategory.Status = model.Status;
                    editCategory.Title = model.Title;
                    editCategory.Description = model.Description;
                    editCategory.UpdatedDate = DateTime.Now;
                    editCategory.UpdatedBy = 0;
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

		// GET: CategorysController/Delete/5
		public ActionResult Delete(int id)
		{
			var category = db.Categories.Find(id);
			if (category == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}

        // POST: CategorysController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var category = db.Categories.Find(id);
                if (category == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                //soft delete
                category.UpdatedDate = DateTime.Now;
                category.UpdatedBy = 0;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
