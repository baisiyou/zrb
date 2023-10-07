using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

namespace assignment
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        public Sales()
        {
            InitializeComponent();
        }
        public static NpgsqlConnection con;
        public static NpgsqlCommand cmd;
        private void establishConnect()
        {
            try
            {
                con = new NpgsqlConnection(get_ConnectionString());
                MessageBox.Show("Connection Established");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string get_ConnectionString()
        {
            string host = "Host=localhost;";
            string port = "Port=5432;";
            string dbName = "Database=zrb;";
            string userName = "Username=postgres;";
            string password = "Password=0911;";
            string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return connectionString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double appleQty = double.Parse(AppleTextBox.Text);
                double raspberryQty = double.Parse(RaspberryTextBox.Text);
                double cauliflowerQty = double.Parse(CauliflowerTextBox.Text);
                double orangeQty = double.Parse(OrangeTextBox.Text);
                double blueberryQty = double.Parse(BlueberryTextBox.Text);

                double applePrice = 2.10;
                double raspberryPrice = 2.35;
                double cauliflowerPrice = 2.22;
                double orangePrice = 2.49;
                double blueberryPrice = 1.45;

                double totalSalesAmount = (appleQty * applePrice) + (raspberryQty * raspberryPrice) + (cauliflowerQty * cauliflowerPrice)
                    + (orangeQty * orangePrice) + (blueberryQty * blueberryPrice);

                // Display the total sales amount
                TotalSalesTextBox.Text = totalSalesAmount.ToString();

                string connectionString = get_ConnectionString();

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Update inventory in the database
                    string updateQuery = $"UPDATE farmers SET amount = amount - {appleQty} WHERE product_name = 'Apple';";
                    updateQuery += $"UPDATE farmers SET amount = amount - {raspberryQty} WHERE product_name = 'Raspberry';";
                    updateQuery += $"UPDATE farmers SET amount = amount - {cauliflowerQty} WHERE product_name = 'Cauliflower';";
                    updateQuery += $"UPDATE farmers SET amount = amount - {orangeQty} WHERE product_name = 'Orange';";
                    updateQuery += $"UPDATE farmers SET amount = amount - {blueberryQty} WHERE product_name = 'Blueberry';";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                // Handle exceptions
                MessageBox.Show(ex.Message);
            }

            // Clear the input fields or perform other necessary actions for the next customer
            AppleTextBox.Clear();
            RaspberryTextBox.Clear();
            CauliflowerTextBox.Clear();
            OrangeTextBox.Clear();
            BlueberryTextBox.Clear();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}

