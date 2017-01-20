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
    public class HotWaterSchedulesController : Controller
    {
        private NestLoggerContext db = new NestLoggerContext();

        // GET: HotWaterSchedules
        public ActionResult Index()
        {
            return View(db.HotWaterSchedules.ToList());
        }

        // GET: HotWaterSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotWaterSchedule hotWaterSchedule = db.HotWaterSchedules.Find(id);
            if (hotWaterSchedule == null)
            {
                return HttpNotFound();
            }
            return View(hotWaterSchedule);
        }

        // GET: HotWaterSchedules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotWaterSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTime,EndTime,StartDate,EndDate")] HotWaterSchedule hotWaterSchedule)
        {
            if (ModelState.IsValid)
            {
                db.HotWaterSchedules.Add(hotWaterSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotWaterSchedule);
        }

        // GET: HotWaterSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotWaterSchedule hotWaterSchedule = db.HotWaterSchedules.Find(id);
            if (hotWaterSchedule == null)
            {
                return HttpNotFound();
            }
            return View(hotWaterSchedule);
        }

        // POST: HotWaterSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,EndTime,StartDate,EndDate")] HotWaterSchedule hotWaterSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotWaterSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotWaterSchedule);
        }

        // GET: HotWaterSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotWaterSchedule hotWaterSchedule = db.HotWaterSchedules.Find(id);
            if (hotWaterSchedule == null)
            {
                return HttpNotFound();
            }
            return View(hotWaterSchedule);
        }

        // POST: HotWaterSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotWaterSchedule hotWaterSchedule = db.HotWaterSchedules.Find(id);
            db.HotWaterSchedules.Remove(hotWaterSchedule);
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
