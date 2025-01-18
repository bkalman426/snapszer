using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly GameService _gameService;
        public PlayerController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("{id}")]
        public ActionResult<Player> GetByID(int id)
        {
            var player = _gameService.GetPlayer(id);
            return Ok(player);
        }

        [HttpPost]
        public IActionResult Join([FromBody] string name)
        {
            try
            {
                Player player = new Player(name);
                _gameService.Join(player);

                return CreatedAtAction(nameof(GetByID), new { id = player.Id }, player);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}/hand")]
        public ActionResult<List<Card>> GetCards(int id)
        {
            return Ok(_gameService.GetPlayerHand(id));
        }
    }
}
