using DataScrapper.src;
using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class RamMemoryController : ControllerBase
    {
        private readonly IWebsites _emag;
        private readonly IConfiguration _config;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public RamMemoryController(IWebsites emag)
        {
            _emag = emag;    
        }

        #region RamMemoryRouting
        [Route("api/RamMemory/{pageCount}")]

        [HttpGet]

        public void GetEmagRamMemoryAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_config.GetSection("UserAgent").Value);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/memorii/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "RamMemoryTable", _config.GetSection("EmagAdsTitles").Value);

        }

        [Route("api/ReadRamMemoryPrices/{querryString}")]
        [HttpGet]

        public string GetRamMemoryPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString, _config.GetSection("EmagAdsPrices").Value, _config.GetSection("EmagAdsPricesForDeals").Value);

        #endregion




    }
}
