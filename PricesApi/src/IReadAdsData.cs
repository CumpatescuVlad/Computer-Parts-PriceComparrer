using HtmlAgilityPack;

namespace DataScrapper.src
{
    public interface IReadAdsData
    {
        string ReadComponentsPrices(HtmlDocument document, string querryString , string firstPriceXpath, string secondpriceXpath);
        void ReadComponentsTitles(HtmlDocument document, string componentTable, string webSiteAdsList);
    }
}