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

        public CostSummary(double currentMeterReadingValue, double previousMeterReadingValue, int daysBetweenReadings)
        {
            NumberOfDays = daysBetweenReadings;
            UnitsUsed = currentMeterReadingValue - previousMeterReadingValue;
            RoundedUnitsUsed = (int) currentMeterReadingValue - (int) previousMeterReadingValue;
            EnergyUsed = (RoundedUnitsUsed * 1.022640 * 39.7) / 3.6;
            EnergyCost = EnergyUsed*0.02726;
            FixedCharged = (DayCharge * daysBetweenReadings);
            TotalChargeNoVAT = EnergyCost + FixedCharged;
            TotalCharge = ((TotalChargeNoVAT / 100) * 5) + TotalChargeNoVAT;
        }

        public double UnitsUsed { get; }

        public double EnergyUsed { get; }

        public double EnergyCost { get;}

        public double TotalChargeNoVAT { get; }

        public double TotalCharge { get; private set; }

        public double DayCharge => 0.1827;

        public double FixedCharged { get; }

        public int NumberOfDays { get; private set; }

        public int RoundedUnitsUsed { get; private set; }

    }
}