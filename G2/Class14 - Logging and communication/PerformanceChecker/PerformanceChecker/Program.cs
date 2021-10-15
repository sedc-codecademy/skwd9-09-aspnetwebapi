using System;
using System.Net.Http;

namespace PerformanceChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting check...");
            CheckNotesApiPerformance();
            Console.ReadLine();
        }

        static void CheckNotesApiPerformance()
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string apiAddress = "http://localhost:64006/api/external/performance";
                int limitInMs = 50;

                HttpResponseMessage response = httpClient.GetAsync(apiAddress).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;
                if(int.Parse(responseBody) > limitInMs)
                {
                    Console.WriteLine($"The request took longer than {limitInMs}");
                }
                else
                {
                    Console.WriteLine($"The request took {responseBody}");
                }
            }
        }
    }
}
