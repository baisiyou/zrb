using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for AdministratorIndex.xaml
    /// </summary>
    public partial class AdministratorIndex : Window
    {
        public AdministratorIndex()
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
                string Query = "select * from users";
                cmd = new NpgsqlCommand(Query, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGrid.ItemsSource = dt.AsDataView();
                DataContext = da;
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();
                string Query = "select * from bank_account";
                cmd = new NpgsqlCommand(Query, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGrid.ItemsSource = dt.AsDataView();
                DataContext = da;
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
                user_info userinfo = new user_info();
                userinfo.Show();
           
            }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Logs log = new Logs();
            log.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            bank_account bankaccount = new bank_account();
            bankaccount.Show();
        }
    }
    }

