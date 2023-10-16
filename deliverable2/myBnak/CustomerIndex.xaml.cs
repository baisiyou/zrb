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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = new SolidColorBrush(Colors.Red);
            Deposit deposit = new Deposit();
            deposit.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = new SolidColorBrush(Colors.Red);
            Withdraw withdraw = new Withdraw();
            withdraw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = new SolidColorBrush(Colors.Red);
            Transfer transfer = new Transfer();
            transfer.Show();
        }
    }
}
