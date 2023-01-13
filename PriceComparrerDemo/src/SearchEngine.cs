using Newtonsoft.Json;
using PriceComparrerDemo;
using System.Web;

namespace PriceComparrerWinforms.src
{
    public class SearchEngine
    {
        private readonly HttpClient _client = new();
        private readonly XpathModel? _xpath = JsonConvert.DeserializeObject<XpathModel>(File.ReadAllText($@"{Environment.CurrentDirectory}\Config\Xpaths.json"));
        

        public void StartSearch(Label searchLbl, TextBox searchBox, RichTextBox richTextBox1, RichTextBox pricesBox)
        {
            if (searchLbl.Text.Contains("Processor"))
            {
                SearchProduct("Processor", searchBox, richTextBox1, pricesBox);

               
            }

            else if (searchLbl.Text.Contains("Video Card"))
            {
                SearchProduct("VideoCard", searchBox, richTextBox1, pricesBox);
            }

            else if (searchLbl.Text.Contains("Motherboard"))
            {
                SearchProduct("Motherboard", searchBox, richTextBox1, pricesBox);


            }
            else if (searchLbl.Text.Contains("Ram Memory"))
            {
                SearchProduct("RamMemory", searchBox, richTextBox1, pricesBox);


            }

            else if (searchLbl.Text.Contains("Power Supply"))
            {
                SearchProduct("PowerSupply", searchBox, richTextBox1, pricesBox);

            }
            else if (searchLbl.Text.Contains("Cooler"))
            {
                SearchProduct("Cooler", searchBox, richTextBox1, pricesBox);

            }
            else if (searchLbl.Text.Contains("Computer Case"))
            {
                SearchProduct("ComputerCase", searchBox, richTextBox1, pricesBox);

            }
            else if (searchLbl.Text.Contains("SSD"))
            {

                SearchProduct("SSD", searchBox, richTextBox1, pricesBox);

            }

            else if (searchLbl.Text.Contains("HDD"))
            {
                SearchProduct("HDD", searchBox, richTextBox1, pricesBox);

            }


        }

        private void SearchProduct(string product, TextBox searchBox, RichTextBox richTextBox1, RichTextBox pricesBox)
        {
            string[] searchItem = searchBox.Text.Split(' ');

            switch (searchItem.Length)
            {
                case 1:

                    Thread firstThread = new(() => DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"{product}Table", "Emag", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpathForDeals)}/"
                    , richTextBox1, pricesBox));
                    firstThread.Start();
                    //DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"{product}Table", "Emag", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpathForDeals)}/"
                    //, richTextBox1, pricesBox);
                    //Thread.Sleep(2000);

                    Thread secondThread = new(() => DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"Second{product}Table", "PcGarage", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.PCGaragePricesXpath)}/"
                    , richTextBox1, pricesBox));
                    secondThread.Start();
                    //DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"Second{product}Table", "PcGarage", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.PCGaragePricesXpath)}/"
                    //, richTextBox1, pricesBox);
                    //Thread.Sleep(2000);

                    Thread thirdThread = new(() => DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"{product}Table", "Evomag", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.EvomagPricesXpath)}/"
                    , richTextBox1, pricesBox));
                    thirdThread.Start();
                    //DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"{product}Table", "Evomag", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.EvomagPricesXpath)}/"
                    //, richTextBox1, pricesBox);
                    //Thread.Sleep(2000);

                    Thread fourthThread = new(()=> DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"Second{product}Table", "Vexio", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.VexioPricesXpath)}/"
                      , richTextBox1, pricesBox));
                    fourthThread.Start();
                    //DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelOneSearchItem($"Second{product}Table", "Vexio", searchItem[0]))}/{HttpUtility.UrlEncode(_xpath.VexioPricesXpath)}/"
                    //  , richTextBox1, pricesBox);

                    ////searchingLbl.Hide();

                    break;
                case 2:
                    Thread fifthThread = new(() => DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelTwoSearchItems($"{product}Table", "Emag", searchItem[0], searchItem[1]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpathForDeals)}/"
                    , richTextBox1, pricesBox));
                   
                    fifthThread.Start();

                    Thread sixthThread = new(() => DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelTwoSearchItems($"Second{product}Table", "PcGarage", searchItem[0], searchItem[1]))}/{HttpUtility.UrlEncode(_xpath.PCGaragePricesXpath)}/"
                    , richTextBox1, pricesBox));
                    MessageBox.Show("Searching Pc garage");
                    sixthThread.Start();    
                   

                    Thread seventhThread = new(() =>
                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelTwoSearchItems($"{product}Table", "Evomag", searchItem[0], searchItem[1]))}/{HttpUtility.UrlEncode(_xpath.EvomagPricesXpath)}/"
                       , richTextBox1, pricesBox));
                    MessageBox.Show("Searching Evomag");
                    seventhThread.Start();
                    

                    Thread eighthThread = new(() => DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelTwoSearchItems($"Second{product}Table", "Vexio", searchItem[0], searchItem[1]))}/{HttpUtility.UrlEncode(_xpath.VexioPricesXpath)}/"
                       , richTextBox1, pricesBox));
                    MessageBox.Show("Vexio");
                    eighthThread.Start();
                    
                    break;
                case 3:
                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelThreeSearchItems($"{product}Table", "Emag", searchItem[0], searchItem[1], searchItem[2]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpathForDeals)}/"
                    , richTextBox1, pricesBox);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelThreeSearchItems($"Second{product}Table", "PcGarage", searchItem[0], searchItem[1], searchItem[2]))}/{HttpUtility.UrlEncode(_xpath.PCGaragePricesXpath)}/"
                        , richTextBox1, pricesBox);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelThreeSearchItems($"{product}Table", "Evomag", searchItem[0], searchItem[1], searchItem[2]))}/{HttpUtility.UrlEncode(_xpath.EvomagPricesXpath)}/"
                      , richTextBox1, pricesBox);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelThreeSearchItems($"Second{product}Table", "Vexio", searchItem[0], searchItem[1], searchItem[2]))}/{HttpUtility.UrlEncode(_xpath.VexioPricesXpath)}/"
                        , richTextBox1, pricesBox);
                    break;
                case >= 4:
                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelFourSearchItems($"{product}Table", "Emag", searchItem[0], searchItem[1], searchItem[2], searchItem[3]))}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpath)}/{HttpUtility.UrlEncode(_xpath.EmagPricesXpathForDeals)}/"
                    , richTextBox1, pricesBox);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelFourSearchItems($"Second{product}Table", "PcGarage", searchItem[0], searchItem[1], searchItem[2], searchItem[3]))}/{HttpUtility.UrlEncode(_xpath.PCGaragePricesXpath)}/"
                       , richTextBox1, pricesBox);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelFourSearchItems($"{product}Table", "Evomag", searchItem[0], searchItem[1], searchItem[2], searchItem[3]))}/{HttpUtility.UrlEncode(_xpath.EvomagPricesXpath)}/"
                      , richTextBox1, pricesBox);
                    Thread.Sleep(2000);

                    DisplayResults($"https://localhost:7210/api/GetProductsPrices/{HttpUtility.UrlEncode(SearchQuerries.ReadComponentModelFourSearchItems($"Second{product}Table", "Vexio", searchItem[0], searchItem[1], searchItem[2], searchItem[3]))}/{HttpUtility.UrlEncode(_xpath.VexioPricesXpath)}/"
                       , richTextBox1, pricesBox);

                    break;
            }

        }

        private void DisplayResults(string apiURl, RichTextBox hyperlinkBox, RichTextBox pricesBox)
        {
            var request = _client.GetAsync(apiURl).Result;

            var response = request.Content.ReadAsStringAsync().Result;

            AdsModel? _ads = JsonConvert.DeserializeObject<AdsModel>(response);

            if (_ads is not null)
            {
                
                hyperlinkBox.Invoke((MethodInvoker)(() => hyperlinkBox.Text += $"{_ads.AdTitle}{_ads.AdHyperlink}"));
                pricesBox.Invoke((MethodInvoker)(() => pricesBox.Text += _ads.AdPrice));
                pricesBox.Invoke(new MethodInvoker(pricesBox.Show));
                hyperlinkBox.Invoke(new MethodInvoker(hyperlinkBox.Show));
                //pricesBox.Show();
                //hyperlinkBox.Show();
                //hyperlinkBox.Text = $"{_ads.AdTitle}{_ads.AdHyperlink}";
                //pricesBox.Text = _ads.AdPrice;

            }
           
        }


    }
}
