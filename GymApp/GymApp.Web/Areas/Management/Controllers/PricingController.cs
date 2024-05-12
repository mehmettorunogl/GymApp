using GymApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Web.Areas.Management.Controllers
{
    public class PricingController : Controller
    {
        GymDbContext db = new GymDbContext();
        // GET: PricingController
        public ActionResult Index()
        {
            var pricing = db.Pricings
                .Where(c => c.Deleted == false) //silinmemiş olanları getirmek için kullanılıyor. 
                .ToList();
            return View(pricing);
        }

        // GET: PricingController/Details/5
        public ActionResult Details(int id)
        {
            var pricing = db.Pricings.Find(id);
            // findda indexlenmiş idsiyle birlikte arama yapıyor
            if (pricing == null)
            {
                return RedirectToAction("Index");
                //böyle bir menü yoksa anasayfaya yönlendir demek
                //return RedirectToAction("Index","Dashboard");
                //böyle bir menü yoksa başka controllera yönlendir demek

            }
            return View(pricing);
        }

        // GET: PricingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PricingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pricing model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Status = true;
                    model.CreatedDate = DateTime.Now;
                    model.CreatedBy = 0;
                    model.Deleted = false;
                    db.Pricings.Add(model);
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

        // GET: PricingController/Edit/5
        public ActionResult Edit(int id)
        {
            var pricing = db.Pricings.Find(id);
            // findda indexlenmiş idsiyle birlikte arama yapıyor
            if (pricing == null)
            {
                return RedirectToAction("Index");
                //böyle bir menü yoksa anasayfaya yönlendir demek
                //return RedirectToAction("Index","Dashboard");
                //böyle bir menü yoksa başka controllera yönlendir demek

            }
            return View(pricing);
        }

        // POST: PricingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pricing model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var editPricing = db.Pricings.Find(model.Id);
                    if (editPricing == null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    editPricing.Title = model.Title;
                    editPricing.Description = model.Description;
                    editPricing.Price = model.Price;
                    editPricing.StartTime = model.StartTime;
                    editPricing.StopTime = model.StopTime;
                    editPricing.MonthCount = model.MonthCount;
                    editPricing.DiscountRate = model.DiscountRate;
                    editPricing.UpdatedBy = 0;
                    editPricing.UpdatedDate = DateTime.Now;
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

        // GET: PricingController/Delete/5
        public ActionResult Delete(int id)
        {
            var pricing = db.Pricings.Find(id);
            if (pricing == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(pricing);
        }

        // POST: PricingController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var pricing = db.Pricings.Find(id);
                if (pricing == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                //soft delete
                pricing.Deleted = true;
                pricing.UpdatedDate = DateTime.Now;
                pricing.UpdatedBy = 0;
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
