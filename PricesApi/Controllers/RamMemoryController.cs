using DataScrapper.src;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class RamMemoryController : ControllerBase
    {
        private readonly Websites emag = new();
        private readonly HttpClient client = new();
        private readonly HtmlAgilityPack.HtmlDocument document = new();

        #region RamMemoryRouting
        [Route("api/RamMemory/{pageCount}")]

        [HttpGet]

        public void GetEmagRamMemoryAds(string pageCount)
        {

            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/memorii/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            emag.ReadComponentsTitles(document, "RamMemoryTable");

        }

        [Route("api/ReadRamMemoryPrices/{ramMemoryModel}")]
        [HttpGet]

        public string GetRamMemoryPrices(string ramMemoryModel) => emag.ReadComponentsPrices(document, "RamMemoryTable", ramMemoryModel);

        #endregion




    }
}
