namespace DataScrapper.src
{
    public static class ReadData
    {
        private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = PriceComparrer; User ID = Vlad;Password = Apicultor__69;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static string ConnectionString { get => _connectionString; }

        public static string ReadProcessorModel(string webSiteName, string processorModel) => $"Select ComponentTitle , ComponentHyperlink  From ProcessorTable Where WebSiteName = '{webSiteName}' and ComponentTitle Like '%{processorModel}%'";

    }
}
