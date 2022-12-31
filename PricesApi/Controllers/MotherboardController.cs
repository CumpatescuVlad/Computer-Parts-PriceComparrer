using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class MotherboardController : ControllerBase
    {
        private readonly IReadAdsData _emag;
        private readonly XpathConfig _xpathConfig;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public MotherboardController(IReadAdsData emag, IOptions<XpathConfig> xpathConfig)
        {
            _emag = emag;
            _xpathConfig = xpathConfig.Value;
        }

        #region MotherboardRouting
        [Route("api/EmagMotherboards/{pageCount}")]

        [HttpGet]

        public void GetEmagMotherboardsAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_xpathConfig.UserAgent);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/placi_baza/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "MotherboardTable", _xpathConfig.EmagAdsTitles, string.Empty, "Emag");

        }

        [Route("api/ReadEmagMotherboardPrices/{querryString}")]
        [HttpGet]

        public string GetMotherboardPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString,_xpathConfig.EmagAdsPrices,_xpathConfig.EmagAdsPricesForDeals);

        #endregion
    }
}
