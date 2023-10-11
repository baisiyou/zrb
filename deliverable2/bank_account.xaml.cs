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
    /// Interaction logic for bank_account.xaml
    /// </summary>
    public partial class bank_account : Window
    {
        public bank_account()
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
      

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
try
            {
                establishConnect();
                con.Open();
                string Query = "insert into bank_account values(@account_number,@account_holder_name,@account_type,@balance,@opened_date,@branch_location,@is_active)";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@account_number", int.Parse(account_number1.Text));
                cmd.Parameters.AddWithValue("@account_holder_name", account_holder_name.Text);
                cmd.Parameters.AddWithValue("@account_type", account_type.Text);
                cmd.Parameters.AddWithValue("@balance", decimal.Parse(balance.Text));
                cmd.Parameters.AddWithValue("@opened_date", DateTime.Parse(opened_date.Text));
                cmd.Parameters.AddWithValue("@branch_location", branch_location.Text);
                cmd.Parameters.AddWithValue("@is_active", bool.Parse(is_active.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Transaction Successfully");
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
