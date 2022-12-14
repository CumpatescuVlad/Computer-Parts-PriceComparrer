using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DataScrapper
{
    [ApiController]
    public class EmagData : ControllerBase
    {
        private readonly AdsScrapper _scapper = new();

        #region !Working

        //[Route("api/EvomagResults/{searchItem}")]

        //[HttpGet]

        //public string ReadEvomagAds(string searchItem) => $"{_scapper.EvomagResults(searchItem)}";

        //[Route("api/VexioResults/{searchItem}")]

        //[HttpGet]

        //public string VexioAds(string searchItem) => $"{_scapper.VexioResults(searchItem)}";

        //[Route("api/IponResults/{searchItem}")]

        //[HttpGet]

        //public string IPonAds(string searchItem) => $"{_scapper.IPonResults(searchItem)}";

        //[Route("api/DwinResults/{searchItem}")]

        //[HttpGet]

        //public string DwinAds(string searchItem) => $"{_scapper.DwinResults(searchItem)}";

        #endregion


        [Route("api/EmagResults/{searchItem}")]

        [HttpGet]

        public string ReadEmagAds(string searchItem) => $"{_scapper.EmagResults(searchItem)}";


        [Route("api/ForITResults/{searchItem}")]

        [HttpGet]

        public string ForITAds(string searchItem) => $"{_scapper.ForITResults(searchItem)}";

        [Route("api/PcOneResults/{searchItem}")]

        [HttpGet]

        public string PcOneAds(string searchItem) => $"{_scapper.PcOneResults(searchItem)}";

        [Route("api/ItGalaxyResults/{searchItem}")]

        [HttpGet]

        public string ItGalaxyAds(string searchItem) => $"{_scapper.ItGalaxyResults(searchItem)}";


        [Route("api/FlaxResults/{searchItem}")]

        [HttpGet]

        public string FlaxAds(string searchItem) => $"{_scapper.FlaxResuls(searchItem)}";

        [Route("api/PcConeResults/{searchItem}")]

        [HttpGet]

        public string PcConeAds(string searchItem) => $"{_scapper.PcConeResuls(searchItem)}";


        [Route("api/PcBitResults/{searchItem}")]

        [HttpGet]

        public string PcBitAds(string searchItem) => $"{_scapper.PcBitResutls(searchItem)}";


        //[Route("api/ITarenaResults/{searchItem}")]

        //[HttpGet]

        //public string ITarenaResults(string searchItem) => $"{_scapper.ITArenaResults(searchItem)}";
    }
}
