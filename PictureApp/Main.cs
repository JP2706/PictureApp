using PictureApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureApp
{
    public partial class Main : Form
    {

        private string _filePath;
        static public bool _startStatus;
        public Main()
        {
            InitializeComponent();
            _startStatus = true;
            if (Properties.Settings.Default.OnOff == true)
                ImageStart();
            Properties.Settings.Default.OnOff = true;
            Properties.Settings.Default.Save();
            _startStatus = false;
            btnDellShow();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            _filePath = openFileDialog.FileName;
            Properties.Settings.Default.FilePathAuto = _filePath;
            Properties.Settings.Default.Save();
            if (_filePath != null)
            {
                AddImagePictureBox();
            }
            btnDellShow();
        }

        private void btnDelImage_Click(object sender, EventArgs e)
        {
            if (pbMain.Image == null)
                MessageBox.Show("Brak obrazka do usunięcia");
            else
            {
                pbMain.Image = null;
            }

            btnDellShow();
        }

        private void AddImagePictureBox()
        {
            var image = new Image(_filePath, pbMain.Width, pbMain.Height, pbMain);
            image.ShowMyImage();
        }

        private void ImageStart()
        {
            _filePath = Properties.Settings.Default.FilePathAuto.ToString();
            AddImagePictureBox();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(pbMain.Image == null)
            {
                Properties.Settings.Default.OnOff = false;
                Properties.Settings.Default.Save();
            }
        }

        private void btnDellShow()
        {
            if(pbMain.Image == null)
                btnDelImage.Enabled = false;
            else
                btnDelImage.Enabled = true;
        }
    }
}
