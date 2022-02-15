using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_JSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string json = File.ReadAllText("MOCK_DATA.json");

            List<Person> ps = JsonConvert.DeserializeObject< List<Person>>(json);

            //lstPeeps.ItemsSource = ps;

            foreach (Person p in ps)
            {
                if (p.city.ToLower()[0] == 'p')
                {
                    lstPeeps.Items.Add(p); 
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string exportData = JsonConvert.SerializeObject(lstPeeps.Items, Formatting.Indented);

            File.WriteAllText("filteredData.json", exportData);
            
            MessageBox.Show("Saved!");
        }
    }
}
