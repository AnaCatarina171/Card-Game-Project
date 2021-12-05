using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Deck
    {
        private List<Card> _deck = new List<Card>();
        private Random random = new Random();

        public Deck()
        {
            random = new Random();
            _deck = CardGenerator.GenerateDeck();
        }

        public Deck(bool shuffle)
        {
            random = new Random();
            _deck = CardGenerator.GenerateDeck();
            if (shuffle)
            {
                Shuffle();
            }
        }

        public bool HasCardsLeft()
        {
            return _deck.Count > 0;
        }

        public Hand DrawHand(int cardCount)
        {
            Hand hand = new Hand();

            while (HasCardsLeft() && hand.Count < cardCount)
            {
                hand.AddCard(DrawTopCard());
            }

            return hand;
        }

        public void Shuffle()
        {
            List<Card> newDeck = new List<Card>();
            while (HasCardsLeft())
            {
                Card randomCard = DrawOneRandomCard();

                newDeck.Add(randomCard);
            }

            //  replace the old deck with the new deck
            _deck = newDeck;
        }

        public Card DrawOneRandomCard()
        {
            int removeIndex = random.Next(0, _deck.Count);

            Card removedCard = DrawCard(removeIndex);

            return removedCard;
        }

        public Card DrawTopCard()
        {
            Card topCard = DrawCard(0);

            return topCard;
        }

        private Card DrawCard(int index)
        {
            Card card = null;

            if (HasCardsLeft())
            {
                card = _deck[index];
                _deck.RemoveAt(index);
            }

            return card;
        }
    }
}
