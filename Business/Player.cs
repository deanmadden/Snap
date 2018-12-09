using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Represents a snap player
    /// </summary>
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Cards = new Stack<Card>();
        }

        /// <summary>
        /// Player name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The players stack of cards
        /// </summary>
        public Stack<Card> Cards { get; set; }

        /// <summary>
        /// How quick the players is to shout snap
        /// </summary>
        public decimal ReactionTime { get; set; }

        /// <summary>
        /// Gets a random value to set the reaction time
        /// </summary>
        /// <param name="random"></param>
        public void SetReactionTime(Random random)
        {
            decimal randomValue = (decimal)random.NextDouble();
            ReactionTime = randomValue;
        }
    }
}
