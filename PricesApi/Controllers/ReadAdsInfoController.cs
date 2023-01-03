using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Web;

namespace DataScrapper.Controllers
{
    
    [ApiController]
    public class GeneralURlController : ControllerBase
    {
        private readonly HttpClient client = new();
        private readonly ConfigModel _modelConfig;
        private readonly IReadAdsData _ads;
        private HtmlDocument document = new();

        public GeneralURlController(IReadAdsData ads, IOptions<ConfigModel> modelConfig)
        {
            _ads = ads;
            _modelConfig = modelConfig.Value;
        }

        [Route("api/GetAdsTitles/{websiteUrl}/{xpath}/{tableName}/{webSiteName}/{websitePrefix?}")]
        [HttpGet]
        public void GetWebsiteTitles(string websiteUrl,string xpath, string tableName,string webSiteName,string? websitePrefix)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_modelConfig.UserAgent);

            var HtmlPage = client.GetStringAsync(HttpUtility.UrlDecode(websiteUrl)).Result;

            document.LoadHtml(HtmlPage);

            _ads.ReadComponentsTitles(document, tableName, HttpUtility.UrlDecode(xpath), webSiteName, HttpUtility.UrlDecode(websitePrefix));

        }   

        [Route("api/GetroductsPrices/{querryString}/{priceXpath}/{priceXpathForDeals}")]

        [HttpGet]

        public string GetCelROProcessorPrices(string querryString,string priceXpath,string priceXpathForDeals) => _ads.ReadComponentsPrices(document, querryString,HttpUtility.UrlDecode(priceXpath), HttpUtility.UrlDecode(priceXpath));
    }
}
