using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class HDDController : ControllerBase
    {

        private readonly IWebsites _emag;
        private readonly IConfiguration _config;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public HDDController(IWebsites emag, IConfiguration config)
        {
            _emag = emag;
            _config = config;
        }

        #region HDDRouting
        [Route("api/HDD/{pageCount}")]

        [HttpGet]

        public void GetEmagHDDAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_config.GetSection("UserAgent").Value);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/hard_disk-uri/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "HDDTable",_config.GetSection("EmagAdsTitles").Value);

        }

        [Route("api/ReadHDDPrices/{querryString}")]
        [HttpGet]

        public string GetHDDPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString,_config.GetSection("EmagAdsPrices").Value,_config.GetSection("EmagAdsPricesForDeals").Value);

        #endregion

    }
}
