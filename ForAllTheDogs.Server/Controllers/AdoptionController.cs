using ForAllTheDogs.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            _env = env;
            _configuration = configuration;
        }

        //Get All Pets Data
        [HttpGet]
        public JsonResult GetPets()
        {

        }

        //Get Individual Pet
        [HttpGet("{id}")]
        public JsonResult GetSinglePet()
        {

        }

        //Insert New Pet
        [HttpPost]
        public JsonResult PostPet(Adoption adp)
        {

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
