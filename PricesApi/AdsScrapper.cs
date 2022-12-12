using HtmlAgilityPack;
using System.Net.Http;
using System.Linq;
namespace DataScrapper
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
                AdSpecs.AdTitle += $"{adTitle.Attributes["href"].Value.Trim()}\n";

                AdSpecs.AdHyperlink += $"{adTitle.InnerText.Trim()}\n";

            }

            var adsPrices = document.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("card-v2-pricing")).ToList();

            foreach (var adPrice in adsPrices)
            {
                var price = adPrice.Descendants("p").Where(node => node.GetAttributeValue("class", "").Equals("product-new-price")).FirstOrDefault();

                AdSpecs.AdPrice += $"{price.InnerText}\n";
            }

            return $"{AdSpecs.AdPrice}{AdSpecs.AdHyperlink}{AdSpecs.AdTitle}";

        }

        public string EvomagResults(string searchItem)
        {
            var html = client.GetStringAsync($"https://www.evomag.ro/?sn.q={searchItem}").Result;

            document.LoadHtml(html);

            var adsTitles = document.DocumentNode.SelectNodes("//div[@class='npi_name']/a[not(@id) and not(@class)]");

            foreach (var adtitle in adsTitles)
            {
                AdSpecs.AdHyperlink += $"{adtitle.Attributes["href"].Value.Trim()}";
                AdSpecs.AdTitle += $"{adtitle.InnerText.Trim()}";
            }

            var adsPrices = document.DocumentNode.SelectNodes(".span[@class='real_price']");

            foreach (var adPrice in adsPrices)
            {
                AdSpecs.AdPrice += $"{adPrice.InnerText}";
            }

            return $"{AdSpecs.AdHyperlink}{AdSpecs.AdTitle}{AdSpecs.AdPrice}";
        }

    }
}

