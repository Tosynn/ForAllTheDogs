using Azure.Core;
using ForAllTheDogs.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Runtime.Intrinsics.Arm;

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
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
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
        public JsonResult PostMeme(Memes mms)
        {
            string query = "insert into dbo.Memes (memePhotoName, dateCreated) values (@memePhotoName, @dateCreated)";
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
                    myCommand.Parameters.AddWithValue("@memePhotoName", mms.memePhotoName);
                    myCommand.Parameters.AddWithValue("@dateCreated", mms.dateCreated);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Meme Added Successfully");

        }


        //Update Meme Data
        [HttpPut]
        public JsonResult PutMeme(Memes mms)
        {
            string query = "update dbo.Memes set memePhotoName = @memePhotoName, dateCreated = @dateCreated";
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
                    myCommand.Parameters.AddWithValue("@memeId", mms.memeId);
                    myCommand.Parameters.AddWithValue("@memePhotoName", mms.memePhotoName);
                    myCommand.Parameters.AddWithValue("@dateCreated", mms.dateCreated);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        //Delete Meme Data
        [HttpDelete]

        public JsonResult DeleteMeme(int id)
        {
            string query = "delete from dbo.Memes where memeId=@memeId";
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
            return new JsonResult("Deleted Succussfully");

        }

        //Save Images
        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/Memes/" + fileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(fileName);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }

    }

       
}
