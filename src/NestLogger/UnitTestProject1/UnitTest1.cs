using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                   { "code", "XRR2MBDD" },
                   { "client_id", "39058eea-077e-4c1d-b8a3-87a65dfd474b" },
                   { "client_secret", "oeOXdMsv2dT5zNuAeYThIEOQM" },
                   { "grant_type", "authorization_code" }
                };

                var content = new FormUrlEncodedContent(values);

                var response = client.PostAsync("http://www.example.com/recepticle.aspx", content).Result;

                Console.WriteLine(response.Content.ReadAsStringAsync());
            }
        }
    }
}
