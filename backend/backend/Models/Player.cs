namespace backend.Models
{
    public class Player
    {
        private static int _idCounter = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Score { get; set; } = 0;
        public List<Card> Hand { get; } = new List<Card>();

        public Player(string name) {
            Id = _idCounter++;
            Name = name;
        }

        public void PlayCard(Card card)
        {
            Hand.Remove(card);
        }
    }
}
