using DataScrapper.src;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;


namespace DataScrapper.Controllers
{
    [ApiController]
    public class VideoCardController : ControllerBase
    {
        private readonly IWebsites _emag;
        private readonly IConfiguration _config;
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();

        public VideoCardController(IWebsites emag)
        {
            _emag= emag;
        }
        #region VideoCardsRouting
        [Route("api/VideoCards/{pageCount}")]

        [HttpGet]

        public void GetEmagVideoCardsAds(string pageCount)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(_config.GetSection("UserAgent").Value);
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/placi_video/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            _emag.ReadComponentsTitles(document, "VideoCardTable", _config.GetSection("EmagAdsTitles").Value);

        }

        [Route("api/ReadVideoCardPrices/{querryString}")]
        [HttpGet]

        public string GetVideoCardPrices(string querryString) => _emag.ReadComponentsPrices(document, querryString, _config.GetSection("EmagAdsPrices").Value, _config.GetSection("EmagAdsPricesForDeals").Value);

        #endregion
    }
}
