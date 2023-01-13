using PriceComparrerWinforms.src;
using System.Diagnostics;

namespace PriceComparrerDemo
{
    public partial class HomePage : UserControl
    {
        private readonly SearchEngine _searchEngine = new();
        private readonly DataAdministration dataAdministration = new();
        public HomePage()
        {
            InitializeComponent();
            searchBox.KeyDown += SearchBox_KeyDown;
            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
            searchBox.GotFocus += SearchBox_GotFocus;

        }

        #region UIChanges
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
                searchingLbl.ForeColor = Color.Green;
                searchingLbl.Hide();
            }

        }

        #endregion

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

        #region SearchingAndDisplayingResults
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
            if (e.KeyCode is Keys.Enter&&!string.IsNullOrEmpty(searchBox.Text))
            {
                _searchEngine.StartSearch(searchLbl, searchBox, richTextBox1, pricesBox);

            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchBox.Text))
            {
                MessageBox.Show("value Cannot be null ");

                return;
            }

            searchingLbl.Show();

            _searchEngine.StartSearch(searchLbl, searchBox, richTextBox1, pricesBox);

        }
        #endregion







    }
}
