using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace KanyeAndRon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest";

           

            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";



            for(int i=0; i<5; i++)
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                Console.WriteLine($"Kanye: {kanyeQuote}");

                var ronResponse = client.GetStringAsync(ronURL).Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                Console.WriteLine($"Ron: {ronQuote}");
                Console.WriteLine("----------------------------");
            }

            
        }
    }
}
