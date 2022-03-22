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
using System.Windows.Shapes;

namespace JSON_PokemonAPI
{
    /// <summary>
    /// Interaction logic for PokemonInfoWindow.xaml
    /// </summary>
    public partial class PokemonInfoWindow : Window
    {
        PokemonDetails deets;
        bool showFront = true;

        public PokemonInfoWindow()
        {
            InitializeComponent();
        }

        public void PopulateData(Pokemon poke)
        {
            lblTitle.Content = poke.name;

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(poke.url).Result;

                 deets = JsonConvert.DeserializeObject<PokemonDetails>(json);

                txtHeight.Text = deets.height.ToString("N");
                txtWeight.Text = deets.weight.ToString("N");
                imgPicture.Source = new BitmapImage(new Uri(deets.sprites.front_default));
                //imgPicture.Tag = false;
                showFront = false;
            }

        }

        private void btnDance_Click(object sender, RoutedEventArgs e)
        {
            if (showFront == false)
            {
                imgPicture.Source = new BitmapImage(new Uri(deets.sprites.back_default));
                showFront = true;
            }
            else
            {
                imgPicture.Source = new BitmapImage(new Uri(deets.sprites.front_default));
                showFront = false;
            }
        }
    }
}
