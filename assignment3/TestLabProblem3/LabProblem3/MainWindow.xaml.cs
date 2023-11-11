using LabProblem3.models;
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

namespace LabProblem3
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

        private void Population_Growth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int populationSize = int.Parse(populSize.Text);
                double increaseRate = double.Parse(incrRate.Text);
                int noofdays = int.Parse(comboBoxOne.Text);
                for (int i = 1; i <= noofdays; i++)
                {

                    int finalPopulation = mnc.CalculatePopulation(populationSize, increaseRate, noofdays);
                    MessageBox.Show("Day no " + i + " & predicted population: " + finalPopulation);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid input for population size, increase rate, and number of days.");
            }
        }
    }
}

