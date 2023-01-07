﻿using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using PriceComparrerWinforms.src;
using System.Diagnostics;
using System.Net;
using Unity;

namespace PriceComparrerDemo
{
    public partial class HomePage : UserControl
    {
        private readonly WebClient client = new();
        private readonly AdsModel _ads = new();
        private readonly SqlConnection connection = new(Data.ConnectionString);
        private readonly DataAdministration dataAdministration = new();
        public HomePage()
        {
            InitializeComponent();
            searchBox.KeyDown += SearchBox_KeyDown;
            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
            searchBox.GotFocus += SearchBox_GotFocus;

        }
        
        private void EvomagHypelinksBox_LinkClicked(object? sender, LinkClickedEventArgs e)
        {
            ProcessStartInfo processInfo = new()
            {
                FileName = e.LinkText,
                UseShellExecute = true
            };

            Process.Start(processInfo);

        }

        #region UIButtons
        private void HomePage_Load(object sender, EventArgs e)
        {
            searchBox.Hide();
            searchBtn.Hide();
            searchLbl.Hide();
            homeBtn.Hide();
            richTextBox1.Hide();
            componentNameLbl.Hide();
            searchingLbl.Hide();
            emagLbl.Hide();

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

        private void SearchBox_GotFocus(object? sender, EventArgs e)
        {
            if (richTextBox1.Text.Contains("No Result That Matches Your Search ,Please Be More Explicit."))
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                richTextBox1.ForeColor = Color.Black;
                richTextBox1.Clear();
            }

        }

        #endregion


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

                if (searchLbl.Text.Contains("Processor"))
                {
                    SearchProduct("Processor");

                }

                else if (searchLbl.Text.Contains("Video Card"))
                {
                    SearchProduct("VideoCard");

                }

                else if (searchLbl.Text.Contains("Motherboard"))
                {

                    SearchProduct("Motherboard");

                }
                else if (searchLbl.Text.Contains("Ram Memory"))
                {
                    SearchProduct("RamMemory");

                }

                else if (searchLbl.Text.Contains("Power Supply"))
                {
                    SearchProduct("PowerSupply");

                }
                else if (searchLbl.Text.Contains("Cooler"))
                {
                    SearchProduct("Cooler");

                }
                else if (searchLbl.Text.Contains("Computer Case"))
                {
                    SearchProduct("ComputerCase");

                }
                else if (searchLbl.Text.Contains("SSD"))
                {

                    SearchProduct("SSD");

                }

                else if (searchLbl.Text.Contains("HDD"))
                {
                    SearchProduct("HDD");

                }

                #endregion

            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
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
                SearchProduct("Processor");

            }

            else if (searchLbl.Text.Contains("Video Card"))
            {
                SearchProduct("VideoCard");

            }

            else if (searchLbl.Text.Contains("Motherboard"))
            {

                SearchProduct("Motherboard");

            }
            else if (searchLbl.Text.Contains("Ram Memory"))
            {
                SearchProduct("RamMemory");

            }

            else if (searchLbl.Text.Contains("Power Supply"))
            {
                SearchProduct("PowerSupply");

            }
            else if (searchLbl.Text.Contains("Cooler"))
            {
                SearchProduct("Cooler");

            }
            else if (searchLbl.Text.Contains("Computer Case"))
            {
                SearchProduct("ComputerCase");

            }
            else if (searchLbl.Text.Contains("SSD"))
            {

                SearchProduct("SSD");

            }

            else if (searchLbl.Text.Contains("HDD"))
            {
                SearchProduct("HDD");

            }

            #endregion

        }


        #region MainButtons

        private void processorBtnTab_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(CheckForExistingAds("ProcessorTable", "Procesor", "Emag")) || String.IsNullOrEmpty(CheckForExistingAds("ProcessorTable", "Procesor", "Evomag")))
            //{
            //    client.OpenRead("https://localhost:7210/api/EmagProcessors/1");

            //    Thread.Sleep(3000);

            //    client.OpenRead("https://localhost:7210/api/EvomagProcessors/1");

            //}

            dataAdministration.FillProcessorTable();

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
            componentNameLbl.Show();
            #endregion

        }

        private void videoCardsBtnTab_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(CheckForExistingAds("VideoCardTable", "Placa", "Emag")))
            //{
            //    client.OpenRead($"https://localhost:7210/api/EmagVideoCards/1");
            //}

            dataAdministration.FillVideoCardTable();

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
            //if (String.IsNullOrEmpty(CheckForExistingAds("MotherboardTable", "Placa de baza", "Emag")))
            //{
            //    client.OpenRead($"https://localhost:7210/api/EmagMotherboards/1");
            //}

            dataAdministration.FillMotherboardTable();

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
            //if (String.IsNullOrEmpty(CheckForExistingAds("RamMemoryTable", "Memorie Ram", "Emag")))
            //{
            //    client.OpenRead($"https://localhost:7210/api/EmagRamMemory/1");
            //}

            dataAdministration.FillRamMemoryTable();

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
            //if (String.IsNullOrEmpty(CheckForExistingAds("PowerSupplyTable", "Sursa", "Emag")))
            //{
            //    client.OpenRead($"https://localhost:7210/api/EmagPowerSupply/1");
            //}

            dataAdministration.FillPowerSupplyTable();

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

            //if (String.IsNullOrEmpty(CheckForExistingAds("CoolerTable", "Cooler", "Emag")))
            //{
            //    client.OpenRead($"https://localhost:7210/api/EmagCooler/1");
            //}
            dataAdministration.FillCoolerTable();


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
            //if (String.IsNullOrEmpty(CheckForExistingAds("ComputerCaseTable", "Carcasa", "Emag")))
            //{
            //    client.OpenRead($"https://localhost:7210/api/EmagComputerCase/1");
            //}

            dataAdministration.FillComputerCaseTable();


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
            //if (String.IsNullOrEmpty(CheckForExistingAds("SSDTable", "Solid State Drive", "Emag")))
            //{
            //    client.OpenRead($"https://localhost:7210/api/EmagSSD/1");
            //}

            dataAdministration.FillSSDTable();

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
            //if (String.IsNullOrEmpty(CheckForExistingAds("HDDTable", "HDD", "Emag")))
            //{
            //    client.OpenRead($"https://localhost:7210/api/EmagHDD/1");
            //}

            dataAdministration.FillHDDTable();

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

        //private string CheckForExistingAds(string tableName, string column, string webSiteName)
        //{
        //    connection.Open();

        //    var readProcessorDataCommand = new SqlCommand(Data.ReadExistingComponentData(tableName, column, webSiteName), connection);

        //    var reader = readProcessorDataCommand.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        _ads.AdTitle += reader.GetString(0);
        //    }

        //    connection.Close();

        //    return _ads.AdTitle;
        //}

        public void DisplayResults(string apiURl, Label componentNameLbl, Label componentPriceLbl, RichTextBox hyperlinkBox, Label webSiteNameLbl, Button? homeBtn, int buttonYPosition)
        {
            Stream stream = client.OpenRead(apiURl);

            var reader = new StreamReader(stream);

            AdsModel _ads = JsonConvert.DeserializeObject<AdsModel>(reader.ReadToEnd());

            if (_ads.AdTitle is not null || _ads.AdHyperlink is not null || _ads.AdPrice is not null)
            {

                webSiteNameLbl.Show();
                hyperlinkBox.Show();
                componentNameLbl.ForeColor = Color.Black;
                componentNameLbl.Text = _ads.AdTitle;
                componentPriceLbl.Text = _ads.AdPrice;
                hyperlinkBox.Text = _ads.AdHyperlink;
                homeBtn.Location = new Point(0, buttonYPosition);


                return;

            }


            componentNameLbl.ForeColor = Color.Red;
            componentNameLbl.Text = "No Result That Matches Your Search ,Please Be More Explicit.";

        }

        private void SearchProduct(string product)
        {
            string[] searchItem = searchBox.Text.Split(' ');

            switch (searchItem.Length)
            {
                case 1:

                    DisplayResults($"https://localhost:7210/api/ReadEmag{product}Prices/{SearchQuerries.ReadComponentModelOneSearchItem($"{product}Table", "Emag", searchItem[0])}"
                        , componentNameLbl, componentPriceLbl, richTextBox1, emagLbl, homeBtn, 580);

                    searchingLbl.Hide();

                    break;

                case 2:

                    DisplayResults($"https://localhost:7210/api/ReadEmag{product}Prices/{SearchQuerries.ReadComponentModelTwoSearchItems($"{product}Table", "Emag", searchItem[0], searchItem[1])}"
                       , componentNameLbl, componentPriceLbl, richTextBox1, emagLbl, homeBtn, 580);


                    break;

                case 3:

                    DisplayResults($"https://localhost:7210/api/ReadEmag{product}Prices/{SearchQuerries.ReadComponentModelThreeSearchItems($"{product}Table", "Emag", searchItem[0], searchItem[1], searchItem[2])}"
                        , componentNameLbl, componentPriceLbl, richTextBox1, emagLbl, homeBtn, 580);

                    searchingLbl.Hide();

                    break;

                case >= 4:

                    DisplayResults($"https://localhost:7210/api/ReadEmag{product}Prices/{SearchQuerries.ReadComponentModelFourSearchItems($"{product}Table", "Emag", searchItem[0], searchItem[1], searchItem[2], searchItem[3])}"
                        , componentNameLbl, componentPriceLbl, richTextBox1, emagLbl, searchBtn, 580);

                    searchingLbl.Hide();

                    break;
            }

        }

    }
}
