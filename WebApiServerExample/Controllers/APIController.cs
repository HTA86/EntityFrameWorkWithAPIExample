using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GamesController(IGamesRepository _gamesRepository) : ControllerBase
    {
        // Hämta alla spel eller filtrera via title
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameEntity>>> GetGamesAsync([FromQuery] string? title = null)
        {

            if (!string.IsNullOrEmpty(title))
            {
                // Om title är specificerat, filtrera på det
                var games = await _gamesRepository.GetGameByTitleAsync(title);
                if (games is null)
                    return NotFound($"Inga spel hittades med titeln: {title}");

                return Ok(games);
            }

            // Om inget title ges, hämta alla spel
            var allGames = await _gamesRepository.GetAllGamesAsync();
            if (allGames is null)
                return BadRequest("Inga spel i databas.");

            return Ok(allGames);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GameEntity>>> GetGameByIdAsync(int id)
        {
            var games = await _gamesRepository.GetGameByIdAsync(id);
            if (games is null)
                return BadRequest("Spelet hittades inte");

            return Ok(games);
        }

    }
}
