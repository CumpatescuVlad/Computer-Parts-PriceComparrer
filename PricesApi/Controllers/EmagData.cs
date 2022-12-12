using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DataScrapper
{
    [ApiController]
    public class EmagData : ControllerBase
    {
        AdsScrapper _scapper = new AdsScrapper();

        [Route("api/EmagResults/{searchItem}")]

        [HttpGet]

        public string ReadEmagAds(string searchItem) => $"{_scapper.EmagResults(searchItem)}";

        [Route("api/EvomagResults/{searchItem}")]

        [HttpGet]

        public string ReadEvomagAds(string searchItem) => $"{_scapper.EvomagResults(searchItem)}";
    }
}
