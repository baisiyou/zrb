using System;
using System.Collections.Generic;
using System.Linq;
using LabProblem2.models;
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

namespace LabProblem2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private calc mnc { get; set; } = null;
        public MainWindow()
        {
            mnc = new calc();
            InitializeComponent();
        }

        private void DisplayShippingCharges(double charges)
        {
            lblResult.Text = $"Shipping Charges: ${charges:F2}";
        }

        private void ShowInvalidInputMessage()
        {
            lblResult.Text = "Invalid input. Please enter valid numbers.";
        }

      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtWeight.Text, out double weight) &&
                 double.TryParse(txtDistance.Text, out double distance))
            {
                double shippingCharges = mnc.CalculateShippingCharges(weight, distance);
                DisplayShippingCharges(shippingCharges);
            }
            else
            {
                ShowInvalidInputMessage();
            }
        }
    }
}
