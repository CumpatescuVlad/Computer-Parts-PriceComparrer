using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Net;

namespace PriceComparrerWinforms.src
{
    public class DataAdministration
    {
        private readonly SqlConnection connection = new(Data.ConnectionString);
        private readonly XpathsModels? _xpath = JsonConvert.DeserializeObject<XpathsModels>(File.ReadAllText($@"{Environment.CurrentDirectory}\Config\Xpaths.json"));
        private readonly WebClient client = new();
        private readonly AdsModel _ads = new();

        public void FillProcessorTable()
        {
            FillColumn("ProcessorTable", "Procesor", "Emag",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/procesoare/p1/c/{_xpath.EmagTitlesXpath}/ProcessorTable/Emag",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/procesoare/p2/c/{_xpath.EmagTitlesXpath}/ProcessorTable/Emag", null);

            //FillColumn("ProcessorTable", "Procesor", "Evomag",
            //  $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:1/{_xpath.EvomagTitlesXpath}/ProcessorTable/Evomag/https://www.evomag.ro",
            //  $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:2/{_xpath.EvomagTitlesXpath}/ProcessorTable/Evomag/https://www.evomag.ro",
            //  $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-procesoare/filtru/pagina:3/{_xpath.EvomagTitlesXpath}/ProcessorTable/Evomag/https://www.evomag.ro");


            //FillColumn("ProcessorTable", "Procesor", "PCGarage",
            //    $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/procesoare/pagina1/{_xpath.PCGarageTitlesXpath}/ProcessorTable/PCGarage/",
            //    $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/procesoare/pagina2/{_xpath.PCGarageTitlesXpath}/ProcessorTable/PCGarage/",
            //    $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/procesoare/pagina3/{_xpath.PCGarageTitlesXpath}/ProcessorTable/PCGarage/");


            //FillColumn("ProcessorTable", "Procesor", "CelRO",
            //   $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/procesoare/0a-1/{_xpath.CelROTitlesXpath}/ProcessorTable/CelRO/",
            //   $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/procesoare/0a-2/{_xpath.CelROTitlesXpath}/ProcessorTable/CelRO/",
            //   $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/procesoare/0a-3/{_xpath.CelROTitlesXpath}/ProcessorTable/CelRO/");

            //FillColumn("ProcessorTable", "Procesor", "ForIT",
            //   $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/procesoare/pagina1/{_xpath.ForITTitlesXpath}/ProcessorTable/ForIT/",
            //   $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/procesoare/pagina2/{_xpath.ForITTitlesXpath}/ProcessorTable/ForIT/",
            //   $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/procesoare/pagina3/{_xpath.ForITTitlesXpath}/ProcessorTable/ForIT/");

            //FillColumn("ProcessorTable", "Procesor", "Vexio",
            //   $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/procesoare/pagina1/{_xpath.VexioTitlesXpath}/ProcessorTable/Vexio/",
            //   $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/procesoare/pagina2/{_xpath.VexioTitlesXpath}/ProcessorTable/Vexio/",
            //   $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/procesoare/pagina3/{_xpath.VexioTitlesXpath}/ProcessorTable/Vexio/");

            //FillColumn("ProcessorTable", "Procesor", "Ipon",
            //  $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/procesor/78?page=1/{_xpath.IponTitlesXpath}/ProcessorTable/Ipon/",
            //  $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/procesor/78?page=2/{_xpath.IponTitlesXpath}/ProcessorTable/Ipon/",
            //  $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/procesor/78?page=3/{_xpath.IponTitlesXpath}/ProcessorTable/Ipon/");


        }

        public void FillVideoCardTable()
        {
            FillColumn("VideoCardTable", "Placa video", "Emag",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/placi_video/p1/c/{_xpath.EmagTitlesXpath}/VideoCardTable/Emag/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/placi_video/p2/c/{_xpath.EmagTitlesXpath}/VideoCardTable/Emag/", null);

            FillColumn("VideoCardTable", "Placa video", "Evomag",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-placi-video/filtru/pagina:1/{_xpath.EvomagTitlesXpath}/VideoCardTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-placi-video/filtru/pagina:2/{_xpath.EvomagTitlesXpath}/VideoCardTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-placi-video/filtru/pagina:3/{_xpath.EvomagTitlesXpath}/VideoCardTable/Evomag/https://www.evomag.ro");


            FillColumn("VideoCardTable", "Placa video", "PCGarage",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/placi-video/pagina1/{_xpath.PCGarageTitlesXpath}/VideoCardTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/placi-video/pagina2/{_xpath.PCGarageTitlesXpath}/VideoCardTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/placi-video/pagina3/{_xpath.PCGarageTitlesXpath}/VideoCardTable/PCGarage/");


            FillColumn("VideoCardTable", "Placa video", "CelRO",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/placi-video/0a-1/{_xpath.CelROTitlesXpath}/VideoCardTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/placi-video/0a-2/{_xpath.CelROTitlesXpath}/VideoCardTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/placi-video/0a-3/{_xpath.CelROTitlesXpath}/VideoCardTable/CelRO/");

            FillColumn("VideoCardTable", "Placa video", "ForIT",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/placi-video/pagina1/{_xpath.ForITTitlesXpath}/VideoCardTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/placi-video/pagina2/{_xpath.ForITTitlesXpath}/VideoCardTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/placi-video/pagina3/{_xpath.ForITTitlesXpath}/VideoCardTable/ForIT/");

            FillColumn("VideoCardTable", "Placa video", "Vexio",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/placi-video/pagina1/{_xpath.VexioTitlesXpath}/VideoCardTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/placi-video/pagina2/{_xpath.VexioTitlesXpath}/VideoCardTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/placi-video/pagina3/{_xpath.VexioTitlesXpath}/VideoCardTable/Vexio/");

            FillColumn("VideoCardTable", "Placa video", "Ipon",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/placa-video/463?page=1/{_xpath.IponTitlesXpath}/VideoCardTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/placa-video/463?page=2/{_xpath.IponTitlesXpath}/VideoCardTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/placa-video/463?page=3/{_xpath.IponTitlesXpath}/VideoCardTable/Ipon/");



        }

        public void FillMotherboardTable()
        {
            FillColumn("MotherboardTable", "Placa de baza", "Emag",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/placi_baza/p1/c/{_xpath.EmagTitlesXpath}/MotherboardTable/Emag/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/placi_baza/p2/c/{_xpath.EmagTitlesXpath}/MotherboardTable/Emag/", null);

            FillColumn("MotherboardTable", "Placa de baza", "Evomag",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-placi-de-baza/filtru/pagina:1/{_xpath.EvomagTitlesXpath}/ProcessorTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-placi-de-baza/filtru/pagina:2/{_xpath.EvomagTitlesXpath}/ProcessorTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-placi-de-baza/filtru/pagina:3/{_xpath.EvomagTitlesXpath}/ProcessorTable/Evomag/https://www.evomag.ro");


            FillColumn("MotherboardTable", "Placa de baza", "PCGarage",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/placi-de-baza/pagina1/{_xpath.PCGarageTitlesXpath}/MotherboardTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/placi-de-baza/pagina2/{_xpath.PCGarageTitlesXpath}/MotherboardTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/placi-de-baza/pagina3/{_xpath.PCGarageTitlesXpath}/MotherboardTable/PCGarage/");


            FillColumn("MotherboardTable", "Placa de baza", "CelRO",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/placi-de-baza/0a-1/{_xpath.CelROTitlesXpath}/MotherboardTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/placi-de-baza/0a-2/{_xpath.CelROTitlesXpath}/MotherboardTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/placi-de-baza/0a-3/{_xpath.CelROTitlesXpath}/MotherboardTable/CelRO/");

            FillColumn("MotherboardTable", "Placa de baza", "ForIT",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/placi-de-baza/pagina1/{_xpath.ForITTitlesXpath}/MotherboardTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/placi-de-baza/pagina2/{_xpath.ForITTitlesXpath}/MotherboardTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/placi-de-baza/pagina3/{_xpath.ForITTitlesXpath}/MotherboardTable/ForIT/");

            FillColumn("MotherboardTable", "Placa de baza", "Vexio",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/placi-de-baza/pagina1/{_xpath.VexioTitlesXpath}/MotherboardTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/placi-de-baza/pagina2/{_xpath.VexioTitlesXpath}/MotherboardTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/placi-de-baza/pagina3/{_xpath.VexioTitlesXpath}/MotherboardTable/Vexio/");

            FillColumn("MotherboardTable", "Placa de baza", "Ipon",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/placa-de-baza/40?page=1/{_xpath.IponTitlesXpath}/MotherboardTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/placa-de-baza/40?page=2/{_xpath.IponTitlesXpath}/MotherboardTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/placa-de-baza/40?page=3/{_xpath.IponTitlesXpath}/MotherboardTable/Ipon/");

        }

        public void FillRamMemoryTable()
        {
            FillColumn("RamMemoryTable", "Memorie", "Emag",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/memorii/p1/c/{_xpath.EmagTitlesXpath}/RamMemoryTable/Emag/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/memorii/p2/c/{_xpath.EmagTitlesXpath}/RamMemoryTable/Emag/", null);

            FillColumn("RamMemoryTable", "Memorie", "Evomag",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-memorii/filtru/pagina:1/{_xpath.EvomagTitlesXpath}/RamMemoryTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-memorii/filtru/pagina:2/{_xpath.EvomagTitlesXpath}/RamMemoryTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-memorii/filtru/pagina:3/{_xpath.EvomagTitlesXpath}/RamMemoryTable/Evomag/https://www.evomag.ro");


            FillColumn("RamMemoryTable", "Memorie", "PCGarage",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/memorii/pagina1/{_xpath.PCGarageTitlesXpath}/RamMemoryTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/memorii/pagina2/{_xpath.PCGarageTitlesXpath}/RamMemoryTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/memorii/pagina3/{_xpath.PCGarageTitlesXpath}/RamMemoryTable/PCGarage/");


            FillColumn("RamMemoryTable", "Memorie", "CelRO",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/memorii/0a-1/{_xpath.CelROTitlesXpath}/RamMemoryTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/memorii/0a-2/{_xpath.CelROTitlesXpath}/RamMemoryTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/memorii/0a-3/{_xpath.CelROTitlesXpath}/RamMemoryTable/CelRO/");

            FillColumn("RamMemoryTable", "Memorie", "ForIT",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/memorii/pagina1/{_xpath.ForITTitlesXpath}/RamMemoryTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/memorii/pagina2/{_xpath.ForITTitlesXpath}/RamMemoryTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/memorii/pagina3/{_xpath.ForITTitlesXpath}/RamMemoryTable/ForIT/");

            FillColumn("RamMemoryTable", "Memorie", "Vexio",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/memorii-ram/pagina1/{_xpath.VexioTitlesXpath}/RamMemoryTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/memorii-ram/pagina2/{_xpath.VexioTitlesXpath}/RamMemoryTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/memorii-ram/pagina3/{_xpath.VexioTitlesXpath}/RamMemoryTable/Vexio/");

            FillColumn("RamMemoryTable", "Memorie", "Ipon",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/memorie/488?page=1/{_xpath.IponTitlesXpath}/RamMemoryTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/memorie/488?page=2/{_xpath.IponTitlesXpath}/RamMemoryTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/memorie/488?page=3/{_xpath.IponTitlesXpath}/RamMemoryTable/Ipon/");

        }

        public void FillCoolerTable()
        {
            FillColumn("CoolerTable", "Cooler", "Emag",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/coolere_procesor/p1/c/{_xpath.EmagTitlesXpath}/CoolerTable/Emag/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/coolere_procesor/p2/c/{_xpath.EmagTitlesXpath}/CoolerTable/Emag/", null);

            FillColumn("CoolerTable", "Cooler", "Evomag",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-coolere-coolere-cpu/filtru/pagina:1/{_xpath.EvomagTitlesXpath}/CoolerTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-coolere-coolere-cpu/filtru/pagina:2/{_xpath.EvomagTitlesXpath}/CoolerTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-coolere-coolere-cpu/filtru/pagina:3/{_xpath.EvomagTitlesXpath}/CoolerTable/Evomag/https://www.evomag.ro");


            FillColumn("CoolerTable", "Cooler", "PCGarage",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/coolere/pagina1/{_xpath.PCGarageTitlesXpath}/CoolerTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/coolere/pagina2/{_xpath.PCGarageTitlesXpath}/CoolerTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/coolere/pagina3/{_xpath.PCGarageTitlesXpath}/CoolerTable/PCGarage/");


            FillColumn("CoolerTable", "Cooler", "CelRO",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/coolere-componente/0a-1/{_xpath.CelROTitlesXpath}/CoolerTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/coolere-componente/0a-2/{_xpath.CelROTitlesXpath}/CoolerTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/coolere-componente/0a-3/{_xpath.CelROTitlesXpath}/CoolerTable/CelRO/");

            FillColumn("CoolerTable", "Cooler", "ForIT",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/coolere/pagina1/{_xpath.ForITTitlesXpath}/CoolerTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/coolere/pagina2/{_xpath.ForITTitlesXpath}/CoolerTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/coolere/pagina3/{_xpath.ForITTitlesXpath}/CoolerTable/ForIT/");

            FillColumn("CoolerTable", "Cooler", "Vexio",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/coolere-si-ventilatoare/pagina1/{_xpath.VexioTitlesXpath}/CoolerTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/coolere-si-ventilatoare/pagina2/{_xpath.VexioTitlesXpath}/CoolerTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/coolere-si-ventilatoare/pagina3/{_xpath.VexioTitlesXpath}/CoolerTable/Vexio/");

            FillColumn("CoolerTable", "Cooler", "Ipon",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/racire-cpu/389?page=1/{_xpath.IponTitlesXpath}/CoolerTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/racire-cpu/389?page=2/{_xpath.IponTitlesXpath}/CoolerTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/racire-cpu/389?page=3/{_xpath.IponTitlesXpath}/CoolerTable/Ipon/");

        }

        public void FillComputerCaseTable()
        {
            FillColumn("ComputerCaseTable", "Carcasa", "Emag",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/carcase/p1/c/{_xpath.EmagTitlesXpath}/ComputerCaseTable/Emag/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/carcase/p2/c/{_xpath.EmagTitlesXpath}/ComputerCaseTable/Emag/", null);

            FillColumn("ComputerCaseTable", "Carcasa", "Evomag",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-carcase/filtru/pagina:1/{_xpath.EvomagTitlesXpath}/ComputerCaseTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-carcase/filtru/pagina:2/{_xpath.EvomagTitlesXpath}/ComputerCaseTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-carcase/filtru/pagina:3/{_xpath.EvomagTitlesXpath}/ComputerCaseTable/Evomag/https://www.evomag.ro");


            FillColumn("ComputerCaseTable", "Carcasa", "PCGarage",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/carcase/pagina1/{_xpath.PCGarageTitlesXpath}/ComputerCaseTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/carcase/pagina2/{_xpath.PCGarageTitlesXpath}/ComputerCaseTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/carcase/pagina3/{_xpath.PCGarageTitlesXpath}/ComputerCaseTable/PCGarage/");


            FillColumn("ComputerCaseTable", "Carcasa", "CelRO",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/carcase/0a-1/{_xpath.CelROTitlesXpath}/ComputerCaseTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/carcase/0a-2/{_xpath.CelROTitlesXpath}/ComputerCaseTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/carcase/0a-3/{_xpath.CelROTitlesXpath}/ComputerCaseTable/CelRO/");

            FillColumn("ComputerCaseTable", "Carcasa", "ForIT",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/carcase/pagina1/{_xpath.ForITTitlesXpath}/ComputerCaseTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/carcase/pagina2/{_xpath.ForITTitlesXpath}/ComputerCaseTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/carcase/pagina3/{_xpath.ForITTitlesXpath}/ComputerCaseTable/ForIT/");

            FillColumn("ComputerCaseTable", "Carcasa", "Vexio",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/carcase-pc/pagina1/{_xpath.VexioTitlesXpath}/ComputerCaseTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/carcase-pc/pagina2/{_xpath.VexioTitlesXpath}/ComputerCaseTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/carcase-pc/pagina3/{_xpath.VexioTitlesXpath}/ComputerCaseTable/Vexio/");

            FillColumn("ComputerCaseTable", "Carcasa", "Ipon",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/carcasa/356?page=1/{_xpath.IponTitlesXpath}/ComputerCaseTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/carcasa/356?page=2/{_xpath.IponTitlesXpath}/ComputerCaseTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/carcasa/356?page=3/{_xpath.IponTitlesXpath}/ComputerCaseTable/Ipon/");

        }

        public void FillPowerSupplyTable()
        {
            FillColumn("PowerSupplyTable", "Sursa", "Emag",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/surse-pc/p1/c/{_xpath.EmagTitlesXpath}/PowerSupplyTable/Emag/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/surse-pc/p2/c/{_xpath.EmagTitlesXpath}/PowerSupplyTable/Emag/", null);

            FillColumn("PowerSupplyTable", "Sursa", "Evomag",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-surse/filtru/pagina:1/{_xpath.EvomagTitlesXpath}/PowerSupplyTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-surse/filtru/pagina:2/{_xpath.EvomagTitlesXpath}/PowerSupplyTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-surse/filtru/pagina:3/{_xpath.EvomagTitlesXpath}/PowerSupplyTable/Evomag/https://www.evomag.ro");


            FillColumn("PowerSupplyTable", "Sursa", "PCGarage",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/surse/pagina1/{_xpath.PCGarageTitlesXpath}/PowerSupplyTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/surse/pagina2/{_xpath.PCGarageTitlesXpath}/PowerSupplyTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/surse/pagina3/{_xpath.PCGarageTitlesXpath}/PowerSupplyTable/PCGarage/");


            FillColumn("PowerSupplyTable", "Sursa", "CelRO",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/surse/0a-1/{_xpath.CelROTitlesXpath}/PowerSupplyTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/surse/0a-2/{_xpath.CelROTitlesXpath}/PowerSupplyTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/surse/0a-3/{_xpath.CelROTitlesXpath}/PowerSupplyTable/CelRO/");

            FillColumn("PowerSupplyTable", "Sursa", "ForIT",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/surse/pagina1/{_xpath.ForITTitlesXpath}/PowerSupplyTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/surse/pagina2/{_xpath.ForITTitlesXpath}/PowerSupplyTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/surse/pagina3/{_xpath.ForITTitlesXpath}/PowerSupplyTable/ForIT/");

            FillColumn("PowerSupplyTable", "Sursa", "Vexio",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/surse/pagina1/{_xpath.VexioTitlesXpath}/PowerSupplyTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/surse/pagina2/{_xpath.VexioTitlesXpath}/PowerSupplyTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/surse/pagina3/{_xpath.VexioTitlesXpath}/PowerSupplyTable/Vexio/");

            FillColumn("PowerSupplyTable", "Sursa", "Ipon",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/sursa-de-alimentare/449?page=1/{_xpath.IponTitlesXpath}/PowerSupplyTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/sursa-de-alimentare/449?page=2/{_xpath.IponTitlesXpath}/PowerSupplyTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/sursa-de-alimentare/449?page=3/{_xpath.IponTitlesXpath}/PowerSupplyTable/Ipon/");

        }

        public void FillSSDTable()
        {
            FillColumn("SSDTable", "Solid", "Emag",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/solid-state_drive_ssd_/p1/c/{_xpath.EmagTitlesXpath}/SSDTable/Emag/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/solid-state_drive_ssd_/p2/c/{_xpath.EmagTitlesXpath}/SSDTable/Emag/", null);

            FillColumn("SSDTable", "SSD", "Evomag",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-solid-state-drive-ssd/filtru/pagina:1/{_xpath.EvomagTitlesXpath}/SSDTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-solid-state-drive-ssd/filtru/pagina:2/{_xpath.EvomagTitlesXpath}/SSDTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-solid-state-drive-ssd/filtru/pagina:3/{_xpath.EvomagTitlesXpath}/SSDTable/Evomag/https://www.evomag.ro");


            FillColumn("SSDTable", "SSD", "PCGarage",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/ssd/pagina1/{_xpath.PCGarageTitlesXpath}/SSDTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/ssd/pagina2/{_xpath.PCGarageTitlesXpath}/SSDTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/ssd/pagina3/{_xpath.PCGarageTitlesXpath}/SSDTable/PCGarage/");


            FillColumn("SSDTable", "SSD", "CelRO",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/ssd-uri/0a-1/{_xpath.CelROTitlesXpath}/SSDTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/ssd-uri/0a-2/{_xpath.CelROTitlesXpath}/SSDTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/ssd-uri/0a-3/{_xpath.CelROTitlesXpath}/SSDTable/CelRO/");

            FillColumn("SSDTable", "SSD", "ForIT",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/ssd-uri/pagina1/{_xpath.ForITTitlesXpath}/SSDTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/ssd-uri/pagina2/{_xpath.ForITTitlesXpath}/SSDTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/ssd-uri/pagina3/{_xpath.ForITTitlesXpath}/SSDTable/ForIT/");

            FillColumn("SSDTable", "SSD", "Vexio",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/ssd-uri/pagina1/{_xpath.VexioTitlesXpath}/SSDTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/ssd-uri/pagina2/{_xpath.VexioTitlesXpath}/SSDTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/ssd-uri/pagina3/{_xpath.VexioTitlesXpath}/SSDTable/Vexio/");

            FillColumn("SSDTable", "Solid", "Ipon",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/ssd-intern/4055?page=1/{_xpath.IponTitlesXpath}/SSDTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/ssd-intern/4055?page=2/{_xpath.IponTitlesXpath}/SSDTable/Ipon/",
              $"https://localhost:7210/api/GetAdsTitles/https://ipon.ro/shop/grup/componente-pc/ssd-intern/4055?page=3/{_xpath.IponTitlesXpath}/SSDTable/Ipon/");

        }

        public void FillHDDTable()
        {
            FillColumn("HDDTable", "HDD", "Emag",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/hard_disk-uri/p1/c/{_xpath.EmagTitlesXpath}/HDDTable/Emag/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.emag.ro/hard_disk-uri/p2/c/{_xpath.EmagTitlesXpath}/HDDTable/Emag/", null);

            FillColumn("HDDTable", "HDD", "Evomag",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-hard-disk-drive-hard-disk-uri-hdd-desktop/filtru/pagina:1/{_xpath.EvomagTitlesXpath}/HDDTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-hard-disk-drive-hard-disk-uri-hdd-desktop/filtru/pagina:2/{_xpath.EvomagTitlesXpath}/HDDTable/Evomag/https://www.evomag.ro",
              $"https://localhost:7210/api/GetAdsTitles/https://www.evomag.ro/componente-pc-gaming-hard-disk-drive-hard-disk-uri-hdd-desktop/filtru/pagina:3/{_xpath.EvomagTitlesXpath}/HDDTable/Evomag/https://www.evomag.ro");


            FillColumn("HDDTable", "Hard", "PCGarage",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/hard-disk-uri/pagina1/{_xpath.PCGarageTitlesXpath}/HDDTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/hard-disk-uri/pagina2/{_xpath.PCGarageTitlesXpath}/HDDTable/PCGarage/",
                $"https://localhost:7210/api/GetAdsTitles/https://www.pcgarage.ro/hard-disk-uri/pagina3/{_xpath.PCGarageTitlesXpath}/HDDTable/PCGarage/");


            FillColumn("HDDTable", "Hard", "CelRO",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/hard-disk-uri/0a-1/{_xpath.CelROTitlesXpath}/HDDTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/hard-disk-uri/0a-2/{_xpath.CelROTitlesXpath}/HDDTable/CelRO/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.cel.ro/hard-disk-uri/0a-3/{_xpath.CelROTitlesXpath}/HDDTable/CelRO/");

            FillColumn("HDDTable", "Hard", "ForIT",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/hard-disk-uri/pagina1/{_xpath.ForITTitlesXpath}/HDDTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/hard-disk-uri/pagina2/{_xpath.ForITTitlesXpath}/HDDTable/ForIT/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.forit.ro/hard-disk-uri/pagina3/{_xpath.ForITTitlesXpath}/HDDTable/ForIT/");

            FillColumn("HDDTable", "Hard", "Vexio",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/hard-disk-uri/pagina1/{_xpath.VexioTitlesXpath}/HDDTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/hard-disk-uri/pagina2/{_xpath.VexioTitlesXpath}/HDDTable/Vexio/",
               $"https://localhost:7210/api/GetAdsTitles/https://www.vexio.ro/hard-disk-uri/pagina3/{_xpath.VexioTitlesXpath}/HDDTable/Vexio/");

        }

        private void FillColumn(string tableName, string columnName, string websiteName, string firstUrl, string secondUrl, string? thirdUrl)
        {
            if (String.IsNullOrEmpty(CheckForExistingAds(tableName, columnName, websiteName)))
            {
                client.OpenRead(firstUrl);

                Thread.Sleep(1000);

                client.OpenRead(secondUrl);

                if (thirdUrl is not null)
                {
                    Thread.Sleep(1000);

                    client.OpenRead(thirdUrl);
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

    }
}
