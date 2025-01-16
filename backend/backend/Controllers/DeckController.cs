using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        public DeckController() { }

        [HttpGet("generate")]
        public ActionResult<List<Card>> GenerateDeck()
        {
            var deck = DeckGenerator.GenerateFullDeck();
            ShuffleService.ShuffleDeck(deck);
            return Ok(deck);
        }
    }
}
