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
using Truco;

namespace MakeAHand
{
    public partial class frmTruco : Form
    {
        private Deck deck;
        private List<Player> players = new List<Player>();

        public frmTruco()
        {
            InitializeComponent();
        }

        private void frmTruco_Load(object sender, EventArgs e)
        {
            deck = new Deck(true);
            AddPlayers();
            picDeck.Image = CardImageUtil.GetDeckImage(); 
        }

        private void frmTruco_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome To Truco Game! To start playing, click in 'Play a new set'");
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            foreach (var player in players)
            {
                CreateHand(player);
            }
        }

        public void CreateHand(Player player)
        {
            Hand playerHand = new Hand();

            playerHand = deck.DrawHand(3);

            if (playerHand.HasCards)
            {
                for (int i = 0; i < playerHand.Count; i++)
                {
                    PictureBox currentPic = GetNextPictureBox();
                    currentPic.Image = playerHand[i].GetImage();
                }
            }
            else
            {
                MessageBox.Show("No cards left to display");
            }

            player.hand = playerHand;
        }

        public PictureBox GetNextPictureBox()
        {
            if (this.picCard1P1.Image == null)
                return picCard1P1;
            if (this.picCard2P1.Image == null)
                return picCard2P1;
            if (this.picCard3P1.Image == null)
                return picCard3P1;
            if (this.picCard1P2.Image == null)
                return picCard1P2;
            if (this.picCard2P2.Image == null)
                return picCard2P2;
            if (this.picCard3P2.Image == null)
                return picCard3P2;
            if (this.picCard1P3.Image == null)
                return picCard1P3;
            if (this.picCard2P3.Image == null)
                return picCard2P3;
            if (this.picCard3P3.Image == null)
                return picCard3P3;
            if (this.picCard1P4.Image == null)
                return picCard1P4;
            if (this.picCard2P4.Image == null)
                return picCard2P4;
            if (this.picCard3P4.Image == null)
                return picCard3P4;

            return null;
        }

        public void AddPlayers()
        {
            Player playerOne = new Player();
            Player playerTwo = new Player();
            Player playerThree = new Player();
            Player playerFour = new Player();
            players.Add(playerOne);
            players.Add(playerTwo);
            players.Add(playerThree);
            players.Add(playerFour);
        }
    }
}
