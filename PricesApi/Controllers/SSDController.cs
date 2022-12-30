using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class SSDController : ControllerBase
    {
        private readonly IReadAdsData _emag;
        private readonly XpathConfig _xpathConfig;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public SSDController(IReadAdsData emag,IOptions<XpathConfig> XpathConfig)
        {
            _emag = emag;
            _xpathConfig = XpathConfig.Value;
        }

        #region SSDRouting
        [Route("api/SSD/{pageCount}")]

        [HttpGet]

        public void GetEmagSSDAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_xpathConfig.UserAgent);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/solid-state_drive_ssd_/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "SSDTable", _xpathConfig.EmagAdsTitles);

        }

        [Route("api/ReadSSDPrices/{querryString}")]
        [HttpGet]

        public string GetSSDPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString, _xpathConfig.EmagAdsPrices, _xpathConfig.EmagAdsPricesForDeals);

        #endregion
    }
}
