using System;

namespace NestLogger.Dtos
{
    public class MeterReading
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public double Value { get; set; }
    }
}
