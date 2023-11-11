using LabProblem1.models;
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
        private cal mnc { get; set; } = null;
        public MainWindow()
        {
            mnc = new cal();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           if (double.TryParse(txtBalance.Text, out double endingBalance) &&
                int.TryParse(txtChecks.Text, out int numberOfChecks))
            {
                double serviceFees = mnc.CalculateServiceFees(endingBalance, numberOfChecks);
                lblResult.Text = $"Service Fees for the Month: ${serviceFees:F2}";
            }
            else
            {
                lblResult.Text = "Invalid input. Please enter valid numbers.";
            }
        }
    }
}
