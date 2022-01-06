using System;
using System.Collections.Generic;
using System.Text;

namespace SetGameSimulationByLeonid
{
    public class CardSet
    {
        public List<Card> CardSetList { get; set; }

        public CardSet()
        {
            CardSetList = new List<Card>();
        }

        public void Display()
        {
            foreach (var cardItem in CardSetList)
            {
                Console.WriteLine(cardItem.Color + " " + cardItem.Shading + cardItem.Shading + cardItem.Shading);
            }
        }

        public static List<CardSet> GetFullSetList(List<Card> cardList)
        {
            var result = new List<CardSet>();

            if (cardList == null || cardList.Count == 0)
            {
                throw new Exception("cardList is empty.");
            }

            for (int i = 0; i < cardList.Count; i++)
            {
                Card cardOne = cardList[i]; // We select our 1st card

                for (int j = i + 1; j < cardList.Count; j++) // We select our 2nd card. To not select the same card twice
                {
                    Card cardTwo = cardList[j];
                    for (int k = j + 1; k < cardList.Count; k++) // We select our 3rd card
                    {
                        Card cardThree = cardList[k];

                        if (Card.IsSet(cardOne, cardTwo, cardThree)) // Check if {cardone, cardTwo, cardThree} is a set
                        {
                            var cardSet = new CardSet();
                            cardSet.CardSetList.Add(cardOne);
                            cardSet.CardSetList.Add(cardTwo);
                            cardSet.CardSetList.Add(cardThree);

                            // Finally add this set to our output
                            result.Add(cardSet);
                        }

                    }
                }
            }
            return result;
        }

        public static List<CardSet> GetDisjointSetList(List<Card> cardList)
        {
            var result = new List<CardSet>();
            List<CardSet> fullCardSetList = GetFullSetList(cardList);

            foreach (var set in fullCardSetList)
            {
                if(CardSet.GetSamePropertiesCount(set) == 0)
                {
                    result.Add(set);
                }
            }

            return result;
        }

        private static int GetSamePropertiesCount(CardSet cardSet)
        {
            if(cardSet.CardSetList.Count != 3)
            {
                throw new Exception("The card set must contains only 3 cards.");
            }

            Card cardOne = cardSet.CardSetList[0];
            Card cardTwo = cardSet.CardSetList[1];
            Card cardThree = cardSet.CardSetList[2];

            int samePropertiesCount = 0;

            if(cardOne.Color == cardTwo.Color && cardTwo.Color == cardThree.Color) { samePropertiesCount++; }
            if(cardOne.Symbol == cardTwo.Symbol && cardTwo.Symbol == cardThree.Symbol) { samePropertiesCount++; }
            if(cardOne.Shading == cardTwo.Shading && cardTwo.Shading == cardThree.Shading) { samePropertiesCount++; }
            if(cardOne.Number == cardTwo.Number && cardTwo.Number == cardThree.Number) { samePropertiesCount++; }

            return samePropertiesCount;
        } 
    }
}
