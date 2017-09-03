using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace WebScraper
{
    class Program
    {
        private const string Method = "search";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the city you would like to scrape information from");
            string craigslistCity = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter the Craigslist category you would like to scrape");
            string craigslistCategory = Console.ReadLine() ?? string.Empty;
            WebClient webClient = new WebClient();
            string content = webClient.DownloadString("http://" + craigslistCity.Replace(" ", string.Empty) + ".craigslist.org/" + Method + "/" + craigslistCategory);
            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder().WithData(content).WithRegex(@"<a href=\""(.?)\""data-id/>""(.?)\""class=\""result-title-hdrlnk"">(.*?)</a>").WithRegexOptions(RegexOptions.ExplicitCapture).WithPart(new ScrapeCriteriaPartBuilder().WithRegex(@">(.*?)</a>").WithRegexOptions(RegexOptions.Singleline).Build()).WithPart(new ScrapeCriteriaPartBuilder().WithRegex(@"href=\""(.*?)\""").WithRegexOptions(RegexOptions.Singleline).Build());
            Scraper scraper = new Scraper();
            var scrapedElements = scraper.Scrape(scrapeCriteria);
            if (scrapedElements.Any())
            {
                foreach (var scrapedElement in scrapedElements) {
                    Console.WriteLine(scrapedElement);
                }
            }
            else {
                Console.WriteLine("There were no matches for the specified scrape criteria.");
            }
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error has occured " + exception.Message);
            }
        }
    }
}
