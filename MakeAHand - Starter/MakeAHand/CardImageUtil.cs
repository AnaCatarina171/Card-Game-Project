using Cards;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeAHand
{
    public static class CardImageUtil
    {
        public static string GetImageFilePath(this Card card)
        {
            return GetImageFilePath(card.Suit, card.FaceValue);
        }

        public static Image GetImage(this Card card)
        {
            string imagePath = card.GetImageFilePath();
            Image cardImage = Image.FromFile(imagePath);
            return cardImage;
        }

        public static string GetImageFilePath(Suit suit, FaceValue faceValue)
        {
            string faceName = faceValue.ToString();
            string suitName = suit.ToString();

            // images are saved in the bin/debug/images folder
            string imgPath = "images\\" + faceName + suitName + ".jpg";

            return imgPath;
        }

        public static PictureBox CreatePictureBox(this Card card, int left, int top)
        {
            Image image = card.GetImage();

            return CreatePictureBox(image, card.Name, left, top);
        }

        public static PictureBox CreatePictureBox(this Image image, string text, int left, int top)
        {
            PictureBox pic = new PictureBox()
            {
                Image = image,
                Text = text,
                Width = image.Width,
                Height = image.Height,
                Left = left,
                Top = top
            };

            return pic;
        }

        public static Image GetDeckImage()
        {
            string imagePath = "images\\cardback.gif";

            Image cardImage = Image.FromFile(imagePath);

            return cardImage;
        }
    }
}
