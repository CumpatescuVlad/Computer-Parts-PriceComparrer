using DataScrapper.src;
using Microsoft.AspNetCore.Mvc;

namespace DataScrapper.Controllers
{

    [ApiController]
    public class ComputerCaseController : ControllerBase
    {
        private readonly Websites emag = new();
        private readonly HttpClient client = new();
        private readonly HtmlAgilityPack.HtmlDocument document = new();

        #region ComputerCaseRouting
        [Route("api/ComputerCase/{pageCount}")]

        [HttpGet]

        public void GetEmagComputerCaseAds(string pageCount)
        {
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/carcase/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            emag.ReadComponentsTitles(document, "ComputerCaseTable");

        }

        [Route("api/ComputerCasePrices/{computerCaseModel}")]
        [HttpGet]

        public string GetComputerCasePrices(string computerCaseModel) => emag.ReadComponentsPrices(document, "ComputerCaseTable", computerCaseModel);

        #endregion



    }
}
