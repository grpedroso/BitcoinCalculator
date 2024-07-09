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
    }
}
