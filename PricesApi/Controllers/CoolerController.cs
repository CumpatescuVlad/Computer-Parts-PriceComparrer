using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class CoolerController : ControllerBase
    {

        private readonly IWebsites _emag;
        private readonly IConfiguration _config;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public CoolerController(IWebsites emag, IConfiguration config)
        {
            _emag = emag;
            _config = config;
        }

        #region CoolerRouting
        [Route("api/Cooler/{pageCount}")]

        [HttpGet]

        public void GetEmagCoolerAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_config.GetSection("UserAgent").Value);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/coolere_procesor/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "CoolerTable",_config.GetSection("EmagAdsTitles").Value);

        }

        [Route("api/CoolerPrices/{querryString}")]

        [HttpGet]

        public string GetCoolerPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString,_config.GetSection("EmagAdsPrices").Value,_config.GetSection("EmagAdsPricesForDeals").Value);

        #endregion





    }
}
