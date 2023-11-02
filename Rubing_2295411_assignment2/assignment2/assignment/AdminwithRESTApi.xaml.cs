using assignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
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
    /// Interaction logic for AdminwithRESTApi.xaml
    /// </summary>
    public partial class AdminwithRESTApi : Window
    {
        HttpClient client = new HttpClient();
        public AdminwithRESTApi()
        {
           
                client.BaseAddress = new Uri("https://localhost:7208/Farmer/");

                //Step 02: we need to clear the default network packet header informaiton
                client.DefaultRequestHeaders.Accept.Clear();

                // Step 03: Add our packet information to the http request
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                InitializeComponent();
            }
        

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Step 01: Create/ Call the method to get all the students
            var server_response = await client.GetStringAsync("GetAllFarmers");
            // step 02: Decrypt/extract the server_response

            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            dataGrid.ItemsSource = response_JSON.farmers;
            DataContext = this;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Step 01: Create/ Call the method to search out one student from the database
            var server_response =
                await client.GetStringAsync("GetFarmerbyId/" + int.Parse(search.Text));

            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            name.Text = response_JSON.farmer.product_name;
            id.Text = response_JSON.farmer.product_id.ToString();
            amount.Text = response_JSON.farmer.amount.ToString();
            price.Text = response_JSON.farmer.price.ToString();
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Farmer farmer = new Farmer();

            farmer.product_name = name.Text;
            farmer.product_id = int.Parse(id.Text);
            farmer.amount = int.Parse(amount.Text);
            farmer.price = Decimal.Parse(price.Text);

            // step 2: create the instance of the Response class 
            // and send the student using rest api to the remote database 
            // server

            // we are generating a Post request of the data to
            // database server
            var server_response =
                await client.PostAsJsonAsync("AddFarmer", farmer);

            // step 3: Get the response and extract it
            //Response response_JSON = 
            //    JsonConvert.DeserializeObject<Response>
            //   (server_response.ToString());
            MessageBox.Show(server_response.ToString());
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Farmer farmer = new Farmer();

            farmer.product_name = name.Text;
            farmer.product_id = int.Parse(id.Text);
            farmer.amount = int.Parse(amount.Text);
            farmer.price = Decimal.Parse(price.Text);


            var server_response =
                await client.PutAsJsonAsync("UpdateFarmer", farmer);
            MessageBox.Show(server_response.ToString());
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var response_JSON =
                await client.DeleteAsync("DeleteFarmerbyId/"
                + int.Parse(search.Text));

            MessageBox.Show(response_JSON.StatusCode.ToString());
            MessageBox.Show(response_JSON.RequestMessage.ToString());
        }
    }
}
