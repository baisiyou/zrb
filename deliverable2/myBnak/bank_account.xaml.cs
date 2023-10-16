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
using System.Xml.Linq;

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
        private void insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();
                string Query = "insert into bank_account values(default, @user_id, @card_number, @card_password, @balance,@isactive,@opened_date)";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@user_id", int.Parse(user_id.Text));
                cmd.Parameters.AddWithValue("@card_number", int.Parse(card_number.Text));
                cmd.Parameters.AddWithValue("@card_password", card_password.Text);
                cmd.Parameters.AddWithValue("@balance", decimal.Parse(balance.Text));
                cmd.Parameters.AddWithValue("@isactive", bool.Parse(isactive.Text));
                cmd.Parameters.AddWithValue("@opened_date", DateTime.Parse(opened_date.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Created Successfully");
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

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();
                string Query = "select * from bank_account where user_id=@Id";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(search.Text));
                bool noData = true;
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    noData = false;
                    id.Text = dr["id"].ToString();
                    user_id.Text = dr["user_id"].ToString();
                    card_number.Text = dr["card_number"].ToString();
                    card_password.Text = dr["card_password"].ToString();
                    balance.Text = dr["balance"].ToString();
                    isactive.Text = dr["isactive"].ToString();
                    opened_date.Text = dr["opened_date"].ToString();

                }
                if (noData)
                {
                    MessageBox.Show("No student with that id is present");
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
                string Query = "Update bank_account set @user_id, @card_number, @card_password, @balance,@isactive,@opened_date where user_id=@ID ";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@user_id", int.Parse(user_id.Text));
                cmd.Parameters.AddWithValue("@card_number", int.Parse(card_number.Text));
                cmd.Parameters.AddWithValue("@card_password", card_password.Text);
                cmd.Parameters.AddWithValue("@balance", decimal.Parse(balance.Text));
                cmd.Parameters.AddWithValue("@isactive", bool.Parse(isactive.Text));
                cmd.Parameters.AddWithValue("@opened_date", DateTime.Parse(opened_date.Text));
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
                string Query = "delete from bank_account where user_id=@ID";
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
