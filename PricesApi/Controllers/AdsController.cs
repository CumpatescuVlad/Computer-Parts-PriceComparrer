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

        [Route("api/Processor/{searchModel}/{pageCount}")]

        [HttpGet]

        public string EmagAds(string pageCount, string searchModel) =>$"{emag.ReadProcessorData(pageCount,searchModel)}";
       

    }
}
