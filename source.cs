using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using HtmlAgilityPack;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.ComponentModel;

using System.Threading;

namespace stdiscm_parallel_programming
{ 
    internal class Source
    {
        static void Main(string[] args)
        {
            //string url = "https://www.dlsu.edu.ph";

            List<string> references = new List<string>();
            List<string> contents = new List<string>();
            List<DataEntry> dataEntries = new List<DataEntry>();


            Console.WriteLine("=========================================================");
            Console.WriteLine("Web Scraper Project by Burguillos & Tansingco");
            Console.WriteLine("=========================================================\n");

            // Acquire the necessary parameters of the program.
            GetInputParameters();

            // Output paramerts set by the User
            Console.WriteLine("\n\n=========================================================");
            Console.WriteLine("Paremeters Set: ");
            Console.WriteLine("URL : " + URL);
            Console.WriteLine("Scraping Time : " + ScrapingTimeInSeconds + " seconds");
            Console.Write("Number of Threads : ");

            if (NumberOfThreads == -1)
            {
                Console.WriteLine("Infinite");
            }
            else
            {
                Console.WriteLine(NumberOfThreads);
            }

            Console.WriteLine("\n\n\n\n");

            Scraping(references, contents, dataEntries);

            //Console.WriteLine("=========================================================");
            //Console.Write("Press enter to continue...");
            Console.ReadKey();

        }

        private static void GetInputParameters()
        {
            while (true)
            {
                Console.Write("URL :\t");
                var foo = Console.ReadLine();

                if (IsValidURL(foo))
                {
                    URL = foo;
                    break;
                }
                else
                {
                    Console.WriteLine("\n!! The given input does not resemble a URL. Please ensure that the input is a URL !!\n");
                }
            }

            Console.WriteLine();

            while (true)
            {
                Console.Write("Scraping Time (in minutes):\t");
                var foo = Console.ReadLine();
                float convertedNum;

                if (float.TryParse(foo, out convertedNum))
                {
                    if (convertedNum <= 0)
                    {
                        Console.WriteLine("\n!! The given input for Scraping time should be more than 0 !!\n");
                    }
                    else
                    {
                        const float SECONDS_IN_A_MINUTE = 60;

                        ScrapingTimeInSeconds = convertedNum * SECONDS_IN_A_MINUTE;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\n!! The given input is not of numerical value! Please ensure that the input is in numerical value !!\n");
                }
            }

            Console.WriteLine();

            while (true)
            {
                Console.Write("Number of Threads (Optional) :\t");
                var foo = Console.ReadLine();
                uint convertedNum;

                // The User skips this input_parameter
                if (foo == "")
                {
                    /*
                     * Tells the program that it can produce
                     * as many threads as it wants.
                     */
                    NumberOfThreads = -1;
                    break;
                }
                else if (uint.TryParse(foo, out convertedNum))
                {
                    NumberOfThreads = (int)convertedNum;
                    break;
                }
                else
                {
                    Console.WriteLine("\n!! The given input is should be of an unsigned integer value !!\n");
                }
            }
        }

        /*
         * Determines whether a given URL is a valid.
         * It utilizes Regex to determine its validity.
         * 
         * Source code acquired from Marco Concas of
         * Stackoverflow, from website:
         * https://stackoverflow.com/questions/7578857/how-to-check-whether-a-string-is-a-valid-http-url
         */
        private static bool IsValidURL(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }

        public static void Scraping(List<string> references, List<string> contents, List<DataEntry> dataEntries)
        {
            //https://stackoverflow.com/questions/3360555/how-to-pass-parameters-to-threadstart-method-in-thread
            Thread thread = new Thread(new ThreadStart(() => WebCrawlerThread.scrape(URL, references, contents, dataEntries)));
            thread.Start();
        }

        // Auto-properties
        public static string URL
        {
            get;
            private set;
        }

        public static float ScrapingTimeInSeconds
        {
            get;
            private set;
        }

        public static int NumberOfThreads
        {
            get;
            private set;
        }

    }
}
