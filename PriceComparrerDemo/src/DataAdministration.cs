using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Text;

namespace PriceComparrerDemo
{
    public class DataAdministration
    {
        private readonly SqlConnection connection = new(Data.ConnectionString);
        private readonly XpathModel? _xpath = JsonConvert.DeserializeObject<XpathModel>(File.ReadAllText($@"{Environment.CurrentDirectory}\Config\Xpaths.json"));
        private readonly HttpClient client = new();
        private readonly AdsModel _ads = new();
        
        private void FillColumn(string tableName, string columnName, string websiteName, string firstUrl, string secondUrl, string? thirdUrl, string xpath, string? websitePrefix)
        {
            if (String.IsNullOrEmpty(CheckForExistingAds(tableName, columnName, websiteName)))
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

        private string CheckForExistingAds(string tableName, string column, string webSiteName)
        {
            connection.Open();

            var readProcessorDataCommand = new SqlCommand(Data.ReadExistingComponentData(tableName, column, webSiteName), connection);

            var reader = readProcessorDataCommand.ExecuteReader();

            while (reader.Read())
            {
                _ads.AdTitle += reader.GetString(0);
            }

            connection.Close();

            return _ads.AdTitle;
        }


        #region FillTables
        public void FillProcessorTable()
        {
            FillColumn("ProcessorTable", "Procesor", "Emag",
                "https://www.emag.ro/procesoare/p1/c", "https://www.emag.ro/procesoare/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            FillColumn("ProcessorTable", "Procesor", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:1",
                "https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:3",
                _xpath.EmagTitlesXpath, "https://www.evomag.ro");

            FillColumn("ProcessorTable", "Procesor", "PCGarage",
               "https://www.pcgarage.ro/procesoare/pagina1",
               "https://www.pcgarage.ro/procesoare/pagina2",
               "https://www.pcgarage.ro/procesoare/pagina3",
               _xpath.PCGarageTitlesXpath, string.Empty);

            FillColumn("ProcessorTable", "Procesor", "CelRO",
               "https://www.cel.ro/procesoare/0a-1",
               "https://www.cel.ro/procesoare/0a-2",
               "https://www.cel.ro/procesoare/0a-3",
               _xpath.CelROTitlesXpath, string.Empty);

            FillColumn("ProcessorTable", "Procesor", "ForIT",
               "https://www.forit.ro/procesoare/pagina1",
               "https://www.forit.ro/procesoare/pagina2",
               "https://www.forit.ro/procesoare/pagina3",
               _xpath.ForITTitlesXpath, string.Empty);

            FillColumn("ProcessorTable", "Procesor", "Vexio",
               "https://www.vexio.ro/procesoare/pagina1",
               "https://www.vexio.ro/procesoare/pagina2",
               "https://www.vexio.ro/procesoare/pagina3",
               _xpath.VexioTitlesXpath, string.Empty);

            FillColumn("ProcessorTable", "Procesor", "Ipon",
               "https://ipon.ro/shop/grup/componente-pc/procesor/78?page=1",
               "https://ipon.ro/shop/grup/componente-pc/procesor/78?page=2",
               "https://ipon.ro/shop/grup/componente-pc/procesor/78?page=3",
               _xpath.IponTitlesXpath, string.Empty);

        }

        public void FillVideoCardTable()
        {
            FillColumn("VideoCardTable", "Placa video", "Emag",
                "https://www.emag.ro/placi_video/p1/c", "https://www.emag.ro/placi_video/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            FillColumn("VideoCardTable", "Placa video", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-placi-video/filtru/pagina:1",
                "https://www.evomag.ro/componente-pc-gaming-placi-video/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-placi-video/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            FillColumn("VideoCardTable", "Placa video", "PCGarage",
               "https://www.pcgarage.ro/placi-video/pagina1",
               "https://www.pcgarage.ro/placi-video/pagina2",
               "https://www.pcgarage.ro/placi-video/pagina3",
               _xpath.PCGarageTitlesXpath, string.Empty);

            FillColumn("VideoCardTable", "Placa video", "CelRO",
               "https://www.cel.ro/placi-video/0a-1",
               "https://www.cel.ro/placi-video/0a-2",
               "https://www.cel.ro/placi-video/0a-3",
               _xpath.CelROTitlesXpath, string.Empty);

            FillColumn("VideoCardTable", "Placa video", "ForIT",
               "https://www.forit.ro/placi-video/pagina1",
               "https://www.forit.ro/placi-video/pagina2",
               "https://www.forit.ro/placi-video/pagina3",
               _xpath.ForITTitlesXpath, string.Empty);

            FillColumn("VideoCardTable", "Placa video", "Vexio",
               "https://www.vexio.ro/placi-video/pagina1",
               "https://www.vexio.ro/placi-video/pagina2",
               "https://www.vexio.ro/placi-video/pagina3",
               _xpath.VexioTitlesXpath, string.Empty);

            FillColumn("VideoCardTable", "Placa video", "Ipon",
               "https://ipon.ro/shop/grup/componente-pc/placa-video/463?page=1",
               "https://ipon.ro/shop/grup/componente-pc/placa-video/463?page=2",
               "https://ipon.ro/shop/grup/componente-pc/placa-video/463?page=3",
               _xpath.IponTitlesXpath, string.Empty);

        }

        public void FillMotherboardTable()
        {
            FillColumn("MotherboardTable", "Placa de baza", "Emag",
                "https://www.emag.ro/placi_baza/p1/c", "https://www.emag.ro/placi_baza/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            FillColumn("MotherboardTable", "Placa de baza", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-placi-de-baza/filtru/pagina:1",
                "https://www.evomag.ro/componente-pc-gaming-placi-de-baza/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-placi-de-baza/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            FillColumn("MotherboardTable", "Placa de baza", "PCGarage",
               "https://www.pcgarage.ro/placi-de-baza/pagina1",
               "https://www.pcgarage.ro/placi-de-baza/pagina2",
               "https://www.pcgarage.ro/placi-de-baza/pagina3",
               _xpath.PCGarageTitlesXpath, string.Empty);

            FillColumn("MotherboardTable", "Placa de baza", "CelRO",
               "https://www.cel.ro/placi-de-baza/0a-1",
               "https://www.cel.ro/placi-de-baza/0a-2",
               "https://www.cel.ro/placi-de-baza/0a-3",
               _xpath.CelROTitlesXpath, string.Empty);

            FillColumn("MotherboardTable", "Placa de baza", "ForIT",
               "https://www.forit.ro/placi-de-baza/pagina1",
               "https://www.forit.ro/placi-de-baza/pagina2",
               "https://www.forit.ro/placi-de-baza/pagina3",
               _xpath.ForITTitlesXpath, string.Empty);

            FillColumn("MotherboardTable", "Placa de baza", "Vexio",
               "https://www.vexio.ro/placi-de-baza/pagina1",
               "https://www.vexio.ro/placi-de-baza/pagina2",
               "https://www.vexio.ro/placi-de-baza/pagina3",
               _xpath.VexioTitlesXpath, string.Empty);

            FillColumn("MotherboardTable", "Placa de baza", "Ipon",
               "https://ipon.ro/shop/grup/componente-pc/placa-de-baza/40?page=1",
               "https://ipon.ro/shop/grup/componente-pc/placa-de-baza/40?page=2",
               "https://ipon.ro/shop/grup/componente-pc/placa-de-baza/40?page=3",
               _xpath.IponTitlesXpath, string.Empty);

        }

        public void FillCoolerTable()
        {
            FillColumn("CoolerTable", "Cooler", "Emag",
                "https://www.emag.ro/coolere_procesor/p1/c", "https://www.emag.ro/coolere_procesor/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            FillColumn("CoolerTable", "Cooler", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-coolere-coolere-cpu/filtru/pagina:1",
                "https://www.evomag.ro/componente-pc-gaming-coolere-coolere-cpu/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-coolere-coolere-cpu/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            FillColumn("CoolerTable", "Cooler", "PCGarage",
               "https://www.pcgarage.ro/coolere/pagina1",
               "https://www.pcgarage.ro/coolere/pagina2",
               "https://www.pcgarage.ro/coolere/pagina3",
               _xpath.PCGarageTitlesXpath, string.Empty);

            FillColumn("CoolerTable", "Cooler", "CelRO",
               "https://www.cel.ro/coolere-componente/0a-1",
               "https://www.cel.ro/coolere-componente/0a-2",
               "https://www.cel.ro/coolere-componente/0a-3",
               _xpath.CelROTitlesXpath, string.Empty);

            FillColumn("CoolerTable", "Cooler", "ForIT",
               "https://www.forit.ro/coolere/pagina1",
               "https://www.forit.ro/coolere/pagina2",
               "https://www.forit.ro/coolere/pagina3",
               _xpath.ForITTitlesXpath, string.Empty);

            FillColumn("CoolerTable", "Cooler", "Vexio",
               "https://www.vexio.ro/coolere-si-ventilatoare/pagina1",
               "https://www.vexio.ro/coolere-si-ventilatoare/pagina2",
               "https://www.vexio.ro/coolere-si-ventilatoare/pagina3",
               _xpath.VexioTitlesXpath, string.Empty);

            FillColumn("CoolerTable", "Cooler", "Ipon",
               "https://ipon.ro/shop/grup/componente-pc/racire-cpu/389?page=1",
               "https://ipon.ro/shop/grup/componente-pc/racire-cpu/389?page=2",
               "https://ipon.ro/shop/grup/componente-pc/racire-cpu/389?page=3",
               _xpath.IponTitlesXpath, string.Empty);

        }

        public void FillRamMemoryTable()
        {
            FillColumn("RamMemoryTable", "Memorie", "Emag",
                "https://www.emag.ro/memorii/p1/c", "https://www.emag.ro/memorii/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            FillColumn("RamMemoryTable", "Memorie", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-memorii/filtru/pagina:1",
                "https://www.evomag.ro/componente-pc-gaming-memorii/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-memorii/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            FillColumn("RamMemoryTable", "Memorie", "PCGarage",
               "https://www.pcgarage.ro/memorii/pagina1",
               "https://www.pcgarage.ro/memorii/pagina2",
               "https://www.pcgarage.ro/memorii/pagina3",
               _xpath.PCGarageTitlesXpath, string.Empty);

            FillColumn("RamMemoryTable", "Memorie", "CelRO",
               "https://www.cel.ro/memorii/0a-1",
               "https://www.cel.ro/memorii/0a-2",
               "https://www.cel.ro/memorii/0a-3",
               _xpath.CelROTitlesXpath, string.Empty);

            FillColumn("RamMemoryTable", "Memorie", "ForIT",
               "https://www.forit.ro/memorii/pagina1",
               "https://www.forit.ro/memorii/pagina2",
               "https://www.forit.ro/memorii/pagina3",
               _xpath.ForITTitlesXpath, string.Empty);

            FillColumn("RamMemoryTable", "Memorie", "Vexio",
               "https://www.vexio.ro/memorii-ram/pagina1",
               "https://www.vexio.ro/memorii-ram/pagina2",
               "https://www.vexio.ro/memorii-ram/pagina3",
               _xpath.VexioTitlesXpath, string.Empty);

            FillColumn("RamMemoryTable", "Memorie", "Ipon",
               "https://ipon.ro/shop/grup/componente-pc/memorie/488?page=1",
               "https://ipon.ro/shop/grup/componente-pc/memorie/488?page=2",
               "https://ipon.ro/shop/grup/componente-pc/memorie/488?page=3",
               _xpath.IponTitlesXpath, string.Empty);

        }

        public void FillPowerSupplyTable()
        {
            FillColumn("PowerSupplyTable", "Sursa", "Emag",
                "https://www.emag.ro/surse-pc/p1/c", "https://www.emag.ro/surse-pc/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            FillColumn("PowerSupplyTable", "Sursa", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-surse/filtru/pagina:1",
                "https://www.evomag.ro/componente-pc-gaming-surse/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-surse/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            FillColumn("PowerSupplyTable", "Sursa", "PCGarage",
               "https://www.pcgarage.ro/surse/pagina1",
               "https://www.pcgarage.ro/surse/pagina2",
               "https://www.pcgarage.ro/surse/pagina3",
               _xpath.PCGarageTitlesXpath, string.Empty);

            FillColumn("PowerSupplyTable", "Sursa", "CelRO",
               "https://www.cel.ro/surse/0a-1",
               "https://www.cel.ro/surse/0a-2",
               "https://www.cel.ro/surse/0a-3",
               _xpath.CelROTitlesXpath, string.Empty);

            FillColumn("PowerSupplyTable", "Sursa", "ForIT",
               "https://www.forit.ro/surse/pagina1",
               "https://www.forit.ro/surse/pagina2",
               "https://www.forit.ro/surse/pagina3",
               _xpath.ForITTitlesXpath, string.Empty);

            FillColumn("PowerSupplyTable", "Sursa", "Vexio",
               "https://www.vexio.ro/surse/pagina1",
               "https://www.vexio.ro/surse/pagina2",
               "https://www.vexio.ro/surse/pagina3",
               _xpath.VexioTitlesXpath, string.Empty);

            FillColumn("PowerSupplyTable", "Sursa", "Ipon",
               "https://ipon.ro/shop/grup/componente-pc/sursa-de-alimentare/449?page=1",
               "https://ipon.ro/shop/grup/componente-pc/sursa-de-alimentare/449?page=2",
               "https://ipon.ro/shop/grup/componente-pc/sursa-de-alimentare/449?page=3",
               _xpath.IponTitlesXpath, string.Empty);

        }

        public void FillComputerCaseTable()
        {
            FillColumn("ComputerCaseTable", "Carcasa", "Emag",
                "https://www.emag.ro/carcase/p1/c", "https://www.emag.ro/carcase/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            FillColumn("ComputerCaseTable", "Carcasa", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-carcase/filtru/pagina:1",
                "https://www.evomag.ro/componente-pc-gaming-carcase/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-carcase/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            FillColumn("ComputerCaseTable", "Carcasa", "PCGarage",
               "https://www.pcgarage.ro/carcase/pagina1",
               "https://www.pcgarage.ro/carcase/pagina2",
               "https://www.pcgarage.ro/carcase/pagina3",
               _xpath.PCGarageTitlesXpath, string.Empty);

            FillColumn("ComputerCaseTable", "Carcasa", "CelRO",
               "https://www.cel.ro/carcase/0a-1",
               "https://www.cel.ro/carcase/0a-2",
               "https://www.cel.ro/carcase/0a-3",
               _xpath.CelROTitlesXpath, string.Empty);

            FillColumn("ComputerCaseTable", "Carcasa", "ForIT",
               "https://www.forit.ro/carcase/pagina1",
               "https://www.forit.ro/carcase/pagina2",
               "https://www.forit.ro/carcase/pagina3",
               _xpath.ForITTitlesXpath, string.Empty);

            FillColumn("ComputerCaseTable", "Carcasa", "Vexio",
               "https://www.vexio.ro/carcase-pc/pagina1",
               "https://www.vexio.ro/carcase-pc/pagina2",
               "https://www.vexio.ro/carcase-pc/pagina3",
               _xpath.VexioTitlesXpath, string.Empty);

            FillColumn("ComputerCaseTable", "Carcasa", "Ipon",
               "https://ipon.ro/shop/grup/componente-pc/carcasa/356?page=1",
               "https://ipon.ro/shop/grup/componente-pc/carcasa/356?page=2",
               "https://ipon.ro/shop/grup/componente-pc/carcasa/356?page=3",
               _xpath.IponTitlesXpath, string.Empty);

        }

        public void FillHDDTable()
        {
            FillColumn("HDDTable", "HDD", "Emag",
                "https://www.emag.ro/hard_disk-uri/p1/c", "https://www.emag.ro/hard_disk-uri/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            FillColumn("HDDTable", "HDD", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-hard-disk-drive-hard-disk-uri-hdd-desktop/filtru/pagina:1",
                "https://www.evomag.ro/componente-pc-gaming-hard-disk-drive-hard-disk-uri-hdd-desktop/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-hard-disk-drive-hard-disk-uri-hdd-desktop/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            FillColumn("HDDTable", "Hard Disk", "PCGarage",
               "https://www.pcgarage.ro/hard-disk-uri/pagina1",
               "https://www.pcgarage.ro/hard-disk-uri/pagina2",
               "https://www.pcgarage.ro/hard-disk-uri/pagina3",
               _xpath.PCGarageTitlesXpath, string.Empty);

            FillColumn("HDDTable", "HDD", "CelRO",
               "https://www.cel.ro/hard-disk-uri/0a-1",
               "https://www.cel.ro/hard-disk-uri/0a-2",
               "https://www.cel.ro/hard-disk-uri/0a-3",
               _xpath.CelROTitlesXpath, string.Empty);

            FillColumn("HDDTable", "Hard Disk", "ForIT",
               "https://www.forit.ro/hard-disk-uri/pagina1",
               "https://www.forit.ro/hard-disk-uri/pagina2",
               "https://www.forit.ro/hard-disk-uri/pagina3",
               _xpath.ForITTitlesXpath, string.Empty);

            FillColumn("HDDTable", "Hard Disk", "Vexio",
               "https://www.vexio.ro/hard-disk-uri/pagina1",
               "https://www.vexio.ro/hard-disk-uri/pagina2",
               "https://www.vexio.ro/hard-disk-uri/pagina3",
               _xpath.VexioTitlesXpath, string.Empty);

        }

        public void FillSSDTable()
        {
            FillColumn("SSDTable", "Solid State Drive", "Emag",
                "https://www.emag.ro/solid-state_drive_ssd_/p1/c", "https://www.emag.ro/solid-state_drive_ssd_/p2/c", null, _xpath.EmagTitlesXpath, string.Empty);

            FillColumn("SSDTable", "SSD", "Evomag",
                "https://www.evomag.ro/componente-pc-gaming-solid-state-drive-ssd/filtru/pagina:1",
                "https://www.evomag.ro/componente-pc-gaming-solid-state-drive-ssd/filtru/pagina:2",
                "https://www.evomag.ro/componente-pc-gaming-solid-state-drive-ssd/filtru/pagina:3",
                _xpath.EvomagTitlesXpath, "https://www.evomag.ro");

            FillColumn("SSDTable", "SSD", "PCGarage",
               "https://www.pcgarage.ro/ssd/pagina1",
               "https://www.pcgarage.ro/ssd/pagina2",
               "https://www.pcgarage.ro/ssd/pagina3",
               _xpath.PCGarageTitlesXpath, string.Empty);

            FillColumn("SSDTable", "SSD", "CelRO",
               "https://www.cel.ro/ssd-uri/0a-1",
               "https://www.cel.ro/ssd-uri/0a-2",
               "https://www.cel.ro/ssd-uri/0a-3",
               _xpath.CelROTitlesXpath, string.Empty);

            FillColumn("SSDTable", "SSD", "ForIT",
               "https://www.forit.ro/ssd-uri/pagina1",
               "https://www.forit.ro/ssd-uri/pagina2",
               "https://www.forit.ro/ssd-uri/pagina3",
               _xpath.ForITTitlesXpath, string.Empty);

            FillColumn("SSDTable", "SSD", "Vexio",
               "https://www.vexio.ro/ssd-uri/pagina1",
               "https://www.vexio.ro/ssd-uri/pagina2",
               "https://www.vexio.ro/ssd-uri/pagina3",
               _xpath.VexioTitlesXpath, string.Empty);

        }
        #endregion


    }
}
