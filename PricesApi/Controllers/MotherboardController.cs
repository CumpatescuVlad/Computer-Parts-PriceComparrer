﻿using Microsoft.Data.SqlClient;
using DataScrapper.src;
using Microsoft.AspNetCore.Mvc;


namespace DataScrapper.Controllers
{
   
    [ApiController]
    public class MotherboardController : ControllerBase
    {
        private readonly EmagAdsData emag = new();
        private readonly HttpClient client = new();
        private readonly HtmlAgilityPack.HtmlDocument document = new();

        #region MotherboardRouting
        [Route("api/Motherboards/{pageCount}")]

        [HttpGet]

        public void GetEmagMotherboardsAds(string pageCount)
        {
            var HtmlPage = client.GetStringAsync($"https://www.emag.ro/placi_baza/p{pageCount}/c").Result;
            document.LoadHtml(HtmlPage);
            emag.ReadMotherboardsTitles(document);

        }

        [Route("api/ReadMotherboardsPrices/{motherboardModel}")]
        [HttpGet]

        public string GetMotherboardsPrices(string motherboardModel) => emag.ReadMotherboardsPrices(document, motherboardModel);

        #endregion
    }
}
