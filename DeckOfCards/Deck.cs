using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    public class Deck
    {
        private List<Card> cards;
        private int numCardsDealt = 0;

        public Deck()
        {
            initializeDeck();
        }

        private void initializeDeck()
        {
            //Creates a brand new, sorted deck
            cards = new List<Card>();
            numCardsDealt = 0;
            for (int rankVal = 2; rankVal <= 14; rankVal++)
            {
                for (int suitVal = 1; suitVal <= 4; suitVal++)
                {
                    Card newCard = new Card(suitVal, rankVal);
                    cards.Add(newCard);
                }
            }
        }

        /// <summary>
        /// Refreshes the deck (returns all dealt cards back to the deck)
        /// </summary>
        public void refresh()
        {
            initializeDeck();
        }

        /// <summary>
        /// shuffle()
        /// Shuffles a deck of cards
        /// </summary>
        public void shuffle()
        {
            try
            {
                Random random = new Random();
                int index = 0;
                int numCardsInDeck = cards.Count();

                List<Card> shuffledCards = new List<Card>();
                for (int cardNum = 1; cardNum <= numCardsInDeck; cardNum++)
                {
                    index = random.Next(0, cards.Count());
                    shuffledCards.Add(cards[index]);
                    cards.RemoveAt(index);
                }

                cards = shuffledCards;
            }
            catch(Exception ex)
            {
                cards = null;
            }
        }

        /// <summary>
        /// dealOneCard()
        /// Deals the next card from the deck
        /// If there are no more cards available, return NULL
        /// </summary>
        /// <returns> Card </returns>
        public Card dealOneCard()
        {
            try
            {
                if (numCardsDealt < cards.Count())
                {
                    return cards[numCardsDealt++];
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }


        //Not immediately required, but this function could be useful later:

        /// <summary>
        /// dealNCards(int numCards)
        /// Returns the number of cards specified by the input parameter of numCards
        /// If no more cards are available, the function will return the subset that is available, if any.
        /// </summary>
        /// <param name="numCards"></param>
        /// <returns> List<Card> </returns>
        public List<Card> dealNCards(int numCards)
        {
            List<Card> cardsToDeal = new List<Card>();
            try
            {
                for (int cardNum = 1; cardNum <= numCards; cardNum++)
                {
                    if (numCardsDealt < cards.Count())
                    {
                        cardsToDeal.Add(cards[numCardsDealt++]);
                    }
                    else
                    {
                        break;
                    }
                }
                return cardsToDeal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
