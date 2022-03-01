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

namespace JSON_ChuckNorrisJokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cboCategories.Items.Add("All");
            cboCategories.SelectedIndex = 0;

            string url = "https://api.chucknorris.io/jokes/categories";

            using (HttpClient client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;

                List<string> categories = JsonConvert.DeserializeObject<List<string>>(json);

                foreach (string category in categories)
                {
                    cboCategories.Items.Add(category);
                }

            }

        }

        private void cboCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Random joke https://api.chucknorris.io/jokes/random
            //Random joke for a category https://api.chucknorris.io/jokes/random?category={category}

            string category = cboCategories.SelectedItem.ToString();
            string url = "https://api.chucknorris.io/jokes/random";
            if (category != "All")
            {
                url += $"?category={category}";
            }
            //txtJoke.Text = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;

                ChuckNorrisJokeApi joke = JsonConvert.DeserializeObject<ChuckNorrisJokeApi>(json);

                txtJoke.Text = joke.Joke;
            }

        }
    }
}
