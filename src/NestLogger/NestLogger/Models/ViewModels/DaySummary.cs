using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NestLogger.Dtos;

namespace NestLogger.Models.ViewModels
{
    public class DaySummary
    {
        public double MeterReading { get; set; }

        public CostSummary CostSummary { get; set; }

        public IEnumerable<ThermostateReading> ThermostateReadings { get; set; } 
    }
}