using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web.API.Models;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> _herous = new List<SuperHero>
        {
            new SuperHero{ Id = 1, Name = "Spider Man", FirstName = "Peter", LastName = "Parker", Place = "New York City"},

            new SuperHero{ Id = 2, Name = "Batman", FirstName = "Bruce", LastName = "Wayne", Place = "Gotham City"}
        };


        /// <summary>
        /// Retuns all super heroes a
        /// </summary>
        /// <returns>
        /// <response code="200">Successful operation</response>
        /// <response code="404">Anomaly not found</response>
        /// <response code="500">Server side found a error</response>
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SuperHero>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(_herous);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(SuperHero hero)
        {
            _herous.Add(hero);
            return Created($"/{hero.Id} info", hero);
        }
    }
}