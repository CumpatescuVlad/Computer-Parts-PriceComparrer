using HtmlAgilityPack;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Web;

namespace DataScrapper.src
{
    public class Websites : IWebsites
    {
        //Check Xpath
        
        private readonly AdsModel _ads = new();
        private readonly IConfiguration _config;
        private readonly HttpClient client = new();
        private readonly SqlConnection connection = new(InsertData.ConnectionString);

        public Websites(IConfiguration config)
        {
            _config = config;
        }
        #region ReadEmagComponentsAds

        public void ReadComponentsTitles(HtmlDocument document, string componentTable, string webSiteAdsList)
        {
            var componentsTitles = document.DocumentNode.SelectNodes(webSiteAdsList);

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

        public string ReadComponentsPrices(HtmlDocument document, string querryString)
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

                    client.DefaultRequestHeaders.UserAgent.ParseAdd(_config.GetSection("UserAgent").Value);

                    var componentsPages = client.GetStringAsync(hyperlink.ToString()).Result;

                    document.LoadHtml(componentsPages);

                    var componentsPrices = document.DocumentNode.SelectNodes(_config.GetSection("EmagAdsPrices").Value);

                    componentsPrices ??= document.DocumentNode.SelectNodes(_config.GetSection("EmagAdsPricesForDeals").Value);

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
