using System;
using System.Collections.Generic;
using System.Text;

namespace SetGameSimulationByLeonid
{
    public class Card
    {
        public string Color { get; set; }
        public char Symbol { get; set; }
        public char Shading { get; set; }
        public int Number { get; set; }

        public Card() { }

        public static Card GetCard(List<string> propertyString)
        {
            Card card = new Card();
            card.SetColor(propertyString);
            card.SetShadingAndSymbol(propertyString);
            card.SetNumber(propertyString);

            return card;
        }

        #region Construction of the Card model
        private void SetColor(List<string> propertyString)
        {
            Color = propertyString[0].ToString().Trim();
        }

        private void SetNumber(List<string> propertyString)
        {
            Number = propertyString[1].ToString().Trim().Length;
        }
        private void SetShadingAndSymbol(List<string> propertyString)
        {
            string shadingWithNumbers = propertyString[1].Substring(0, 1).Trim();
            Shading = shadingWithNumbers[0];
            SetSymbol(propertyString);
        }

        private void SetSymbol(List<string> shading)
        {
            if (Shading == '\0' || Shading == ' ')
            {
                throw new Exception("Shading is void.");
            }
            else
            {
                if (Shading.Equals('a') || Shading.Equals('A') || Shading.Equals('@'))
                {
                    Symbol = 'A';
                }
                if (Shading.Equals('s') || Shading.Equals('S') || Shading.Equals('$'))
                {
                    Symbol = 'S';
                }
                if (Shading.Equals('h') || Shading.Equals('H') || Shading.Equals('#'))
                {
                    Symbol = 'H';
                }
            }
        }
        #endregion

        public bool IsEqual(Card otherCard)
        {
            return Equals(Color, otherCard.Color) && Equals(Symbol, otherCard.Symbol) && Equals(Shading, otherCard.Shading) && Equals(Number, otherCard.Number);
        }
    }
}
