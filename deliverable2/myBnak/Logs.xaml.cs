using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Logs.xaml
    /// </summary>
    public partial class Logs : Window
    {
        public Logs()
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
        private void insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();
                string Query = "INSERT INTO log (log_type, user_id, user_name, operation_detail, operation_date, ip_address) VALUES (@log_type, @user_id, @user_name, @operation_detail, @operation_date, @ip_address)";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@log_type", log_type.Text);
                cmd.Parameters.AddWithValue("@user_id", int.Parse(user_id.Text));
                cmd.Parameters.AddWithValue("@user_name", user_name.Text);
                cmd.Parameters.AddWithValue("@operation_detail", operation_detail1.Text);
                cmd.Parameters.AddWithValue("@operation_date", DateTime.Parse(operation_date.Text));
                cmd.Parameters.AddWithValue("@ip_address", ip_address.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("User Created Successfully");
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void show_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();
                string Query = "select * from log";
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

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();
                string Query = "select * from log where user_id=@Id";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(search.Text));
                bool noData = true;
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    noData = false;
                    id.Text = dr["id"].ToString();
                    log_type.Text = dr["log_type"].ToString();
                    user_id.Text = dr["user_id"].ToString();
                    user_name.Text = dr["user_name"].ToString();
                    operation_detail1.Text = dr["operation_detail"].ToString();
                    operation_date.Text = dr["operation_date"].ToString();
                    ip_address.Text = dr["ip_address"].ToString();

                }
                if (noData)
                {
                    MessageBox.Show("No user with that id is present");
                }
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();
                string Query = "Update log set log_type=@log_type, user_id=@user_id, user_name=@user_name, operation_detail=@operation_detail, operation_date=@operation_date,ip_address=@ip_address where user_id=@ID";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@log_type", log_type.Text);
                cmd.Parameters.AddWithValue("@user_id", int.Parse(user_id.Text));
                cmd.Parameters.AddWithValue("@user_name", user_name.Text);
                cmd.Parameters.AddWithValue("@operation_detail", operation_detail1.Text);
                cmd.Parameters.AddWithValue("@operation_date", DateTime.Parse(operation_date.Text));
                cmd.Parameters.AddWithValue("@ip_address", ip_address.Text);
                cmd.Parameters.AddWithValue("@ID", int.Parse(search.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update successful");
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();
                string Query = "delete from log where id=@ID";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(search.Text));
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
