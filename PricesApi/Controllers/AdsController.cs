using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataScrapper.src;
namespace DataScrapper.Controllers
{
   
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly EmagAdsData emag = new();
        private readonly HttpClient client = new();
        private readonly HtmlDocument document = new();
        [Route("api/Processor/{pageCount}")]

        [HttpGet]

        public void ReadEmagAds(string pageCount)
        {
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/procesoare/p{pageCount}/c").Result;

            document.LoadHtml(HtmlPage);

            //emag.ReadProcessorTitle(document, pageCount);
            //emag.ReadProcessorHyperlink(document, pageCount);
            //emag.ReadProcessorPrices(document, pageCount);

            //emag.InsertProcessorData($"{emag.ReadProcessorTitle(document)}",$"{emag.ReadProcessorHyperlink(document)}",$"{emag.ReadProcessorPrices(document)}");

            emag.ReadProcessorTitle(document);
        }

        [Route("api/ProcessorModel/{processorModel}")]

        [HttpGet]

        public string ReadProcessorModel(string processorModel) =>emag.ReadProcessorAds(processorModel);

    }
}
