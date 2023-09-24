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

namespace LabProblem4
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void CalculateCharges_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtWeight.Text, out double weight) &&
                double.TryParse(txtDistance.Text, out double distance))
            {
                double shippingCharges = CalculateShippingCharges(weight, distance);
                DisplayShippingCharges(shippingCharges);
            }
            else
            {
                ShowInvalidInputMessage();
            }
        }

        private double CalculateShippingCharges(double weight, double distance)
        {
            double ratePer500Miles = 0.0;

            if (weight <= 2)
            {
                ratePer500Miles = 1.10;
            }
            else if (weight <= 6)
            {
                ratePer500Miles = 2.20;
            }
            else if (weight <= 10)
            {
                ratePer500Miles = 3.70;
            }
            else
            {
                ratePer500Miles = 4.80;
            }

            // Calculate charges for distances greater than 500 miles
            double charges = 0.0;
            if (500 < distance & distance < 1000)
            {
                double extraDistance = 500;
                double extraCharges = (extraDistance / 500) * ratePer500Miles;
                charges = ratePer500Miles + extraCharges;
            }
            else
            {
                charges = ratePer500Miles; // Use the fixed rate for distances less than or equal to 500 miles
            }

            return charges;
        }

        private void DisplayShippingCharges(double charges)
        {
            lblResult.Text = $"Shipping Charges: ${charges:F2}";
        }

        private void ShowInvalidInputMessage()
        {
            lblResult.Text = "Invalid input. Please enter valid numbers.";
        }
    }
}
