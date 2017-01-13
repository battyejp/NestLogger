using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NestLogger.Models
{
    public class ThermostateReading
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string RoomTemperature { get; set; }

        public string TargetTemperature { get; set; }
    }
}