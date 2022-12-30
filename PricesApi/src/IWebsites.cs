using HtmlAgilityPack;

namespace DataScrapper.src
{
    public interface IWebsites
    {
        string ReadComponentsPrices(HtmlDocument document, string querryString);
        void ReadComponentsTitles(HtmlDocument document, string componentTable, string webSiteAdsList);
    }
}