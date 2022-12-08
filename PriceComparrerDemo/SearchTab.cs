namespace PriceComparrerDemo
{
    public partial class SearchTab : UserControl
    {
        public SearchTab()
        {
            InitializeComponent();
            searchBox.KeyDown += SearchBox_KeyDown;
             
        }


        #region UIBehaviour
        private void ShowResultsTab(Label websiteLbl, RichTextBox resultsBox, ComboBox hyperlinkBox, Button naviagteBtn)
        {
            websiteLbl.Show();
            websiteLbl.BringToFront();
            resultsBox.Show();
            resultsBox.BringToFront();
            hyperlinkBox.Show();
            hyperlinkBox.BringToFront();
            naviagteBtn.Show();
            naviagteBtn.BringToFront();

        }

        private void HideResultsTab(Label websiteLbl, RichTextBox resultsBox, ComboBox hyperlinkBox, Button naviagteBtn)
        {
            websiteLbl.Hide();
            resultsBox.Hide();
            hyperlinkBox.Hide();
            naviagteBtn.Hide();

        }
        #endregion

        private void SearchTab_Load(object sender, EventArgs e)
        {
            HideResultsTab(websiteLblOne, resultsBoxOne, hyperlinkBoxOne, naviagteBtnOne);
            HideResultsTab(websiteLblTwo, resultsBoxTwo, hyperlinkBoxTwo, naviagteBtnTwo);
            HideResultsTab(websiteLblThree, resultsBoxThree, hyperlinkBoxThree, naviagteBtnThree);
            HideResultsTab(websiteLblFour, resultsBoxFour, hyperlinkBoxFour, naviagteBtnFour);
        }
        private void SearchBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter && !String.IsNullOrEmpty(searchBox.Text))
            {
                ShowResultsTab(websiteLblOne, resultsBoxOne, hyperlinkBoxOne, naviagteBtnOne);
                ShowResultsTab(websiteLblTwo, resultsBoxTwo, hyperlinkBoxTwo, naviagteBtnTwo);
                MessageBox.Show("Enter was pressed.");
            }
        }

        #region Buttons
        private void searchBtn_Click(object sender, EventArgs e)
        {

        }

        private void naviagteBtnOne_Click(object sender, EventArgs e)
        {

        }

        private void naviagteBtnTwo_Click(object sender, EventArgs e)
        {

        }

        private void naviagteBtnThree_Click(object sender, EventArgs e)
        {

        }

        private void naviagteBtnFour_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
