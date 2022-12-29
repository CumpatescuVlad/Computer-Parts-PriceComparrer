using DataScrapper.src;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class HDDController : ControllerBase
    {

        private readonly Websites emag = new();
        private readonly HttpClient client = new();
        private readonly HtmlAgilityPack.HtmlDocument document = new();

        #region HDDRouting
        [Route("api/HDD/{pageCount}")]

        [HttpGet]

        public void GetEmagHDDAds(string pageCount)
        {
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/hard_disk-uri/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            emag.ReadComponentsTitles(document, "HDDTable");

        }

        [Route("api/ReadHDDPrices/{querryString}")]
        [HttpGet]

        public string GetHDDPrices(string querryString) => emag.ReadComponentsPrices(document,querryString);

        #endregion

    }
}
