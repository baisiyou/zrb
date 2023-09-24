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

namespace LabProblem4
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (radioOne.IsChecked == true)
            {
                Window1 populationprediction = new Window1();
                populationprediction.Show();
            }
            else if (radioTwo.IsChecked == true)
            {
                Window2 populationprediction = new Window2();
                populationprediction.Show();
            }
            else if (radioThree.IsChecked == true)
            {
                Window3 populationprediction = new Window3();
                populationprediction.Show();
            }
        }
    }
}
