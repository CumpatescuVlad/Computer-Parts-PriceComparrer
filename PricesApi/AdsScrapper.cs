using HtmlAgilityPack;
using System.Net.Http;
using System.Linq;
using System.Diagnostics.Contracts;

namespace DataScrapper
{
    public class AdsScrapper
    {
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();
       
        public string EmagResults(string searchitem)
        {
            var htmlPage = client.GetStringAsync($"https://www.emag.ro/search/{searchitem}").Result;

            document.LoadHtml(htmlPage);

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
        #region !Working

        //public string EvomagResults(string searchItem)
        //{
        //    var htmlPage = client.GetStringAsync($"https://www.evomag.ro/?sn.q={searchItem}").Result;

        //    document.LoadHtml(htmlPage);

        //    //var adsTitles = document.DocumentNode.SelectNodes("//div[@class='npi_name']/a");

        //    var adsTitles = document.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("npi_name")).ToList();

        //    foreach (var adTitle in adsTitles)
        //    {
        //        // var aElement = adTitle.SelectSingleNode("a");
        //        //AdSpecs.AdHyperlink += $"{aElement.Attributes["href"].Value}\n";
        //        //AdSpecs.AdTitle += $"{aElement.InnerText}\n";

        //        var variable = adTitle.SelectSingleNode("//a");

        //        AdSpecs.AdTitle += $"{variable.InnerText}";

        //        AdSpecs.AdHyperlink += $"{variable.Attributes["href"].Value}";
        //    }

        //    //var adsPrices = document.DocumentNode.SelectNodes("//span[@class='real_price']");

        //    //foreach (var adPrice in adsPrices)
        //    //{
        //    //    AdSpecs.AdPrice += $"{adPrice.InnerText}";
        //    //}

        //    return $"{AdSpecs.AdHyperlink}{AdSpecs.AdTitle}";
        //}

        //public string ITArenaResults(string searchItem)
        //{
        //    var htmlPage = client.GetStringAsync($"https://www.itarena.ro/?sn.q={searchItem}").Result;

        //    document.LoadHtml(htmlPage);

        //    var adsTitles = document.DocumentNode.Descendants("h4").Where(node=>node.GetAttributeValue("class","").Equals("product-title")).ToList();

        //    foreach (var adTitle in adsTitles) 
        //    {
        //        var title = adTitle.Descendants("a").FirstOrDefault();

        //        AdSpecs.AdTitle += $"{title.InnerText}\n";

        //    }  

        //    return $"{AdSpecs.AdTitle}";
        //}

        //public string IPonResults(string searchItem)
        //{
        //    var htmlPage = client.GetStringAsync($"https://ipon.ro/cautare/shop?keyword={searchItem}").Result;

        //    document.LoadHtml(htmlPage);

        //    var adsTitles = document.DocumentNode.SelectNodes("//a[@class='shop-card__title']");

        //    foreach (var adTitle in adsTitles)
        //    {

        //        AdSpecs.AdHyperlink += $"{adTitle.InnerText.Trim()}\n";

        //    }

        //    return $"{AdSpecs.AdTitle}{AdSpecs.AdHyperlink}";
        //}


        #endregion

        public string ForITResults(string searchItem) 
        {
            var htmlPage = client.GetStringAsync($"https://www.forit.ro/search/?c=0&q={searchItem}").Result;

            document.LoadHtml(htmlPage);

            var adsTitles = document.DocumentNode.SelectNodes("//h5[@class='name']/a[@data-ecproduct='true']");

            foreach (var adTitle in adsTitles)
            {
                AdSpecs.AdTitle += $"{adTitle.InnerText.Trim()}\n";

                AdSpecs.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";

            }

            var adPrices = document.DocumentNode.SelectNodes("//div[@class='price-value text-bold']");

            foreach (var adPrice in adPrices)
            {
                AdSpecs.AdPrice += $"{adPrice.InnerText.Trim()}\n";
            }

            return $"{AdSpecs.AdTitle}{AdSpecs.AdPrice}{AdSpecs.AdHyperlink}";
        
        }

        public string PcOneResults(string searchItem) 
        {
            var htmlPage = client.GetStringAsync($"https://www.pcone.ro/search/?q={searchItem}").Result;

            document.LoadHtml(htmlPage);

            var adsTitles = document.DocumentNode.SelectNodes("//h2[@class='name']/a[@data-ecproduct='true']");

            foreach (var adTitle in adsTitles)
            {
                AdSpecs.AdTitle += $"{adTitle.Attributes["title"].Value.Trim()}\n";
                AdSpecs.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";

            }

            var adsPrices = document.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("pull-left")).ToList();

            foreach (var adPrice in adsPrices)
            {
                AdSpecs.AdPrice += $"{adPrice.InnerText}\n";
            }

            return $"{AdSpecs.AdTitle}{AdSpecs.AdHyperlink}{AdSpecs.AdPrice}";
        }
        
        public string VexioResults(string searchItem)
        {
            var htmlPage = client.GetStringAsync($"https://www.flax.ro/produse?term={searchItem}").Result;

            document.LoadHtml(htmlPage);

            var adsTitles = document.DocumentNode.SelectNodes("//h2[@class='product-title']/a[@data-ecproduct='true']");

            foreach (var adTitle in adsTitles) 
            {
                AdSpecs.AdTitle += $"{adTitle.Attributes["title"].Value.Trim()}\n";
                AdSpecs.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";
            }

            return $"{AdSpecs.AdTitle}{AdSpecs.AdHyperlink}";
        }

        public string ItGalaxyResults(string searchItem) 
        {
            var htmlPage = client.GetStringAsync($"https://www.itgalaxy.ro/cauta/{searchItem}").Result;

            document.LoadHtml(htmlPage);

            var adsTitles = document.DocumentNode.SelectNodes("//h5[@class='name']/a[@data-ecproduct='true']");

            foreach (var adTitle in adsTitles)
            {
                AdSpecs.AdTitle += $"{adTitle.Attributes["title"].Value.Trim()}\n";
                AdSpecs.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";
            }

            return $"{AdSpecs.AdTitle}{AdSpecs.AdHyperlink}";
        }

       
    }
}

