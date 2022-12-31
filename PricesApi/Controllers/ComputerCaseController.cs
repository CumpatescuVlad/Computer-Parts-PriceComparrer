using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class ComputerCaseController : ControllerBase
    {
        
        private readonly IReadAdsData _emag;
        private readonly XpathConfig _xpathConfig;
        private readonly HttpClient client = new();
        private readonly HtmlAgilityPack.HtmlDocument document = new();

        public ComputerCaseController(IReadAdsData emag, IOptions<XpathConfig> xpathConfig)
        {
            _emag = emag;
            _xpathConfig = xpathConfig.Value;
        }

        #region ComputerCaseRouting
        [Route("api/EmagComputerCase/{pageCount}")]

        [HttpGet]

        public void GetEmagComputerCaseAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_xpathConfig.UserAgent);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/carcase/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "ComputerCaseTable" ,_xpathConfig.EmagAdsTitles,string.Empty,"Emag");

        }

        [Route("api/ReadEmagComputerCasePrices/{querryString}")]
        [HttpGet]

        public string GetComputerCasePrices(string querryString) => _emag.ReadComponentsPrices(document, querryString, _xpathConfig.EmagAdsPrices, _xpathConfig.EmagAdsPricesForDeals);

        #endregion



    }
}
