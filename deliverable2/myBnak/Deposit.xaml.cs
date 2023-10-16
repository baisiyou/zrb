using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Xml.Linq;

namespace myBnak
{
    /// <summary>
    /// Interaction logic for Deposit.xaml
    /// </summary>
    public partial class Deposit : Window
    {
        public Deposit()
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
            string accountNumber = txtAccountNumber.Text;
            if (!string.IsNullOrWhiteSpace(accountNumber))
            {
                if (decimal.TryParse(txtAmount.Text, out decimal depositAmount))
                {
                    bool depositSuccess = PerformDeposit(accountNumber, depositAmount);

                    if (depositSuccess)
                    {
                        MessageBox.Show("Deposit successful.");
                    }
                    else
                    {
                        MessageBox.Show("Deposit failed. Check the card number.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid amount. Please enter a valid number.");
                }
            }
            else
            {
                MessageBox.Show("Please enter the account number.");
            }
        }

        private bool PerformDeposit(string accountNumber, decimal depositAmount)
        {
            try
            {
                establishConnect();
                con.Open();
                string Query = "UPDATE bank_account SET balance = balance + @depositAmount WHERE card_number = @accountNumber";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@depositAmount", depositAmount);
                cmd.Parameters.AddWithValue("@accountNumber", int.Parse(accountNumber));
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Deposit Error: " + ex.Message);
                return false;
            }
        }
    }
}
