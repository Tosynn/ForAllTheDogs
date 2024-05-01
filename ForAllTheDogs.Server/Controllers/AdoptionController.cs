using ForAllTheDogs.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ForAllTheDogs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public AdoptionController(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        //Get All Pets Data
        [HttpGet]
        public JsonResult GetPets()
        {
            string query = "select * from dbo.Adoption";
            DataTable table = new DataTable();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query,myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        //Get Individual Pet
        [HttpGet("{id}")]
        public JsonResult GetSinglePet(int id)
        {
            string query = "select petId, petName, petDescription, petBreed, petPhotoFileName, petAge where petId = @petId";
            DataTable table = new DataTable();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@petId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

    }

        //Insert New Pet
        [HttpPost]
        public JsonResult PostPet(Adoption adp)
        {
            string query = "insert into dbo.Adoption (petDescription, petBreed, petPhotoFileName, petAge) values (@petDescription, @petBreed, @petPhotoFileName, @petAge)";
            DataTable table = new DataTable();
    #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
    #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@petDescription", adp.petDescription);
                    myCommand.Parameters.AddWithValue("@petBreed", adp.petBreed);
                    myCommand.Parameters.AddWithValue("@petPhotoFileName", adp.petPhotoFileName);
                    myCommand.Parameters.AddWithValue("@petAge", adp.petAge);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Pet Added Successfully");

        }

        //Update Pet Data
        [HttpPut]
        public JsonResult PutPet(Adoption adp)
        {

        }

        //Delete Pet Data
        [HttpDelete]

        public JsonResult DeletePet(Adoption adp)
        {

        }
        
    }
}
