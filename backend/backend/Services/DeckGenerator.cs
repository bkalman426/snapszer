using backend.Models;

namespace backend.Services
{
    public static class DeckGenerator
    {
        public static List<Card> GenerateFullDeck()
        {
            var deck = new List<Card>();
            foreach(CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    deck.Add(new Card(suit, value));
                }
            }
            return deck;
        }
    }
}
