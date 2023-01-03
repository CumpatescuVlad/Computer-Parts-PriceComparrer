using HtmlAgilityPack;

namespace DataScrapper.src
{
    public interface IReadAdsData
    {
        string ReadComponentsPrices(HtmlDocument document, string querryString, string firstPricesXpath, string xpathPricesForDeals);
        void ReadComponentsTitles(HtmlDocument document, string componentTable, string adsTitlesXpath, string webSiteName, string? websitePrefix);
    }
}