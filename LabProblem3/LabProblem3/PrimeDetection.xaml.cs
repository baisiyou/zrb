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

namespace LabProblem3
{
    /// <summary>
    /// Interaction logic for PrimeDetection.xaml
    /// </summary>
    public partial class PrimeDetection : Window
    {
        public PrimeDetection()
        {
            InitializeComponent();
        }

        private void Prime_Detection_Click(object sender, RoutedEventArgs e)
        {
            int variable = int.Parse(primeInput.Text);
            bool isPrime = true;

            for (int div = 2; div <= variable / 2; div++)
            {
                if (variable % div == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            result.IsEnabled = true;

            if (isPrime)
            {
                result.Content = "Prime Number !!!";
            }
            else
            {
                result.Content = "Non-Prime Number !!!";
            }

        }
    }
}
