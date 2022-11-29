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
        static uint numberOfThreads;

        static void Main(string[] args)
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("Web Scraper Project by Burguillos & Tansingco");
            Console.WriteLine("=========================================================\n");

            // Acquire the necessary parameters of the program.
            while (true)
            {
                Console.Write("URL :\t");
                var foo = Console.ReadLine();

                if (isValidURL(foo))
                {
                    break;
                } else
                {
                    Console.WriteLine("\n!! The given input does not resemble a URL. Please ensure that the input is a URL !!\n");
                }
            }

            Console.WriteLine();

            while (true)
            {
                Console.Write("Scraping Time :\t");
                var foo = Console.ReadLine();
                float convertedNum;

                if (float.TryParse(foo, out convertedNum))
                {
                    if (convertedNum <= 0)
                    {
                        Console.WriteLine("\n!! The given input for Scraping time should be more than 0 !!\n");
                    } else
                    {
                        scrapingTime = convertedNum;
                        break;
                    }
                } else
                {
                    Console.WriteLine("\n!! The given input is not of numerical value! Please ensure that the input is in numerical value !!\n");
                }
            }

            Console.WriteLine();

            while (true)
            {
                Console.Write("Number of Threads :\t");
                var foo = Console.ReadLine();
                uint convertedNum;

                if (uint.TryParse(foo, out convertedNum))
                {
                    numberOfThreads = convertedNum;
                    break;
                } else
                {
                    Console.WriteLine("\n!! The given input is should be of an unsigned integer value !!\n");
                }
            }

            // Output paramerts set by the User
            Console.WriteLine("\n\n=========================================================");
            Console.WriteLine("Paremeters Set: ");
            Console.WriteLine("URL : " + URL);
            Console.WriteLine("Scraping Time : " + scrapingTime);
            Console.WriteLine("Number of Threads : " + numberOfThreads);
            Console.WriteLine("=========================================================");
            Console.Write("Press enter to continue...");
            Console.ReadKey();
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
