﻿using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Web;

namespace PriceComparrerDemo
{
    public partial class HomePage : UserControl
    {
        private readonly WebClient client = new();
        private readonly HttpClient _client = new();
        private readonly XpathModel? _xpath = JsonConvert.DeserializeObject<XpathModel>(File.ReadAllText($@"{Environment.CurrentDirectory}\Config\Xpaths.json"));
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
            searchingLbl.ForeColor = Color.Black;
            searchBox.Hide();
            searchBtn.Hide();
            searchLbl.Hide();
            homeBtn.Hide();
            richTextBox1.Hide();
            pricesBox.Hide();
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
            richTextBox1.Hide();
            searchBox.Clear();
            richTextBox1.Clear();
            searchLbl.Text = string.Empty;
            pricesBox.Hide();
            #endregion


        }

        private void SearchBox_GotFocus(object? sender, EventArgs e)
        {
            if (searchingLbl.Visible is true)
            {
               searchingLbl.ForeColor= Color.Green;
               searchingLbl.Hide();
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
            #endregion

        }

        private void videoCardsBtnTab_Click(object sender, EventArgs e)
        {
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
            #endregion


        }

        private void motherboardBtnTab_Click(object sender, EventArgs e)
        {
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
            #endregion

        }

        private void ramBtnTab_Click(object sender, EventArgs e)
        {
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
            #endregion

        }

        private void powerSupplyBtnTab_Click(object sender, EventArgs e)
        {
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
            #endregion

        }

        private void coolerBtnTab_Click(object sender, EventArgs e)
        {
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
            #endregion

        }

        private void caseBtnTab_Click(object sender, EventArgs e)
        {
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
            #endregion

        }

        private void ssdBtnTab_Click(object sender, EventArgs e)
        {
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
            #endregion

        }

        private void hddBtnTab_Click(object sender, EventArgs e)
        {
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
            #endregion

        }

        #endregion

        //public void DisplayResults(string apiURl, RichTextBox hyperlinkBox, RichTextBox pricesBox,Label searchingLbl)
        //{
        //    Stream stream = client.OpenRead(apiURl);

        //    var reader = new StreamReader(stream);

        //    AdsModel? _ads = JsonConvert.DeserializeObject<AdsModel>(reader.ReadToEnd());

        //    if (_ads.AdTitle is not null || _ads.AdHyperlink is not null || _ads.AdPrice is not null)
        //    {
        //        pricesBox.Show();
        //        hyperlinkBox.Show();
        //        hyperlinkBox.Text = $"{_ads.AdTitle}{_ads.AdHyperlink}";
        //        pricesBox.Text = _ads.AdPrice;

        //        return;

        //    }

        //    searchingLbl.ForeColor = Color.Red;

        //    searchingLbl.Text = "No Results please be more Explicit";

        //}

        public void DisplayResults(string apiURl, RichTextBox hyperlinkBox,RichTextBox pricesBox, Label searchingLbl)
        {
            Stream stream = client.OpenRead(apiURl);

            var reader = new StreamReader(stream);

            var request = _client.GetAsync(apiURl).Result;

            var response = request.Content.ReadAsStringAsync().Result;

            AdsModel? _ads = JsonConvert.DeserializeObject<AdsModel>(response);

            if (_ads.AdTitle is not null || _ads.AdHyperlink is not null || _ads.AdPrice is not null)
            {
                pricesBox.Show();
                hyperlinkBox.Show();
                hyperlinkBox.Text = $"{_ads.AdTitle}{_ads.AdHyperlink}";
                pricesBox.Text = _ads.AdPrice;

                return;

            }


            searchingLbl.ForeColor = Color.Red;

            searchingLbl.Text = "No Results please be more Explicit";

        }

        private void SearchProduct(string product)
        {
            string[] searchItem = searchBox.Text.Split(' ');

            switch (searchItem.Length)
            {
                case 1:

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"{product}Table", "Emag", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/"
                        , richTextBox1, pricesBox, searchingLbl);

                    ////searchingLbl.Hide();

                    break;

                case 2:

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelTwoSearchItems($"{product}Table", "Emag", searchItem[0], searchItem[1]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/"
                        ,richTextBox1,pricesBox,searchingLbl);


                    break;

                case 3:

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelThreeSearchItems($"{product}Table", "Emag", searchItem[0], searchItem[1], searchItem[2]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/"
                        , richTextBox1, pricesBox, searchingLbl);
                   
                    break;

                case >= 4:

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelFourSearchItems($"{product}Table", "Emag", searchItem[0], searchItem[1], searchItem[2], searchItem[3]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/"
                       , richTextBox1, pricesBox, searchingLbl);


                    break;
            }

        }

    }
}
