using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DataScrapper.Controllers
{
    [ApiController]
    public class VideoCardController : ControllerBase
    {
        private readonly IReadAdsData _emag;
        private readonly XpathConfig _xpathConfig;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public VideoCardController(IReadAdsData emag,IOptions<XpathConfig> xpathConfig)
        {
            _emag= emag;
            _xpathConfig = xpathConfig.Value;
        }
        #region VideoCardsRouting
        [Route("api/VideoCards/{pageCount}")]

        [HttpGet]

        public void GetEmagVideoCardsAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_xpathConfig.UserAgent);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/placi_video/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "VideoCardTable", _xpathConfig.EmagAdsTitles);

        }

        [Route("api/ReadVideoCardPrices/{querryString}")]
        [HttpGet]

        public string GetVideoCardPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString,_xpathConfig.EmagAdsPrices,_xpathConfig.EmagAdsPricesForDeals);

        #endregion
    }
}
