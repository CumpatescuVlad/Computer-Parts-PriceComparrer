using Microsoft.AspNetCore.Mvc;

namespace PricesApi.Controllers
{
    //[Route("api/EmagPrices/{searchitem}")]
    [ApiController]
    public class AdsApi : ControllerBase
    {
        
        private readonly AdsScrapper _dataScrapper = new();
        
        [HttpGet]
        [Route("api/EmagPrices/{searchitem}")]
       public string EmagResponse(string searchitem)=> _dataScrapper.EmagResults(searchitem);

        
    }
}
