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

namespace JSON_FromAFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CarOwner> Owners;

        public MainWindow()
        {
            InitializeComponent();

            string json = File.ReadAllText("Mock_Data_Car_Owners.json");
            Owners = JsonConvert.DeserializeObject<List<CarOwner>>(json);

            cboColors.Items.Add("All");
            cboColors.SelectedIndex = 0;

            foreach (CarOwner owner in Owners)
            {
                if (cboColors.Items.Contains(owner.Color) == false)
                {
                    cboColors.Items.Add(owner.Color);
                }

                lstOwners.Items.Add(owner);
            }



        }

        private void cboColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string color = cboColors.SelectedItem.ToString();
            lstOwners.Items.Clear();

            foreach (CarOwner owner in Owners)
            {
                if (owner.Color == color)
                {
                    lstOwners.Items.Add(owner);
                }
                else if (color == "All")
                {
                    lstOwners.Items.Add(owner);
                }
            }


        }

        private void lstOwners_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CarOwner selected = (CarOwner)lstOwners.SelectedItem;

            WindowCarOwnerDetails wnd = new WindowCarOwnerDetails();
            wnd.PopulateData(selected);
            wnd.Selected = selected;
            wnd.ShowDialog();
        }
    }
}
