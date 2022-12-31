using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class HDDController : ControllerBase
    {

        private readonly IReadAdsData _emag;
        private readonly XpathConfig _xpathConfig;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public HDDController(IReadAdsData emag, IOptions<XpathConfig> xpathConfig)
        {
            _emag = emag;
            _xpathConfig = xpathConfig.Value;
        }

        #region HDDRouting
        [Route("api/EmagHDD/{pageCount}")]

        [HttpGet]

        public void GetEmagHDDAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_xpathConfig.UserAgent);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/hard_disk-uri/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "HDDTable", _xpathConfig.EmagAdsTitles, string.Empty, "Emag");

        }

        [Route("api/ReadEmagHDDPrices/{querryString}")]
        [HttpGet]

        public string GetHDDPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString,_xpathConfig.EmagAdsPrices,_xpathConfig.EmagAdsPrices);

        #endregion

    }
}
