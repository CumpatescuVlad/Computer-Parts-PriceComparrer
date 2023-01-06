using HtmlAgilityPack;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Web;

namespace DataScrapper.src
{
    public class ReadAdsData : IReadAdsData
    {
        private readonly AdsModel _ads = new();
        private readonly ConfigModel _configModel;
        private readonly HttpClient client = new();

        public ReadAdsData(IOptions<ConfigModel> modelConfig)
        {
            _configModel = modelConfig.Value;
        }

        #region ReadComponentsAds

        public void ReadComponentsTitles(HtmlDocument document, string componentTable, string adsTitlesXpath, string webSiteName, string? websitePrefix)
        {
            var connection = new SqlConnection(_configModel.ConnectionString);

            var componentsTitles = document.DocumentNode.SelectNodes(adsTitlesXpath);

            connection.Open();

            foreach (var componentTitle in componentsTitles)
            {
                var insertTitlesCommand = new SqlCommand(InsertData.InsertComponentData(componentTable, webSiteName, componentTitle.InnerText, $"{websitePrefix}{componentTitle.Attributes["href"].Value}"), connection);

                var adapter = new SqlDataAdapter(insertTitlesCommand);

                adapter.InsertCommand = insertTitlesCommand;

                adapter.InsertCommand.ExecuteNonQuery();

            }

            connection.Close();
            connection.Dispose();
        }

        public string ReadComponentsPrices(HtmlDocument document, string querryString, string firstPricesXpath, string xpathPricesForDeals)
        {
            var connection = new SqlConnection(_configModel.ConnectionString);

            connection.Open();

            var command = new SqlCommand(querryString, connection);

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

                    Thread.Sleep(3000);

                    client.DefaultRequestHeaders.UserAgent.ParseAdd(_configModel.UserAgent);

                    var componentsPages = client.GetStringAsync(hyperlink.ToString()).Result;

                    document.LoadHtml(componentsPages);

                    var componentsPrices = document.DocumentNode.SelectNodes(firstPricesXpath);

                    componentsPrices ??= document.DocumentNode.SelectNodes(xpathPricesForDeals);

                    foreach (var componentPrice in componentsPrices)
                    {
                        _ads.AdPrice += $"{HttpUtility.HtmlDecode(componentPrice.InnerText)}\n";

                    }

                }

            }
            connection.Close();

            return JsonConvert.SerializeObject(_ads);

        }

        #endregion

    }
}
