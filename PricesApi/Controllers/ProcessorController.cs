using DataScrapper.src;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class ProcessorController : ControllerBase
    {
        private readonly EmagAdsData emag = new();
        private readonly HttpClient client = new();
        private readonly HtmlAgilityPack.HtmlDocument document = new();

        #region ProcessorsRouting
        [Route("api/Processors/{pageCount}")]

        [HttpGet]

        public void GetEmagProcessorsAds(string pageCount)
        {
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/procesoare/p{pageCount}/c").Result;

            document.LoadHtml(HtmlPage);

            emag.ReadProcessorsTitles(document);

        }

        [Route("api/ReadProcessorsPrices/{processorModel}")]

        [HttpGet]

        public string GetProcessorsPrices(string processorModel) => emag.ReadProcessorsPrices(document, processorModel);
        #endregion

    }
}
