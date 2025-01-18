using backend.Models;

namespace backend.Services
{
    public class RoundService
    {
        public CardSuit Trump {  get; set; }

        public List<Card> GetPlayableCards(RoundState state)
        {
            if(!state.PlayedCards.Any())
            {
                return state.CurrentPlayer.Hand;
            }

            CardSuit suit = state.PlayedCards[0].Card.Suit;
            var playedCards = state.PlayedCards.Select(x => x.Card).ToList();
            var highestCard = GetHighestCard(playedCards);
            var rules = new List<Func<List<Card>, List<Card>>>
            {
                h => GetCardsMatchingSuitAndHigher(h, suit, highestCard),
                h => GetCardsMatchingSuit(h, suit),
                h => GetTrumpCardsAndHigher(h, highestCard),
                h => GetTrumpCards(h),
                h => h
            };

            foreach (var rule in rules)
            {
                var result = rule(state.CurrentPlayer.Hand);
                if (result.Any())
                {
                    return result;
                }
            }

            return new List<Card>();
        }

        public void StartRound(RoundState round, Player starter)
        {
            round.PlayedCards.Clear();
            round.StartingPlayer = starter;
            round.CurrentPlayer = round.StartingPlayer;
            round.RoundNumber++;
        }

        // Azonos színű és magasabb lapok
        private List<Card> GetCardsMatchingSuitAndHigher(List<Card> hand, CardSuit suit, Card highestCard)
        {
            return hand.Where(card => card.Suit == suit && GetHigherCard(card, highestCard, suit) == card).ToList();
        }

        // Azonos színű lapok
        private List<Card> GetCardsMatchingSuit(List<Card> hand, CardSuit suit)
        {
            return hand.Where(card => card.Suit == suit).ToList();
        }

        // Adu és magasabb lapok
        private List<Card> GetTrumpCardsAndHigher(List<Card> hand, Card highestCard)
        {
            return hand.Where(card => card.Suit == Trump && GetHigherCard(card, highestCard, Trump) == card).ToList();
        }

        // Adu lapok
        private List<Card> GetTrumpCards(List<Card> hand)
        {
            return hand.Where(card => card.Suit == Trump).ToList();
        }

        private Card GetHighestCard(List<Card> cards)
        {
            var bottom = cards[0];
            var highest = bottom;

            foreach(var card in cards)
            {
                highest = GetHigherCard(card, highest, bottom.Suit);
            }
            
            return highest;
        }

        private Card GetHigherCard(Card card1, Card card2, CardSuit suit)
        {
            if(card1.Suit == card2.Suit)
            {
                return card1.Number > card2.Number ? card1 : card2;
            }
            else if(card1.Suit == Trump)
            {
                return card1;
            }
            else if(card2.Suit == Trump)
            {
                return card2;
            }
            else if(card1.Suit == suit)
            {
                return card1;
            }
            else
            {
                return card2;
            }
        }

        public int DetermineWinner(RoundState state)
        {
            var playedCards = state.PlayedCards.Select(x => x.Card).ToList();
            var highestCard = GetHighestCard(playedCards);
            var winner = state.PlayedCards.Where(c =>  c.Card == highestCard).Select(c => c.PlayerId).SingleOrDefault();
            return winner;
        }

        public void NextPlayer(RoundState roundState, List<Player> players)
        {
            var currentIndex = players.FindIndex(p => p.Id == roundState.CurrentPlayer.Id);
            if (currentIndex == -1)
            {
                throw new InvalidOperationException("Current player not found in the player list.");
            }

            var nextIndex = (currentIndex + 1) % players.Count;
            roundState.CurrentPlayer = players[nextIndex];
        }

        public void PlayCard(RoundState roundState, PlayedCard card)
        {
            if(roundState.CurrentPlayer == null)
            {
                throw new NullReferenceException();
            }
            if(roundState.CurrentPlayer.Id != card.PlayerId)
            {
                throw new InvalidOperationException();
            }
            if(!GetPlayableCards(roundState).Contains(card.Card))
            {
                throw new ArgumentException();
            }

            roundState.PlayedCards.Add(card);
            roundState.CurrentPlayer.Hand.Remove(card.Card);
        }
    }
}
