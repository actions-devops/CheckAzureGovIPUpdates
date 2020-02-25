using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HtmlAgileCoreConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://www.microsoft.com/en-us/download/details.aspx?id=57063");
            var pageContents = await response.Content.ReadAsStringAsync();

            HtmlDocument pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(pageContents);
            var divs = pageDocument.DocumentNode.SelectNodes("(/html/body/main/div/div/form/div/div[2]/div/div/div/div[2]/div/div/div/div/div[4]/div/div/div/div/div/div[1]/ul/li/div/div/div/div/div/div/div[1]/div/div/div[2]/div[1]/div/p)");
            foreach (var d in divs)
            {
                var dateUpdated = d.InnerText;
                Console.WriteLine("Date Updated: {0}", dateUpdated);
            }
            
            
            HttpClient client2 = new HttpClient();
            var response2 = await client2.GetAsync("https://www.microsoft.com/en-us/download/confirmation.aspx?id=57063");
            var pageContents2 = await response2.Content.ReadAsStringAsync();

            HtmlDocument pageDocument2 = new HtmlDocument();
            pageDocument2.LoadHtml(pageContents2);
            var divs2 = pageDocument2.DocumentNode.SelectNodes("(/html/body/main/div/div/form/div/div[4]/div/div[1]/div/div[1]/div/div/div/div/div/div[2]/div[1]/a)");
            foreach (var d in divs2)
            {
                var attCol = d.Attributes;
                foreach (var att in attCol)
                {
                    if (att.Name == "href")
                   {
                        Console.WriteLine(att.Value);
                   }
                }
            }
        }
    }
}
