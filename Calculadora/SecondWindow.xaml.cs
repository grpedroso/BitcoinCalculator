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
                    preco = preco + (preco * 0.89);
                }
                if (ano == 5)
                {
                    preco = preco + (preco * 3.71);
                }
                if (ano == 10)
                {
                    preco = preco + (preco * 110);
                }
                MessageBox.Show($"The investment will return ${preco}");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"ERROR{ex}, TRY AGAIN");
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
