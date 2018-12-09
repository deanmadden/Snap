using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Represents the referee or dealer
    /// </summary>
    public class Referee
    {
        /// <summary>
        /// The state of the game
        /// </summary>
        public GameState GameStatus { get; set; }

        public Referee()
        {
            GameStatus = new GameState();
        }

        /// <summary>
        /// Sets up the initial state of the game
        /// </summary>
        /// <returns></returns>
        public bool SetupGame()
        {
            bool ret = GetPlayers();

            if (!ret)
            {
                return ret;
            }

            Deck deck = new Deck();
            deck.Shuffle();
            DealCards(deck);

            return ret;
        }

        /// <summary>
        /// Starts the game of snap
        /// </summary>
        /// <returns></returns>
        public bool StartGame()
        {
            GameStatus.Finished = false;

            Console.WriteLine("Starting game.");

            while (!GameStatus.Finished)
            {
                GameStatus.PlayRound();
            }

            return true;
        }

        /// <summary>
        /// Gets the snap players
        /// </summary>
        /// <returns></returns>
        private bool GetPlayers()
        {
            bool ret = GetNumberOfPlayers();

            if (!ret)
            {
                Console.WriteLine("Error getting number of players!");
                return ret;
            }

            ret = GetPlayerNames();

            return ret;
        }

        /// <summary>
        /// Asks how many players
        /// </summary>
        /// <returns></returns>
        private bool GetNumberOfPlayers()
        {
            Console.WriteLine("Hello. How many snap players?");
            var response = Console.ReadLine();

            int playercount = 0;

            if (int.TryParse(response, out playercount))
            {
                if (playercount > 52)
                {
                    Console.WriteLine("I'm sorry I only have 52 cards to play with!");
                    return false;
                }

                if (playercount <= 0)
                {
                    Console.WriteLine("Don't be silly!");
                    return false;
                }

                GameStatus.PlayerCount = playercount;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Asks for the names of the players
        /// </summary>
        /// <returns></returns>
        private bool GetPlayerNames()
        {
            try
            {
                for (int i = 0; i < GameStatus.PlayerCount; i++)
                {
                    Console.WriteLine("Please enter Player " + (i + 1) + " Name");
                    string playerName = Console.ReadLine();

                    Player player = new Player(playerName);

                    GameStatus.Players.Add(player);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting player names: " + e.ToString());
                return false;
            }            

            return true;
        }

        /// <summary>
        /// Deals the cards to the players ensuring each gets an equal number of cards
        /// </summary>
        /// <param name="deck"></param>
        public void DealCards(Deck deck)
        {
            Console.WriteLine("Dealing cards.");

            // Gets the modules and discards the remainder
            int cardsToBeDealt = 52 / GameStatus.PlayerCount;

            Console.WriteLine("Each players gets " + cardsToBeDealt + " cards.");

            for (int i = 0; i < cardsToBeDealt; i++)
            {
                foreach (var player in GameStatus.Players)
                {
                    var card = deck.Cards[0];
                    deck.Cards.RemoveAt(0);

                    Console.WriteLine("Dealing " + card.Rank + " of " + card.Suit + " to " + player.Name);

                    player.Cards.Push(card);
                }
            }

            Console.WriteLine("Finished dealing cards.");
        }
    }
}
