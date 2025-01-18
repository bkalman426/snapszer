namespace backend.Models
{
    public class RoundState
    {
        public int Id { get; set; } = 0;
        public List<PlayedCard> PlayedCards { get; set; } = new List<PlayedCard>();
        public Player? CurrentPlayer { get; set; }
        public Player? StartingPlayer { get; set; }
        public Card? CalledCard {  get; set; }
        public int RoundNumber { get; set; } = 0;
    }
}
