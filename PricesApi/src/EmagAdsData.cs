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

        public string ReadProcessorTitle(HtmlDocument document)
        {
            var processorTitles = document.DocumentNode.SelectNodes("//div[@class='pad-hrz-xs']/a[@data-zone='title']");

            foreach (var processorTitle in processorTitles)
            {
                Ads.AdTitle += $"{processorTitle.InnerText}\n";
                Ads.AdHyperlink += $"{processorTitle.Attributes["href"].Value}\n";
            }

            var processorsPrices = document.DocumentNode.SelectNodes("//div[@class='card-v2-pricing']/p[@class='product-new-price']");

            foreach (var processorPrice in processorsPrices)
            {
                Ads.AdPrice += $"{processorPrice.InnerText}\n";

            }

            var insertCommand = new SqlCommand(InsertData.InsertProcessorData("Emag", Ads.AdTitle, Ads.AdHyperlink, Ads.AdPrice), connection);

            connection.Open();

            var adapter = new SqlDataAdapter(insertCommand);

            adapter.InsertCommand = insertCommand;

            adapter.InsertCommand.ExecuteNonQuery();

            connection.Close();

            return Ads.AdTitle;
        }

        public string ReadProcessorHyperlink(HtmlDocument document)
        {
            var processorTitles = document.DocumentNode.SelectNodes("//div[@class='pad-hrz-xs']/a[@data-zone='title']");

            foreach (var processorTitle in processorTitles)
            {
                Ads.AdHyperlink += $"{processorTitle.Attributes["href"].Value}\n";

            }
            return Ads.AdHyperlink;
        }

        public string ReadProcessorPrices(HtmlDocument document)
        {
            var processorsPrices = document.DocumentNode.SelectNodes("//div[@class='card-v2-pricing']/p[@class='product-new-price']");

            foreach (var processorPrice in processorsPrices)
            {
                Ads.AdPrice += $"{processorPrice.InnerText}\n";

            }

            return Ads.AdPrice;

        }

        public void InsertProcessorData(string processorTitle,string processorHyperlink,string processorPrice)
        {
            var insertCommand = new SqlCommand(InsertData.InsertProcessorData("Emag",processorTitle,processorHyperlink,processorPrice),connection);

            connection.Open();

            var adapter = new SqlDataAdapter(insertCommand);

            adapter.InsertCommand= insertCommand;

            adapter.InsertCommand.ExecuteNonQuery();

            connection.Close();

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
