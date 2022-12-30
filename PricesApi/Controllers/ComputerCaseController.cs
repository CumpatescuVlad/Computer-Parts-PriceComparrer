using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class ComputerCaseController : ControllerBase
    {
        
        private readonly IWebsites _emag;
        private readonly IConfiguration _config;
        private readonly HttpClient client = new();
        private readonly HtmlAgilityPack.HtmlDocument document = new();

        public ComputerCaseController(IWebsites emag, IConfiguration config)
        {
            _emag = emag;
            _config = config;
        }

        #region ComputerCaseRouting
        [Route("api/ComputerCase/{pageCount}")]

        [HttpGet]

        public void GetEmagComputerCaseAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_config.GetSection("UserAgent").Value);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/carcase/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "ComputerCaseTable" ,_config.GetSection("EmagAdsTitles").Value);

        }

        [Route("api/ComputerCasePrices/{querryString}")]
        [HttpGet]

        public string GetComputerCasePrices(string querryString) => _emag.ReadComponentsPrices(document, querryString,_config.GetSection("EmagAdsPrices").Value, _config.GetSection("EmagAdsPricesForDeals").Value);

        #endregion



    }
}
