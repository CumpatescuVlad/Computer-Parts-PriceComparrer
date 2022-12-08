using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PricesApi.Controllers
{
    [Route("api/EmagPrices")]
    [ApiController]
    public class EmagAds : ControllerBase
    {
        [HttpGet]

        public string Response() => "This the respone"; 
    }
}
