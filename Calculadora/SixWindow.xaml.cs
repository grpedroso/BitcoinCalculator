using Calculadora;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static CriptoLivra.SixWindow;

namespace CriptoLivra
{
    /// <summary>
    /// Interaction logic for SixWindow.xaml
    /// </summary>
    public partial class SixWindow : Window
    {
        public SixWindow()
        {
            InitializeComponent();
            LoadDataFromAPI();
            LoadWallet();
            ConfigureDataGridColumns();
            UpdateUI();
                      
        }

        private void ConfigureDataGridColumns()
        {
            CoinsDataGrid.AutoGenerateColumns = false;
            DataGridTextColumn nameColumn = new DataGridTextColumn
            {
                Header = "Data",
                Binding = new System.Windows.Data.Binding("Date"),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            };
            DataGridTextColumn valueColumn = new DataGridTextColumn
            {
                Header = "Quantidade",
                Binding = new System.Windows.Data.Binding("Value"),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            };
            DataGridTextColumn actionColumn = new DataGridTextColumn
            {
                Header = "Ação",
                Binding = new System.Windows.Data.Binding("Action"),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            };
            CoinsDataGrid.Columns.Add(nameColumn);
            CoinsDataGrid.Columns.Add(valueColumn);
            CoinsDataGrid.Columns.Add(actionColumn);

        }

        public class Operation
        {
            public DateTime Date { get; set; }
            public string Action { get; set; }
            public float Value { get; set; }
        }
        public class Bitcoin
        {
            public Bitcoin()
            {
                Operations = new List<Operation>();
            }
            public float Value { get; set; }
            public List<Operation> Operations { get; set; } = new List<Operation>();
            
        }

        public float precoBit {  get; set; }
        private Bitcoin wallet;
        private string dataFilePath = "coins.json";

        public async void LoadDataFromAPI()
        {
            string url = $"https://criptoya.com/api/binance/btc/brl/1";
            DataAPI data = await DataAPI.GetDataFromAPIAsync(url);
            precoBit = data.PrecoC;
            reaisBit.Text = (wallet.Value * precoBit).ToString("F2");
        }
        private void AddBitcoin_Click(object sender, RoutedEventArgs e)
        {
            float.TryParse(AddBitText.Text, out float value); 
            var operation = new Operation
            {
                Date = DateTime.Now,
                Action = "Adição",
                Value = value
            };
            wallet.Operations.Add(operation);
            wallet.Value = wallet.Value + value;
            SaveWallet();
            UpdateUI();
            LoadDataFromAPI();
            AddBitText.Clear();
    
        }

        private void DelBitcoin_Click(object sender, RoutedEventArgs e)
        {

            float.TryParse(AddBitText.Text, out float value);
          
            var operation = new Operation
            {
                Date = DateTime.Now,
                Action = "Subtração",
                Value = value
            };
            wallet.Operations.Add(operation);
            wallet.Value = wallet.Value - value;
            SaveWallet();
            UpdateUI();
            LoadDataFromAPI();
            AddBitText.Clear();

        }

        private void BackToHome(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void LoadWallet()
        {
            if (File.Exists(dataFilePath))
            {
                var json = File.ReadAllText(dataFilePath);
                wallet = JsonConvert.DeserializeObject<Bitcoin>(json) ?? new Bitcoin();
            }
            else
            {
                wallet = new Bitcoin();
            }
        }
        private void UpdateUI()
        {
            CoinsDataGrid.ItemsSource = null;
            CoinsDataGrid.ItemsSource = wallet.Operations;
            BitcoinBalanceTextBlock.Text = wallet.Value.ToString("F8");
        }
        private void SaveWallet()
        {
            var json = JsonConvert.SerializeObject(wallet, Formatting.Indented);
            File.WriteAllText(dataFilePath, json);
        }


    }

}
