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
    /// Interaction logic for populationPrediction.xaml
    /// </summary>
    public partial class populationPrediction : Window
    {
        public populationPrediction()
        {
            InitializeComponent();
        }
        private void Population_Growth_Click(object sender, RoutedEventArgs e)
        {
            int populationSize = int.Parse(populSize.Text);
            double increaseRate = double.Parse(incrRate.Text);
            int noofdays = int.Parse(comboBoxOne.Text);
            int daysPopulations = populationSize;
            for (int i = 1; i <= noofdays; i++)
            {
                double increasePopulation = (daysPopulations * increaseRate / 100);
                daysPopulations = (int)(daysPopulations + increasePopulation);
                MessageBox.Show("Day no" + i + "&predicted population:" + daysPopulations);
            }
        }
    }
}
