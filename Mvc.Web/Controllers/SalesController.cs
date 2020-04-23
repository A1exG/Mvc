using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc.Web.Models;

namespace Mvc.Web.Controllers
{
    public class SalesController : Controller
    {
        private AnseremDbEntities db = new AnseremDbEntities();

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Сities).Include(s => s.Сontacts).Include(s => s.Сounterpartys);
            return View(sales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Сities, "CityId", "CityName");
            ViewBag.ContactId = new SelectList(db.Сontacts, "ContactId", "CounterpartyContact");
            ViewBag.СounterpartyId = new SelectList(db.Сounterpartys, "СounterpartyId", "СounterpartyName");
            return View();
        }

        // POST: Sales/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleId,SaleName,СounterpartyId,ContactId,CityId")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Сities, "CityId", "CityName", sales.CityId);
            ViewBag.ContactId = new SelectList(db.Сontacts, "ContactId", "CounterpartyContact", sales.ContactId);
            ViewBag.СounterpartyId = new SelectList(db.Сounterpartys, "СounterpartyId", "СounterpartyName", sales.СounterpartyId);
            return View(sales);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Сities, "CityId", "CityName", sales.CityId);
            ViewBag.ContactId = new SelectList(db.Сontacts, "ContactId", "CounterpartyContact", sales.ContactId);
            ViewBag.СounterpartyId = new SelectList(db.Сounterpartys, "СounterpartyId", "СounterpartyName", sales.СounterpartyId);
            return View(sales);
        }

        // POST: Sales/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleId,SaleName,СounterpartyId,ContactId,CityId")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Сities, "CityId", "CityName", sales.CityId);
            ViewBag.ContactId = new SelectList(db.Сontacts, "ContactId", "CounterpartyContact", sales.ContactId);
            ViewBag.СounterpartyId = new SelectList(db.Сounterpartys, "СounterpartyId", "СounterpartyName", sales.СounterpartyId);
            return View(sales);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sales sales = db.Sales.Find(id);
            db.Sales.Remove(sales);
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
