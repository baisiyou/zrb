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

namespace myBnak
{
    /// <summary>
    /// Interaction logic for CustomerIndex.xaml
    /// </summary>
    public partial class CustomerIndex : Window
    {
        public CustomerIndex()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (radioOne.IsChecked == true)
            {
                bank_account bankaccount = new bank_account();
                bankaccount.Show();
            }
            else if (radioTwo.IsChecked == true)
            {
                Transaction transaction = new Transaction();
                  transaction.Show();
            }
            else if (radioTree.IsChecked == true)
            {
                New_Bank_Card newcard = new New_Bank_Card();
                newcard.Show();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

    }
}
