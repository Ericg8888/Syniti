using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syniti
{
    class Deck
    {
        private List<Card> cards;
        private int numCardsDealt = 0;

        public Deck()
        {
            //Creates a brand new, sorted deck
            cards = new List<Card>();
            for (int rankVal = 2; rankVal <= 14; rankVal++)
            {
                for (int suitVal = 1; suitVal <= 4; suitVal++)
                {
                    Card newCard = new Card(suitVal,rankVal);
                    cards.Add(newCard);
                }
            }
        }

        /// <summary>
        /// shuffle()
        /// Shuffles a deck of cards
        /// </summary>
        public void shuffle()
        {
            Random random = new Random();
            int index = 0;
            int numCardsInDeck = cards.Count();

            List<Card> shuffledCards = new List<Card>();
            for(int cardNum = 1; cardNum <= numCardsInDeck; cardNum++)
            {
                index = random.Next(0, cards.Count());
                shuffledCards.Add(cards[index]);
                cards.RemoveAt(index);
            }

            cards = shuffledCards;
        }

        /// <summary>
        /// dealOneCard()
        /// Deals the next card from the deck
        /// If there are no more cards available, return NULL
        /// </summary>
        /// <returns> Card </returns>
        public Card dealOneCard()
        {
            if (numCardsDealt < cards.Count())
            {
                return cards[numCardsDealt++];
            }
            return null;
        }
    }
}
