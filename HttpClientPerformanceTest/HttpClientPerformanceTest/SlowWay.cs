using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientPerformanceTest
{
    public static class SlowWay
    {
        private static string _url = "http://jsonplaceholder.typicode.com/photos";
        public static int RequestsCount = 15;

        public async static Task Fetch()
        {
            for (int i = 0; i < RequestsCount; i++)
            {
                using (HttpClient http = new HttpClient())
                {
                    HttpResponseMessage response = await http.GetAsync(_url);
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine($"API responded with {response.StatusCode}");
                }
            }
        }

    }
}