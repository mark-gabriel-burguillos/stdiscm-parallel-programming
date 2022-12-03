using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace stdiscm_parallel_programming
{
    internal class WebCrawlerThread
    {
        public static void scrape(string url, List<string> references, List<string> contents, List<DataEntry> dataEntries)
        {
            //string url = "https://www.dlsu.edu.ph";

            //https://oxylabs.io/blog/csharp-web-scraping
            //https://medium.com/c-sharp-progarmming/create-your-own-web-scraper-in-c-in-just-a-few-minutes-c42649adda8
            //https://html-agility-pack.net/documentation
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);


            //Test Website for Scraping Emails Used: https://blog.close.com/email-finder-from-website/

            string value;
            //Look for all website links present within page

            HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes("//a[@href]");
            Console.WriteLine("Hyperlinks in Webpage");
            Console.WriteLine("==========================================================================");

            foreach (HtmlNode i in linkNodes)
            {
                value = i.Attributes["href"].Value;

                if (value.Trim().StartsWith(url))
                {

                    Console.WriteLine(value);

                    if (references.Contains(value))
                        references.Add(value);

                }

                else if (value.Trim().StartsWith("/"))
                {
                    value = url + value;
                    Console.WriteLine(url + value);
                    if (references.Contains(value))
                        references.Add(url + value);
                }

            }
            Console.WriteLine("\n\n");

            Console.WriteLine("Emails in Webpage");
            Console.WriteLine("==========================================================================");
            List<string> emails = getEmails(url);

            foreach(string i in emails)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n\n");
            Console.WriteLine("Done!!");
        }

        public static List<string> getEmails(string url)
        {
            WebClient webClient = new WebClient();
            string data = webClient.DownloadString(url);
            //string download = Encoding.ASCII.GetString(data);

            Console.WriteLine(data);

            /*
            download = download.Replace("<em>", "");
            download = download.Replace("</em>", "");
            download = download.Replace("<b>", "");
            download = download.Replace("</b>", "");
            */ 
            //Console.WriteLine(download);

            Regex reg = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}", RegexOptions.IgnoreCase);
            Match match;

            List<string> results = new List<string>();
            for (match = reg.Match(data); match.Success; match = match.NextMatch())
            {
                if (!(results.Contains(match.Value)))
                    results.Add(match.Value);
                    
            }

            return results;
        }


    }
}
