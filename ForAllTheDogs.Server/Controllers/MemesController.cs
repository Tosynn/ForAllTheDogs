using ForAllTheDogs.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ForAllTheDogs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public MemesController(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        //Get All Memes Data
        [HttpGet]
        public JsonResult GetMemes()
        {
            string query = "select * from dbo.Memes";
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
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        //Get Individual Meme
        [HttpGet("{id}")]
        public JsonResult GetSingleMeme(int id)
        {
            string query = "select memeId, memePhotoFileName where memeId = @memeId";
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
                    myCommand.Parameters.AddWithValue("@memeId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        //Insert New Meme
        [HttpPost]
        public JsonResult PostMeme(Adoption adp)
        {

        }

        //Update Meme Data
        [HttpPut]
        public JsonResult PutMeme(Adoption adp)
        {

        }

        //Delete Meme Data
        [HttpDelete]

        public JsonResult DeleteMeme(Adoption adp)
        {

        }
    }
}
