using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Business.Tests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // act
            Deck deck = new Deck();

            // assert
            Assert.AreEqual(52, deck.Cards.Count, "Incorrect number of cards in deck");
            Assert.AreEqual(1, deck.Cards.Where(x => x.Rank == Enums.RankEnum.Ace && x.Suit == Enums.SuitEnum.Spades).Count(), "Should only be one ace of spades");
        }

        [TestMethod]
        public void ShuffleTest()
        {
            // arrange
            Deck originalDeck = new Deck();
            Deck newDeck = new Deck();

            // act
            newDeck.Shuffle();

            // assert
            Assert.AreEqual(52, newDeck.Cards.Count, "Incorrect number of cards in deck");
            Assert.AreEqual(1, newDeck.Cards.Where(x => x.Rank == Enums.RankEnum.Nine && x.Suit == Enums.SuitEnum.Diamonds).Count(), "Should only be one nine of diamonds");
            Assert.AreNotEqual(originalDeck, newDeck, "Deck hasn't been shuffled properly");
        }
    }
}
