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

namespace assignment
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
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
                string Query = "INSERT INTO farmers (product_name, product_id, amount, price) VALUES (@product_name, @product_id, @amount, @price)";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@product_name", name.Text);
                cmd.Parameters.AddWithValue("@product_id", int.Parse(id.Text));
                cmd.Parameters.AddWithValue("@amount", decimal.Parse(amount.Text));
                cmd.Parameters.AddWithValue("@price", decimal.Parse(price.Text));

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

            try
            {
                establishConnect();
                con.Open();
                string Query = "select * from farmers where product_ID=@id";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@id", int.Parse(search.Text));
                bool noData = true;
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    noData = false;
                    name.Text = dr["product_name"].ToString();
                    id.Text = dr["product_id"].ToString();
                    amount.Text = dr["amount"].ToString();
                    price.Text = dr["price"].ToString();
                }

                dr.Close();

                if (noData)
                {
                    MessageBox.Show("No product with that id is present");
                }

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
                string Query = "Update students set product_name=@product_name, product_id=@product_id, amount=@amount, price=@price";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@product_name", name.Text);
                cmd.Parameters.AddWithValue("@product_id", int.Parse(id.Text));
                cmd.Parameters.AddWithValue("@amount", int.Parse(amount.Text));
                cmd.Parameters.AddWithValue("@price", decimal.Parse(price.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update successful");
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();
                string Query = "select * from farmers";
                cmd = new NpgsqlCommand(Query, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGrid.ItemsSource = dt.AsDataView(); // this line is going to copy the whole
                DataContext = da;
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();
                string Query = "delete from farmers where product_ID=@id";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@id", int.Parse(search.Text));
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
