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
        [Route("api/Processor/{pageCount}")]

        [HttpGet]

        public void GetEmagProcessorAds(string pageCount)
        {
            // client.DefaultRequestHeaders.Add("User-Agent : Mozilla/5.0");
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/procesoare/p{pageCount}/c").Result;

            document.LoadHtml(HtmlPage);

            emag.ReadProcessorTitles(document);

        }

        [Route("api/ReadProcessorPrice/{processorModel}")]

        [HttpGet]

        public string ReadProcessorPrices(string processorModel) => emag.ReadProcessorAds(document, processorModel);


    }
}
