using CriptoLivra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Important(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Important: This is a study project that takes past income into account, DO NOT BELIEVE THE INFORMATION");
        }
        private void OpenSecondWindow_Click(object sender, RoutedEventArgs e)
        {
            // Cria uma nova instância da janela SecondWindow
            SecondWindow secondWindow = new SecondWindow();
            // Exibe a nova janela
            secondWindow.Show();
            this.Close();

        }
        private void OpenThirdWindow_Click(object sender, RoutedEventArgs e)
        {
            // Cria uma nova instância da janela SecondWindow
            ThirdWindow thirdWindow = new ThirdWindow();            // Exibe a nova janela
            thirdWindow.Show();
            this.Close();

        }

        private void OpenFourthWindow_Click(object sender, RoutedEventArgs e)
        {
            // Cria uma nova instância da janela SecondWindow
            FourthWindow fourthWindow = new FourthWindow();            // Exibe a nova janela
            fourthWindow.Show();
            this.Close();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://www.instagram.com/criptolivra/";
            OpenUrl(url);
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Failed to open URL: {ex.Message}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SixWindow sixWindow = new SixWindow();            // Exibe a nova janela
            sixWindow.Show();
            this.Close();
        }
    }
}
