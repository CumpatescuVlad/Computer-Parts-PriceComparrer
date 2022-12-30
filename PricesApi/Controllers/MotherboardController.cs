using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;


namespace DataScrapper.Controllers
{

    [ApiController]
    public class MotherboardController : ControllerBase
    {
        private readonly IWebsites _emag;
        private readonly IConfiguration _config;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public MotherboardController(IWebsites emag, IConfiguration config)
        {
            _emag = emag;
            _config = config;
        }



        #region MotherboardRouting
        [Route("api/Motherboards/{pageCount}")]

        [HttpGet]

        public void GetEmagMotherboardsAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_config.GetSection("UserAgent").Value);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/placi_baza/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "MotherboardTable",_config.GetSection("EmagAdsTitles").Value);

        }

        [Route("api/ReadMotherboardPrices/{querryString}")]
        [HttpGet]

        public string GetMotherboardPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString,_config.GetSection("EmagAdsPrices").Value,_config.GetSection("EmagAdsPricesForDeals").Value);

        #endregion
    }
}
