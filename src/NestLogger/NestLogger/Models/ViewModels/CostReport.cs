using System;

namespace NestLogger.Models.ViewModels
{
    public class CostReport
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int StartMeterReading { get; set; }

        public int EndMeterReading { get; set; }

        public CostSummary CostSummary { get; set; }
    }
}