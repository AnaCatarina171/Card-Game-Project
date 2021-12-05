using Cards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeAHand
{
    public partial class frmHand : Form
    {
        private const int CARDS_PER_HAND = 5;

        private Deck deck;
        private Hand hand;

        public frmHand()
        {
            InitializeComponent();
        }

        private void frmHand_Load(object sender, EventArgs e)
        {
            GenerateNewDeck();
        }

        private void btnNewDeck_Click(object sender, EventArgs e)
        {
            GenerateNewDeck();
        }

        private void btnDisplayHand_Click(object sender, EventArgs e)
        {
            hand = deck.DrawHand(CARDS_PER_HAND);

            DisplayHand(hand);
        }

        private void GenerateNewDeck()
        {
            try
            {
                deck = new Deck();
                deck.Shuffle();

                ClearHandDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void DisplayHand(Hand hand)
        {
            ClearHandDisplay();

            if (hand.HasCards)
            {
                for(int i = 0; i < hand.Count; i++)
                {
                    PictureBox currentPic = GetNextPictureBox();
                    currentPic.Image = hand[i].GetImage();
                }
            }
            else
            {
                MessageBox.Show("No cards left to display");
            }
        }

        private void ClearHandDisplay()
        {
            this.picCard1.Image = null;
            this.picCard2.Image = null;
            this.picCard3.Image = null;
            this.picCard4.Image = null;
            this.picCard5.Image = null;
        }

        private Image GetCardImage(Card card)
        {
            Image cardImage = card.GetImage();

            return cardImage;
        }

        private PictureBox GetNextPictureBox()
        {
            if (this.picCard1.Image == null)
            {
                return picCard1;
            }
            else if (this.picCard2.Image == null)
            {
                return picCard2;
            }
            else if (this.picCard3.Image == null)
            {
                return picCard3;
            }
            else if (this.picCard4.Image == null)
            {
                return picCard4;
            }
            else if (this.picCard5.Image == null)
            {
                return picCard5;
            }

            return null;
        }
    }
}
