using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class CoolerController : ControllerBase
    {

        private readonly IReadAdsData _emag;
        private readonly XpathConfig _xpathConfig;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public CoolerController(IReadAdsData emag, IOptions<XpathConfig> xpathConfig)
        {
            _emag = emag;
            _xpathConfig = xpathConfig.Value;
        }

        #region CoolerRouting
        [Route("api/Cooler/{pageCount}")]

        [HttpGet]

        public void GetEmagCoolerAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_xpathConfig.UserAgent);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/coolere_procesor/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "CoolerTable",_xpathConfig.EmagAdsTitles);

        }

        [Route("api/CoolerPrices/{querryString}")]

        [HttpGet]

        public string GetCoolerPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString,_xpathConfig.EmagAdsPrices, _xpathConfig.EmagAdsPricesForDeals);

        #endregion





    }
}
