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
    public partial class frmDeck : Form
    {
        private const int CARDS_PER_HAND = 5;

        private Deck deck;
        private Hand hand;

        public frmDeck()
        {
            InitializeComponent();
        }

        private void frmDeck_Load(object sender, EventArgs e)
        {
            picDeck.Image = CardImageUtil.GetDeckImage();
            SetUpDragDrop(grpHand);
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

        private void picDeck_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                PictureBox pic = (PictureBox)sender;
                if(pic.Image != null)
                {
                    pic.DoDragDrop(pic.Image, DragDropEffects.Move);
                }
            }
        }

        private void picCard_DragEnter(object sender, DragEventArgs e)
        {
            if(sender is PictureBox)
            {
                PictureBox pic = (PictureBox)sender;
                if(pic.Image == null)
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        private void picCard_DragDrop(object sender, DragEventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pic = (PictureBox)sender;

                Card card = deck.DrawTopCard();

                pic.Image = card.GetImage();
            }
        }

        private void SetUpDragDrop(Control control)
        {
            if (control is PictureBox)
            {
                PictureBox pic = (PictureBox)control;
                pic.AllowDrop = true;
            }
            else
            {
                foreach (Control item in control.Controls)
                {
                    SetUpDragDrop(item);
                }
            }
        }
    }
}
