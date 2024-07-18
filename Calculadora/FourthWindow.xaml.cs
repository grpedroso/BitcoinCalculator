using System;
using System.Collections.Generic;
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

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for FourthWindow.xaml
    /// </summary>
    public partial class FourthWindow : Window
    {
        public FourthWindow()
        {
            InitializeComponent();
            LoadDataFromAPI();
        }

        private void BackToHome(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public float price { get; set; }


        private void ReaisTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (float.TryParse(ReaisTextBox.Text, out float input))
            {
                float result = input/price; // Calcula o quadrado do número
                BitcoinTextBox.Text = result.ToString("F8");
            }
            else
            {
                BitcoinTextBox.Text = "Entrada inválida"; // Exibe mensagem de erro se a entrada não for um número
            }
        }

        public async void LoadDataFromAPI()
        {
            string url = $"https://criptoya.com/api/binance/btc/brl/1";
            DataAPI data = await DataAPI.GetDataFromAPIAsync(url);
            price = data.PrecoC;


        }
    }
}
