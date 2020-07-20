using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    public class Card
    {
        private readonly SuitNumber suit;
        private readonly CardValue value;

        public Card(int nSuit, int nValue)
        {
            suit = (SuitNumber)(nSuit);
            value = (CardValue)(nValue);
        }

        public SuitNumber CardSuit
        {
            get { return suit; }
        }

        public CardValue CardValue
        {
            get { return value; }
        }
    }
}
