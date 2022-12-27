using DataScrapper.src;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class CoolerController : ControllerBase
    {
        private readonly Websites emag = new();
        private readonly HttpClient client = new();
        private readonly HtmlAgilityPack.HtmlDocument document = new();

        #region CoolerRouting
        [Route("api/Cooler/{pageCount}")]

        [HttpGet]

        public void GetEmagCoolerAds(string pageCount)
        {
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/coolere_procesor/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            emag.ReadComponentsTitles(document, "CoolerTable");

        }

        [Route("api/CoolerPrices/{coolerModel}")]

        [HttpGet]

        public string GetCoolerPrices(string coolerModel) => emag.ReadComponentsPrices(document, "CoolerTable", coolerModel);

        #endregion





    }
}
