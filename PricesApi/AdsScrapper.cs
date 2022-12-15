using HtmlAgilityPack;
using System.Linq;


namespace DataScrapper
{
    public class AdsScrapper
    {
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        #region !Need
        //public string EmagResults(string searchitem)
        //{
        //    var htmlPage = client.GetStringAsync($"https://www.emag.ro/search/{searchitem}").Result;

        //    document.LoadHtml(htmlPage);

        //    var adsTitles = document.DocumentNode.SelectNodes("//div[@class='pad-hrz-xs']/a[@data-zone='title']");

        //    foreach (var adTitle in adsTitles)
        //    {
        //        Ads.AdTitle += $"{adTitle.Attributes["href"].Value.Trim()}\n";

        //        Ads.AdHyperlink += $"{adTitle.InnerText.Trim()}\n";

        //    }

        //    var adsPrices = document.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("card-v2-pricing")).ToList();

        //    foreach (var adPrice in adsPrices)
        //    {
        //        var price = adPrice.Descendants("p").Where(node => node.GetAttributeValue("class", "").Equals("product-new-price")).FirstOrDefault();

        //        Ads.AdPrice += $"{price.InnerText}\n";
        //    }

        //    return $"{Ads.AdPrice}{Ads.AdHyperlink}{Ads.AdTitle}";

        //}

        //#region !Working

        ////public string EvomagResults(string searchItem)
        ////{
        ////    var htmlPage = client.GetStringAsync($"https://www.evomag.ro/?sn.q={searchItem}").Result;

        ////    document.LoadHtml(htmlPage);

        ////    var adsTitles = document.DocumentNode.SelectNodes("//div[@class='npi_name']/a");

        ////    foreach (var adTitle in adsTitles)
        ////    {
        ////        AdSpecs.AdTitle += $"{adTitle.InnerText.Trim()}\n";

        ////        AdSpecs.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";
        ////    }

        ////    //var adsPrices = document.DocumentNode.SelectNodes("//span[@class='real_price']");

        ////    //foreach (var adPrice in adsPrices)
        ////    //{
        ////    //    AdSpecs.AdPrice += $"{adPrice.InnerText}";
        ////    //}

        ////    return $"{AdSpecs.AdHyperlink}{AdSpecs.AdTitle}";
        ////}

        ////public string IPonResults(string searchItem)
        ////{
        ////    var htmlPage = client.GetStringAsync($"https://ipon.ro/cautare/shop?keyword={searchItem}").Result;

        ////    document.LoadHtml(htmlPage);

        ////    var adsTitles = document.DocumentNode.SelectNodes("//a[@class='shop-card__overlay-link']");

        ////    foreach (var adTitle in adsTitles)
        ////    {
        ////        AdSpecs.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";
        ////        AdSpecs.AdTitle += $"{adTitle.InnerText.Trim()}\n";

        ////    }

        ////    return $"{AdSpecs.AdTitle}{AdSpecs.AdHyperlink}";
        ////}

        ////public string DwinResults(string searchItem)
        ////{
        ////    var htmlPage = client.GetStringAsync($"https://www.dwyn.ro/?sn.q={searchItem}").Result;

        ////    document.LoadHtml(htmlPage);

        ////    var adsTitles = document.DocumentNode.SelectNodes("//div[@class='grid-full col-xs-6 col-sm-5 col-md-4']/h5[@class='name margin-bottom-xs']/a");

        ////    foreach (var adTitle in adsTitles)
        ////    {
        ////        //AdSpecs.AdTitle += $"{adTitle.Attributes["title"].Value.Trim()}\n";

        ////        AdSpecs.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";
        ////    }

        ////    return $"{AdSpecs.AdTitle}{AdSpecs.AdHyperlink}";
        ////}


        ////public string ITArenaResults(string searchItem)
        ////{
        ////    var htmlPage = client.GetStringAsync($"https://www.itarena.ro/?sn.q={searchItem}").Result;

        ////    document.LoadHtml(htmlPage);

        ////    var adsTitles = document.DocumentNode.SelectNodes("//h4[@class='product-title']/a  ");

        ////    foreach (var adTitle in adsTitles)
        ////    {
        ////        AdSpecs.AdTitle += $"{adTitle.InnerText.Trim()}\n";

        ////        // AdSpecs.AdTitle += $"{title.InnerText}\n";

        ////    }

        ////    return $"{AdSpecs.AdTitle}";
        ////}

        //#endregion

        //public string ForITResults(string searchItem) 
        //{
        //    var htmlPage = client.GetStringAsync($"https://www.forit.ro/search/?c=0&q={searchItem}").Result;

        //    document.LoadHtml(htmlPage);

        //    var adsTitles = document.DocumentNode.SelectNodes("//h5[@class='name']/a[@data-ecproduct='true']");

        //    foreach (var adTitle in adsTitles)
        //    {
        //        Ads.AdTitle += $"{adTitle.InnerText.Trim()}\n";

        //        Ads.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";

        //    }

        //    var adPrices = document.DocumentNode.SelectNodes("//div[@class='price-value text-bold']");

        //    foreach (var adPrice in adPrices)
        //    {
        //        Ads.AdPrice += $"{adPrice.InnerText.Trim()}\n";
        //    }

        //    return $"{Ads.AdTitle}{Ads.AdPrice}{Ads.AdHyperlink}";

        //}

        //public string PcOneResults(string searchItem) 
        //{
        //    var htmlPage = client.GetStringAsync($"https://www.pcone.ro/search/?q={searchItem}").Result;

        //    document.LoadHtml(htmlPage);

        //    var adsTitles = document.DocumentNode.SelectNodes("//h2[@class='name']/a[@data-ecproduct='true']");

        //    foreach (var adTitle in adsTitles)
        //    {
        //        Ads.AdTitle += $"{adTitle.Attributes["title"].Value.Trim()}\n";
        //        Ads.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";

        //    }

        //    var adsPrices = document.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("pull-left")).ToList();

        //    foreach (var adPrice in adsPrices)
        //    {
        //        Ads.AdPrice += $"{adPrice.InnerText}\n";
        //    }

        //    return $"{Ads.AdTitle}{Ads.AdHyperlink}{Ads.AdPrice}";
        //}

        //public string VexioResults(string searchItem)
        //{
        //    var htmlPage = client.GetStringAsync($"https://www.flax.ro/produse?term={searchItem}").Result;

        //    document.LoadHtml(htmlPage);

        //    var adsTitles = document.DocumentNode.SelectNodes("//h2[@class='product-title']/a[@data-ecproduct='true']");

        //    foreach (var adTitle in adsTitles) 
        //    {
        //        Ads.AdTitle += $"{adTitle.Attributes["title"].Value.Trim()}\n";
        //        Ads.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";
        //    }

        //    return $"{Ads.AdTitle}{Ads.AdHyperlink}";
        //}

        //public string ItGalaxyResults(string searchItem) 
        //{
        //    var htmlPage = client.GetStringAsync($"https://www.itgalaxy.ro/cauta/{searchItem}").Result;

        //    document.LoadHtml(htmlPage);

        //    var adsTitles = document.DocumentNode.SelectNodes("//h5[@class='name']/a[@data-ecproduct='true']");

        //    foreach (var adTitle in adsTitles)
        //    {
        //        Ads.AdTitle += $"{adTitle.Attributes["title"].Value.Trim()}\n";
        //        Ads.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";
        //    }

        //    var adsPrices = document.DocumentNode.SelectNodes("//div[@class='']/strong");

        //    foreach (var adPrice in adsPrices)
        //    {
        //        Ads.AdPrice += $"{adPrice.InnerText}\n";
        //    }

        //    return $"{Ads.AdTitle}{Ads.AdHyperlink}{Ads.AdPrice}";
        //}

        //public string FlaxResuls(string searchItem)
        //{
        //    var htmlPage = client.GetStringAsync($"https://www.flax.ro/produse?term={searchItem}").Result;

        //    document.LoadHtml(htmlPage);

        //    var adsTitles = document.DocumentNode.SelectNodes("//h2[@class='product-title']/a");

        //    foreach (var adTtile in adsTitles)
        //    {
        //        Ads.AdTitle += $"{adTtile.Attributes["title"].Value}\n";
        //        Ads.AdHyperlink += $"{adTtile.Attributes["href"].Value}\n";

        //    }

        //    var adsPrices = document.DocumentNode.SelectNodes("//div[@class='price']");

        //    foreach (var adPrice in adsPrices)
        //    {
        //        Ads.AdPrice += $"{adPrice.InnerText.Trim()}\n";
        //    }

        //    return $"{Ads.AdTitle}{Ads.AdHyperlink}{Ads.AdPrice}";
        //}


        //public string PcConeResuls(string searchItem)
        //{
        //    var htmlPage = client.GetStringAsync($"https://www.pcone.ro/search/?q={searchItem}").Result;

        //    document.LoadHtml(htmlPage);

        //    var adsTitles = document.DocumentNode.SelectNodes("//h2[@class='name']/a[@data-ecproduct='true']");


        //    foreach (var adTitle in adsTitles)
        //    {
        //        Ads.AdTitle += $"{adTitle.Attributes["title"].Value.Trim()}\n";
        //        Ads.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";
        //    }

        //    var adsPrices = document.DocumentNode.SelectNodes("//div[@class='pull-left ']/strong");

        //    foreach (var adPrice in adsPrices)
        //    {
        //        Ads.AdPrice += $"{adPrice.InnerText.Trim()}\n";
        //    }

        //    return $"{Ads.AdTitle}{Ads.AdHyperlink}{Ads.AdPrice}";
        //}

        //public string PcBitResutls(string searchItem)
        //{
        //    var htmlPage = client.GetStringAsync($"https://www.pcbit.ro/cauta?q={searchItem}").Result;

        //    document.LoadHtml(htmlPage);

        //    var adsTitles = document.DocumentNode.SelectNodes("//article[@class='product']/a ");

        //    foreach (var adTitle in adsTitles)
        //    {
        //        Ads.AdTitle += $"{adTitle.InnerText.Trim()}\n";
        //        Ads.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";
        //    }

        //    var adsPrices = document.DocumentNode.SelectNodes("//article[@class='product']/em");

        //    foreach (var adPrice in adsPrices)
        //    {
        //        Ads.AdPrice += $"{adPrice.InnerText.Trim()}\n";

        //    }

        //    return $"{Ads.AdTitle}{Ads.AdHyperlink}{Ads.AdPrice}";
        //}

        #endregion

        public string AllEmagResuls(string pageCount)
        {
            var htmlPage = client.GetStringAsync($"https://www.emag.ro/procesoare/p{pageCount}/c").Result;

            document.LoadHtml(htmlPage);

            var adsTitles = document.DocumentNode.SelectNodes("//div[@class='pad-hrz-xs']/a ");

            foreach (var adTitle in adsTitles)
            {
                Ads.AdTitle += $"{adTitle.InnerText}\n";
                Ads.AdHyperlink += $"{adTitle.Attributes["href"].Value}\n";
            }

            var adsPrices = document.DocumentNode.SelectNodes("//div[@class='card-v2-pricing']/p[@class='product-new-price']");

            foreach (var adPrice in adsPrices)
            {
                Ads.AdPrice += $"{adPrice.InnerText}\n";
            }

            return $"{Ads.AdTitle}{Ads.AdHyperlink}{Ads.AdPrice}";
        }

        public string EvomagResults(string pageCount) 
        {
            var htmlPage = client.GetStringAsync($"https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:{pageCount}").Result;

            document.LoadHtml(htmlPage);

            var adsTitles = document.DocumentNode.SelectNodes("//div[@class='npi_name']/h2/a ");

            foreach (var adTitle in adsTitles)
            {
                Ads.AdTitle += $"{adTitle.InnerText.Trim()}\n";
                Ads.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";
            }

            var adsPrices = document.DocumentNode.SelectNodes("//div[@style='position:relative']/span[@class='real_price']");

            foreach (var adPrice in adsPrices)
            {
                Ads.AdPrice += $"{adPrice.InnerText.Trim()}\n";
            }
            return $"{Ads.AdTitle}{Ads.AdHyperlink}{Ads.AdPrice}";
        
        
        }

        public string IponResults(string pageCount)
        {
            var htmlPage = client.GetStringAsync($"https://ipon.ro/shop/grup/componente-pc/procesor/78?page={pageCount}").Result;

            document.LoadHtml(htmlPage);

            var adsTitles = document.DocumentNode.SelectNodes("//a[@class='shop-card__overlay-link']");

            foreach (var adTitle in adsTitles)
            {
                Ads.AdTitle += $"{adTitle.InnerText.Trim()}\n";
                //Ads.AdHyperlink += $"{adTitle.Attributes["href"].Value.Trim()}\n";
            }  

            return $"{Ads.AdTitle}{Ads.AdHyperlink}"; 
        }
    }
}

