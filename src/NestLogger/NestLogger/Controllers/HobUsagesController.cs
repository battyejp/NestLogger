using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NestLogger.Dtos;
using NestLogger.Models;

namespace NestLogger.Controllers
{
    public class HobUsagesController : Controller
    {
        private NestLoggerContext db = new NestLoggerContext();

        // GET: HobUsages
        public ActionResult Index()
        {
            return View(db.HobUsages.ToList());
        }

        // GET: HobUsages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HobUsage hobUsage = db.HobUsages.Find(id);
            if (hobUsage == null)
            {
                return HttpNotFound();
            }
            return View(hobUsage);
        }

        // GET: HobUsages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HobUsages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,MinutesUsed")] HobUsage hobUsage)
        {
            if (ModelState.IsValid)
            {
                db.HobUsages.Add(hobUsage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hobUsage);
        }

        // GET: HobUsages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HobUsage hobUsage = db.HobUsages.Find(id);
            if (hobUsage == null)
            {
                return HttpNotFound();
            }
            return View(hobUsage);
        }

        // POST: HobUsages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,MinutesUsed")] HobUsage hobUsage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hobUsage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hobUsage);
        }

        // GET: HobUsages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HobUsage hobUsage = db.HobUsages.Find(id);
            if (hobUsage == null)
            {
                return HttpNotFound();
            }
            return View(hobUsage);
        }

        // POST: HobUsages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HobUsage hobUsage = db.HobUsages.Find(id);
            db.HobUsages.Remove(hobUsage);
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
