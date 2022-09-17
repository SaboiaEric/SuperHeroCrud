using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Get specific super heroes
        /// </summary>
        /// <returns>
        /// <response code="200">Successful operation</response>
        /// <response code="404">Anomaly not found</response>
        /// <response code="500">Server side found a error</response>
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<SuperHero>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var hero = _herous.Find(x => x.Id == id);

            if (hero is null) return BadRequest();

            return Ok(hero);
        }

        /// <summary>
        /// Create a super hero
        /// </summary>
        /// <returns>
        /// <response code="201">Include successfully</response>
        /// <response code="500">Server side found a error</response>
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(SuperHero input)
        {
            _herous.Add(input);
            return Created($"/{input.Id}info", input);
        }

        /// <summary>
        /// Update a super hero
        /// </summary>
        /// <returns>
        /// <response code="200">Successful operation</response>
        /// <response code="404">Anomaly not found</response>
        /// <response code="500">Server side found a error</response>
        /// </returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(SuperHero input)
        {
            if (input is null) return BadRequest();

            var hero = _herous.Find(x => x.Id == input.Id);

            if (hero is null) return BadRequest();

            hero.Name = input.Name;
            hero.FirstName = input.FirstName;
            hero.LastName = input.LastName;
            hero.Place = input.Place;

            return Ok(hero);
        }
    }
}