using backend.Services;

namespace backend.Models
{
    public class GameState
    {
        public List<Player> Players { get; } = new List<Player>();
        public RoundState RoundState { get; set; } = new RoundState();

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
    }
}
