using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Card
    {
        public Card(Suit newSuit, FaceValue newValue)
        {
            Suit = newSuit;
            FaceValue = newValue;
        }

        public Suit Suit { get; private set; }

        public FaceValue FaceValue { get; private set; }

        public string Name
        {
            get
            {
                string faceName = FaceValue.ToString();
                string suitName = Suit.ToString();

                string name = $"{faceName} of {suitName}";

                return name;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
