using Microsoft.AspNetCore.Mvc;
using Web.API.Models;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

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
            return Ok(await _context.SuperHeroes.ToListAsync());
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
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero is null) return BadRequest();

            return Ok(hero);
        }

        /// <summary>
        /// Create a super hero
        /// </summary>
        /// <returns>
        /// <response code="200">Successful operation</response>
        /// <response code="500">Server side found a error</response>
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(SuperHero input)
        {
            _context.SuperHeroes.Add(input);

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
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

            var hero = await _context.SuperHeroes.FindAsync(input.Id);

            if (hero is null) return BadRequest();

            hero.Name = input.Name;
            hero.FirstName = input.FirstName;
            hero.LastName = input.LastName;
            hero.Place = input.Place;

            _context.SuperHeroes.Update(hero);

            await _context.SaveChangesAsync();

            return Ok(hero);
        }

        /// <summary>
        /// Delete a super hero
        /// </summary>
        /// <returns>
        /// <response code="200">Successful operation</response>
        /// /// <response code="404">Anomaly not found</response>
        /// <response code="500">Server side found a error</response>
        /// </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero is null) return BadRequest();

            _context.SuperHeroes.Remove(hero);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}