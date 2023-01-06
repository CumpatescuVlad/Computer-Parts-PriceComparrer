namespace DataScrapper.src
{
    public static class InsertData
    {
        public static string InsertComponentData(string tableName, string webSiteName, string titles, string hyperlinks) => $"Insert into {tableName} (WebSiteName,ComponentTitle,ComponentHyperlink) values ('{webSiteName}','{titles}','{hyperlinks}') ";

    }
}
