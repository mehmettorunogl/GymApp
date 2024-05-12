using GymApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Web.Areas.Management.Controllers
{
	public class ContactController : Controller
	{
		GymDbContext db = new GymDbContext();
		// GET: ContactController
		public ActionResult Index()
		{
			var Contact = db.Contacts
				.Where(c => c.Deleted == false) //silinmemiş olanları getirmek için kullanılıyor. 
				.ToList();
			return View(Contact);
		}

		

		// GET: ContactController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ContactController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Contact model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					model.Status = true;
					model.CreatedDate = DateTime.Now;
					model.CreatedBy = 1;
					model.Deleted = false;
					db.Contacts.Add(model);
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

		// GET: ContactController/Edit/5
		public ActionResult Edit(int id)
		{
			var contact = db.Contacts.Find(id);
			if (contact == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return View(contact);
		}

		// POST: ContactController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Contact model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var editContact = db.Contacts.Find(model.Id);
					if (editContact == null)
					{
						return RedirectToAction(nameof(Index));
					}
					editContact.ImageUrl= model.ImageUrl;
					editContact.Title= model.Title;
					editContact.Description= model.Description;
					editContact.InstagramRedirectUrl= model.InstagramRedirectUrl;
					editContact.XRedirectUrl= model.XRedirectUrl;
					editContact.LinkedinRedirectUrl= model.LinkedinRedirectUrl;
					editContact.UpdatedBy = 0;
					editContact.UpdatedDate = DateTime.Now;
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

		// GET: ContactController/Delete/5
		public ActionResult Delete(int id)
		{
            var contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

		// POST: ContactController/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			try
			{


				var contact = db.Contacts.Find(id);
				if (contact == null)
				{
					return RedirectToAction(nameof(Index));
				}
				//soft delete
				contact.Deleted = true;
				contact.UpdatedDate = DateTime.Now;
				contact.UpdatedBy = 0;
				db.SaveChanges();

				//hard delete
				//db.Trainers.Remove(trainer);
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
