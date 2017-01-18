using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NestLogger.Dtos;

namespace NestLogger.Models.ViewModels
{
    public class CostSummary
    {
        public CostSummary()
        {
            
        }

        public CostSummary(int currentMeterReadingValue, int previousMeterReadingValue, int daysBetweenReadings)
        {
            NumberOfDays = daysBetweenReadings;
            UnitsUsed = currentMeterReadingValue - previousMeterReadingValue;
            EnergyUsed = (UnitsUsed * 1.022640 * 39.5) / 3.6;
            EnergyCost = EnergyUsed*0.0375;
            FixedCharged = (DayCharge * daysBetweenReadings);
            TotalChargeNoVAT = EnergyCost + FixedCharged;
            TotalCharge = ((TotalChargeNoVAT / 100) * 5) + TotalChargeNoVAT;
        }

        public int UnitsUsed { get; }

        public double EnergyUsed { get; }

        public double EnergyCost { get;}

        public double TotalChargeNoVAT { get; }

        public double TotalCharge { get; private set; }

        public double DayCharge => 0.1409;

        public double FixedCharged { get; }

        public int NumberOfDays { get; private set; }
    }
}