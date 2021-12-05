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
    public partial class frmDinamicCards : Form
    {
        private Deck deck;
        public frmDinamicCards()
        {
            InitializeComponent();
        }

        private void frmDinamicCards_Load(object sender, EventArgs e)
        {
            deck = new Deck(true);
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Hand hand = deck.DrawHand(5);

            DisplayHand(hand);
        }

        private void DisplayHand(Hand hand)
        {
            grpHand.Controls.Clear();

            for (int i = 0; i < hand.Count; i++)
            {
                int leftOffSet = i * 50;
                int topOffSet = i * 30;

                Card card = hand[i];

                var pic = card.CreatePictureBox(leftOffSet, topOffSet);

                grpHand.Controls.Add(pic);
                pic.BringToFront();
            }
        }
    }
}
