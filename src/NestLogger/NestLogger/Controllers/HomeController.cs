using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NestLogger.Models;
using NestLogger.Models.ViewModels;

namespace NestLogger.Controllers
{
    public class HomeController : Controller
    {
        private NestLoggerContext db = new NestLoggerContext();

        // GET: Home
        public ActionResult Index(DateTime? date)
        {
            if (!date.HasValue)
                return RedirectToAction("Index", new { date = DateTime.Today });

            var daySummary = new DaySummary();
            daySummary.ThermostateReadings = db.ThermostateReadings.ToList()
                .Where(x => x.DateTime.Date == date);

            var meterReading = db.MeterReadings.ToList()
                .SingleOrDefault(x => x.DateTime.Date == date.Value);

            if (meterReading != null)
            {
                var previousMeterReading = db.MeterReadings.ToList()
                    .SingleOrDefault(x => x.DateTime.Date == date.Value.AddDays(-1));

                daySummary.MeterReading = meterReading.Value;

                if (previousMeterReading != null)
                {
                    daySummary.UnitsUsed = meterReading.Value - previousMeterReading.Value;
                }
            }

            return View(daySummary);
        }
    }
}