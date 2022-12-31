using HtmlAgilityPack;

namespace DataScrapper.src
{
    public interface IReadAdsData
    {
        string ReadComponentsPrices(HtmlDocument document, string querryString, string firstPricesXpath, string secondXpathPrices);
        void ReadComponentsTitles(HtmlDocument document, string componentTable, string webSiteAdsList, string? websitePrefix, string webSiteName);
    }
}