using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class SSDController : ControllerBase
    {
        private readonly IWebsites _emag;
        private readonly IConfiguration _config;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public SSDController(IWebsites emag)
        {
            _emag = emag;
        }
        #region SSDRouting
        [Route("api/SSD/{pageCount}")]

        [HttpGet]

        public void GetEmagSSDAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_config.GetSection("UserAgent").Value);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/solid-state_drive_ssd_/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "SSDTable", _config.GetSection("EmagAdsTitles").Value);

        }

        [Route("api/ReadSSDPrices/{querryString}")]
        [HttpGet]

        public string GetSSDPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString, _config.GetSection("EmagAdsPrices").Value, _config.GetSection("EmagAdsPricesForDeals").Value);

        #endregion
    }
}
