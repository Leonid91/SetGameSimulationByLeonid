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

        public static List<CardSet> GetCardSet(List<Card> cardList)
        {
            List<CardSet> cardSetList = new List<CardSet>();

            Card card1 = new Card();
            Card card2 = new Card();
            Card card3 = new Card();

            for (int i = 0; i < cardList.Count; i++)
            {
                card1 = cardList[i];
                for (int j = 0; j < cardList.Count; j++)
                {
                    card2 = cardList[j];
                    if (!card1.IsEqual(card2))
                    {
                        for (int k = 0; k < cardList.Count; k++)
                        {
                            card3 = cardList[k];
                            if (!card1.IsEqual(card3) && !card2.IsEqual(card3))
                            {
                                CardSet testSet = new CardSet();
                                testSet.CardSetList.Add(card1);
                                testSet.CardSetList.Add(card2);
                                testSet.CardSetList.Add(card3);

                                if (testSet.isCardSet())
                                {
                                    cardSetList.Add(testSet);
                                }
                            }
                        }
                    }

                }
            }

            return cardSetList;
        }

        private bool isCardSet()
        {
            bool isCardSet = false;

            Card card1 = CardSetList[0];
            Card card2 = CardSetList[1];
            Card card3 = CardSetList[2];

            // Color
            if (
                (
                    (card1.Color == card2.Color) && (card2.Color == card3.Color)
                    ||
                    (card1.Color != card2.Color) && (card2.Color != card3.Color)
                )
                &&
                (
                    (card1.Symbol == card2.Symbol) && (card2.Symbol == card3.Symbol)
                    ||
                    (card1.Symbol != card2.Symbol) && (card2.Symbol != card3.Symbol)
                )
                &&
                (
                    (card1.Shading == card2.Shading) && (card2.Shading == card3.Shading)
                    ||
                    (card1.Shading != card2.Shading) && (card2.Shading != card3.Shading)
                )
                &&
                (
                    (card1.Number == card2.Number) && (card2.Number == card3.Number)
                    ||
                    (card1.Number != card2.Number) && (card2.Number != card3.Number)
                )
               )
            {
                isCardSet = true;
            }

            return isCardSet;
        }
    }
}
