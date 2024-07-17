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
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
        }
        private void Calculator_Bitcoin(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
                int ano = int.Parse(selectedItem.Content.ToString());
                double preco = double.Parse(textBox.Text);
                if (ano == 1)
                {
                    preco = preco * (1 + 145/100);
                }
                if (ano == 5)
                {
                    preco = preco * (1 + 895 / 100);
                }
                if (ano == 10)
                {
                    preco = preco * (1 + 29000 / 100);
                }
                if (ano == 1) { MessageBox.Show($"Daqui {ano} ano, você tera R$ {preco}"); }
                else { MessageBox.Show($"Daqui {ano} anos, você tera R$ {preco}"); }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show($"ERROR{ex}, TENTE NOVAMENTE");
            }
        }

        private void BackToHome(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            // Exibe a nova janela
            mainWindow.Show();
            this.Close();
        }
    }
}
