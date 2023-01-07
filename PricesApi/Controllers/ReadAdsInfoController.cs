using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Web;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class ReadAdsInfoController : ControllerBase
    {
        private readonly IReadAdsData _ads;
        private readonly ConfigModel _configModel;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public ReadAdsInfoController(IReadAdsData ads, IOptions<ConfigModel> configModel)
        {
            _ads = ads;
            _configModel = configModel.Value;
        }

        [Route("api/GetAdsTitles/{websiteUrl}/{xpath}/{tableName}/{webSiteName}/{websitePrefix?}")]

        [HttpPost]
        public string GetWebsiteTitles(string websiteUrl, string xpath, string tableName, string webSiteName, string? websitePrefix)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_configModel.UserAgent);

            var HtmlPage = client.GetStringAsync(HttpUtility.UrlDecode(websiteUrl)).Result;

            document.LoadHtml(HtmlPage);

            _ads.ReadComponentsTitles(document, tableName, HttpUtility.UrlDecode(xpath), webSiteName, HttpUtility.UrlDecode(websitePrefix));

            return "200 OK";
        }

        [Route("api/GetProductsPrices/{querryString}/{priceXpath}/{priceXpathForDeals}")]

        [HttpGet]

        public string GetProductsPrices(string querryString, string priceXpath, string priceXpathForDeals) => _ads.ReadComponentsPrices(document, querryString, HttpUtility.UrlDecode(priceXpath), HttpUtility.UrlDecode(priceXpathForDeals));
    }
}
