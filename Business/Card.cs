using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Enums;

namespace Business
{
    /// <summary>
    /// Represents a playing card
    /// </summary>
    public class Card
    {
        public Card(RankEnum rank, SuitEnum suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public RankEnum Rank { get; set; }

        public SuitEnum Suit { get; set; }
    }
}
