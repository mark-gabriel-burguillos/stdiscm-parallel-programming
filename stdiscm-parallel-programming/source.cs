using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace stdiscm_parallel_programming
{
    internal class Source
    {
<<<<<<< HEAD
        static string URL;
        static float scrapingTimeInSeconds;
        static int numberOfThreads;

=======
>>>>>>> output_setup
        static void Main(string[] args)
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("Web Scraper Project by Burguillos & Tansingco");
            Console.WriteLine("=========================================================\n");

            // Acquire the necessary parameters of the program.
            GetInputParameters();

            Output.AddEntry(new DataEntry("sample", "a", "b", "c"));
            Output.AddEntry(new DataEntry("sample", "a", "b", "c"));
            Output.AddEntry(new DataEntry("sample", "a", "b", "c"));

            Output.OutputDataFile();
            Output.OutputStatisticsFile();

            // Output paramerts set by the User
            Console.WriteLine("\n\n=========================================================");
            Console.WriteLine("Paremeters Set: ");
            Console.WriteLine("URL : " + URL);
            Console.WriteLine("Scraping Time : " + ScrapingTime);
            Console.WriteLine("Number of Threads : " + NumberOfThreads);
            Console.WriteLine("=========================================================");
            Console.Write("Press enter to continue...");
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
<<<<<<< HEAD
                        const float SECONDS_IN_A_MINUTE = 60;

                        scrapingTimeInSeconds = convertedNum * SECONDS_IN_A_MINUTE;
=======
                        ScrapingTime = convertedNum;
>>>>>>> output_setup
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
<<<<<<< HEAD
                    /*
                     * Tells the program that it can produce
                     * as many threads as it wants.
                     */
                    numberOfThreads = -1;
                    break;
                }
                else if (uint.TryParse(foo, out convertedNum))
                {
                    numberOfThreads = (int)convertedNum;
=======
                    NumberOfThreads = convertedNum;
>>>>>>> output_setup
                    break;
                }
                else
                {
                    Console.WriteLine("\n!! The given input is should be of an unsigned integer value !!\n");
                }
            }
<<<<<<< HEAD

            // Output paramerts set by the User
            Console.WriteLine("\n\n=========================================================");
            Console.WriteLine("Paremeters Set: ");
            Console.WriteLine("URL : " + URL);
            Console.WriteLine("Scraping Time : " + scrapingTimeInSeconds + " seconds");
            Console.Write("Number of Threads : ");

            if (numberOfThreads == -1)
            {
                Console.WriteLine("Infinite");
            } else
            {
                Console.WriteLine(numberOfThreads);
            }

            Console.WriteLine("=========================================================");
            Console.Write("Press enter to continue...");
            Console.ReadKey();
=======
>>>>>>> output_setup
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

        // Auto-properties
        public static string URL
        {
            get;
            private set;
        }

        public static float ScrapingTime
        {
            get;
            private set;
        }

        public static uint NumberOfThreads
        {
            get;
            private set;
        }
    }
}
