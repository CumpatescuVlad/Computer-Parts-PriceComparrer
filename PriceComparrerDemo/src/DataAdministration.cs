using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Text;

namespace PriceComparrerDemo
{
    public class DataAdministration
    {
        private readonly SqlConnection connection = new(DatabaseInfo.ConnectionString);
        private readonly XpathModel? _xpath = JsonConvert.DeserializeObject<XpathModel>(File.ReadAllText($@"{Environment.CurrentDirectory}\Config\Xpaths.json"));
        private readonly HttpClient client = new();
        private readonly AdsModel _ads = new();

        private void FillColumn(string tableName, string websiteName, string firstUrl, string secondUrl, string? thirdUrl, string xpath, string? websitePrefix)
        {
            if (CheckForExistingData(tableName, websiteName) is false)
            {
                object websiteModel = new WebsiteModel()
                {
                    WebsiteUrl = firstUrl,
                    Xpath = xpath,
                    TableName = tableName,
                    WebsiteName = websiteName,
                    WebsitePrefix = websitePrefix,
                };

                client.PostAsync($"https://localhost:7210/api/InsertAdsTitles", new StringContent(JsonConvert.SerializeObject(websiteModel), Encoding.UTF8, "application/json"));

                Thread.Sleep(1000);

                object secondWebsiteModel = new WebsiteModel()
                {
                    WebsiteUrl = secondUrl,
                    Xpath = xpath,
                    TableName = tableName,
                    WebsiteName = websiteName,
                    WebsitePrefix = websitePrefix,
                };

                client.PostAsync($"https://localhost:7210/api/InsertAdsTitles", new StringContent(JsonConvert.SerializeObject(secondWebsiteModel), Encoding.UTF8, "application/json"));

                if (thirdUrl is not null)
                {
                    Thread.Sleep(1000);

                    object thirdWebsiteModel = new WebsiteModel()
                    {
                        WebsiteUrl = thirdUrl,
                        Xpath = xpath,
                        TableName = tableName,
                        WebsiteName = websiteName,
                        WebsitePrefix = websitePrefix,
                    };

                    client.PostAsync($"https://localhost:7210/api/InsertAdsTitles", new StringContent(JsonConvert.SerializeObject(thirdWebsiteModel), Encoding.UTF8, "application/json"));
                }

            }

        }

        private bool CheckForExistingData(string tableName, string webSiteName)
        {
            connection.Open();

            var readExistingDataCommand = new SqlCommand(DatabaseInfo.ReadExistingData(tableName, webSiteName), connection);

            var reader = readExistingDataCommand.ExecuteReader();

            while (reader.Read())
            {
                _ads.AdTitle += reader.GetString(0);
                _ads.AdHyperlink += reader.GetString(1);
            }

            connection.Close();

            bool dataExists = _ads.AdTitle is not null && _ads.AdHyperlink is not null;

            return dataExists;
        }


        #region FillTables
        public void FillProcessorTable()
        {
            FillColumn("ProcessorTable", "Emag",
              "https://www.emag.ro/procesoare/p1/c", "https://www.emag.ro/procesoare/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("ProcessorTable", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:1",
                "https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            Thread.Sleep(1000);

            FillColumn("SecondProcessorTable", "PcGarage",
               "https://www.pcgarage.ro/procesoare/pagina1/",
               "https://www.pcgarage.ro/procesoare/pagina2/",
               "https://www.pcgarage.ro/procesoare/pagina3/",
               _xpath.PCGarageTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("SecondProcessorTable", "Vexio",
               "https://www.vexio.ro/procesoare/pagina1",
               "https://www.vexio.ro/procesoare/pagina2",
               "https://www.vexio.ro/procesoare/pagina3",
               _xpath.VexioTitlesXpath, string.Empty);



        }

        public void FillVideoCardTable()
        {
            FillColumn("VideoCardTable", "Emag",
                "https://www.emag.ro/placi_video/p1/c", "https://www.emag.ro/placi_video/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("VideoCardTable", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-placi-video/",
                "https://www.evomag.ro/componente-pc-gaming-placi-video/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-placi-video/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            Thread.Sleep(1000);

            FillColumn("SecondVideoCardTable", "PCGarage",
               "https://www.pcgarage.ro/placi-video/",
               "https://www.pcgarage.ro/placi-video/pagina2/",
               "https://www.pcgarage.ro/placi-video/pagina3/",
               _xpath.PCGarageTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("SecondVideoCardTable", "Vexio",
               "https://www.vexio.ro/placi-video/",
               "https://www.vexio.ro/placi-video/pagina2/",
               "https://www.vexio.ro/placi-video/pagina3/",
               _xpath.VexioTitlesXpath, string.Empty);


        }

        public void FillMotherboardTable()
        {
            FillColumn("MotherboardTable", "Emag",
                "https://www.emag.ro/placi_baza/p1/c", "https://www.emag.ro/placi_baza/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("MotherboardTable", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-placi-de-baza/",
                "https://www.evomag.ro/componente-pc-gaming-placi-de-baza/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-placi-de-baza/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            Thread.Sleep(1000);

            FillColumn("SecondMotherboardTable", "PCGarage",
               "https://www.pcgarage.ro/placi-de-baza/",
               "https://www.pcgarage.ro/placi-de-baza/pagina2/",
               "https://www.pcgarage.ro/placi-de-baza/pagina3/",
               _xpath.PCGarageTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("SecondMotherboardTable", "Vexio",
               "https://www.vexio.ro/placi-de-baza/",
               "https://www.vexio.ro/placi-de-baza/pagina2/",
               "https://www.vexio.ro/placi-de-baza/pagina3/",
               _xpath.VexioTitlesXpath, string.Empty);

        }

        public void FillCoolerTable()
        {
            FillColumn("CoolerTable", "Emag",
                "https://www.emag.ro/coolere_procesor/p1/c", "https://www.emag.ro/coolere_procesor/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("CoolerTable", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-coolere-coolere-cpu/",
                "https://www.evomag.ro/componente-pc-gaming-coolere-coolere-cpu/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-coolere-coolere-cpu/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            Thread.Sleep(1000);

            FillColumn("SecondCoolerTable", "PCGarage",
               "https://www.pcgarage.ro/coolere/",
               "https://www.pcgarage.ro/coolere/pagina2/",
               "https://www.pcgarage.ro/coolere/pagina3/",
               _xpath.PCGarageTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("SecondCoolerTable", "Vexio",
               "https://www.vexio.ro/coolere-si-ventilatoare/pagina1",
               "https://www.vexio.ro/coolere-si-ventilatoare/pagina2",
               "https://www.vexio.ro/coolere-si-ventilatoare/pagina3",
               _xpath.VexioTitlesXpath, string.Empty);

        }

        public void FillRamMemoryTable()
        {
            FillColumn("RamMemoryTable", "Emag",
                "https://www.emag.ro/memorii/p1/c", "https://www.emag.ro/memorii/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);
            Thread.Sleep(1000);
            FillColumn("RamMemoryTable", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-memorii/",
                "https://www.evomag.ro/componente-pc-gaming-memorii/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-memorii/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            FillColumn("SecondRamMemoryTable", "PCGarage",
               "https://www.pcgarage.ro/memorii/",
               "https://www.pcgarage.ro/memorii/pagina2/",
               "https://www.pcgarage.ro/memorii/pagina3/",
               _xpath.PCGarageTitlesXpath, string.Empty);

            Thread.Sleep(1000);
            FillColumn("SecondRamMemoryTable", "Vexio",
               "https://www.vexio.ro/memorii-ram/",
               "https://www.vexio.ro/memorii-ram/pagina2/",
               "https://www.vexio.ro/memorii-ram/pagina3/",
               _xpath.VexioTitlesXpath, string.Empty);

        }

        public void FillPowerSupplyTable()
        {
            FillColumn("PowerSupplyTable", "Emag",
                "https://www.emag.ro/surse-pc/p1/c", "https://www.emag.ro/surse-pc/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("PowerSupplyTable", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-surse/",
                "https://www.evomag.ro/componente-pc-gaming-surse/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-surse/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            Thread.Sleep(1000);

            FillColumn("SecondPowerSupplyTable", "PCGarage",
               "https://www.pcgarage.ro/surse/",
               "https://www.pcgarage.ro/surse/pagina2/",
               "https://www.pcgarage.ro/surse/pagina3/",
               _xpath.PCGarageTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("SecondPowerSupplyTable", "Vexio",
               "https://www.vexio.ro/surse/",
               "https://www.vexio.ro/surse/pagina2/",
               "https://www.vexio.ro/surse/pagina3/",
               _xpath.VexioTitlesXpath, string.Empty);

        }

        public void FillComputerCaseTable()
        {
            FillColumn("ComputerCaseTable", "Emag",
                "https://www.emag.ro/carcase/p1/c", "https://www.emag.ro/carcase/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("ComputerCaseTable", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-carcase/",
                "https://www.evomag.ro/componente-pc-gaming-carcase/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-carcase/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            Thread.Sleep(1000);

            FillColumn("SecondComputerCaseTable", "PCGarage",
               "https://www.pcgarage.ro/carcase/",
               "https://www.pcgarage.ro/carcase/pagina2/",
               "https://www.pcgarage.ro/carcase/pagina3/",
               _xpath.PCGarageTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("SecondComputerCaseTable", "Vexio",
               "https://www.vexio.ro/carcase-pc/",
               "https://www.vexio.ro/carcase-pc/pagina2/",
               "https://www.vexio.ro/carcase-pc/pagina3/",
               _xpath.VexioTitlesXpath, string.Empty);

        }

        public void FillHDDTable()
        {
            FillColumn("HDDTable", "Emag",
                "https://www.emag.ro/hard_disk-uri/p1/c", "https://www.emag.ro/hard_disk-uri/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            FillColumn("HDDTable", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-hard-disk-drive-hard-disk-uri-hdd-desktop/",
                "https://www.evomag.ro/componente-pc-gaming-hard-disk-drive-hard-disk-uri-hdd-desktop/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-hard-disk-drive-hard-disk-uri-hdd-desktop/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            FillColumn("SecondHDDTable", "PCGarage",
               "https://www.pcgarage.ro/hard-disk-uri/",
               "https://www.pcgarage.ro/hard-disk-uri/pagina2/",
               "https://www.pcgarage.ro/hard-disk-uri/pagina3/",
               _xpath.PCGarageTitlesXpath, string.Empty);


            FillColumn("SecondHDDTable", "Vexio",
               "https://www.vexio.ro/hard-disk-uri/",
               "https://www.vexio.ro/hard-disk-uri/pagina2/",
               "https://www.vexio.ro/hard-disk-uri/pagina3/",
               _xpath.VexioTitlesXpath, string.Empty);

        }

        public void FillSSDTable()
        {
            FillColumn("SSDTable", "Emag",
                "https://www.emag.ro/solid-state_drive_ssd_/p1/c", "https://www.emag.ro/solid-state_drive_ssd_/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("SSDTable", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-solid-state-drive-ssd/",
                "https://www.evomag.ro/componente-pc-gaming-solid-state-drive-ssd/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-solid-state-drive-ssd/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            Thread.Sleep(1000);

            FillColumn("SecondSSDTable", "PCGarage",
               "https://www.pcgarage.ro/ssd/",
               "https://www.pcgarage.ro/ssd/pagina2/",
               "https://www.pcgarage.ro/ssd/pagina3/",
               _xpath.PCGarageTitlesXpath, string.Empty);

            Thread.Sleep(1000);

            FillColumn("SecondSSDTable", "Vexio",
               "https://www.vexio.ro/ssd-uri/",
               "https://www.vexio.ro/ssd-uri/pagina2/",
               "https://www.vexio.ro/ssd-uri/pagina3/",
               _xpath.VexioTitlesXpath, string.Empty);

        }

        #endregion


    }
}
