using Newtonsoft.Json;
using PriceComparrerDemo;
using System.Web;

namespace PriceComparrerWinforms.src
{
    public class SearchEngine
    {
        private readonly HttpClient _client = new();
        private readonly XpathModel? _xpath = JsonConvert.DeserializeObject<XpathModel>(File.ReadAllText($@"{Environment.CurrentDirectory}\Config\Xpaths.json"));
        private void DisplayResults(string apiURl, RichTextBox hyperlinkBox, RichTextBox pricesBox, Label searchingLbl)
        {
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

        public void SearchProduct(string product, TextBox searchBox, RichTextBox richTextBox1, RichTextBox pricesBox, Label searchingLbl)
        {
            string[] searchItem = searchBox.Text.Split(' ');
            switch (searchItem.Length)
            {
                case 1:
                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"{product}Table", "Emag", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpathForDeals)}/"
                    , richTextBox1, pricesBox, searchingLbl);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"Second{product}Table", "PcGarage", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.PCGaragePricesXpath)}/"
                    , richTextBox1, pricesBox, searchingLbl);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"{product}Table", "Evomag", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.EvomagPricesXpath)}/"
                    , richTextBox1, pricesBox, searchingLbl);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"Second{product}Table", "Vexio", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.VexioPricesXpath)}/"
                      , richTextBox1, pricesBox, searchingLbl);

                    ////searchingLbl.Hide();

                    break;
                case 2:
                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelTwoSearchItems($"{product}Table", "Emag", searchItem[0], searchItem[1]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpathForDeals)}/"
                    , richTextBox1, pricesBox, searchingLbl);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelTwoSearchItems($"Second{product}Table", "PcGarage", searchItem[0], searchItem[1]))}/{HttpUtility.UrlEncode(_xpath.PCGaragePricesXpath)}/"
                    , richTextBox1, pricesBox, searchingLbl);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelTwoSearchItems($"{product}Table", "Evomag", searchItem[0], searchItem[1]))}/{HttpUtility.UrlEncode(_xpath.EvomagPricesXpath)}/"
                       , richTextBox1, pricesBox, searchingLbl);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelTwoSearchItems($"Second{product}Table", "Vexio", searchItem[0], searchItem[1]))}/{HttpUtility.UrlEncode(_xpath.VexioPricesXpath)}/"
                       , richTextBox1, pricesBox, searchingLbl);
                    break;
                case 3:
                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelThreeSearchItems($"{product}Table", "Emag", searchItem[0], searchItem[1], searchItem[2]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpathForDeals)}/"
                    , richTextBox1, pricesBox, searchingLbl);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelThreeSearchItems($"Second{product}Table", "PcGarage", searchItem[0], searchItem[1], searchItem[2]))}/{HttpUtility.UrlEncode(_xpath.PCGaragePricesXpath)}/"
                        , richTextBox1, pricesBox, searchingLbl);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelThreeSearchItems($"{product}Table", "Evomag", searchItem[0], searchItem[1], searchItem[2]))}/{HttpUtility.UrlEncode(_xpath.EvomagPricesXpath)}/"
                      , richTextBox1, pricesBox, searchingLbl);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelThreeSearchItems($"Second{product}Table", "Vexio", searchItem[0], searchItem[1], searchItem[2]))}/{HttpUtility.UrlEncode(_xpath.VexioPricesXpath)}/"
                        , richTextBox1, pricesBox, searchingLbl);
                    break;
                case >= 4:
                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelFourSearchItems($"{product}Table", "Emag", searchItem[0], searchItem[1], searchItem[2], searchItem[3]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpathForDeals)}/"
                    , richTextBox1, pricesBox, searchingLbl);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelFourSearchItems($"Second{product}Table", "PcGarage", searchItem[0], searchItem[1], searchItem[2], searchItem[3]))}/{HttpUtility.UrlEncode(_xpath.PCGaragePricesXpath)}/"
                       , richTextBox1, pricesBox, searchingLbl);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelFourSearchItems($"{product}Table", "Evomag", searchItem[0], searchItem[1], searchItem[2], searchItem[3]))}/{HttpUtility.UrlEncode(_xpath.EvomagPricesXpath)}/"
                      , richTextBox1, pricesBox, searchingLbl);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelFourSearchItems($"Second{product}Table", "Vexio", searchItem[0], searchItem[1], searchItem[2], searchItem[3]))}/{HttpUtility.UrlEncode(_xpath.VexioPricesXpath)}/"
                       , richTextBox1, pricesBox, searchingLbl);

                    break;
            }

        }


    }
}
