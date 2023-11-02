using assignment.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
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
using System.Xml.Linq;

namespace assignment
{
    /// <summary>
    /// Interaction logic for SaleswithRESTApi.xaml
    /// </summary>
    public partial class SaleswithRESTApi : Window
    {
        HttpClient client = new HttpClient();
        public SaleswithRESTApi()
        {

            client.BaseAddress = new Uri("https://localhost:7208/Farmer/");

            //Step 02: we need to clear the default network packet header informaiton
            client.DefaultRequestHeaders.Accept.Clear();

            // Step 03: Add our packet information to the http request
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }



        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
                // Parse the quantities from the respective textboxes.
                int appleQty = int.Parse(appleamount.Text);
                int orangeQty = int.Parse(orangeamount.Text);
                int raspberryQty = int.Parse(raspberryamount.Text);
                int blueberryQty = int.Parse(blueberryamount.Text);
                int cauliflowerQty = int.Parse(caulifloweramount.Text);

                // Define prices for each item.
                decimal applePrice = 2.10m;
                decimal orangePrice = 2.49m;
                decimal raspberryPrice = 2.35m;
                decimal blueberryPrice = 1.45m;
                decimal cauliflowerPrice = 2.22m;

                // Calculate the total sales amount.
                decimal totalSalesAmount = (appleQty * applePrice) +
                                          (raspberryQty * raspberryPrice) +
                                          (cauliflowerQty * cauliflowerPrice) +
                                          (orangeQty * orangePrice) +
                                          (blueberryQty * blueberryPrice);

                // Display or use the totalSalesAmount as needed.

                // Display the total sales amount
                totalprice1.Text = totalSalesAmount.ToString();

            
        }

     

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            // Define a function to update a Farmer
            async Task UpdateFarmerAsync(HttpClient client, string idText, string nameText, string amountText, string priceText)
            {
                int id = int.Parse(idText);
                var serverResponse = await client.GetStringAsync("GetFarmerbyId/" + id);
                Response responseJSON = JsonConvert.DeserializeObject<Response>(serverResponse);

                Farmer farmer = new Farmer
                {
                    product_name = nameText,
                    product_id = id,
                    amount = responseJSON.farmer.amount - int.Parse(amountText),
                    price = Decimal.Parse(priceText)
                };

                var serverResponseUpdate = await client.PutAsJsonAsync("UpdateFarmer", farmer);
                MessageBox.Show(serverResponseUpdate.ToString());
            }

            // Usage example for apple
            await UpdateFarmerAsync(client, appleid.Text, applename.Text, appleamount.Text, appleprice.Text);

            // Usage example for orange
            await UpdateFarmerAsync(client, orangeid.Text, orangename.Text, orangeamount.Text, orangeprice.Text);
            await UpdateFarmerAsync(client, raspberryid.Text, raspberryname.Text, raspberryamount.Text, raspberryprice.Text);
            await UpdateFarmerAsync(client, blueberryid.Text, blueberryname.Text, blueberryamount.Text, blueberryprice.Text);
            await UpdateFarmerAsync(client, cauliflowerid.Text, cauliflowername.Text, caulifloweramount.Text, cauliflowerprice.Text);


        }
    }
}











