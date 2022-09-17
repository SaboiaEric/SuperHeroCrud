using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.API.Models;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]       
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var heroes = new List<SuperHero>
            {
                new SuperHero{ Id = 1, Name = "Spider Man", FirstName = "Peter", LastName = "Parker", Place = "New York City"}
            };

            return Ok(heroes);
        }
    }
}
