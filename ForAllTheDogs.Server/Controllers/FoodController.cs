using ForAllTheDogs.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForAllTheDogs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public FoodController(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        //Get All Foods Data
        [HttpGet]
        public JsonResult GetFoods()
        {

        }

        //Get Individual Food
        [HttpGet("{id}")]
        public JsonResult GetSingleFood()
        {

        }

        //Insert New Food
        [HttpPost]
        public JsonResult PostFood(Adoption adp)
        {

        }

        //Update Food Data
        [HttpPut]
        public JsonResult PutFood(Adoption adp)
        {

        }

        //Delete Food Data
        [HttpDelete]

        public JsonResult DeleteFood(Adoption adp)
        {

        }
    }
}
