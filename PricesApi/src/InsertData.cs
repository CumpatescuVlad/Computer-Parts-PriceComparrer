namespace DataScrapper.src
{
    public static class  InsertData
    {
        private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = PriceComparrer; User ID = Vlad;Password = Apicultor__69;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static string ConnectionString { get=>_connectionString;}

        public static  string InsertProcessorTitles(string webSiteName,string titles, string hyperlinks) => $"Insert into ProcessorTable (WebSiteName,ComponentTitle,ComponentHyperlink) values ('{webSiteName}','{titles}','{hyperlinks}') ";

        public static string InsertProcessorPrices(string webSiteName,string price) => $"Insert into ProcessorTable  (ComponentPrices) values  ('{price}')  Where WebSiteName ='{webSiteName}' ";


	}
}
