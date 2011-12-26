using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TetrisReturn
{
    public partial class ImageButton : UserControl
    {
        private Bitmap iEnabled;
        private Bitmap iDisabled;
        private Bitmap iHover;
        private Bitmap iOnclick;
        private String sText;

        public String SText
        {
            get { return sText; }
            set { sText = value; }
        }
        public Bitmap IEnabled
        {
            get { return iEnabled; }
            set { iEnabled = value; }
        }

        public Bitmap IDisabled
        {
            get { return iDisabled; }
            set { iDisabled = value; }
        }

        public Bitmap IHover
        {
            get { return iHover; }
            set { iHover = value; }
        }

        public Bitmap IOnclick
        {
            get { return iOnclick; }
            set { iOnclick = value; }
        }
        public ImageButton()
        {
            InitializeComponent();
            
        }


        private void picBox_MouseHover(object sender, EventArgs e)
        {
            if (Enabled)
                picBox.Image = IHover;
        }

        private void picBox_MouseLeave(object sender, EventArgs e)
        {
            if (Enabled)
                picBox.Image = IEnabled;
            Graphics.FromImage(picBox.Image).
                DrawString(SText, new Font("Transformers Movie", Height / 3, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(0, Height / 3));
        }

        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Enabled)
                picBox.Image = IOnclick;
        }

        private void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Enabled)
                picBox.Image = IEnabled;
        }

        private void ImageButton_Load(object sender, EventArgs e)
        {
            picBox.Left = 0;
            picBox.Top = 0;
            picBox.Height = Height;
            picBox.Width = Width;
            
            if (Enabled)
                picBox.Image = IEnabled;
            else
                picBox.Image = IDisabled;
            Graphics.FromImage(picBox.Image).
                DrawString(SText, new Font("Transformers Movie", Height / 3, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(0, Height/3));
            picBox.Refresh();
        }

        private void picBox_MouseEnter(object sender, EventArgs e)
        {
            if (Enabled)
                picBox.Image = IHover;
            Graphics.FromImage(picBox.Image).
                DrawString(SText, new Font("Transformers Movie", Height / 3, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(0, Height /3));
        }

        private void ImageButton_EnabledChanged(object sender, EventArgs e)
        {
            if (Enabled)
                picBox.Image = IEnabled;
            else
                picBox.Image = IDisabled;
        }
    }
}
