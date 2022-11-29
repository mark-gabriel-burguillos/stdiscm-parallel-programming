using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace stdiscm_parallel_programming
{
    internal class source
    {
        static string URL;
        static float scrapingTime;
        static uint noOfThreads;

        static void Main(string[] args)
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("Web Scraper Project by Burguillos & Tansingco");
            Console.WriteLine("=========================================================\n");

            // Acquire the necessary parameters of the program.
            string foo;

            while (true)
            {
                Console.Write("URL :\t");
                foo = Console.ReadLine();

                if (isValidURL(foo))
                {
                    break;
                } else
                {
                    Console.WriteLine("!!!!! The given input does not resemble a URL. Please ensure that the input is a URL !!!!!\n");
                }
            }

            // !!! EVERYTHING BELOW THIS LINE IS TODO !!!
            /*while(true)
            {
                Console.Write("Scraping Time :\t");
                var sample = Console.Read();
            }*/
            
            /*Console.Write("Number of threads :\t");
            noOfThreads = Console.Read();*/
        }

        /*
         * Determines whether a given URL is a valid.
         * It utilizes Regex to determine its validity.
         * 
         * Source code acquired from Marco Concas of
         * Stackoverflow, from website:
         * https://stackoverflow.com/questions/7578857/how-to-check-whether-a-string-is-a-valid-http-url
         */
        private static bool isValidURL(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }
    }
}
