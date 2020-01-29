using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace MyCurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            bool gameOver = false;

            Console.WriteLine("Welcome to our currency converter!\n");

            string url = "https://openexchangerates.org/api/latest.json?app_id=b05a9cc2604b409aab098cf79b143034";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                Rates rates = JsonConvert.DeserializeObject<Rates>(response);
                //Console.WriteLine(response); //hack

                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(response);

                Console.WriteLine($"Base currency: {rootObject.@base}");
                Console.WriteLine($"Timestamp: {rootObject.timestamp}\n");

                Console.WriteLine("Today's rates are as following:\n ");
                Console.WriteLine($"Australian dollar: {rootObject.rates.AUD}");
                Console.WriteLine($"Egyptian Pound: {rootObject.rates.EGP}");
                Console.WriteLine($"Euro: {rootObject.rates.EUR}");
                Console.WriteLine($"British Pound: {rootObject.rates.GBP}");
                Console.WriteLine($"Norwegian Crone: {rootObject.rates.NOK}");
                Console.WriteLine($"New Zealand Dollar: {rootObject.rates.NZD}\n");

                Start:
                Console.WriteLine("Enter your amount in USD: ");
                int userInput= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");
                Console.WriteLine("The amount is: \n");

                Console.WriteLine($"Australian dollar: {userInput * rootObject.rates.AUD}");
                Console.WriteLine($"Egyptian Pound: {userInput * rootObject.rates.EGP}");
                Console.WriteLine($"Euro: {userInput * rootObject.rates.EUR}");
                Console.WriteLine($"British Pound: {userInput * rootObject.rates.GBP}");
                Console.WriteLine($"Norwegian Crone: {userInput * rootObject.rates.NOK}");
                Console.WriteLine($"New Zealand Dollar: {userInput * rootObject.rates.NZD}\n");

                Console.WriteLine("Would you like to calculate again? y/n");
                string userAnswer = Console.ReadLine();

                if (userAnswer.ToLower() == "y")
                {
                    goto Start;
                }
                else if(userAnswer.ToLower()=="n")
                {
                    
                    Console.WriteLine("See you soon!");
                    gameOver = true;
                   
                }
                else
                {
                    Console.WriteLine("\nCheck your input!");
                    goto Start;
                }



            }
            Console.ReadLine();
        }

    }
}
