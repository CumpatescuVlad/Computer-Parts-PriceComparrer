using HtmlAgilityPack;
using System.Collections;
using System.Reflection.Metadata;

namespace DataScrapper.src
{
    public class EmagAdsData
    {
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public string ReadProcessorData(string pageCount,string searchModel)
        {
           
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/procesoare/p{pageCount}/c").Result;

            document.LoadHtml(HtmlPage);

            var processorAds = document.DocumentNode.SelectNodes("//div[@class='pad-hrz-xs']/a[@data-zone='title']");

           
            var processorModels = from processorModel in processorAds
                                  where processorModel.InnerText.Contains(searchModel)
                                  select processorModel;
             

            foreach (var processor in processorModels)
            {
                Ads.AdTitle += $"{processor.InnerText}\n{processor.Attributes["href"].Value}\n";

               
            }

            

            return $"{Ads.AdTitle}{Ads.AdPrice}";
        }



    }
}
