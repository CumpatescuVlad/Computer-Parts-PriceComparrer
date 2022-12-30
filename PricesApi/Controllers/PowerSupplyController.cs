using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class PowerSupplyController : ControllerBase
    {
        private readonly IReadAdsData _emag;
        private readonly XpathConfig _xpathConfig;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public PowerSupplyController(IReadAdsData emag, IOptions<XpathConfig> xpathConfig)
        {
            _emag = emag;
            _xpathConfig = xpathConfig.Value;
        }

        #region PowerSupplyRouting
        [Route("api/PowerSupply/{pageCount}")]

        [HttpGet]

        public void GetEmagPowerSupplyAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_xpathConfig.UserAgent);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/surse-pc/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "PowerSupplyTable",_xpathConfig.EmagAdsTitles);

        }

        [Route("api/ReadPowerSupplyPrices/{querryString}")]
        [HttpGet]

        public string GetPowerSupplyPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString,_xpathConfig.EmagAdsPrices, _xpathConfig.EmagAdsPricesForDeals);

        #endregion

    }
}
