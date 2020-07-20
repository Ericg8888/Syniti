using DeckOfCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syniti
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Deck ourDeck = new Deck();
                TestDealSortedDeck(ourDeck);

                ourDeck.refresh();
                TestShuffleAndDealNCards(ourDeck, 53); //Try to deal the whole deck plus 1 extra card

                ourDeck.refresh();
                ourDeck.shuffle();
                TestSimulateHeadsUpTexasHoldem(ourDeck);

                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception in Main: " + ex.Message);
            }
        }

        /// <summary>
        /// TestDealSortedDeck
        /// Given a deck of cards, deal them out without shuffling. Specifically deal 52 cards in this test.
        /// </summary>
        private static void TestDealSortedDeck(Deck ourDeck)
        {
            try
            {
                Console.WriteLine("Beginning TestDealSortedDeck");
                Card oneCard;
                for (int numCard = 1; numCard < 53; numCard++)
                {
                    oneCard = ourDeck.dealOneCard();
                    Console.WriteLine(oneCard.CardValue + " of " + oneCard.CardSuit.ToString());
                }
                Console.WriteLine("");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception in Test1: " + ex.Message);
            }
        }

        /// <summary>
        /// TestShuffleAndDealNCards  
        /// Given a deck of cards, shuffles then tries to deal out the number of cards specified
        /// </summary>
        private static void TestShuffleAndDealNCards(Deck ourDeck, int nNumCardsToDeal)
        {
            try
            {
                Console.WriteLine("Beginning TestShuffleAndDealNCards (" + nNumCardsToDeal + ")");
                ourDeck.shuffle();
                Card oneCard;
                for (int numCard = 1; numCard <= nNumCardsToDeal; numCard++)
                {
                    oneCard = ourDeck.dealOneCard();
                    if (oneCard != null)
                    {
                        Console.WriteLine(oneCard.CardValue + " of " + oneCard.CardSuit.ToString());
                    }
                    else
                    {
                        Console.WriteLine("No more cards available in the deck.");
                    }
                }
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Test2: " + ex.Message);
            }
        }

        /// <summary>
        /// TestDealSpecificNumberOfCards  
        /// Generate a deck of cards, shuffle, then deal out the number of cards specified
        /// </summary>
        private static void TestDealSpecificNumberOfCards(Deck ourDeck, int nNumCardsToDeal)
        {
            try
            {
                Card oneCard;
                List<Card> manyCards = new List<Card>();
                manyCards = ourDeck.dealNCards(nNumCardsToDeal);

                for (int numCard = 0; numCard < nNumCardsToDeal; numCard++)
                {
                    oneCard = manyCards[numCard];
                    if (oneCard != null)
                    {
                        Console.WriteLine(oneCard.CardValue + " of " + oneCard.CardSuit.ToString());
                    }
                    else
                    {
                        Console.WriteLine("No more cards available.");
                    }
                }
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Test2: " + ex.Message);
            }
        }

        /// <summary>
        /// TestSimulateHeadsUpTexasHoldem
        /// </summary>
        /// <param name="ourDeck"></param>
        private static void TestSimulateHeadsUpTexasHoldem(Deck ourDeck)
        {
            Console.WriteLine("Player 1:");
            TestDealSpecificNumberOfCards(ourDeck, 2);
            Console.WriteLine("Player 2:");
            TestDealSpecificNumberOfCards(ourDeck, 2);
            Console.WriteLine("Flop:");
            TestDealSpecificNumberOfCards(ourDeck, 3);
            Console.WriteLine("Turn:");
            TestDealSpecificNumberOfCards(ourDeck, 1);
            Console.WriteLine("River:");
            TestDealSpecificNumberOfCards(ourDeck, 1);
        }


    }
}
