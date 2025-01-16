using backend.Models;

namespace backend.Services
{
    public static class ShuffleService
    {
        private static Random random = new Random();
        public static void ShuffleDeck(List<Card> cards)
        {
            for(int i = 0; i < cards.Count -1;  i++)
            {
                int k = random.Next(i+1);
                Card temp = cards[i];
                cards[i] = cards[k];
                cards[k] = temp;
            }
        }
    }
}
