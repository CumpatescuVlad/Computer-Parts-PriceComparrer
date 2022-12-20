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
        
        [Route("api/Processor/{pageCount}")]

        [HttpGet]

        public string ReadEmagAds(string pageCount, string searchModel) =>$"{emag.InsertProcessorData(pageCount,searchModel)}";


        [Route("api/ProcessorModel/{processorModel}")]

        [HttpGet]

        public string ReadProcessorModel(string processorModel) =>emag.ReadProcessorAds(processorModel);

    }
}
