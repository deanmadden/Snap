using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Represents the game status as it's being played
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// Constructor to initialise variables
        /// </summary>
        public GameState()
        {
            Players = new List<Player>();
            CentralPile = new Stack<Card>();
            Finished = false;
            PlayerTurn = 0;
        }

        /// <summary>
        /// Number of players
        /// </summary>
        public int PlayerCount { get; set; }

        /// <summary>
        /// The players in the game
        /// </summary>
        public List<Player> Players { get; set; }

        /// <summary>
        /// Whether the game has reached its conclusion
        /// </summary>
        public bool Finished { get; set; }

        /// <summary>
        /// Whos turn it is
        /// </summary>
        public int PlayerTurn { get; set; }

        /// <summary>
        /// The pile of cards in the middle of the players
        /// </summary>
        public Stack<Card> CentralPile { get; set; }

        /// <summary>
        /// The previous card dealt
        /// </summary>
        public Card LastCard { get; set; }

        /// <summary>
        /// Plays a round of snap
        /// </summary>
        /// <returns></returns>
        public bool PlayRound()
        {
            if (CheckIfNoCardsLeft())
            {
                return true;
            }

            // The player places a card onto the central pile
            var poppedCard = Players[PlayerTurn].Cards.Pop();

            Console.WriteLine(Players[PlayerTurn].Name + " adds " + poppedCard.Rank + " of " + poppedCard.Suit + " to central pile.");

            CentralPile.Push(poppedCard);

            if (LastCard != null)
            {
                if (CheckForSnap(poppedCard))
                {
                    return true;
                }
            }

            LastCard = poppedCard;

            SetPlayerTurn();

            return true;
        }

        /// <summary>
        /// Determines whos turn it is
        /// </summary>
        private void SetPlayerTurn()
        {
            if (PlayerTurn == Players.Count - 1)
            {
                PlayerTurn = 0;
            }
            else
            {
                PlayerTurn++;
            }
        }

        // Check if a player can call snap
        private bool CheckForSnap(Card card)
        {
            if (LastCard.Rank == card.Rank)
            {
                ProcessMatchingCards();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// If a players has no cards left, remove them from the game
        /// </summary>
        /// <returns></returns>
        private bool CheckIfNoCardsLeft()
        {
            if (Players[PlayerTurn].Cards.Count == 0)
            {
                Console.WriteLine("Player " + Players[PlayerTurn].Name + " has no cards left!");
                Players.RemoveAt(PlayerTurn);

                if (PlayerTurn >= Players.Count - 1)
                {
                    PlayerTurn = 0;
                }

                if (Players.Count == 0)
                {
                    // This is ambiguous whether we should call it a draw or have the remaining player win.
                    // But the rules say the player with all the cards wins
                    Finished = true;
                    Console.WriteLine("Game has finished, noone wins!");
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// If there are matching rank cards, determine who shouts first to win the pile
        /// </summary>
        private void ProcessMatchingCards()
        {
            var fastestPlayer = GetFastestPlayer();
            Console.WriteLine("Player " + fastestPlayer.Name + " shouts SNAP!");

            if (Players.Count == 1)
            {
                Finished = true;
                Console.WriteLine("Game has finished. " + Players[0].Name + " is the Winner!");
            }
            else
            {
                MoveCentralCardsToPlayer(fastestPlayer);
            }
        }

        /// <summary>
        /// Add the central cards the bottom of the players pile
        /// </summary>
        /// <param name="fastestPlayer"></param>
        private void MoveCentralCardsToPlayer(Player fastestPlayer)
        {
            var oldStack = fastestPlayer.Cards;

            var newStack = CentralPile;

            foreach (var item in oldStack)
            {
                newStack.Push(item);
            }

            fastestPlayer.Cards = newStack;
            CentralPile = new Stack<Card>();
            LastCard = null;
            PlayerTurn = Players.IndexOf(fastestPlayer);
        }

        /// <summary>
        /// Gets the fastest player
        /// </summary>
        /// <returns></returns>
        private Player GetFastestPlayer()
        {
            // It wasn't clear how we wanted to simulate the players so I chose to randomly create the reaction times of each player
            Random random = new Random();

            foreach (var player in Players)
            {
                player.SetReactionTime(random);
            }

            var fastestPlayer = Players.OrderBy(x => x.ReactionTime).FirstOrDefault();
            return fastestPlayer;
        }
    }
}
