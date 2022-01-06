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
                if(cardItem.Number == 1)
                {
                    Console.WriteLine(cardItem.Color + " " + cardItem.Shading);
                }
                else if (cardItem.Number == 2)
                {
                    Console.WriteLine(cardItem.Color + " " + cardItem.Shading + cardItem.Shading);
                }
                else if (cardItem.Number == 3)
                {
                    Console.WriteLine(cardItem.Color + " " + cardItem.Shading + cardItem.Shading + cardItem.Shading);
                }
            }
        }

        public static List<CardSet> GetFullSetList(List<Card> cardList)
        {
            var result = new List<CardSet>();

            if (cardList == null || cardList.Count == 0)
            {
                throw new Exception("cardList is empty.");
            }

            for (int i = 0; i < cardList.Count; i++) // We select our 1st card
            {
                Card cardOne = cardList[i]; 

                for (int j = i + 1; j < cardList.Count; j++) // We select our 2nd card. To not select the same card twice
                {
                    Card cardTwo = cardList[j];

                    for (int k = j + 1; k < cardList.Count; k++) // We select our 3rd card
                    {
                        Card cardThree = cardList[k];

                        if (CardSet.IsSet(cardOne, cardTwo, cardThree)) // Check if {cardone, cardTwo, cardThree} is a set
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

        public static List<CardSet> GetDisjointSetList(List<CardSet> cardSetlist)
        {
            var result = new List<CardSet>();
            bool isDisjoint = true;

            for (int i = 0; i < cardSetlist.Count; i++)
            {
                CardSet cardSetOne = cardSetlist[i];

                for (int j = i + 1; j < cardSetlist.Count; j++)
                {
                    CardSet cardSetTwo = cardSetlist[j];

                    if
                        (
                            (cardSetOne.CardSetList[0].IsEqual(cardSetTwo.CardSetList[0])) ||
                            (cardSetOne.CardSetList[0].IsEqual(cardSetTwo.CardSetList[1])) ||
                            (cardSetOne.CardSetList[0].IsEqual(cardSetTwo.CardSetList[2])) ||

                            (cardSetOne.CardSetList[1].IsEqual(cardSetTwo.CardSetList[0])) ||
                            (cardSetOne.CardSetList[1].IsEqual(cardSetTwo.CardSetList[1])) ||
                            (cardSetOne.CardSetList[1].IsEqual(cardSetTwo.CardSetList[2])) ||

                            (cardSetOne.CardSetList[2].IsEqual(cardSetTwo.CardSetList[0])) ||
                            (cardSetOne.CardSetList[2].IsEqual(cardSetTwo.CardSetList[1])) ||
                            (cardSetOne.CardSetList[2].IsEqual(cardSetTwo.CardSetList[2]))
                        )
                    {
                        isDisjoint = false;
                        break;
                    }
                }

                if (isDisjoint)
                {
                    result.Add(cardSetOne);
                    
                }
                isDisjoint = true; // Reset
            }

            return result;
        }

        private static bool IsSet(Card card1, Card card2, Card card3)
        {
            bool result = false;

            if
                (
                    (
                         (String.Equals(card1.Color, card2.Color)) && (String.Equals(card2.Color, card3.Color)) // All equal
                         ||
                         (!String.Equals(card1.Color, card2.Color)) && (!String.Equals(card1.Color, card3.Color)) && (!String.Equals(card2.Color, card3.Color)) // All not equal
                    )
                )
            {
                result = true;
            }
            else
            {
                return false;
            }

            if
                (
                    (
                         (Char.Equals(card1.Symbol, card2.Symbol)) && (Char.Equals(card2.Symbol, card3.Symbol)) // All equal
                         ||
                         (!Char.Equals(card1.Symbol, card2.Symbol)) && (!Char.Equals(card1.Symbol, card3.Symbol)) && (!Char.Equals(card2.Symbol, card3.Symbol)) // All not equal
                    )
                )
            {
                result = true;
            }
            else
            {
                return false;
            }

            if
                (
                    (
                         (Char.Equals(card1.Shading, card2.Shading)) && (Char.Equals(card2.Shading, card3.Shading)) // All equal
                         ||
                         (!Char.Equals(card1.Shading, card2.Shading)) && (!Char.Equals(card1.Shading, card3.Shading)) && (!Char.Equals(card2.Shading, card3.Shading)) // All not equal
                    )
                )
            {
                result = true;
            }
            else
            {
                return false;
            }

            if
                (
                    (
                         (card1.Number  == card2.Number) && (card2.Number == card3.Number) // All equal
                         ||
                         (card1.Number == card2.Number) && (card1.Number == card3.Number) && (card2.Number == card3.Number) // All not equal
                    )
                )
            {
                result = true;
            }
            else
            {
                return false;
            }

            return result;
        }
    }
}
