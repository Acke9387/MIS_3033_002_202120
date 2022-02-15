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

namespace WPF_Classes
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string msg = "";
            bool isDataValid = true;
            if (string.IsNullOrWhiteSpace(txtImage.Text))
            {
                //MessageBox.Show("You need to enter valid data for the image.");
                //return;

                msg += "You need to enter valid data for the image.\n";
                isDataValid =   false;
            }

            if (string.IsNullOrWhiteSpace(txtManufacturer.Text))
            {
                msg += "You need to enter valid data for the manufacturer.\n";
                isDataValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                msg += "You need to enter valid data for the name.\n";
                isDataValid = false;
            }

            double price;
            if (double.TryParse(txtPrice.Text, out price) == false)
            {
                msg += "You need to enter valid data for the price.\n";
                isDataValid = false;
            }

            if (isDataValid == false)
            {
                MessageBox.Show(msg);
                return;
            }

            Toy t = new Toy()
            {
                Image = txtImage.Text,
                Manufacturer = txtManufacturer.Text,
                Name = txtName.Text,
                Price = price
            };

            //t.Image = txtImage.Text; 

            lstToys.Items.Add(t);
        }

        private void lstToys_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Toy selectedToy = (Toy)lstToys.SelectedItem;

            imgToy.Source = new BitmapImage(new Uri(selectedToy.Image));
            MessageBox.Show(selectedToy.GetAisle());
        }
    }
}
