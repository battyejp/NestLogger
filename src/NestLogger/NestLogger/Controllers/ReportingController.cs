using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ApplicationInsights.DataContracts;
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
            date = date.AddHours(12); // so deals with BST
            var meterReading = db.MeterReadings.ToList().SingleOrDefault(x => x.DateTime.Date == date.Date);

            var telemetry = new Microsoft.ApplicationInsights.TelemetryClient();
            telemetry.TrackTrace("MeterReading Post date",
                           SeverityLevel.Information,
                           new Dictionary<string, string> { { "date", date.ToShortDateString() }, { "date2", date.ToString()}, { "date3", date.ToLongDateString() } });

            if (meterReading != null)
                return Json(meterReading.Value);
            else
                return Json(0);
        }
    }
}