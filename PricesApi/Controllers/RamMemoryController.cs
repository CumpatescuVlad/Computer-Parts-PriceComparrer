using DataScrapper.src;
using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class RamMemoryController : ControllerBase
    {
        private readonly IReadAdsData _emag;
        private readonly XpathConfig _xpathConfig;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public RamMemoryController(IReadAdsData emag,IOptions<XpathConfig> xpathConfig)
        {
            _emag = emag; 
            _xpathConfig = xpathConfig.Value;
        }

        #region RamMemoryRouting
        [Route("api/RamMemory/{pageCount}")]

        [HttpGet]

        public void GetEmagRamMemoryAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_xpathConfig.UserAgent);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/memorii/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "RamMemoryTable", _xpathConfig.EmagAdsTitles);

        }

        [Route("api/ReadRamMemoryPrices/{querryString}")]
        [HttpGet]

        public string GetRamMemoryPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString, _xpathConfig.EmagAdsPrices, _xpathConfig.EmagAdsPricesForDeals);

        #endregion




    }
}
