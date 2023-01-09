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

        [Route("api/InsertAdsTitles")]

        [HttpPost]
        public void InsertAdsTitles(WebsiteModel websiteModel)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_configModel.UserAgent);

            if (websiteModel.WebsiteUrl is not null)
            {
                var HtmlPage = client.GetStringAsync(websiteModel.WebsiteUrl).Result;

                document.LoadHtml(HtmlPage);

                _ads.ReadComponentsTitles(document, websiteModel.TableName, websiteModel.Xpath, websiteModel.WebsiteName, websiteModel.WebsitePrefix);
            }

        }

        [Route("api/GetProductsPrices/{querryString}/{priceXpath}/{priceXpathForDeals}/")]

        [HttpGet]

        public string GetProductsPrices(string querryString, string priceXpath, string priceXpathForDeals) => _ads.ReadComponentsPrices(document, querryString, HttpUtility.UrlDecode(priceXpath), HttpUtility.UrlDecode(priceXpathForDeals));
    }
}
