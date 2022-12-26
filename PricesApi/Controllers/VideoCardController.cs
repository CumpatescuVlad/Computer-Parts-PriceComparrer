using DataScrapper.src;
using Microsoft.AspNetCore.Mvc;


namespace DataScrapper.Controllers
{
    [ApiController]
    public class VideoCardController : ControllerBase
    {
        private readonly EmagAdsData emag = new();
        private readonly HttpClient client = new();
        private readonly HtmlAgilityPack.HtmlDocument document = new();

        #region VideoCardsRouting
        [Route("api/VideoCards/{pageCount}")]

        [HttpGet]

        public void GetEmagVideoCardsAds(string pageCount)
        {
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/placi_video/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            emag.ReadVideoCardsTitles(document);

        }

        [Route("api/ReadVideoCardsPrices/{videoCardModel}")]
        [HttpGet]

        public string GetVideoCardsPrices(string videoCardModel) => emag.ReadVideoCardsPrices(document, videoCardModel);

        #endregion
    }
}
