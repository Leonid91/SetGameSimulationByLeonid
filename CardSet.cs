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

        public static List<CardSet> GetAllSets(List<Card> cardList)
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
    }
}
