using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PriceComparrerWinforms.src
{
    public class DataChecking
    {
        private readonly SqlConnection connection = new(Data.ConnectionString);
        private readonly XpathsModels _xpath = JsonConvert.DeserializeObject<XpathsModels>(File.ReadAllText($@"{Environment.CurrentDirectory}\Config\Xpaths.json"));
        private readonly WebClient client = new();
        private readonly AdsModel _ads = new();

        

         public void ExistingAds()
         {

         }

        private void FillProcessorTable()
        {
            if (String.IsNullOrEmpty(CheckForExistingAds("ProcessorTable", "Procesor", "Emag")))
            {
                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/procesoare/p1/c/{_xpath.EmagTitlesXpath}/ProcessorTable/Emag/");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/procesoare/p2/c/{_xpath.EmagTitlesXpath}/ProcessorTable/Emag/");
            }
            else if (String.IsNullOrEmpty(CheckForExistingAds("ProcessorTable", "Procesor", "Evomag")))
            {
                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:1/{_xpath.EvomagTitlesXpath}/ProcessorTable/Evomag/https://www.evomag.ro");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:2/{_xpath.EvomagTitlesXpath}/ProcessorTable/Evomag/https://www.evomag.ro");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:3/{_xpath.EvomagTitlesXpath}/ProcessorTable/Evomag/https://www.evomag.ro");

            }
            else if (String.IsNullOrEmpty(CheckForExistingAds("ProcessorTable", "Procesor", "PCGarage")))
            {
                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/procesoare/pagina1/{_xpath.PCGarageTitlesXpath}/ProcessorTable/PCGarage/");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/procesoare/pagina2/{_xpath.PCGarageTitlesXpath}/ProcessorTable/PCGarage/");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/procesoare/pagina3/{_xpath.PCGarageTitlesXpath}/ProcessorTable/PCGarage/");

                
            }
            else if (String.IsNullOrEmpty(CheckForExistingAds("ProcessorTable", "Procesor", "CelRO")))
            {
                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/procesoare/0a-1/{_xpath.CelROTitlesXpath}/ProcessorTable/CelRO/");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/procesoare/0a-2/{_xpath.CelROTitlesXpath}/ProcessorTable/CelRO/");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/procesoare/0a-3/{_xpath.CelROTitlesXpath}/ProcessorTable/CelRO/");
            }
            else if (String.IsNullOrEmpty(CheckForExistingAds("ProcessorTable", "Procesor", "ForIT")))
            {
                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/procesoare/pagina1/{_xpath.ForITTitlesXpath}/ProcessorTable/ForIT/");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/procesoare/pagina2/{_xpath.ForITTitlesXpath}/ProcessorTable/ForIT/");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/procesoare/pagina3/{_xpath.ForITTitlesXpath}/ProcessorTable/ForIT/");
            }
            else if (String.IsNullOrEmpty(CheckForExistingAds("ProcessorTable", "Procesor", "Vexio")))
            {
                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/procesoare/pagina1/{_xpath.VexioTitlesXpath}/ProcessorTable/Vexio/");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/procesoare/pagina2/{_xpath.VexioTitlesXpath}/ProcessorTable/Vexio/");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/procesoare/pagina3/{_xpath.VexioTitlesXpath}/ProcessorTable/Vexio/");

            }
            else if (String.IsNullOrEmpty(CheckForExistingAds("ProcessorTable", "Procesor", "Ipon")))
            {
                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/procesor/78?page=1/{_xpath.IponTitlesXpath}/ProcessorTable/Ipon/");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/procesor/78?page=2/{_xpath.IponTitlesXpath}/ProcessorTable/Ipon/");

                Thread.Sleep(1000);

                client.OpenRead($"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/procesor/78?page=3/{_xpath.IponTitlesXpath}/ProcessorTable/Ipon/");
                
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

    }
}
