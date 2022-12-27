using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using PriceComparrerWinforms.src;
using System.Diagnostics;
using System.Net;

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
                searchingLbl.Show();

                if (String.IsNullOrEmpty(searchBox.Text))
                {
                    MessageBox.Show("value Cannot be null ");

                    return;
                }

                #region SearchLblContents
                if (searchLbl.Text.Contains("Processor"))
                {
                    DisplayResults($"https://localhost:7210/api/ReadProcessorsPrices/{ParseImput(searchBox.Text)}");

                    searchingLbl.Hide();

                }

                else if (searchLbl.Text.Contains("Video Card"))
                {

                    DisplayResults($"https://localhost:7210/api/ReadVideoCardsPrices/{ParseImput(searchBox.Text)}");

                    searchingLbl.Hide();

                }

                else if (searchLbl.Text.Contains("Motherboard"))
                {
                    DisplayResults($"https://localhost:7210/api/ReadMotherboardsPrices/{ParseImput(searchBox.Text)}");

                    searchingLbl.Hide();

                }
                else if (searchLbl.Text.Contains("Ram Memory"))
                {
                    DisplayResults($"https://localhost:7210/api/ReadRamMemoryPrices/{ParseImput(searchBox.Text)}");

                    MessageBox.Show("this os the Ram Tab");
                }

                else if (searchLbl.Text.Contains("Power Supply"))
                {
                    //search processsor prices 
                    //null exceptions
                    MessageBox.Show("This is the pwoert supply Tab Tab");
                }
                else if (searchLbl.Text.Contains("Cooler"))
                {
                    MessageBox.Show("This is the cooler Tab");
                }
                else if (searchLbl.Text.Contains("Computer Case"))
                {
                    //search processsor prices 
                    //null exceptions

                    MessageBox.Show("Case Tab is here ");
                }
                else if (searchLbl.Text.Contains("SSD"))
                {
                    MessageBox.Show("SSSd Tab is here ");
                }

                else if (searchLbl.Text.Contains("HDD"))
                {
                    //search processsor prices 
                    //null exceptions

                    MessageBox.Show("THdd Tahb is here ");
                }

                #endregion




            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            //Make a Separate Class Called Data Validator 

            searchingLbl.Show();

            if (String.IsNullOrEmpty(searchBox.Text))
            {
                MessageBox.Show("value Cannot be null ");

                return;
            }

            #region SearchLblContents
            if (searchLbl.Text.Contains("Processor"))
            {
                DisplayResults($"https://localhost:7210/api/ReadProcessorsPrices/{ParseImput(searchBox.Text)}");

                searchingLbl.Hide();

            }

            else if (searchLbl.Text.Contains("Video Card"))
            {

                DisplayResults($"https://localhost:7210/api/ReadVideoCardsPrices/{ParseImput(searchBox.Text)}");

                searchingLbl.Hide();

            }

            else if (searchLbl.Text.Contains("Motherboard"))
            {
                DisplayResults($"https://localhost:7210/api/ReadMotherboardsPrices/{ParseImput(searchBox.Text)}");

                searchingLbl.Hide();

            }
            else if (searchLbl.Text.Contains("Ram Memory"))
            {
                DisplayResults($"https://localhost:7210/api/ReadRamMemoryPrices/{ParseImput(searchBox.Text)}");

                searchingLbl.Hide();
            }

            else if (searchLbl.Text.Contains("Power Supply"))
            {
                DisplayResults($"https://localhost:7210/api/ReadPowerSupplyPrices/{ParseImput(searchBox.Text)}");

                searchingLbl.Hide();
            }
            else if (searchLbl.Text.Contains("Cooler"))
            {
                DisplayResults($"https://localhost:7210/api/CoolerPrices/{ParseImput(searchBox.Text)}");

                searchingLbl.Hide();

            }
            else if (searchLbl.Text.Contains("Computer Case"))
            {
                DisplayResults($"https://localhost:7210/api/ComputerCasePrices/{ParseImput(searchBox.Text)}");

                searchingLbl.Hide();


            }
            else if (searchLbl.Text.Contains("SSD"))
            {
                DisplayResults($"https://localhost:7210/api/ReadSSDPrices/{ParseImput(searchBox.Text)}");

                searchingLbl.Hide();
            }

            else if (searchLbl.Text.Contains("HDD"))
            {
                DisplayResults($"https://localhost:7210/api/ReadHDDPrices/{ParseImput(searchBox.Text)}");

                searchingLbl.Hide();


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

        private static string ParseImput(string imput)
        {

            var splitText = imput.Split(' ');

            string model = splitText[1];

            if (model.Length < 1)
            {
                model = splitText[2];
            }

            return model;
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
