using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NestLogger.Dtos;

namespace NestLogger.Models.ViewModels
{
    public class DaySummary
    {
        public int MeterReading { get; set; }

        public int UnitsUsed { get; set; }

        public double EnergyUsed => (UnitsUsed*1.022640*39.5)/3.6;

        public double EnergyCost => EnergyUsed*0.0375;

        public double DayCharge => 0.1409;

        public double TotalChargeNoVAT => EnergyCost + DayCharge;

        public double TotalCharge => ((TotalChargeNoVAT/100)*5) + TotalChargeNoVAT;

        public IEnumerable<ThermostateReading> ThermostateReadings { get; set; } 
    }
}