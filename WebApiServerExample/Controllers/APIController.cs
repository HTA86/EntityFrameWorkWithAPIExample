using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GamesController(IGamesRepository _gamesRepository) : ControllerBase
    {
        [HttpGet]
        public async Task <ActionResult<IEnumerable<GameEntity>>> GetGamesAsync()
        {
            var games = await _gamesRepository.GetAllGamesAsync();
            if (games is null)
                return BadRequest("Inga spel i databas.");

            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GameEntity>>> GetGameByIdAsync(int id)
        {
            var games = await _gamesRepository.GetGameByIdAsync(id);
            if (games is null)
                return BadRequest("Spelet hittades inte");

            return Ok(games);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<GameEntity>>> GetGameByTitleAsync([FromQuery] string title)
        {
            Console.WriteLine($"Söker efter spel med titel: {title}");
            if (string.IsNullOrEmpty(title))
                return BadRequest("Title is required for search.");

            var games = await _gamesRepository.GetGameByTitleAsync(title);
            if (games is null)
                return BadRequest("Spelet hittades inte");

            return Ok(games);
        }
    }
}
