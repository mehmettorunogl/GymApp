using GymApp.Web.Models;
using GymApp.Web.Utis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Web.Areas.Management.Controllers
{
	public class CategoryController : Controller
	{
		//dependency injection
		private readonly IWebHostEnvironment _environment;
		GymDbContext db = new GymDbContext();
		// GET: CategoryController
		public CategoryController(IWebHostEnvironment environment)
		{
			_environment = environment;
		}
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

		[Authorize]
		// GET: CategorysController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CategorysController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Category model, IFormFile? img)
		{
			try
		    {
		    if (ModelState.IsValid)
		    {
				if (img != null)
				{
					model.ImageUrl = await ImageUploader.UploadImageAsync(_environment, img);
				}
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
			var Category = db.Categories.Find(id);
			if (Category == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return View(Category);
		}

		// POST: CategorysController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(About model, IFormFile? img)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var category = db.Categories.Find(model.Id);
					if (category == null)
					{
						return RedirectToAction(nameof(Index));

					}
					if (img != null)
					{
						await ImageUploader.DeleteImageAsync(_environment, category.ImageUrl);
						category.ImageUrl = await ImageUploader.UploadImageAsync(_environment, img);
					}
					category.Title = model.Title;
					category.Description = model.Description;
					category.UpdatedDate = model.UpdatedDate;
					category.UpdatedBy = 0;
					category.Status = model.Status;
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
