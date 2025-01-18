using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("call")]
        public IActionResult CallCard([FromBody] Card card)
        {
            _gameService.Call(card);
            return NoContent();
        }

        [HttpPost]
        public IActionResult PlayCard([FromBody] PlayedCard request)
        {
            try
            {
                _gameService.PlayCard(request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
