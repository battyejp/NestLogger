using System;

namespace NestLogger.Models.ViewModels
{
    public class CostReport
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double StartMeterReading { get; set; }

        public double EndMeterReading { get; set; }

        public CostSummary CostSummary { get; set; }
    }
}