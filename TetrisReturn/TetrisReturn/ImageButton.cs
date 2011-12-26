using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace TetrisReturn
{
    public partial class ImageButton : UserControl
    {
        private Bitmap iEnabled;
        private Bitmap iDisabled;
        private Bitmap iHover;
        private Bitmap iOnclick;
        private String sText;// button text
        private Color tColor = Color.White; // text color
        private Color strokeColor = Color.Black; //stroke color
        private int strokeWidth = 2; //stroke width
        private Font tFont; // font of text
        private Point tPos; //pos of text
        public Point TPos
        {
            get { return tPos; }
            set { tPos = value; }
        }
        public Font TFont
        {
            get { return tFont; }
            set { 
                tFont = value;
                SizeF sz = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(SText, TFont);
                //sap xep vi tri cua text
                if (picBox.Height - (int)sz.Height < 0 || picBox.Width - (int)sz.Width < 0)
                    TPos = new Point(0, 0);
                else
                    TPos = new Point((picBox.Width - (int)sz.Width) / 2, (picBox.Height - (int)sz.Height) / 2);
            }
        }
        public int StrokeWidth
        {
            get { return strokeWidth; }
            set { strokeWidth = value; }
        }
        public Color StrokeColor
        {
            get { return strokeColor; }
            set { strokeColor = value; }
        }

        public Color TColor
        {
            get { return tColor; }
            set { tColor = value; }
        }
        public String SText
        {
            get { return sText; }
            set
            {
                sText = value;
                if (canDraw())
                {
                    SizeF sz = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(SText, TFont);
                    //sap xep vi tri cua text
                    if (picBox.Height - (int)sz.Height < 0 || picBox.Width - (int)sz.Width < 0)
                        TPos = new Point(0, 0);
                    else
                        TPos = new Point((picBox.Width - (int)sz.Width) / 2, (picBox.Height - (int)sz.Height) / 2);
                    drawStr();
                    drawImg();
                }
            }
        }
        public Bitmap IEnabled
        {
            get { return iEnabled; }
            set { iEnabled = value; }
        }

        public Bitmap IDisabled
        {
            get { return iDisabled; }
            set { iDisabled = value;}
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
            //default
            picBox.Top = 0;
            picBox.Left = 0;
            picBox.Height = Height;
            picBox.Width = Width;
            picBox.Image = new Bitmap(picBox.Width, picBox.Height);
            TPos = new Point(0, 0);
            TFont = new Font("Arial", 5);
        }


        private void picBox_MouseHover(object sender, EventArgs e)
        {
            if (Enabled && IHover != null)
                Graphics.FromImage(picBox.Image).DrawImage(IHover, new Point(0, 0));
            drawStr(); 
        }

        private void picBox_MouseLeave(object sender, EventArgs e)
        {
            if (Enabled && IEnabled != null)
                Graphics.FromImage(picBox.Image).DrawImage(IEnabled, new Point(0, 0));
            drawStr();
        }

        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Enabled && IHover != null)
                Graphics.FromImage(picBox.Image).DrawImage(IHover, new Point(0, 0));
            drawStr();            
        }

        private void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Enabled && IEnabled != null)
                Graphics.FromImage(picBox.Image).DrawImage(IEnabled, new Point(0, 0));
            drawStr();
            if (e.X <= picBox.Width && e.X <= picBox.Height && e.X >= 0 && e.Y >= 0)
            {
                //thuc hien
                MessageBox.Show("It's Ok!");
            }
        }
      
        private void picBox_MouseEnter(object sender, EventArgs e)
        {
            if (Enabled && IEnabled != null)
                Graphics.FromImage(picBox.Image).DrawImage(IHover, new Point(0, 0));
            drawStr();            
        }

        private void drawStr()
        {
            if (Enabled)
                Graphics.FromImage(picBox.Image).DrawImage(getImgFromTxt(), TPos);
            else
                Graphics.FromImage(picBox.Image).DrawImage(getImgFromTxtDis(), TPos);
            picBox.Refresh();
        }

        private void drawImg()
        {
            if (Enabled && IEnabled != null)
            {
                Graphics.FromImage(picBox.Image).DrawImage(IEnabled, new Point(0, 0));
            }
            else
            {
                Graphics.FromImage(picBox.Image).DrawImage(IDisabled, new Point(0, 0));
            }
            drawStr();  
        }

        private Image getImgFromTxtDis() // ve text trong -  disable
        {
            Bitmap bmpOut = null; // bitmap we are creating and will return from this function.
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            SizeF sz = g.MeasureString(SText, TFont);
            bmpOut = new Bitmap((int)sz.Width + strokeWidth, (int)sz.Height + strokeWidth);
            SolidBrush brFore = new SolidBrush(Color.White);
            Graphics gBmpOut = Graphics.FromImage(bmpOut);
            gBmpOut.SmoothingMode = SmoothingMode.HighQuality;
            gBmpOut.InterpolationMode = InterpolationMode.HighQualityBilinear;
            gBmpOut.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            gBmpOut.DrawString(SText, TFont, brFore, strokeWidth / 2, strokeWidth / 2);
            return bmpOut;
        }

        private Image getImgFromTxt()
        {
            Bitmap bmpOut = null; // bitmap we are creating and will return from this function.

            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF sz = g.MeasureString(SText, TFont);
                using (Bitmap bmp = new Bitmap((int)sz.Width, (int)sz.Height))
                using (Graphics gBmp = Graphics.FromImage(bmp))
                using (SolidBrush brBack = new SolidBrush(Color.FromArgb(255, StrokeColor.R, StrokeColor.G, StrokeColor.B)))
                using (SolidBrush brFore = new SolidBrush(TColor))
                {
                    gBmp.SmoothingMode = SmoothingMode.HighQuality;
                    gBmp.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gBmp.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    gBmp.DrawString(SText, TFont, brBack, 0, 0);

                    // make bitmap we will return.
                    bmpOut = new Bitmap(bmp.Width + strokeWidth, bmp.Height + strokeWidth);
                    using (Graphics gBmpOut = Graphics.FromImage(bmpOut))
                    {
                        gBmpOut.SmoothingMode = SmoothingMode.HighQuality;
                        gBmpOut.InterpolationMode = InterpolationMode.HighQualityBilinear;
                        gBmpOut.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                        // smear image of background of text about to make blurred background "halo"
                        for (int x = 0; x <= strokeWidth; x++)
                            for (int y = 0; y <= strokeWidth; y++)
                                gBmpOut.DrawImageUnscaled(bmp, x, y);

                        // draw actual text
                        gBmpOut.DrawString(SText, TFont, brFore, strokeWidth / 2, strokeWidth / 2);
                    }
                }
            }

            return bmpOut;
        }

        private bool canDraw()
        {
            if (TFont == null)
                return false;
            if (SText == null)
                return false;
            if (IEnabled == null)
                return false;
            if (IDisabled == null)
                return false;
            if (IOnclick == null)
                return false;
            if (IHover== null)
                return false;
            if (TColor == null)
                return false;
            if (StrokeColor == null)
                return false;
            if (TPos == null)
                return false;

            return true;
        }
        private void ImageButton_EnabledChanged(object sender, EventArgs e)
        {
            drawImg();
            drawStr();            
        }
    }
}
