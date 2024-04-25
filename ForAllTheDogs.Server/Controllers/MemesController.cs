using ForAllTheDogs.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        }

        //Get Individual Meme
        [HttpGet("{id}")]
        public JsonResult GetSingleMeme()
        {

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
