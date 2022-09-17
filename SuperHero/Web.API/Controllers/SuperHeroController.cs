using Microsoft.AspNetCore.Mvc;
using Web.API.Models;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SuperHeroController : ControllerBase
    {
        /// <summary>
        /// Retuns all super heroes
        /// </summary>
        /// <returns>
        /// <response code="200">Successful operation</response>
        /// <response code="404">Anomaly not found</response>
        /// <response code="500">Server side found a error</response>
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SuperHero>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
