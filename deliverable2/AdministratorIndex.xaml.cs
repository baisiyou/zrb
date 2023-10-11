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
                string Query = "insert into CustomerInfo values(@username,@password,@gender,@ID_card,@birthday,@phone_no,@card_no)";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@username", name.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@gender", gender.Text);
               
                cmd.Parameters.AddWithValue("@ID_card", int.Parse(IDcard.Text));
                cmd.Parameters.AddWithValue("@birthday", birthday.Text);
                cmd.Parameters.AddWithValue("@phone_no", int.Parse(phoneno.Text));
                cmd.Parameters.AddWithValue("@card_no", int.Parse(cardno.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Created Successfully");
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        try
            {
                establishConnect();
                con.Open();
                string Query = "select * from customerinfo";
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
                string Query = "delete from customerinfo where id_card=@card";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@card", int.Parse(IDcard.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successful");
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
