using System;

namespace NestLogger.Dtos
{
    public class ThermostateReading
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string RoomTemperature { get; set; }

        public string TargetTemperature { get; set; }

        public string OutsideTemperature { get; set; }

        public string JsonReading { get; set; }

        public string WeatherJsonReading { get; set; }
    }
}