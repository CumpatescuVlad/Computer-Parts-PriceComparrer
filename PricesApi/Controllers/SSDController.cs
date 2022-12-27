using DataScrapper.src;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class SSDController : ControllerBase
    {
        private readonly Websites emag = new();
        private readonly HttpClient client = new();
        private readonly HtmlAgilityPack.HtmlDocument document = new();

        #region SSDRouting
        [Route("api/SSD/{pageCount}")]

        [HttpGet]

        public void GetEmagSSDAds(string pageCount)
        {
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/solid-state_drive_ssd_/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            emag.ReadComponentsTitles(document, "SSDTable");

        }

        [Route("api/ReadSSDPrices/{ssdModel}")]
        [HttpGet]

        public string GetSSDPrices(string ssdModel) => emag.ReadComponentsPrices(document, "SSDTable", ssdModel);

        #endregion
    }
}
