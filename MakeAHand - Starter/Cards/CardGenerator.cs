using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public static class CardGenerator
    {
        public static List<Card> GenerateDeck()
        {
            List<Card> cards = new List<Card>();

            List<Suit> suits = GetSuits();

            foreach (var suit in suits)
            {
                List<Card> currentSuit = CreateSuit(suit);

                cards.AddRange(currentSuit);
            }

            return cards;
        }
        public static List<Card> CreateSuit(Suit suit)
        {
            List<Card> cards = new List<Card>();

            for (int value = 0; value <= 12; value++)
            {
                // create a card for the current suit and value
                Card newCard = new Card(suit, (FaceValue)value);

                // add the card to the deck
                cards.Add(newCard);
            }

            return cards;
        }
        public static List<Suit> GetSuits()
        {
            List<Suit> suits = Enum.GetValues(typeof(Suit)).Cast<Suit>().ToList();

            return suits;
        }
    }
}
