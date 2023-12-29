using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureApp
{
    internal class Image
    {

        public string PathToImage { get; set; }
        public int XSize { get; set; }
        public int YSize { get; set; }
        public PictureBox PictureBox { get; set; }

        private Bitmap _myImage;

        public Image(string pathToImage, int xSize, int ySize, PictureBox pictureBox)
        {
            PathToImage = pathToImage;
            XSize = xSize;
            YSize = ySize;
            PictureBox = pictureBox;
        }

        public void ShowMyImage()
        {
            if(_myImage != null) 
            {
                _myImage.Dispose();
            }

            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                _myImage = new Bitmap(PathToImage);
                PictureBox.ClientSize = new Size(XSize, YSize);
                PictureBox.Image = _myImage;
            }
            catch (Exception)
            {
                if(Main._startStatus == false)
                    MessageBox.Show("Nie można załadować pliku", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            

        }
    }
}
