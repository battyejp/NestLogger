using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NestLogger.Models;
using NestLogger.Models.ViewModels;

namespace NestLogger.Controllers
{
    public class ReportingController : Controller
    {
        private NestLoggerContext db = new NestLoggerContext();

        // GET: Reporting
        public ActionResult Index()
        {
            var costReport = new CostReport
            {
                StartDate = DateTime.Today.AddDays(-7),
                EndDate = DateTime.Today
            };

            return View(costReport);
        }

        // POST: MeterReadings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "StartDate,EndDate,StartMeterReading,EndMeterReading")] CostReport costReport)
        {
            if (ModelState.IsValid)
            {
                if (costReport.StartMeterReading == 0 || costReport.EndMeterReading == 0)
                {
                    ModelState.AddModelError("StartMeterReading", "Select Dates that have a meter reading");
                    return View(costReport);
                }

                costReport.CostSummary = new CostSummary(costReport.EndMeterReading, costReport.StartMeterReading, (int)(costReport.EndDate - costReport.StartDate).TotalDays);
            }

            return View(costReport);
        }

        [HttpPost]
        public JsonResult MeterReading(DateTime date)
        {
            var meterReading = db.MeterReadings.SingleOrDefault(x => x.DateTime == date);

            if (meterReading != null)
                return Json(meterReading.Value);
            else
                return Json(0);
        }
    }
}