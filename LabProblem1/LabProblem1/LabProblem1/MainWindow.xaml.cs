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

namespace LabProblem1
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

        private void CalculateFees_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtBalance.Text, out double endingBalance) &&
                int.TryParse(txtChecks.Text, out int numberOfChecks))
            {
                double serviceFees = CalculateServiceFees(endingBalance, numberOfChecks);
                lblResult.Text = $"Service Fees for the Month: ${serviceFees:F2}";
            }
            else
            {
                lblResult.Text = "Invalid input. Please enter valid numbers.";
            }
        }

        private double CalculateServiceFees(double endingBalance, int numberOfChecks)
        {
            const double monthlyCharge = 10.0;
            double checkFee = 0.0;

            if (numberOfChecks < 20)
            {
                checkFee = numberOfChecks * 0.10;
            }
            else if (numberOfChecks >= 20 && numberOfChecks <= 39)
            {
                checkFee = numberOfChecks * 0.08;
            }
            else if (numberOfChecks >= 40 && numberOfChecks <= 59)
            {
                checkFee = numberOfChecks * 0.06;
            }
            else if (numberOfChecks >= 60)
            {
                checkFee = numberOfChecks * 0.10;
            }

            if (endingBalance < 400)
            {
                checkFee += 15.0;
            }

            return monthlyCharge + checkFee;
        }
    }
}
