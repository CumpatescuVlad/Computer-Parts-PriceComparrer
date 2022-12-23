using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace DataScrapper.src
{
    public class EmagAdsData
    {
        private readonly AdsModel _ads = new();
        private readonly HttpClient client = new();
        private readonly SqlConnection connection = new(InsertData.ConnectionString);

        public void ReadProcessorTitles(HtmlAgilityPack.HtmlDocument document)
        {
            var processorsTitles = document.DocumentNode.SelectNodes("//div[@class='pad-hrz-xs']/a[@data-zone='title']");

            foreach (var processorTitle in processorsTitles)
            {
                connection.Open();

                var insertCommand = new SqlCommand(InsertData.InsertProcessorData("Emag", processorTitle.InnerText, processorTitle.Attributes["href"].Value), connection);

                var adapter = new SqlDataAdapter(insertCommand);

                adapter.InsertCommand = insertCommand;

                adapter.InsertCommand.ExecuteNonQuery();

                connection.Close();
            }

        }

        public string ReadProcessorAds(HtmlAgilityPack.HtmlDocument document, string processorModel)
        {
            connection.Open();

            var command = new SqlCommand(ReadData.ReadProcessorModel("Emag", processorModel), connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                _ads.AdTitle += $"{reader.GetString(0)}\n";

                //List<string> hyperlinks = new()
                //{
                //    $"{reader.GetString(1)}\n"

                //};

                _ads.AdHyperlinks = new List<string>();

                _ads.AdHyperlinks.Add($"{reader.GetString(1)}\n");

                foreach (var hyperlink in _ads.AdHyperlinks)
                {
                    _ads.AdHyperlink += hyperlink.ToString();

                    Thread.Sleep(10000);

                    var processorsPages = client.GetStringAsync(hyperlink.ToString()).Result;

                    document.LoadHtml(processorsPages);

                    var processorsPrices = document.DocumentNode.SelectNodes("//div[@class='pricing-block  has-installments']/p[@class='product-new-price']");

                    foreach (var processorPrice in processorsPrices)
                    {
                        _ads.AdPrice += $"{processorPrice.InnerText}\n";

                    }

                }

            }
            connection.Close();

            File.WriteAllText(@"C:\Users\VLAD\Documents\Ads.json", $"{JsonConvert.SerializeObject(_ads)}");

            return JsonConvert.SerializeObject(_ads);
        }


    }
}
