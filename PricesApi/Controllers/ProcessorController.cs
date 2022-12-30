using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class ProcessorController : ControllerBase
    {
        private readonly IReadAdsData _emag;
        private readonly XpathConfig _xpathConfig;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public ProcessorController(IReadAdsData emag,IOptions<XpathConfig> xpathConfig)
        {
            _emag = emag;
            _xpathConfig = xpathConfig.Value;
        }

        #region ProcessorsRouting
        [Route("api/Processors/{pageCount}")]

        [HttpGet]

        public void GetEmagProcessorsAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_xpathConfig.UserAgent);

            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/procesoare/p{pageCount}/c").Result;

            document.LoadHtml(HtmlPage);

            _emag.ReadComponentsTitles(document, "ProcessorTable",_xpathConfig.EmagAdsTitles);

        }

        [Route("api/ReadProcessorPrices/{querryString}")]

        [HttpGet]

        public string GetProcessorPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString,_xpathConfig.EmagAdsPrices, _xpathConfig.EmagAdsPricesForDeals);
        #endregion

    }
}
