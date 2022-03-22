using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace JSON_PokemonAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?offset=0&limit=1200").Result;
                AllPokemonAPI api = JsonConvert.DeserializeObject<AllPokemonAPI>(json);

                cboPokemen.ItemsSource = api.results;

                //api.results.ForEach(poke => cboPokemen.Items.Add(poke));    

                //foreach (var poke in api.results)
                //{
                //    cboPokemen.Items.Add(poke);
                //}
            }

        }

        private void cboPokemen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pokemon selected = cboPokemen.SelectedItem as Pokemon;

            PokemonInfoWindow wnd = new PokemonInfoWindow();
            wnd.PopulateData(selected);

            wnd.ShowDialog();

        }
    }
}
