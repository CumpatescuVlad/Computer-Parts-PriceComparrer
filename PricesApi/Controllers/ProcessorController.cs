using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class ProcessorController : ControllerBase
    {
        private readonly IWebsites _emag;
        private readonly IConfiguration _config;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public ProcessorController(IWebsites emag)
        {
            _emag = emag;
        }

        #region ProcessorsRouting
        [Route("api/Processors/{pageCount}")]

        [HttpGet]

        public void GetEmagProcessorsAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_config.GetSection("UserAgent").Value);

            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/procesoare/p{pageCount}/c").Result;

            document.LoadHtml(HtmlPage);

            _emag.ReadComponentsTitles(document, "ProcessorTable",_config.GetSection("EmagAdsTitles").Value);

        }

        [Route("api/ReadProcessorPrices/{querryString}")]

        [HttpGet]

        public string GetProcessorPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString);
        #endregion

    }
}
