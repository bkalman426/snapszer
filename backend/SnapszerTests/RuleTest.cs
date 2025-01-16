//using backend.Models;
//using backend.Services;

//namespace SnapszerTests
//{
//    public class RuleTest
//    {
//        private readonly RoundService _ruleSet = new RoundService();
//        [Fact]
//        public void NoPlayedCards()
//        {
//            _ruleSet.Trump = CardSuit.Makk;

//            var hand = new List<Card>
//            {
//                new Card(CardSuit.Makk, CardValue.Király),
//                new Card(CardSuit.Piros, CardValue.Kilenc),
//                new Card(CardSuit.Piros, CardValue.Felső),
//                new Card(CardSuit.Tök, CardValue.Tíz),
//                new Card(CardSuit.Zöld, CardValue.Király),
//                new Card(CardSuit.Tök, CardValue.Ász)
//            };

//            var result = _ruleSet.GetPlayableCards(new List<Card>(), hand);
//            Assert.NotNull(result);
//            Assert.Equal(result, hand);
//        }

//        [Fact]
//        public void SameSuitPlayedCardsNoTrumpInHand()
//        {
//            _ruleSet.Trump = CardSuit.Makk;

//            var hand = new List<Card>
//            {
//                new Card(CardSuit.Piros, CardValue.Király),
//                new Card(CardSuit.Piros, CardValue.Kilenc),
//                new Card(CardSuit.Piros, CardValue.Ász),
//                new Card(CardSuit.Tök, CardValue.Tíz),
//                new Card(CardSuit.Zöld, CardValue.Király),
//                new Card(CardSuit.Tök, CardValue.Ász)
//            };

//            var playedCards = new List<Card>
//            {
//                new Card(CardSuit.Piros, CardValue.Alsó),
//                new Card(CardSuit.Piros, CardValue.Felső)
//            };

//            var result = _ruleSet.GetPlayableCards(playedCards, hand);

//            Assert.NotNull(result);
//            Assert.Equal(2, result.Count);
//            Assert.Contains(new Card(CardSuit.Piros, CardValue.Király), result);
//            Assert.Contains(new Card(CardSuit.Piros, CardValue.Ász), result);
//        }

//        [Fact]
//        public void SameSuitPlayedCardsTrumpInHand()
//        {
//            _ruleSet.Trump = CardSuit.Makk;

//            var hand = new List<Card>
//            {
//                new Card(CardSuit.Piros, CardValue.Király),
//                new Card(CardSuit.Piros, CardValue.Kilenc),
//                new Card(CardSuit.Piros, CardValue.Ász),
//                new Card(CardSuit.Makk, CardValue.Tíz),
//                new Card(CardSuit.Zöld, CardValue.Király),
//                new Card(CardSuit.Tök, CardValue.Ász)
//            };

//            var playedCards = new List<Card>
//            {
//                new Card(CardSuit.Piros, CardValue.Alsó),
//                new Card(CardSuit.Piros, CardValue.Felső)
//            };

//            var result = _ruleSet.GetPlayableCards(playedCards, hand);

//            Assert.NotNull(result);
//            Assert.Equal(2, result.Count);
//            Assert.Contains(new Card(CardSuit.Piros, CardValue.Király), result);
//            Assert.Contains(new Card(CardSuit.Piros, CardValue.Ász), result);
//        }

//        [Fact]
//        public void HaveSameSuitAndTrumpInHand()
//        {
//            _ruleSet.Trump = CardSuit.Makk;

//            var hand = new List<Card>
//            {
//                new Card(CardSuit.Piros, CardValue.Király),
//                new Card(CardSuit.Piros, CardValue.Kilenc),
//                new Card(CardSuit.Piros, CardValue.Ász),
//                new Card(CardSuit.Makk, CardValue.Tíz),
//                new Card(CardSuit.Zöld, CardValue.Király),
//                new Card(CardSuit.Tök, CardValue.Ász)
//            };

//            var playedCards = new List<Card>
//            {
//                new Card(CardSuit.Piros, CardValue.Alsó),
//                new Card(CardSuit.Makk, CardValue.Felső)
//            };

//            var result = _ruleSet.GetPlayableCards(playedCards, hand);

//            Assert.NotNull(result);
//            Assert.Equal(3, result.Count);
//            Assert.Contains(new Card(CardSuit.Piros, CardValue.Király), result);
//            Assert.Contains(new Card(CardSuit.Piros, CardValue.Ász), result);
//            Assert.Contains(new Card(CardSuit.Piros, CardValue.Kilenc), result);
//        }

//        [Fact]
//        public void NoSameSuitOrTrump()
//        {
//            _ruleSet.Trump = CardSuit.Makk;

//            var hand = new List<Card>
//            {
//                new Card(CardSuit.Tök, CardValue.Király),
//                new Card(CardSuit.Tök, CardValue.Tíz),
//                new Card(CardSuit.Tök, CardValue.Ász),
//                new Card(CardSuit.Zöld, CardValue.Tíz),
//                new Card(CardSuit.Zöld, CardValue.Király),
//                new Card(CardSuit.Zöld, CardValue.Ász)
//            };

//            var playedCards = new List<Card>
//            {
//                new Card(CardSuit.Piros, CardValue.Tíz),
//                new Card(CardSuit.Piros, CardValue.Ász)
//            };

//            var result = _ruleSet.GetPlayableCards(playedCards, hand);

//            Assert.NotNull(result);
//            Assert.Equal(result, hand);
//        }

//        [Fact]
//        public void NoSameSuitWithTrumpInHand()
//        {
//            _ruleSet.Trump = CardSuit.Tök;

//            var hand = new List<Card>
//            {
//                new Card(CardSuit.Tök, CardValue.Király),
//                new Card(CardSuit.Piros, CardValue.Tíz),
//                new Card(CardSuit.Piros, CardValue.Ász),
//                new Card(CardSuit.Zöld, CardValue.Tíz),
//                new Card(CardSuit.Zöld, CardValue.Király),
//                new Card(CardSuit.Zöld, CardValue.Ász)
//            };

//            var playedCards = new List<Card>
//            {
//                new Card(CardSuit.Makk, CardValue.Kilenc),
//                new Card(CardSuit.Makk, CardValue.Alsó)
//            };

//            var result = _ruleSet.GetPlayableCards(playedCards, hand);

//            Assert.NotNull(result);
//            Assert.Single(result);
//            Assert.Equal(new Card(CardSuit.Tök, CardValue.Király), result[0]);
//        }

//        [Fact]
//        public void HaveSameSuitWithTrumpInPlay()
//        {
//            _ruleSet.Trump = CardSuit.Tök;

//            var hand = new List<Card>
//            {
//                new Card(CardSuit.Tök, CardValue.Király),
//                new Card(CardSuit.Piros, CardValue.Tíz),
//                new Card(CardSuit.Piros, CardValue.Ász),
//                new Card(CardSuit.Zöld, CardValue.Tíz),
//                new Card(CardSuit.Zöld, CardValue.Király),
//                new Card(CardSuit.Zöld, CardValue.Ász)
//            };

//            var playedCards = new List<Card>
//            {
//                new Card(CardSuit.Piros, CardValue.Kilenc),
//                new Card(CardSuit.Tök, CardValue.Alsó)
//            };

//            var result = _ruleSet.GetPlayableCards(playedCards, hand);

//            Assert.NotNull(result);
//            Assert.Equal(2, result.Count);
//            Assert.Contains(new Card(CardSuit.Piros, CardValue.Tíz), result);
//            Assert.Contains(new Card(CardSuit.Piros, CardValue.Ász), result);
//        }

//        [Fact]
//        public void HaveHigherAndLowerSameSuitWithTrumpInPlay()
//        {
//            _ruleSet.Trump = CardSuit.Tök;

//            var hand = new List<Card>
//            {
//                new Card(CardSuit.Tök, CardValue.Király),
//                new Card(CardSuit.Piros, CardValue.Kilenc),
//                new Card(CardSuit.Piros, CardValue.Ász),
//                new Card(CardSuit.Zöld, CardValue.Tíz),
//                new Card(CardSuit.Zöld, CardValue.Király),
//                new Card(CardSuit.Zöld, CardValue.Ász)
//            };

//            var playedCards = new List<Card>
//            {
//                new Card(CardSuit.Piros, CardValue.Felső),
//                new Card(CardSuit.Tök, CardValue.Alsó)
//            };

//            var result = _ruleSet.GetPlayableCards(playedCards, hand);

//            Assert.NotNull(result);
//            Assert.Equal(2, result.Count);
//            Assert.Contains(new Card(CardSuit.Piros, CardValue.Kilenc), result);
//            Assert.Contains(new Card(CardSuit.Piros, CardValue.Ász), result);
//        }
//    }
//}