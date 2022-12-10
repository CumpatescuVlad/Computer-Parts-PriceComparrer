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

            var adsTitles = document.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("pad-hrz-xs")).ToList();

            foreach (var adTitle in adsTitles)
            {
                var title = adTitle.Descendants("a").Where(node => node.GetAttributeValue("data-zone", "").Equals("title")).FirstOrDefault();

                AdSpecs.AdTitle += $"{title.InnerText}\n";

            }

            var adsPrices = document.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("card-v2-pricing")).ToList();

            foreach (var adPrice in adsPrices)
            {
                var price = adPrice.Descendants("p").Where(node => node.GetAttributeValue("class", "").Equals("product-new-price")).FirstOrDefault();

                AdSpecs.AdPrice += $"{price.InnerText}\n";
            }

            return $"{AdSpecs.AdTitle}{AdSpecs.AdPrice}";


        }







    }
}
