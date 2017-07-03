using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientPerformanceTest
{
    public static class FastWay
    {
        private static string _url = "http://jsonplaceholder.typicode.com/photos";
        public static int RequestsCount = 15;
        private static HttpClient _http = new HttpClient();

        public static async Task Fetch()
        {
            for (int i = 0; i < RequestsCount; i++)
            {
                HttpResponseMessage response = await _http.GetAsync(_url);
                Console.WriteLine($"API responded with: {response.StatusCode}");
            }
        }
    }
}