using backend.Models;

namespace backend.Services
{
    public class GameService
    {
        private GameState _gameState;
        private RoundService _roundService;

        public GameService()
        {
            _gameState = new GameState();
            _roundService = new RoundService();
        }

        private void InitializeGame()
        {
            var random = new Random();
            _gameState.RoundState.StartingPlayer = _gameState.Players[random.Next(4)];
        }

        public void StartGame()
        {
            if(_gameState.Players.Count < 4) 
            {
                throw new InvalidOperationException("Not enough players in the lobby!");
            }
            var deck = DeckGenerator.GenerateFullDeck();
            ShuffleService.ShuffleDeck(deck);
            for (int i = 0; i < deck.Count; i++)
            {
                _gameState.Players[i % 4].Hand.Add(deck[i]);
            }
            var index = _gameState.Players.FindIndex(p => p.Id == _gameState.RoundState.StartingPlayer.Id);
            var nextIndex = (index + 1) % _gameState.Players.Count;
            var starter = _gameState.Players[nextIndex];
            _roundService.StartRound(_gameState.RoundState, starter);
        }

        public void Join(Player player)
        {
            if(_gameState.Players.Count >= 4)
            {
                throw new InvalidOperationException("The lobby is already full!");
            }

            _gameState.AddPlayer(player);

            if(_gameState.Players.Count == 4)
            {
                InitializeGame();
            }
        }

        public Player GetPlayer(int id) 
        {
            return _gameState.Players.Single(p => p.Id == id);
        }

        public void PlayCard(PlayedCard card)
        {
            _roundService.PlayCard(_gameState.RoundState ,card);

            if(_gameState.RoundState.PlayedCards.Count == 4)
            {
                EndRound();
            }
            else
            {
                _roundService.NextPlayer(_gameState.RoundState, _gameState.Players);
            }
        }

        public void Call(Card card)
        {
            _gameState.RoundState.CalledCard = card;
        }

        public Card GetCalledCard()
        {
            if( _gameState.RoundState.CalledCard == null)
            {
                throw new NullReferenceException("");
            }
            return _gameState.RoundState.CalledCard;
        }

        public void EndRound()
        {
            var winnerId = _roundService.DetermineWinner(_gameState.RoundState);
            var winner = _gameState.Players.Where(p => p.Id == winnerId).Single();
            if( winner != null )
            {
                winner.Score += _gameState.RoundState.PlayedCards.Select(c => c.Card.Number).Cast<int>().Sum();
                if(_gameState.RoundState.RoundNumber == 6)
                {
                    EndGame();
                }
                else
                {
                    _roundService.StartRound(_gameState.RoundState, winner);
                }
            }      
        }
        public void EndGame()
        {
            foreach(var player in _gameState.Players)
            {
                player.Score = 0;
            }
        }

        public List<Card> GetPlayerHand(int id)
        {
            var player = GetPlayer(id);

            if(_gameState.RoundState.CurrentPlayer == player && _gameState.RoundState.CalledCard == null)
            {
                return player.Hand.Take(3).ToList();
            }

            return player.Hand.ToList();
        }
    }
}
