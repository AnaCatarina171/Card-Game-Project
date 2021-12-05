using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Hand
    {
        private List<Card> _cards = new List<Card>();

        public int Count
        {
            get
            {
                return _cards.Count();
            }
        }

        public bool HasCards
        {
            get
            {
                return Count > 0;
            }
        }

        public Card this[int index]
        {
            get
            {
                return _cards[index];
            }
        }

        public void AddCard(Card newCard)
        {
            if (ContainsCard(newCard))
            {
                throw new Exception(newCard.Name + " already exists in the hand");
            }
            _cards.Add(newCard);
        }

        private bool ContainsCard(Card cardToCheck)
        {
            foreach (var currentCard in _cards)
            {
                if(IsMatch(cardToCheck, currentCard))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsMatch(Card card1, Card card2)
        {
            if (card1.Suit != card2.Suit)
                return false;
            if (card1.FaceValue != card2.FaceValue)
                return false;

            return true;
        }
    }
}
