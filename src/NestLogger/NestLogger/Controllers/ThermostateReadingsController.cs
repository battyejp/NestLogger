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
    public class ThermostateReadingsController : Controller
    {
        private NestLoggerContext db = new NestLoggerContext();

        // GET: ThermostateReadings
        public ActionResult Index(DateTime? date)
        {
            var readings = db.ThermostateReadings.ToList()
                .Where(x => !date.HasValue|| x.DateTime.Date == date.Value);

            return View(readings);
        }

        // GET: ThermostateReadings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThermostateReading thermostateReading = db.ThermostateReadings.Find(id);
            if (thermostateReading == null)
            {
                return HttpNotFound();
            }
            return View(thermostateReading);
        }

        // GET: ThermostateReadings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThermostateReadings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateTime,RoomTemperature,TargetTemperature,OutsideTemperature,JsonReading,WeatherJsonReading")] ThermostateReading thermostateReading)
        {
            if (ModelState.IsValid)
            {
                db.ThermostateReadings.Add(thermostateReading);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thermostateReading);
        }

        // GET: ThermostateReadings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThermostateReading thermostateReading = db.ThermostateReadings.Find(id);
            if (thermostateReading == null)
            {
                return HttpNotFound();
            }
            return View(thermostateReading);
        }

        // POST: ThermostateReadings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime,RoomTemperature,TargetTemperature,OutsideTemperature,JsonReading,WeatherJsonReading")] ThermostateReading thermostateReading)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thermostateReading).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thermostateReading);
        }

        // GET: ThermostateReadings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThermostateReading thermostateReading = db.ThermostateReadings.Find(id);
            if (thermostateReading == null)
            {
                return HttpNotFound();
            }
            return View(thermostateReading);
        }

        // POST: ThermostateReadings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThermostateReading thermostateReading = db.ThermostateReadings.Find(id);
            db.ThermostateReadings.Remove(thermostateReading);
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
