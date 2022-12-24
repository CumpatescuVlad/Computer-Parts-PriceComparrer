using Microsoft.Data.SqlClient;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace DataScrapper.src
{
    public class EmagAdsData
    {
        private readonly AdsModel _ads = new();
        private readonly HttpClient client = new();
        private readonly SqlConnection connection = new(InsertData.ConnectionString);

        public void ReadProcessorsTitles(HtmlDocument document)
        {
            var processorsTitles = document.DocumentNode.SelectNodes("//div[@class='pad-hrz-xs']/a[@data-zone='title']");

            foreach (var processorTitle in processorsTitles)
            {
                connection.Open();

                var insertCommand = new SqlCommand(InsertData.InsertComponentData("ProcessorTable","Emag", processorTitle.InnerText, processorTitle.Attributes["href"].Value), connection);

                var adapter = new SqlDataAdapter(insertCommand);

                adapter.InsertCommand = insertCommand;

                adapter.InsertCommand.ExecuteNonQuery();

                connection.Close();
            }

        }

        public string ReadProcessorsPrices(HtmlDocument document, string processorModel)
        {
            connection.Open();

            var command = new SqlCommand(ReadData.ReadComponentModel("VideoCardTable","Emag", processorModel), connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                _ads.AdTitle += $"{reader.GetString(0)}\n";

                _ads.AdHyperlinks = new List<string>()
                {
                    $"{reader.GetString(1)}\n"
                };

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

            return JsonConvert.SerializeObject(_ads);
        }

        public void ReadVideoCardsTitles(HtmlDocument document)
        {
            var videoCardsTitles = document.DocumentNode.SelectNodes("//div[@class='pad-hrz-xs']/a[@data-zone='title']");

            foreach (var videoCardTitle in videoCardsTitles)
            {
                connection.Open();

                var insertCommand = new SqlCommand(InsertData.InsertComponentData("VideoCardTable","Emag", videoCardTitle.InnerText, videoCardTitle.Attributes["href"].Value), connection);

                var adapter = new SqlDataAdapter(insertCommand);

                adapter.InsertCommand = insertCommand;

                adapter.InsertCommand.ExecuteNonQuery();

                connection.Close();
            }



        }

        public string ReadVideoCardsPrices(HtmlDocument document, string videoCardModel)
        {
            connection.Open();

            var command = new SqlCommand(ReadData.ReadComponentModel("VideoCardTable","Emag", videoCardModel), connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                _ads.AdTitle += $"{reader.GetString(0)}\n";

                _ads.AdHyperlinks = new List<string>()
                {
                    $"{reader.GetString(1)}\n"
                };

                foreach (var hyperlink in _ads.AdHyperlinks)
                {
                    _ads.AdHyperlink += hyperlink.ToString();

                    Thread.Sleep(10000);

                    var videoCardsPages = client.GetStringAsync(hyperlink.ToString()).Result;

                    document.LoadHtml(videoCardsPages);

                    var videoCardsPrices = document.DocumentNode.SelectNodes("//div[@class='pricing-block  has-installments']/p[@class='product-new-price']");

                    foreach (var videoCardPrice in videoCardsPrices)
                    {
                        _ads.AdPrice += $"{videoCardPrice.InnerText}\n";

                    }

                }

            }
            connection.Close();

            return JsonConvert.SerializeObject(_ads);

        }
    }
}
