using HtmlAgilityPack;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace DataScrapper.src
{
    public class Websites
    {
        //Check Xpath
        private readonly AdsModel _ads = new();
        private readonly HttpClient client = new();
        private readonly SqlConnection connection = new(InsertData.ConnectionString);

        #region ReadEmagComponentsAds

        public void ReadComponentsTitles(HtmlDocument document, string componentTable)
        {
            var componentsTitles = document.DocumentNode.SelectNodes("//div[@class='pad-hrz-xs']/a[@data-zone='title']");

            foreach (var componentTitle in componentsTitles)
            {
                connection.Open();

                var insertTitlesCommand = new SqlCommand(InsertData.InsertComponentData(componentTable, "Emag", componentTitle.InnerText, componentTitle.Attributes["href"].Value), connection);

                var adapter = new SqlDataAdapter(insertTitlesCommand);

                adapter.InsertCommand = insertTitlesCommand;

                adapter.InsertCommand.ExecuteNonQuery();

                connection.Close();
            }



        }

        public string ReadComponentsPrices(HtmlDocument document, string componentTable, string ramModel)
        {
            connection.Open();

            var command = new SqlCommand(ReadData.ReadComponentModel(componentTable, "Emag", ramModel), connection);

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

                    var componentsPages = client.GetStringAsync(hyperlink.ToString()).Result;

                    document.LoadHtml(componentsPages);

                    var componentsPrices = document.DocumentNode.SelectNodes("//div[@class='pricing-block  has-installments']/p[@class='product-new-price']");

                    componentsPrices ??= document.DocumentNode.SelectNodes("//div[@class='pricing-block  has-installments']/p[@class='product-new-price has-deal']");

                    foreach (var componentPrice in componentsPrices)
                    {
                        _ads.AdPrice += $"{componentPrice.InnerText}\n";

                    }

                }

            }
            connection.Close();

            return JsonConvert.SerializeObject(_ads);

        }

        #endregion

    }
}
