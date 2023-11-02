using Npgsql;
using System.Data;

namespace RestAPIassignment.Models
{
    public class DBApplication
    {
        public Response GetAllFarmers(NpgsqlConnection con)
        {
            string Query = "Select * from farmers";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            List<Farmer> farmers = new List<Farmer>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Farmer farmer = new Farmer();
                    farmer.product_name = (string)dt.Rows[i]["product_name"];
                    farmer.product_id = (int)dt.Rows[i]["product_id"];
                    farmer.amount = (int)dt.Rows[i]["amount"];
                    farmer.price = (decimal)dt.Rows[i]["price"];
                    farmers.Add(farmer);
                }

            }
                if (farmers.Count > 0)
                {
                    response.statusCode = 200;
                    response.messageCode = "Data Retrieved Successfully";
                    response.farmer = null;
                    response.farmers = farmers;
                }
                else
                {
                    response.statusCode = 100;
                    response.messageCode = "Data failed to Retrieve or may be table is empty";
                    response.farmer = null;
                    response.farmers = null;
                }
                return response;
            }
        

        public Response GetFarmerbyId(NpgsqlConnection con, int id)
        {
            Response response = new Response();
            string Query = "Select* from farmers where product_id = '" + id + "'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Farmer farmer = new Farmer();
                farmer.product_name = (string)dt.Rows[0]["product_name"];
                farmer.product_id = (int)dt.Rows[0]["product_id"];
                farmer.amount = (int)dt.Rows[0]["amount"];
                farmer.price = (Decimal)dt.Rows[0]["price"];
                response.statusCode = 200;
                response.messageCode = "Successfully Retrieved";
                response.farmer = farmer;
                response.farmers = null;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Data couldn't found.. check the id";
                response.farmers = null;
                response.farmer = null;
            }
            return response;
        }
        public Response AddFarmer(NpgsqlConnection con, Farmer farmer)
        {
            con.Open();
            Response response = new Response();
            string Query = "insert into farmers values(@product_name, default, @amount, " +
                "@price )";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@product_name", farmer.product_name);
            cmd.Parameters.AddWithValue("@product_id", farmer.product_id);
            cmd.Parameters.AddWithValue("@amount", farmer.amount);
            cmd.Parameters.AddWithValue("@price", farmer.price);

            int i = cmd.ExecuteNonQuery();


            if (i > 0) // that means, the command is executed successfully
            {
                response.statusCode = 200;
                response.messageCode = "Successfully inserted";
                response.farmer = farmer;
                response.farmers = null;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Insertion is not successfull";
                response.farmer = null;
                response.farmers = null;
            }
            con.Close();
            return response;
        }
        public Response UpdateFarmer(NpgsqlConnection con, Farmer farmer)
        {
            con.Open();
            Response response = new Response();
            string Query = "Update farmers set product_name=@product_name, product_id=@product_id" +
                ",amount=@amount,price=@price where product_id=@product_id";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@product_name", farmer.product_name);
            cmd.Parameters.AddWithValue("@product_id", farmer.product_id);
            cmd.Parameters.AddWithValue("@amount", farmer.amount);
            cmd.Parameters.AddWithValue("@price", farmer.price);

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Updated Successfully";
                response.farmer = farmer;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Update failed or id wasn't in correct form";
            }
            con.Close();
            return response;
        }
        public Response DeleteStudentbyId(NpgsqlConnection con, int id)
        {
            con.Open();
            Response response = new Response();
            string Query = "Delete from farmers where product_id='" + id + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);

            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = " Delected Successfully";
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "not found!!! Could perform delete Ops";
            }
            con.Close();
            return response;
        }
    }
}
