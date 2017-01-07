using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarApplication.Models;
using CarApplication.DAL;

namespace CarApplication.Controllers
{
    public class BrandModelController : Controller
    {
        private CarModelContext db = new CarModelContext();

        // GET: /BrandModel/
        public ActionResult Index(int? SelectedManufacturer)
        {
            var manufacturer = db.Manufacturer.OrderBy(q => q.BrandName).ToList();
            ViewBag.SelectedManufacturer = new SelectList(manufacturer, "ManufacturerID", "BrandName", SelectedManufacturer);
            int manufacturerID = SelectedManufacturer.GetValueOrDefault();

            IQueryable<BrandModel> brandModel = db.BrandModel
                .Where(c => !SelectedManufacturer.HasValue || c.ManufacturerID == manufacturerID)
                .OrderBy(d => d.ModelID)
                .Include(d => d.Manufacturer);
            var sql = manufacturer.ToString();
            return View(brandModel.ToList());

            //return View(db.BrandModel.ToList());
        }

        // GET: /BrandModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandModel brandmodel = db.BrandModel.Find(id);
            if (brandmodel == null)
            {
                return HttpNotFound();
            }
            return View(brandmodel);
        }

        // GET: /BrandModel/Create
        public ActionResult Create()
        {
            PopulateManufacturerDropDownList();
            return View();
        }

        // POST: /BrandModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelID,ModelName,ModelPrice,ManufacturerID")] BrandModel brandmodel)
        {
            if (ModelState.IsValid)
            {
                db.BrandModel.Add(brandmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateManufacturerDropDownList(brandmodel.ManufacturerID);
            return View(brandmodel);
        }

        private void PopulateManufacturerDropDownList(object selectedManufacturer = null)
        {
            var manufacturerQuery = from d in db.Manufacturer
                                    orderby d.BrandName
                                    select d;
            ViewBag.ManufacturerID = new SelectList(manufacturerQuery, "ManufacturerID", "BrandName", selectedManufacturer);
        }

        // GET: /BrandModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandModel brandmodel = db.BrandModel.Find(id);
            if (brandmodel == null)
            {
                return HttpNotFound();
            }
            PopulateManufacturerDropDownList(brandmodel.ManufacturerID);
            return View(brandmodel);
        }

        // POST: /BrandModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ModelID,ModelName,ModelPrice,ManufacturerID")] BrandModel brandmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brandmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brandmodel);
        }

        // GET: /BrandModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandModel brandmodel = db.BrandModel.Find(id);
            if (brandmodel == null)
            {
                return HttpNotFound();
            }
            return View(brandmodel);
        }

        // POST: /BrandModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BrandModel brandmodel = db.BrandModel.Find(id);
            db.BrandModel.Remove(brandmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
