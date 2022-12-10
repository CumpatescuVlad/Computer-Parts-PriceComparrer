using HtmlAgilityPack;
using System.Net.Http;
using System.Linq;
namespace PricesApi
{
    public class AdsScrapper 
    {
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public string EmagResults(string searchitem)
        {
            var html = client.GetStringAsync($"https://www.emag.ro/search/{searchitem}").Result;

            document.LoadHtml(html);

            var adsTitles = document.DocumentNode.SelectNodes("//div[@class='pad-hrz-xs']/a[@data-zone='title']");

            foreach (var adTitle in adsTitles)
            {
                var title = adTitle.Attributes["href"].Value.Trim();

                var hyperlink = adTitle.InnerText.Trim();

                AdSpecs.AdTitle += $"{title}\n";

                AdSpecs.AdHyperlink += $"{hyperlink}\n";
               
            }

            var adsPrices = document.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("card-v2-pricing")).ToList();

            foreach (var adPrice in adsPrices)
            {
                var price = adPrice.Descendants("p").Where(node => node.GetAttributeValue("class", "").Equals("product-new-price")).FirstOrDefault();

                AdSpecs.AdPrice += $"{price.InnerText}\n";
            }

            return $"{AdSpecs.AdTitle}{AdSpecs.AdHyperlink}";


        }







    }
}
