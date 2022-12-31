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

        #region EmagProcessorsRouting
        [Route("api/EmagProcessors/{pageCount}")]

        [HttpGet]

        public void GetEmagProcessorsAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_xpathConfig.UserAgent);

            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/procesoare/p{pageCount}/c").Result;

            document.LoadHtml(HtmlPage);

            _emag.ReadComponentsTitles(document, "ProcessorTable",_xpathConfig.EmagAdsTitles,string.Empty,"Emag");

        }

        [Route("api/ReadEmagProcessorPrices/{querryString}")]

        [HttpGet]

        public string GetEmagProcessorPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString,_xpathConfig.EmagAdsPrices, _xpathConfig.EmagAdsPricesForDeals);
        #endregion

        #region EvomagProcessorsRouting
        [Route("api/EvomagProcessors/{pageCount}")]

        [HttpGet]

        public void GetEvomagProcessorsAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_xpathConfig.UserAgent);

            var HtmlPage = client.GetStringAsync($"https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:{pageCount}").Result;

            document.LoadHtml(HtmlPage);

            _emag.ReadComponentsTitles(document, "ProcessorTable", _xpathConfig.EmagAdsTitles,_xpathConfig.Website,"Evomag");

        }

        [Route("api/ReadEvomagProcessorPrices/{querryString}")]

        [HttpGet]

        public string GetEvomagProcessorPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString, _xpathConfig.EmagAdsPrices, _xpathConfig.EmagAdsPricesForDeals);
        #endregion

    }
}
