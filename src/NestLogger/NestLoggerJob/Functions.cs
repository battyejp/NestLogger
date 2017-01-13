using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Net.Http;
using System.Net.Http.Headers;
using Flurl;
using Flurl.Http;

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

            var test =
            "https://firebase-apiserver01-tah01-iad01.dapi.production.nest.com:9553/devices/thermostats/xojpoFNq0Mbg6KtnlM_po-9fq8FsJ0ZS".WithOAuthBearerToken(
                "c.qltDMn1Wzs07mKQOYDMJwWzCmcPemYtpLUzvwT0Cg67LCggWjhRXZb1HJkfW3474deoZk0u58kciM2NuqAX6LrXyu0vc6QU2Hia6On5xYdJm1CkXfGo7zQXBwcCIHjv5n9UzJvLOyNnwmA1Y")
                //.WithHeader("Access-Control-Allow-Origin", "*")
                //.WithHeaders(new { Access_Control_Allow_Origin = "*", Cache_Control = "private, no-cache, no-store, max-age=0", Connection = "close", Content_Type = "application/json; charset=UTF-8", Pragma = "no-cache", content_length = "4562" })
                .GetStringAsync().Result;

            Console.WriteLine(test);
        }
    }
}
