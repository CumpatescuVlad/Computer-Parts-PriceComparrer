using HtmlAgilityPack;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Reflection.Metadata;

namespace DataScrapper.src
{
    public class EmagAdsData
    {
        //private readonly IConfiguration configuration;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();
        private readonly SqlConnection connection = new(InsertData.ConnectionString);

        public async Task<string> InsertProcessorData(string pageCount, string searchModel)
        {
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/procesoare/p{pageCount}/c").Result;

            document.LoadHtml(HtmlPage);

            var processorTitles = document.DocumentNode.SelectNodes("//div[@class='pad-hrz-xs']/a[@data-zone='title']");

            connection.Open();

            foreach (var processorTitle in processorTitles)
            {
                var insertTitlesAndHyperlinks = new SqlCommand(InsertData.InsertProcessorTitles("Emag", processorTitle.InnerText, processorTitle.Attributes["href"].Value), connection);

                var adapter = new SqlDataAdapter(insertTitlesAndHyperlinks);

                adapter.InsertCommand = insertTitlesAndHyperlinks;

                adapter.InsertCommand.ExecuteNonQuery();

               
            }
            
            var processorPrices = document.DocumentNode.SelectNodes("//div[@class='card-v2-pricing']/p[@class='product-new-price']");

            foreach (var processorPrice in processorPrices)
            {
                var insertTitlesAndHyperlinks = new SqlCommand(InsertData.InsertProcessorPrices("Emag", processorPrice.InnerText), connection);

                var adapter = new SqlDataAdapter(insertTitlesAndHyperlinks);

                adapter.InsertCommand = insertTitlesAndHyperlinks;

                adapter.InsertCommand.ExecuteNonQuery();
                File.WriteAllText($@"C:Users\Vlad\Documents\Prices.txt", processorPrice.InnerText);

            }
           
            connection.Close();

            string returnMessage = $"I Wrote Prices In DataBase.";

            return returnMessage;
        }

        public string ReadProcessorAds(string processorModel)
        {
            connection.Open();

            var command = new SqlCommand(ReadData.ReadProcessorModel("Emag",processorModel),connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Ads.AdTitle += $"{reader.GetString(0)}\n";
                Ads.AdHyperlink += $"{reader.GetString(1)}\n";
                Ads.AdPrice += $"{reader.GetString(2)}\n";

            }
            connection.Close();

            return $"{Ads.AdTitle}{Ads.AdHyperlink}{Ads.AdPrice}";
        }


    }
}
