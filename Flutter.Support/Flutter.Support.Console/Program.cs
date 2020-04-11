using System;
using System.Net.Http;

namespace Flutter.Support.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var result = client.GetAsync("http://www.lqixy.com/api/test/get").Result;
            //new HttpClientFactory();
            System.Console.WriteLine(result);
        }
    }
}
