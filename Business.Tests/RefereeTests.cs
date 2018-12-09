using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.Tests
{
    [TestClass]
    public class RefereeTests
    {
        [TestMethod]
        public void DealCardsTestFivePlayers()
        {
            // arrange
            Referee referee = new Referee();
            referee.GameStatus.PlayerCount = 5;

            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");
            Player player3 = new Player("Player3");
            Player player4 = new Player("Player4");
            Player player5 = new Player("Player5");

            referee.GameStatus.Players.Add(player1);
            referee.GameStatus.Players.Add(player2);
            referee.GameStatus.Players.Add(player3);
            referee.GameStatus.Players.Add(player4);
            referee.GameStatus.Players.Add(player5);

            Deck deck = new Deck();
            deck.Shuffle();

            // act
            referee.DealCards(deck);

            // assert
            Assert.AreEqual(10, referee.GameStatus.Players[0].Cards.Count, "Each player should have 10 cards.");

        }
    }
}
