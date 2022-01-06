using System;
using System.Collections.Generic;

namespace SetGameSimulationByLeonid
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;
            string cardString;
            List<Card> cardList = new List<Card>();

            while (N < 3 || N > 30)
            {
                Console.WriteLine("Choose the number of cards : ");
                N = Int16.Parse(Console.ReadLine());

                if(N < 3 || N > 30)
                {
                    Console.WriteLine("The number N must be 3 and 30 included. Re-enter the number N please. \n");
                }
            }

            Console.WriteLine("Enter your cards : \n");
            while (N > 0)
            {
                cardString = Console.ReadLine();

                var cardProperties = new List<string>(cardString.Split(' '));

                Card card = Card.GetCard(cardProperties);
                cardList.Add(card);

                N -= 1;
            }

            List<CardSet> fullCardSetlist = CardSet.GetFullSetList(cardList);
            Console.WriteLine("There are " + fullCardSetlist.Count + " sets : ");
            List<CardSet> disjointCardSetlist = CardSet.GetDisjointSetList(cardList);
            Console.WriteLine("There are " + disjointCardSetlist.Count + " sets : ");
        }
    }
}
