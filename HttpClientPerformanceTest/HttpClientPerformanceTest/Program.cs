using System;
using System.Diagnostics;

namespace HttpClientPerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SlowWay.RequestsCount = FastWay.RequestsCount = 30;
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Testing Slow Way:");
            sw.Start();
            try
            {
                SlowWay.Fetch().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine("Http Request failed");
                Console.WriteLine(e.Message);
            }
            sw.Stop();
            TimeSpan slowWayTimeSpan = sw.Elapsed;

            Console.WriteLine();
            Console.WriteLine("Testing Fast Way:");
            sw.Restart();
            try
            {
                FastWay.Fetch().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine("Http Request failed");
                Console.WriteLine(e.Message);

            }
            sw.Stop();
            TimeSpan fastWayTimeSpan = sw.Elapsed;

            Console.WriteLine();
            Console.WriteLine($"Slow Way Completed in {slowWayTimeSpan}");
            Console.WriteLine($"Fast Way Completed in {fastWayTimeSpan}");

            Console.ReadKey();
        }
    }
}