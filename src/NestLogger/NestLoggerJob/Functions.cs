using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Flurl;
using Flurl.Http;
using NestLogger.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace NestLoggerJob
{
    public class Functions
    {
        // This function will be triggered based on the schedule you have set for this WebJob
        // This function will enqueue a message on an Azure Queue called queue
        [NoAutomaticTrigger]
        public static void ManualTrigger(TextWriter log, int value, [Queue("queue")] out string message)
        {
            log.WriteLine("Function is invoked with value={0}", value);
            message = value.ToString();
            log.WriteLine("Following message will be written on the Queue={0}", message);


            var reading = GetThermostateReading();
            var weatherReadingJson = GetJsonWeatherReading(log);
            reading.WeatherJsonReading = weatherReadingJson;

            if (!string.IsNullOrWhiteSpace(weatherReadingJson))
            {
                var jobj = JObject.Parse(weatherReadingJson);
                var temp = jobj["main"]["temp"].ToString();
                var tempVal = double.Parse(temp);
                var tempInC = tempVal - 273.15;
                reading.OutsideTemperature = tempInC.ToString("0.#");
            }

            UploadReading(reading, log);
        }

        private static string GetJsonWeatherReading(TextWriter log)
        {
            string jsonStr = string.Empty;

            try
            {
                jsonStr = "http://api.openweathermap.org/data/2.5/weather?q=ls297sy,uk&appid=6b3fbed55067d35f5c7c29f95192bfaf".GetStringAsync().Result;
            }
            catch (Exception ex)
            {
                log.WriteLine($"Error getting weather reading");
            }

            return jsonStr;
        }

        private static void UploadReading(ThermostateReading reading, TextWriter log)
        {
            var json = JsonConvert.SerializeObject(reading);

            var client = new RestClient("http://nestlogger.azurewebsites.net/api/ThermostateReadingsservice");
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.Created)
            {
                log.WriteLine($"Error posting reading at {reading.DateTime.ToShortDateString()}");
            }

            log.WriteLine($"Success posting reading at {reading.DateTime.ToShortDateString()}");
        }

        private static ThermostateReading GetThermostateReading()
        {
            string readingStr = null;

            try
            {
                readingStr = GetJsonThermostateReading("https://developer-api.nest.com/devices/thermostats/xojpoFNq0Mbg6KtnlM_po-9fq8FsJ0ZS");
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException.Message;
                var linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var matches = linkParser.Matches(msg);
                var url = matches[0].ToString();

                readingStr = GetJsonThermostateReading(url);
            }

            var jobj = JObject.Parse(readingStr);

            return new ThermostateReading
            {
                DateTime = DateTime.Now,
                RoomTemperature = jobj["ambient_temperature_c"].ToString(),
                TargetTemperature = jobj["target_temperature_c"].ToString(),
                JsonReading = readingStr
            };
        }

        private static string GetAccessToken()
        {
            var test = "https://api.home.nest.com/oauth2/access_token"
                .PostUrlEncodedAsync(
                    new
                    {
                        code = "UU93AG2F",
                        client_id = "39058eea-077e-4c1d-b8a3-87a65dfd474b",
                        client_secret = "oeOXdMsv2dT5zNuAeYThIEOQM",
                        grant_type = "authorization_code"
                    })
                .Result.Content.ReadAsStringAsync().Result;

            var json = JObject.Parse(test);
           return json["access_token"].ToString();
        }

        private static string GetJsonThermostateReading(string url)
        {
            return url
                .WithOAuthBearerToken("c.qltDMn1Wzs07mKQOYDMJwWzCmcPemYtpLUzvwT0Cg67LCggWjhRXZb1HJkfW3474deoZk0u58kciM2NuqAX6LrXyu0vc6QU2Hia6On5xYdJm1CkXfGo7zQXBwcCIHjv5n9UzJvLOyNnwmA1Y")
                .WithHeader("cache-control", "no-cache")
                .WithHeader("postman-token", "4ff98e5a-4cee-9db0-86da-b49824f9fffe")
                .GetStringAsync().Result;
        }
    }
}
