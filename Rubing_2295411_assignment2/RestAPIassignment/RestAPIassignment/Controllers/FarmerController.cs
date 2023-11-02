using Microsoft.AspNetCore.Mvc;
using RestAPIassignment.Models;
using Npgsql;
namespace RestAPIassignment.Controllers
{
    
        [Route("[controller]")]
        [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public FarmerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllFarmers")]
        public Response GetAllFarmers()
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("farmerConnection"));
            DBApplication dbA = new DBApplication();
            response = dbA.GetAllFarmers(con);
            return response;
        }
        [HttpGet]
        [Route("GetFarmerbyId/{id}")]
        public Response
            GetStudentbyId(int id)
        {
            Response response = new Response();
            NpgsqlConnection con =
             new NpgsqlConnection(_configuration.GetConnectionString("farmerConnection"));
            DBApplication dbA = new DBApplication();
            response = dbA.GetFarmerbyId(con, id);
            return response;
        }
        [HttpPost]
        [Route("AddFarmer")]
        public Response AddFarmer(Farmer farmer)
        {
            Response response = new Response();
            NpgsqlConnection con =
            new NpgsqlConnection(_configuration.GetConnectionString("farmerConnection"));
            DBApplication dbA = new DBApplication();
            response = dbA.AddFarmer(con, farmer);
            return response;
        }
        [HttpPut] // to update any information in server, we either use put or post request
        [Route("UpdateFarmer")]
        public Response UpdateFarmer(Farmer farmer) 
        {
            Response response = new Response();
            NpgsqlConnection con =
                new NpgsqlConnection(_configuration.GetConnectionString("farmerConnection"));
            DBApplication dbA = new DBApplication();
            response = dbA.UpdateFarmer(con, farmer);
            return response;
        }
        [HttpDelete]
        [Route("DeleteFarmerbyId/{id}")]
        public Response DeleteFarmerbyId(int id)
        {
            Response response = new Response();
            NpgsqlConnection con =
                new NpgsqlConnection(_configuration.GetConnectionString("farmerConnection"));
            DBApplication dbA = new DBApplication();
            response = dbA.DeleteStudentbyId(con, id);
            return response;
        }
    }
}
