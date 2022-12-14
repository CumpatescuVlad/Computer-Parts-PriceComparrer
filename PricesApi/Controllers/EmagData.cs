using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DataScrapper
{
    [ApiController]
    public class EmagData : ControllerBase
    {
        private readonly AdsScrapper _scapper = new();

        [Route("api/EmagResults/{searchItem}")]

        [HttpGet]

        public string ReadEmagAds(string searchItem) => $"{_scapper.EmagResults(searchItem)}";

        #region !Working
        //[Route("api/EvomagResults/{searchItem}")]

        //[HttpGet]

        //public string ReadEvomagAds(string searchItem) => $"{_scapper.EvomagResults(searchItem)}";

        //[Route("api/ITarenaResults/{searchItem}")]

        //[HttpGet]

        //public string ITarenaResults(string searchItem) => $"{_scapper.ITArenaResults(searchItem)}";

        //[Route("api/VexioResults/{searchItem}")]

        //[HttpGet]

        //public string VexioAds(string searchItem) => $"{_scapper.VexioResults(searchItem)}";

        //[Route("api/VexioResults/{searchItem}")]

        //[HttpGet]

        //public string IPon(string searchItem) => $"{_scapper.IPonResults(searchItem)}";

        #endregion

        [Route("api/ForITResults/{searchItem}")]

        [HttpGet]

        public string ForITAds(string searchItem) => $"{_scapper.ForITResults(searchItem)}";

        [Route("api/PcOneResults/{searchItem}")]

        [HttpGet]

        public string PcOneAds(string searchItem) => $"{_scapper.PcOneResults(searchItem)}";

        [Route("api/ItGalaxyResults/{searchItem}")]

        [HttpGet]

        public string ItGalaxyAds(string searchItem) => $"{_scapper.ItGalaxyResults(searchItem)}";

    }
}
