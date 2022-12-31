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
        private readonly XpathConfig _xpathConfig;
        private readonly HttpClient client = new();
        private readonly SqlConnection connection = new(InsertData.ConnectionString);

        public ReadAdsData(IOptions<XpathConfig> xpathConfig)
        {
            _xpathConfig = xpathConfig.Value;
        }
        #region ReadEmagComponentsAds

        public void ReadComponentsTitles(HtmlDocument document, string componentTable, string webSiteAdsList, string? websitePrefix, string webSiteName)
        {
            var componentsTitles = document.DocumentNode.SelectNodes(webSiteAdsList);

            foreach (var componentTitle in componentsTitles)
            {
                connection.Open();

                var insertTitlesCommand = new SqlCommand(InsertData.InsertComponentData(componentTable, webSiteName, componentTitle.InnerText, $"{websitePrefix}{componentTitle.Attributes["href"].Value}"), connection);

                var adapter = new SqlDataAdapter(insertTitlesCommand);

                adapter.InsertCommand = insertTitlesCommand;

                adapter.InsertCommand.ExecuteNonQuery();

                connection.Close();
            }



        }

        public string ReadComponentsPrices(HtmlDocument document, string querryString, string firstPricesXpath, string secondXpathPrices)
        {
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

                    Thread.Sleep(10000);

                    client.DefaultRequestHeaders.UserAgent.ParseAdd(_xpathConfig.UserAgent);

                    var componentsPages = client.GetStringAsync(hyperlink.ToString()).Result;

                    document.LoadHtml(componentsPages);

                    var componentsPrices = document.DocumentNode.SelectNodes(firstPricesXpath);

                    componentsPrices ??= document.DocumentNode.SelectNodes(secondXpathPrices);

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
