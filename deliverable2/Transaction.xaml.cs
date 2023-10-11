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
using System.Xml.Linq;

namespace myBnak
{
    /// <summary>
    /// Interaction logic for Transaction.xaml
    /// </summary>
    public partial class Transaction : Window
    {
        public Transaction()
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
                establishConnect();
                con.Open();
                string Query = "insert into Transaction values(@transaction_id,@account_number,@transaction_date,@transaction_type,@amount,@balance_after)";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@transaction_id", int.Parse(transaction_id.Text));
                cmd.Parameters.AddWithValue("@account_number", int.Parse(account_number.Text));
                cmd.Parameters.AddWithValue("@transaction_date", DateTime.Parse(transaction_date.Text));
                cmd.Parameters.AddWithValue("@transaction_type", transaction_type.Text);
                cmd.Parameters.AddWithValue("@amount", decimal.Parse(amount.Text));
                cmd.Parameters.AddWithValue("@balance_after", decimal.Parse(balance_after.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Transaction Successfully");
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
