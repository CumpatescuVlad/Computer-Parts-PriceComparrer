using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class PowerSupplyController : ControllerBase
    {
        private readonly IWebsites _emag;
        private readonly IConfiguration _config;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public PowerSupplyController(IWebsites emag, IConfiguration config)
        {
            _emag = emag;
            _config = config;
        }


        #region PowerSupplyRouting
        [Route("api/PowerSupply/{pageCount}")]

        [HttpGet]

        public void GetEmagPowerSupplyAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_config.GetSection("UserAgent").Value);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/surse-pc/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "PowerSupplyTable",_config.GetSection("EmagAdsTitles").Value);

        }

        [Route("api/ReadPowerSupplyPrices/{querryString}")]
        [HttpGet]

        public string GetPowerSupplyPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString,_config.GetSection("EmagAdsPrices").Value, _config.GetSection("EmagAdsPricesForDeals").Value);

        #endregion

    }
}
