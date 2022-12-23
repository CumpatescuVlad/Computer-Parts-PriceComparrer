using Newtonsoft.Json;
using PriceComparrerWinforms.src;
using System.Diagnostics;
using System.Net;

namespace PriceComparrerDemo
{
    public partial class HomePage : UserControl
    {
        private readonly WebClient client = new();

        public HomePage()
        {
            InitializeComponent();
            searchBox.KeyDown += SearchBox_KeyDown;
            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
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
                MessageBox.Show($"Now THhe search method will be executed whe nkey is {e.KeyCode}");
            }
        }

        private void processorBtnTab_Click(object sender, EventArgs e)
        {
            //search for the processors on varous webSites 

            // https://localhost:7210/api/Processor/1

            #region HideElements
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

        #region !Useful
        private void genericTab1_Load(object sender, EventArgs e)
        {

        }

        //private void HideElements(Button? processorBtn,Button? videoCardtbn,Button ? motherboardBtn,Button? ramBtn,
        //    Button ? powerSupplyBtn,Button? coolerBtn,Button? caseBtn,Button? ssdBtn,Button? hddBtn,Button? m2btn,Label chooseProdBtn)
        //{
        //    motherboardBtn.Hide();
        //    powerSupplyBtn.Hide();
        //    chooseProdBtn.Hide();
        //    processorBtn.Hide();
        //    videoCardtbn.Hide();
        //    coolerBtn.Hide();
        //    caseBtn.Hide();
        //    ssdBtn.Hide();
        //    hddBtn.Hide();
        //    m2btn.Hide();
        //    ramBtn.Hide();

        //}

        #endregion


        private void HomePage_Load(object sender, EventArgs e)
        {
            searchBox.Hide();
            searchBtn.Hide();
            searchLbl.Hide();
            homeBtn.Hide();
            richTextBox1.Hide();
            componentNameLbl.Hide();

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            //Make a Separate Class Called Data Validator 

            if (String.IsNullOrEmpty(searchBox.Text))
            {
                MessageBox.Show("value Cannot be null ");

                return;
            }

           
            #region SearchLblContents
            if (searchLbl.Text.Contains("Processor"))
            {
                //search processsor prices 
                //null exceptions

                Stream stream = client.OpenRead($"https://localhost:7210/api/ReadProcessorPrice/{searchBox.Text}");

                var reader = new StreamReader(stream);

                AdsModel _ads = JsonConvert.DeserializeObject<AdsModel>(reader.ReadToEnd());

                componentNameLbl.Text = _ads.AdTitle;
                componentPriceLbl.Text = _ads.AdPrice;
                richTextBox1.Text = _ads.AdHyperlink;

                MessageBox.Show("This is the processor Tab");
            }
            else if (searchLbl.Text.Contains("Video Card"))
            {
                MessageBox.Show("this is the Video Card tab");
            }

            else if (searchLbl.Text.Contains("Motherboard"))
            {
                //search processsor prices 
                //null exceptions

                MessageBox.Show("This is the Mobo Tab");
            }
            else if (searchLbl.Text.Contains("Ram Memory"))
            {
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

        private void videoCardsBtnTab_Click(object sender, EventArgs e)
        {
            //client.OpenRead($"https://localhost:7210/api/ReadProcessorPrice/i7/{linkBox}");


            #region HideElements
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
            #endregion


        }

        private void motherboardBtnTab_Click(object sender, EventArgs e)
        {
            #region HideElements
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
            #endregion

        }

        private void ramBtnTab_Click(object sender, EventArgs e)
        {
            #region HideElements
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
            #endregion

        }

        private void powerSupplyBtnTab_Click(object sender, EventArgs e)
        {
            #region HideElements
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
            #endregion

        }

        private void coolerBtnTab_Click(object sender, EventArgs e)
        {
            #region HideElements
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
            #endregion

        }

        private void caseBtnTab_Click(object sender, EventArgs e)
        {
            #region HideElements
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
            #endregion

        }

        private void ssdBtnTab_Click(object sender, EventArgs e)
        {
            #region HideElements
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
            #endregion

        }

        private void hddBtnTab_Click(object sender, EventArgs e)
        {
            #region HideElements
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
            #endregion

        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region ShowElements
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
            #endregion


        }

        private void linkBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
