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
    /// Interaction logic for user_info.xaml
    /// </summary>
    public partial class user_info : Window
    {
        public user_info()
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
                string Query = "insert into users values(default, @user_name, @user_type, @password, @gender, @id_number, @birthday, @phone_number)";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@user_name", user_name.Text);
                cmd.Parameters.AddWithValue("@user_type", user_type.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@gender", gender.Text);
                cmd.Parameters.AddWithValue("@id_number", int.Parse(id_number.Text));
                cmd.Parameters.AddWithValue("@birthday", DateTime.Parse(birthday.Text));
                cmd.Parameters.AddWithValue("@phone_number", phone_number.Text);
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

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();
                string Query = "select * from users where id=@Id";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(search.Text));
                bool noData = true;
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    noData = false;
                    user_id.Text = dr["id"].ToString();
                    user_name.Text = dr["user_name"].ToString();
                    user_type.Text = dr["user_type"].ToString();
                    password.Text = dr["password"].ToString();
                    gender.Text = dr["gender"].ToString();
                    id_number.Text = dr["id_number"].ToString();
                    birthday.Text = dr["birthday"].ToString();
                    phone_number.Text = dr["phone_number"].ToString();
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
                string Query = "Update users set user_name=@user_name, user_type=@user_type, password=@password, gender=@gender, id_number=@id_number,birthday=@birthday, phone_number=@phone_number where id=@ID";
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@user_name", user_name.Text);
                cmd.Parameters.AddWithValue("@user_type", user_type.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@gender", gender.Text);
                cmd.Parameters.AddWithValue("@id_number", int.Parse(id_number.Text));
                cmd.Parameters.AddWithValue("@birthday", DateTime.Parse(birthday.Text));
                cmd.Parameters.AddWithValue("@phone_number", int.Parse(phone_number.Text));
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
                string Query = "delete from users where user_id=@ID";
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
