using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace stdiscm_parallel_programming
{
    internal class WebCrawlerThread
    {
        public static void scrape(string url, List<string> references, List<string> contents, List<DataEntry> dataEntries)
        {
            //https://oxylabs.io/blog/csharp-web-scraping
            //https://medium.com/c-sharp-progarmming/create-your-own-web-scraper-in-c-in-just-a-few-minutes-c42649adda8
            //https://html-agility-pack.net/documentation

            //string url = "https://www.dlsu.edu.ph";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            //Look for all website links present within page

            HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes("//a[@href]");
            Console.WriteLine("Hyperlinks in Webpage");
            Console.WriteLine("==========================================================================");
            foreach (HtmlNode i in linkNodes)
            {
                string value = i.Attributes["href"].Value;

                if (value.Trim().StartsWith(url))
                {

                    //Console.WriteLine(value);

                    if (references.Contains(value))
                        references.Add(value);

                }

                else if (value.Trim().StartsWith("/"))
                {
                    value = url + value;
                    //Console.WriteLine(url + value);
                    if (references.Contains(value))
                        references.Add(url + value);
                }

            }
            Console.WriteLine("\n\n");

            /*
            Random rn = new Random();
            url = referenceList[rn.Next(referenceList.Count)];
            Console.WriteLine(url);
            doc = web.Load(url);
            */

            var webpageContent = doc.DocumentNode.SelectNodes("//body");
            Console.WriteLine("Hyperlinks in Webpage");
            Console.WriteLine("==========================================================================");
            foreach (HtmlNode i in webpageContent)
            {
                Console.WriteLine(i.InnerText);
                contents.Add(i.InnerText);
            }
            Console.WriteLine("\n\n");



        }


    }
}
