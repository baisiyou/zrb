using myBnak;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
    /// Interaction logic for Transfer.xaml
    /// </summary>
    public partial class Transfer : Window
    {
        public Transfer()
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
        private bool PerformTransfer(string fromAccount, string toAccount, decimal amount)
        {
            try
            {
                establishConnect();
                con.Open();
                string QueryFrom = "UPDATE bank_account SET balance = balance - @amount WHERE card_number = @fromAccount";
                string QueryTo = "UPDATE bank_account SET balance = balance + @amount WHERE card_number = @toAccount";
               cmd = new NpgsqlCommand(QueryFrom, con);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@fromAccount", int.Parse(fromAccount));
                cmd.ExecuteNonQuery();

                cmd = new NpgsqlCommand(QueryTo, con);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@toAccount", int.Parse(toAccount));
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Transfer Error: " + ex.Message);
                return false;
            }
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string fromAccount = txtFromAccount.Text;
            string toAccount = txtToAccount.Text;
            if (!string.IsNullOrWhiteSpace(fromAccount) && !string.IsNullOrWhiteSpace(toAccount))
            {
                if (decimal.TryParse(txtAmount.Text, out decimal amount))
                {
                    bool transferSuccess = PerformTransfer(fromAccount, toAccount, amount);

                    if (transferSuccess)
                    {
                        MessageBox.Show("Money transfer successful.");
                    }
                    else
                    {
                        MessageBox.Show("Money transfer failed. Check account numbers and balance.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid amount. Please enter a valid number.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in both account numbers.");
            }
        }
    }
}
