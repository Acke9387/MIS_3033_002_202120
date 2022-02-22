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

namespace JSON_FromAFile
{
    /// <summary>
    /// Interaction logic for WindowCarOwnerDetails.xaml
    /// </summary>
    public partial class WindowCarOwnerDetails : Window
    {
        public CarOwner Selected { get; set; }
        public WindowCarOwnerDetails()
        {
            InitializeComponent();
        }

        public void PopulateData(CarOwner c)
        {
            txtColor.Text = c.Color;
            txtMake.Text = c.Make;
            txtModel.Text = c.Model;
            txtYear.Text = c.Year.ToString("G0");
            lblTitle.Content = $"{c.FirstName} {c.LastName}'s Car Details";

        }
    }
}
