using Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Represents a deck of cards
    /// </summary>
    public class Deck
    {
        public List<Card> Cards { get; set; }

        /// <summary>
        /// Constructor to create a deck of 52 playing cards
        /// </summary>
        public Deck()
        {
            Cards = new List<Card>();

            for (int suit = 0; suit < Enum.GetNames(typeof(SuitEnum)).Length; suit++)
            {
                for (int rank = 1; rank <= Enum.GetNames(typeof(RankEnum)).Length; rank++)
                {
                    Card card = new Card((RankEnum)rank, (SuitEnum)suit);
                    Cards.Add(card);
                }
            }
        }

        /// <summary>
        /// Rudimentary shuffle of cards in deck
        /// </summary>
        public void Shuffle()
        {
            // There are more precise and complicated ways of shuffling, but this does the job
            Cards = Cards.OrderBy(a => Guid.NewGuid()).ToList();
        }
    }
}
