using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    class Deck
    {
        private static Random rng = new Random();
        List<String> cards;
        List<String> defaultCards = new List<String>()
            {
                "HA", "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "HJ", "HQ", "HK",
                "SA", "S1", "S2", "S3", "S4", "S5", "S6", "S7", "S8", "S9", "S10", "SJ", "SQ", "SK",
                "CA", "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10", "CJ", "CQ", "CK",
                "DA", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D10", "DJ", "DQ", "DK"
            };
        // If we want to keep track of used cards
        List<String> usedCards;

        public Deck()
        {
            Populate();
        }

        public void Populate()
        {
            cards = new List<String>(defaultCards);
            Shuffle(cards);
        }

        public void AppendNewDeck()
        {
            List<String> newDeck = new List<String>(defaultCards);
            Shuffle(newDeck);
            cards.AddRange(newDeck);
        }

        public void Shuffle(List<String> DeckToShuffle)
        {
            int n = DeckToShuffle.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                String value = DeckToShuffle[k];
                DeckToShuffle[k] = DeckToShuffle[n];
                DeckToShuffle[n] = value;
            }

        }

        public Boolean hasNextCard()
        {
            return (cards.Count > 0);
        }

        public String NextCard()
        {
            if (!hasNextCard())
            {
                AppendNewDeck();
            }
            String temp = cards.First();
            cards.RemoveAt(0);
            return temp;
        }
    }
}
