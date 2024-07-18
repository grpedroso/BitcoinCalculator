using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;


namespace Calculadora
{

    
    public partial class ThirdWindow : Window
    {
        public ThirdWindow()
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

        public async void LoadDataFromAPI()
        {
            string url = $"https://criptoya.com/api/binance/btc/brl/1";
            DataAPI data = await DataAPI.GetDataFromAPIAsync(url);
            precoCtextBox.Text = data.PrecoC.ToString();
            precoVtextBox.Text = data.PrecoV.ToString();
            
        }


    }




    public class DataAPI
    {
        [JsonProperty("totalAsk")]
        public float PrecoC { get; set; }
        [JsonProperty("ask")]
        public float ask { get; set; }
        [JsonProperty("bid")]
        public float bid { get; set; }
        [JsonProperty("totalBid")]
        public float PrecoV { get; set; }
        [JsonProperty("time")]
        public int Time {  get; set; }

        
      
        public static async Task<DataAPI> GetDataFromAPIAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string reponseBody = await response.Content.ReadAsStringAsync();
                
                DataAPI data = JsonConvert.DeserializeObject<DataAPI>(reponseBody);
                return data;
            }
        }

    }
    
    

}
    
    

