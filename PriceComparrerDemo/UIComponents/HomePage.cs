using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using PriceComparrerWinforms.src;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace PriceComparrerDemo
{
    public partial class HomePage : UserControl
    {
        private readonly WebClient client = new();
        private readonly AdsModel _ads = new();
        private readonly SqlConnection connection = new SqlConnection(Data.ConnectionString);

        public HomePage()
        {
            InitializeComponent();
            searchBox.KeyDown += SearchBox_KeyDown;
            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
            searchBox.GotFocus += SearchBox_GotFocus;
        }

        private void SearchBox_GotFocus(object? sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox1.ForeColor = Color.Black;
            richTextBox1.Clear();
        }

        private void RichTextBox1_LinkClicked(object? sender, LinkClickedEventArgs e)
        {
            ProcessStartInfo processInfo = new()
            {
                FileName = e.LinkText,
                UseShellExecute = true
            };

            Process.Start(processInfo);


        }

        private void SearchBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                #region SearchEngine

                searchingLbl.Show();

                if (searchLbl.Text.Contains("Processor"))
                {
                    string[] searchItem = searchBox.Text.Split(' ');

                    switch (searchItem.Length)
                    {
                        case 1:

                            DisplayResults($"https://localhost:7210/api/ReadProcessorsPrices/{SearchQuerries.ReadComponentModelOneSearchItem("ProcessorTable", "Emag", searchItem[0])}");

                            searchLbl.Hide();

                            break;

                        case 2:

                            DisplayResults($"https://localhost:7210/api/ReadProcessorsPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("ProcessorTable", "Emag", searchItem[0], searchItem[1])}");

                            searchingLbl.Hide();

                            break;

                        case >= 3:

                            DisplayResults($"https://localhost:7210/api/ReadProcessorsPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("ProcessorTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                            searchingLbl.Hide();

                            break;

                    }

                }

                else if (searchLbl.Text.Contains("Video Card"))
                {
                    string[] searchItem = searchBox.Text.Split(' ');

                    switch (searchItem.Length)
                    {
                        case 1:

                            DisplayResults($"https://localhost:7210/api/ReadVideoCardsPrices/{SearchQuerries.ReadComponentModelOneSearchItem("VideoCardTable", "Emag", searchItem[0])}");

                            searchLbl.Hide();

                            break;

                        case 2:

                            DisplayResults($"https://localhost:7210/api/ReadVideoCardsPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("VideoCardTable", "Emag", searchItem[0], searchItem[1])}");

                            searchingLbl.Hide();

                            break;

                        case >= 3:

                            DisplayResults($"https://localhost:7210/api/ReadVideoCardsPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("VideoCardTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                            searchingLbl.Hide();

                            break;

                    }


                }

                else if (searchLbl.Text.Contains("Motherboard"))
                {

                    string[] searchItem = searchBox.Text.Split(' ');

                    switch (searchItem.Length)
                    {
                        case 1:

                            DisplayResults($"https://localhost:7210/api/ReadMotherboardsPrices/{SearchQuerries.ReadComponentModelOneSearchItem("MotherboardTable", "Emag", searchItem[0])}");

                            searchLbl.Hide();

                            break;

                        case 2:

                            DisplayResults($"https://localhost:7210/api/ReadMotherboardsPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("MotherboardTable", "Emag", searchItem[0], searchItem[1])}");

                            searchingLbl.Hide();

                            break;

                        case 3:

                            DisplayResults($"https://localhost:7210/api/ReadMotherboardsPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("MotherboardTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                            searchingLbl.Hide();

                            break;

                        case >= 4:

                            DisplayResults($"https://localhost:7210/api/ReadMotherboardsPrices/{SearchQuerries.ReadComponentModelFourSearchItems("MotherboardTable", "Emag", searchItem[0], searchItem[1], searchItem[2], searchItem[3])}");

                            searchingLbl.Hide();

                            break;

                    }

                }
                else if (searchLbl.Text.Contains("Ram Memory"))
                {
                    string[] searchItem = searchBox.Text.Split(' ');

                    switch (searchItem.Length)
                    {
                        case 1:

                            DisplayResults($"https://localhost:7210/api/ReadRamMemoryPrices/{SearchQuerries.ReadComponentModelOneSearchItem("RamMemoryTable", "Emag", searchItem[0])}");

                            searchLbl.Hide();

                            break;

                        case 2:

                            DisplayResults($"https://localhost:7210/api/ReadRamMemoryPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("RamMemoryTable", "Emag", searchItem[0], searchItem[1])}");

                            searchingLbl.Hide();

                            break;

                        case 3:

                            DisplayResults($"https://localhost:7210/api/ReadRamMemoryPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("RamMemoryTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                            searchingLbl.Hide();

                            break;

                        case >= 4:

                            DisplayResults($"https://localhost:7210/api/ReadRamMemoryPrices/{SearchQuerries.ReadComponentModelFourSearchItems("RamMemoryTable", "Emag", searchItem[0], searchItem[1], searchItem[2], searchItem[3])}");

                            searchingLbl.Hide();

                            break;

                    }

                }

                else if (searchLbl.Text.Contains("Power Supply"))
                {
                    string[] searchItem = searchBox.Text.Split(' ');

                    switch (searchItem.Length)
                    {
                        case 1:

                            DisplayResults($"https://localhost:7210/api/ReadPowerSupplyPrices/{SearchQuerries.ReadComponentModelOneSearchItem("PowerSupplyTable", "Emag", searchItem[0])}");

                            searchLbl.Hide();

                            break;

                        case 2:

                            DisplayResults($"https://localhost:7210/api/ReadPowerSupplyPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("PowerSupplyTable", "Emag", searchItem[0], searchItem[1])}");

                            searchingLbl.Hide();

                            break;

                        case 3:

                            DisplayResults($"https://localhost:7210/api/ReadPowerSupplyPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("PowerSupplyTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                            searchingLbl.Hide();

                            break;
                    }

                }
                else if (searchLbl.Text.Contains("Cooler"))
                {
                    string[] searchItem = searchBox.Text.Split(' ');

                    switch (searchItem.Length)
                    {
                        case 1:

                            DisplayResults($"https://localhost:7210/api/CoolerPrices/{SearchQuerries.ReadComponentModelOneSearchItem("CoolerTable", "Emag", searchItem[0])}");

                            searchLbl.Hide();

                            break;

                        case 2:

                            DisplayResults($"https://localhost:7210/api/CoolerPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("CoolerTable", "Emag", searchItem[0], searchItem[1])}");

                            searchingLbl.Hide();

                            break;

                        case 3:

                            DisplayResults($"https://localhost:7210/api/CoolerPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("CoolerTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                            searchingLbl.Hide();

                            break;
                    }

                }
                else if (searchLbl.Text.Contains("Computer Case"))
                {
                    string[] searchItem = searchBox.Text.Split(' ');

                    switch (searchItem.Length)
                    {
                        case 1:

                            DisplayResults($"https://localhost:7210/api/ComputerCasePrices/{SearchQuerries.ReadComponentModelOneSearchItem("ComputerCaseTable", "Emag", searchItem[0])}");

                            searchLbl.Hide();

                            break;

                        case 2:

                            DisplayResults($"https://localhost:7210/api/ComputerCasePrices/{SearchQuerries.ReadComponentModelTwoSearchItems("ComputerCaseTable", "Emag", searchItem[0], searchItem[1])}");

                            searchingLbl.Hide();

                            break;

                        case 3:

                            DisplayResults($"https://localhost:7210/api/ComputerCasePrices/{SearchQuerries.ReadComponentModelThreeSearchItems("ComputerCaseTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                            searchingLbl.Hide();

                            break;
                    }

                }
                else if (searchLbl.Text.Contains("SSD"))
                {

                    string[] searchItem = searchBox.Text.Split(' ');

                    switch (searchItem.Length)
                    {
                        case 1:

                            DisplayResults($"https://localhost:7210/api/ReadSSDPrices/{SearchQuerries.ReadComponentModelOneSearchItem("SSDTable", "Emag", searchItem[0])}");

                            searchLbl.Hide();

                            break;

                        case 2:

                            DisplayResults($"https://localhost:7210/api/ReadSSDPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("SSDTable", "Emag", searchItem[0], searchItem[1])}");

                            searchingLbl.Hide();

                            break;

                        case 3:

                            DisplayResults($"https://localhost:7210/api/ReadSSDPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("SSDTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                            searchingLbl.Hide();

                            break;
                    }

                }

                else if (searchLbl.Text.Contains("HDD"))
                {
                    string[] searchItem = searchBox.Text.Split(' ');

                    switch (searchItem.Length)
                    {
                        case 1:

                            DisplayResults($"https://localhost:7210/api/ReadHDDPrices/{SearchQuerries.ReadComponentModelOneSearchItem("HDDTable", "Emag", searchItem[0])}");

                            searchLbl.Hide();

                            break;

                        case 2:

                            DisplayResults($"https://localhost:7210/api/ReadHDDPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("HDDTable", "Emag", searchItem[0], searchItem[1])}");

                            searchingLbl.Hide();

                            break;

                        case 3:

                            DisplayResults($"https://localhost:7210/api/ReadHDDPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("HDDTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                            searchingLbl.Hide();

                            break;
                    }

                }

                #endregion




            }
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            searchingLbl.Show();

            if (String.IsNullOrEmpty(searchBox.Text))
            {
                MessageBox.Show("value Cannot be null ");

                return;
            }

            #region SearchEngine

            if (searchLbl.Text.Contains("Processor"))
            {
                string[]  searchItem = searchBox.Text.Split(' ');

                switch (searchItem.Length)
                {
                    case 1:

                        DisplayResults($"https://localhost:7210/api/ReadProcessorsPrices/{SearchQuerries.ReadComponentModelOneSearchItem("ProcessorTable", "Emag", searchItem[0])}");

                        searchLbl.Hide();

                        break;

                    case 2:

                        DisplayResults($"https://localhost:7210/api/ReadProcessorsPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("ProcessorTable", "Emag", searchItem[0], searchItem[1])}");

                        searchingLbl.Hide();

                        break;

                    case >=3:

                        DisplayResults($"https://localhost:7210/api/ReadProcessorsPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("ProcessorTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                        searchingLbl.Hide();

                        break;

                }

            }

            else if (searchLbl.Text.Contains("Video Card"))
            {
                string[] searchItem = searchBox.Text.Split(' ');

                switch (searchItem.Length)
                {
                    case 1:

                        DisplayResults($"https://localhost:7210/api/ReadVideoCardsPrices/{SearchQuerries.ReadComponentModelOneSearchItem("VideoCardTable", "Emag", searchItem[0])}");

                        searchLbl.Hide();

                        break;

                    case 2:

                        DisplayResults($"https://localhost:7210/api/ReadVideoCardsPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("VideoCardTable", "Emag", searchItem[0], searchItem[1])}");

                        searchingLbl.Hide();

                        break;

                    case >= 3:

                        DisplayResults($"https://localhost:7210/api/ReadVideoCardsPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("VideoCardTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                        searchingLbl.Hide();

                        break;

                }


            }

            else if (searchLbl.Text.Contains("Motherboard"))
            {

                string[] searchItem = searchBox.Text.Split(' ');

                switch (searchItem.Length)
                {
                    case 1:

                        DisplayResults($"https://localhost:7210/api/ReadMotherboardsPrices/{SearchQuerries.ReadComponentModelOneSearchItem("MotherboardTable", "Emag", searchItem[0])}");

                        searchLbl.Hide();

                        break;

                    case 2:

                        DisplayResults($"https://localhost:7210/api/ReadMotherboardsPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("MotherboardTable", "Emag", searchItem[0], searchItem[1])}");

                        searchingLbl.Hide();

                        break;

                    case 3:

                        DisplayResults($"https://localhost:7210/api/ReadMotherboardsPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("MotherboardTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                        searchingLbl.Hide();

                        break;

                    case >= 4:

                        DisplayResults($"https://localhost:7210/api/ReadMotherboardsPrices/{SearchQuerries.ReadComponentModelFourSearchItems("MotherboardTable", "Emag", searchItem[0], searchItem[1], searchItem[2], searchItem[3])}");

                        searchingLbl.Hide();

                        break;

                }

            }
            else if (searchLbl.Text.Contains("Ram Memory"))
            {
                string[] searchItem = searchBox.Text.Split(' ');

                switch (searchItem.Length)
                {
                    case 1:

                        DisplayResults($"https://localhost:7210/api/ReadRamMemoryPrices/{SearchQuerries.ReadComponentModelOneSearchItem("RamMemoryTable", "Emag", searchItem[0])}");

                        searchLbl.Hide();

                        break;

                    case 2:

                        DisplayResults($"https://localhost:7210/api/ReadRamMemoryPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("RamMemoryTable", "Emag", searchItem[0], searchItem[1])}");

                        searchingLbl.Hide();

                        break;

                    case 3:

                        DisplayResults($"https://localhost:7210/api/ReadRamMemoryPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("RamMemoryTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                        searchingLbl.Hide();

                        break;

                    case >= 4:

                        DisplayResults($"https://localhost:7210/api/ReadRamMemoryPrices/{SearchQuerries.ReadComponentModelFourSearchItems("RamMemoryTable", "Emag", searchItem[0], searchItem[1], searchItem[2], searchItem[3])}");

                        searchingLbl.Hide();

                        break;

                }

            }

            else if (searchLbl.Text.Contains("Power Supply"))
            {
                string[] searchItem = searchBox.Text.Split(' ');

                switch (searchItem.Length)
                {
                    case 1:

                        DisplayResults($"https://localhost:7210/api/ReadPowerSupplyPrices/{SearchQuerries.ReadComponentModelOneSearchItem("PowerSupplyTable", "Emag", searchItem[0])}");

                        searchLbl.Hide();

                        break;

                    case 2:

                        DisplayResults($"https://localhost:7210/api/ReadPowerSupplyPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("PowerSupplyTable", "Emag", searchItem[0], searchItem[1])}");

                        searchingLbl.Hide();

                        break;

                    case 3:

                        DisplayResults($"https://localhost:7210/api/ReadPowerSupplyPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("PowerSupplyTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                        searchingLbl.Hide();

                        break;
                }

            }
            else if (searchLbl.Text.Contains("Cooler"))
            {
                string[] searchItem = searchBox.Text.Split(' ');

                switch (searchItem.Length)
                {
                    case 1:

                        DisplayResults($"https://localhost:7210/api/CoolerPrices/{SearchQuerries.ReadComponentModelOneSearchItem("CoolerTable", "Emag", searchItem[0])}");

                        searchLbl.Hide();

                        break;

                    case 2:

                        DisplayResults($"https://localhost:7210/api/CoolerPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("CoolerTable", "Emag", searchItem[0], searchItem[1])}");

                        searchingLbl.Hide();

                        break;

                    case 3:

                        DisplayResults($"https://localhost:7210/api/CoolerPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("CoolerTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                        searchingLbl.Hide();

                        break;
                }

            }
            else if (searchLbl.Text.Contains("Computer Case"))
            {
                string[] searchItem = searchBox.Text.Split(' ');

                switch (searchItem.Length)
                {
                    case 1:

                        DisplayResults($"https://localhost:7210/api/ComputerCasePrices/{SearchQuerries.ReadComponentModelOneSearchItem("ComputerCaseTable", "Emag", searchItem[0])}");

                        searchLbl.Hide();

                        break;

                    case 2:

                        DisplayResults($"https://localhost:7210/api/ComputerCasePrices/{SearchQuerries.ReadComponentModelTwoSearchItems("ComputerCaseTable", "Emag", searchItem[0], searchItem[1])}");

                        searchingLbl.Hide();

                        break;

                    case 3:

                        DisplayResults($"https://localhost:7210/api/ComputerCasePrices/{SearchQuerries.ReadComponentModelThreeSearchItems("ComputerCaseTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                        searchingLbl.Hide();

                        break;
                }

            }
            else if (searchLbl.Text.Contains("SSD"))
            {

                string[] searchItem = searchBox.Text.Split(' ');

                switch (searchItem.Length)
                {
                    case 1:

                        DisplayResults($"https://localhost:7210/api/ReadSSDPrices/{SearchQuerries.ReadComponentModelOneSearchItem("SSDTable", "Emag", searchItem[0])}");

                        searchLbl.Hide();

                        break;

                    case 2:

                        DisplayResults($"https://localhost:7210/api/ReadSSDPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("SSDTable", "Emag", searchItem[0], searchItem[1])}");

                        searchingLbl.Hide();

                        break;

                    case 3:

                        DisplayResults($"https://localhost:7210/api/ReadSSDPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("SSDTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                        searchingLbl.Hide();

                        break;
                }

            }

            else if (searchLbl.Text.Contains("HDD"))
            {
                string[] searchItem = searchBox.Text.Split(' ');

                switch (searchItem.Length)
                {
                    case 1:

                        DisplayResults($"https://localhost:7210/api/ReadHDDPrices/{SearchQuerries.ReadComponentModelOneSearchItem("HDDTable", "Emag", searchItem[0])}");

                        searchLbl.Hide();

                        break;

                    case 2:

                        DisplayResults($"https://localhost:7210/api/ReadHDDPrices/{SearchQuerries.ReadComponentModelTwoSearchItems("HDDTable", "Emag", searchItem[0], searchItem[1])}");

                        searchingLbl.Hide();

                        break;

                    case 3:

                        DisplayResults($"https://localhost:7210/api/ReadHDDPrices/{SearchQuerries.ReadComponentModelThreeSearchItems("HDDTable", "Emag", searchItem[0], searchItem[1], searchItem[2])}");

                        searchingLbl.Hide();

                        break;
                }

            }

            #endregion

        }


        #region MainButtons

        private void processorBtnTab_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CheckForExistingAds("ProcessorTable", "Procesor", "Emag")))
            {
                client.OpenRead($"https://localhost:7210/api/Processors/1");
            }

            #region HideElements
            searchLbl.Hide();
            processorBtnTab.Hide();
            videoCardsBtnTab.Hide();
            motherboardBtnTab.Hide();
            ramBtnTab.Hide();
            powerSupplyBtnTab.Hide();
            coolerBtnTab.Hide();
            caseBtnTab.Hide();
            ssdBtnTab.Hide();
            hddBtnTab.Hide();
            ssdBtnTab.Hide();
            chooseComponentLbl.Hide();
            searchBox.Show();
            searchBtn.Show();
            searchLbl.Show();
            searchLbl.Text = "Search Processor Model";
            homeBtn.Show();
            richTextBox1.Show();
            componentNameLbl.Show();
            #endregion

        }

        private void videoCardsBtnTab_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CheckForExistingAds("VideoCardTable", "Placa", "Emag")))
            {
                client.OpenRead($"https://localhost:7210/api/VideoCards/1");
            }

            #region HideElements
            searchLbl.Hide();
            processorBtnTab.Hide();
            videoCardsBtnTab.Hide();
            motherboardBtnTab.Hide();
            ramBtnTab.Hide();
            powerSupplyBtnTab.Hide();
            coolerBtnTab.Hide();
            caseBtnTab.Hide();
            ssdBtnTab.Hide();
            hddBtnTab.Hide();
            ssdBtnTab.Hide();
            chooseComponentLbl.Hide();
            searchBox.Show();
            searchBtn.Show();
            searchLbl.Show();
            searchLbl.Text = "Search Video Card Model";
            homeBtn.Show();
            richTextBox1.Show();
            componentNameLbl.Show();
            componentPriceLbl.Show();
            #endregion


        }

        private void motherboardBtnTab_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CheckForExistingAds("MotherboardTable", "Placa de baza", "Emag")))
            {
                client.OpenRead($"https://localhost:7210/api/Motherboards/1");
            }

            #region HideElements
            searchLbl.Hide();
            processorBtnTab.Hide();
            videoCardsBtnTab.Hide();
            motherboardBtnTab.Hide();
            ramBtnTab.Hide();
            powerSupplyBtnTab.Hide();
            coolerBtnTab.Hide();
            caseBtnTab.Hide();
            ssdBtnTab.Hide();
            hddBtnTab.Hide();
            ssdBtnTab.Hide();
            chooseComponentLbl.Hide();
            searchBox.Show();
            searchBtn.Show();
            searchLbl.Show();
            searchLbl.Text = "Search Motherboard Model";
            homeBtn.Show();
            richTextBox1.Show();
            componentNameLbl.Show();
            componentPriceLbl.Show();
            #endregion

        }

        private void ramBtnTab_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(CheckForExistingAds("RamMemoryTable", "Memorie Ram", "Emag")))
            {
                client.OpenRead($"https://localhost:7210/api/RamMemory/1");
            }

            #region HideElements
            searchLbl.Hide();
            processorBtnTab.Hide();
            videoCardsBtnTab.Hide();
            motherboardBtnTab.Hide();
            ramBtnTab.Hide();
            powerSupplyBtnTab.Hide();
            coolerBtnTab.Hide();
            caseBtnTab.Hide();
            ssdBtnTab.Hide();
            hddBtnTab.Hide();
            ssdBtnTab.Hide();
            chooseComponentLbl.Hide();
            searchBox.Show();
            searchBtn.Show();
            searchLbl.Show();
            searchLbl.Text = "Search Ram Memory Model";
            homeBtn.Show();
            richTextBox1.Show();
            componentNameLbl.Show();
            componentPriceLbl.Show();
            #endregion

        }

        private void powerSupplyBtnTab_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CheckForExistingAds("PowerSupplyTable", "Sursa", "Emag")))
            {
                client.OpenRead($"https://localhost:7210/api/PowerSupply/1");
            }

            #region HideElements
            searchLbl.Hide();
            processorBtnTab.Hide();
            videoCardsBtnTab.Hide();
            motherboardBtnTab.Hide();
            ramBtnTab.Hide();
            powerSupplyBtnTab.Hide();
            coolerBtnTab.Hide();
            caseBtnTab.Hide();
            ssdBtnTab.Hide();
            hddBtnTab.Hide();
            ssdBtnTab.Hide();
            chooseComponentLbl.Hide();
            searchBox.Show();
            searchBtn.Show();
            searchLbl.Show();
            searchLbl.Text = "Search Power Supply Model";
            homeBtn.Show();
            richTextBox1.Show();
            componentNameLbl.Show();
            componentPriceLbl.Show();
            #endregion

        }

        private void coolerBtnTab_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(CheckForExistingAds("CoolerTable", "Cooler", "Emag")))
            {
                client.OpenRead($"https://localhost:7210/api/Cooler/1");
            }


            #region HideElements
            searchLbl.Hide();
            processorBtnTab.Hide();
            videoCardsBtnTab.Hide();
            motherboardBtnTab.Hide();
            ramBtnTab.Hide();
            powerSupplyBtnTab.Hide();
            coolerBtnTab.Hide();
            caseBtnTab.Hide();
            ssdBtnTab.Hide();
            hddBtnTab.Hide();
            ssdBtnTab.Hide();
            chooseComponentLbl.Hide();
            searchBox.Show();
            searchBtn.Show();
            searchLbl.Show();
            searchLbl.Text = "Search Cooler Model";
            homeBtn.Show();
            richTextBox1.Show();
            componentNameLbl.Show();
            componentPriceLbl.Show();
            #endregion

        }

        private void caseBtnTab_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(CheckForExistingAds("ComputerCaseTable", "Carcasa", "Emag")))
            {
                client.OpenRead($"https://localhost:7210/api/ComputerCase/1");
            }


            #region HideElements
            searchLbl.Hide();
            processorBtnTab.Hide();
            videoCardsBtnTab.Hide();
            motherboardBtnTab.Hide();
            ramBtnTab.Hide();
            powerSupplyBtnTab.Hide();
            coolerBtnTab.Hide();
            caseBtnTab.Hide();
            ssdBtnTab.Hide();
            hddBtnTab.Hide();
            ssdBtnTab.Hide();
            chooseComponentLbl.Hide();
            searchBox.Show();
            searchBtn.Show();
            searchLbl.Show();
            searchLbl.Text = "Search Computer Case Model";
            homeBtn.Show();
            richTextBox1.Show();
            componentNameLbl.Show();
            componentPriceLbl.Show();
            #endregion

        }

        private void ssdBtnTab_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(CheckForExistingAds("SSDTable", "Solid State Drive", "Emag")))
            {
                client.OpenRead($"https://localhost:7210/api/SSD/1");
            }

            #region HideElements
            searchLbl.Hide();
            processorBtnTab.Hide();
            videoCardsBtnTab.Hide();
            motherboardBtnTab.Hide();
            ramBtnTab.Hide();
            powerSupplyBtnTab.Hide();
            coolerBtnTab.Hide();
            caseBtnTab.Hide();
            ssdBtnTab.Hide();
            hddBtnTab.Hide();
            ssdBtnTab.Hide();
            chooseComponentLbl.Hide();
            searchBox.Show();
            searchBtn.Show();
            searchLbl.Show();
            searchLbl.Text = "Search SSD Model";
            homeBtn.Show();
            richTextBox1.Show();
            componentNameLbl.Show();
            componentPriceLbl.Show();
            #endregion

        }

        private void hddBtnTab_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(CheckForExistingAds("HDDTable", "HDD", "Emag")))
            {
                client.OpenRead($"https://localhost:7210/api/HDD/1");
            }

            #region HideElements
            searchLbl.Hide();
            processorBtnTab.Hide();
            videoCardsBtnTab.Hide();
            motherboardBtnTab.Hide();
            ramBtnTab.Hide();
            powerSupplyBtnTab.Hide();
            coolerBtnTab.Hide();
            caseBtnTab.Hide();
            ssdBtnTab.Hide();
            hddBtnTab.Hide();
            ssdBtnTab.Hide();
            chooseComponentLbl.Hide();
            searchBox.Show();
            searchBtn.Show();
            searchLbl.Show();
            searchLbl.Text = "Search HDD Model";
            homeBtn.Show();
            richTextBox1.Show();
            componentNameLbl.Show();
            componentPriceLbl.Show();
            #endregion

        }





        #endregion

        private void HomePage_Load(object sender, EventArgs e)
        {
            searchBox.Hide();
            searchBtn.Hide();
            searchLbl.Hide();
            homeBtn.Hide();
            richTextBox1.Hide();
            componentNameLbl.Hide();
            searchingLbl.Hide();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            #region ShowElements
            searchLbl.Hide();
            processorBtnTab.Show();
            videoCardsBtnTab.Show();
            motherboardBtnTab.Show();
            ramBtnTab.Show();
            powerSupplyBtnTab.Show();
            coolerBtnTab.Show();
            caseBtnTab.Show();
            ssdBtnTab.Show();
            hddBtnTab.Show();
            ssdBtnTab.Show();
            chooseComponentLbl.Show();
            searchBox.Hide();
            searchBtn.Hide();
            searchLbl.Hide();
            homeBtn.Show();
            homeBtn.Hide();
            richTextBox1.Show();
            componentNameLbl.Show();
            richTextBox1.Hide();
            componentNameLbl.Hide();
            componentPriceLbl.Hide();
            searchBox.Clear();
            richTextBox1.Clear();
            searchLbl.Text = string.Empty;
            componentNameLbl.Text = string.Empty;
            componentPriceLbl.Text = string.Empty;
            #endregion


        }

        private string CheckForExistingAds(string tableName, string likeKeyword, string webSiteName)
        {
            connection.Open();

            var readProcessorDataCommand = new SqlCommand(Data.ReadExistingComponentData(tableName, likeKeyword, webSiteName), connection);

            var reader = readProcessorDataCommand.ExecuteReader();

            while (reader.Read())
            {
                _ads.AdTitle += reader.GetString(0);
            }

            connection.Close();

            return _ads.AdTitle;
        }

        private void DisplayResults(string apiURl)
        {
            Stream stream = client.OpenRead(apiURl);

            var reader = new StreamReader(stream);

            AdsModel _ads = JsonConvert.DeserializeObject<AdsModel>(reader.ReadToEnd());

            componentNameLbl.Text = _ads.AdTitle;
            componentPriceLbl.Text = _ads.AdPrice;
            richTextBox1.Text = _ads.AdHyperlink;

            if (String.IsNullOrEmpty(_ads.AdTitle) || String.IsNullOrEmpty(_ads.AdPrice) || String.IsNullOrEmpty(_ads.AdHyperlink))
            {

                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.Text = "No Result That Matches Your Search ,Please Be More Explicit.";

            }
        }

    }


}
