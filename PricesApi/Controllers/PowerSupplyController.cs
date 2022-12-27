using DataScrapper.src;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class PowerSupplyController : ControllerBase
    {
        private readonly Websites emag = new();
        private readonly HttpClient client = new();
        private readonly HtmlAgilityPack.HtmlDocument document = new();

        #region PowerSupplyRouting
        [Route("api/PowerSupply/{pageCount}")]

        [HttpGet]

        public void GetEmagPowerSupplyAds(string pageCount)
        {

            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/surse-pc/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            emag.ReadComponentsTitles(document, "PowerSupplyTable");

        }

        [Route("api/ReadPowerSupplyPrices/{powerSupplyModel}")]
        [HttpGet]

        public string GetPowerSupplyPrices(string powerSupplyModel) => emag.ReadComponentsPrices(document, "PowerSupplyTable", powerSupplyModel);

        #endregion







    }
}
