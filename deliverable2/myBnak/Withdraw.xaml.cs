using Npgsql;
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
    /// Interaction logic for Withdraw.xaml
    /// </summary>
    public partial class Withdraw : Window
    {
        public Withdraw()
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
                if (decimal.TryParse(txtAmount.Text, out decimal withdrawalAmount))
                {
                    bool withdrawalSuccess = PerformWithdrawal(accountNumber, withdrawalAmount);

                    if (withdrawalSuccess)
                    {
                        MessageBox.Show("Withdrawal successful.");
                    }
                    else
                    {
                        MessageBox.Show("Withdrawal failed. Check the account number and balance.");
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

        private bool PerformWithdrawal(string accountNumber, decimal withdrawalAmount)
        {
            {
                try
                {
                    establishConnect();
                    con.Open();
                    string Query = "UPDATE bank_account SET balance = balance - @withdrawalAmount WHERE card_number = @accountNumber";
                    cmd = new NpgsqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@withdrawalAmount", withdrawalAmount);
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
}

