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
        //bitmap for state
        //String 
        private String sText;// button text
        private Color cText = Color.White; // text color
        private Color cStroke = Color.Black; //stroke color
        private int iWidth = 2; //stroke width
        private Font fText; // font of text
        private Point pText; //pos of text
        //Drawable
        private bool drawabled;
        private Bitmap buffer;
        //event
        public delegate void ImageButton_ClickHandle();
        public event ImageButton_ClickHandle Button_Click;
        public bool Drawabled
        {
            get { return drawabled; }
            set { 
                drawabled = value;
                if (drawabled)
                {
                    buffer = new Bitmap(Height, Width);
                    SizeF sz = Graphics.FromImage(buffer).MeasureString(SText, FText);
                    if (Width - (int)sz.Width > 0 && Height - (int)sz.Height > 0)
                        PText = new Point((Width - (int)sz.Width) / 2, (Height - (int)sz.Height) / 2);
                    else
                        PText = new Point(0, 0);
                    drawImg();
                    Refresh();
                }
            }
        }
        public Point PText
        {
            get { return pText; }
            set { pText = value; }
        }
        public Font FText
        {
            get { return fText; }
            set { fText = value;}
        }
        public int IWidth
        {
            get { return iWidth; }
            set { iWidth = value; }
        }
        public Color CStroke
        {
            get { return cStroke; }
            set { cStroke = value; }
        }
        public Color CText
        {
            get { return cText; }
            set { cText = value; }
        }
        public String SText
        {
            get { return sText; }
            set { sText = value;}
        }
        
        
        public ImageButton()
        {
            InitializeComponent();

            Drawabled = false;
            
            //default
        }

        protected override void  OnPaint(PaintEventArgs e)
        {
 	        base.OnPaint(e);
            if(Drawabled)
                e.Graphics.DrawImage(buffer, new Point(0,0));
        }
        


        private void drawImg()
        {
            if (!Drawabled)
                return;
            SizeF sz = Graphics.FromImage(buffer).MeasureString(SText, FText);
            if (Width - (int)sz.Width > 0 && Height - (int)sz.Height > 0)
                PText = new Point((Width - (int)sz.Width) / 2, (Height - (int)sz.Height) / 2);
            else
                PText = new Point(0, 0);
            if(Enabled)
            {
                Graphics.FromImage(buffer).DrawImage(Constants.theme.NormalButton, new Point(0, 0));
                Graphics.FromImage(buffer).DrawImage(getImgFromTxt(), PText);
            }
            else
            {
                Graphics.FromImage(buffer).DrawImage(Constants.theme.DisableButton, new Point(0, 0));
                Graphics.FromImage(buffer).DrawImage(getImgFromTxtDis(), PText);
            }
        }

        private Image getImgFromTxtDis() // ve text trong -  disable
        {
            if (FText == null || SText == null)
                return null;
            Bitmap bmpOut = null; 
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            SizeF sz = g.MeasureString(SText, FText);
            bmpOut = new Bitmap((int)sz.Width + iWidth, (int)sz.Height + iWidth);
            SolidBrush brFore = new SolidBrush(Color.White);
            Graphics gBmpOut = Graphics.FromImage(bmpOut);
            gBmpOut.SmoothingMode = SmoothingMode.HighQuality;
            gBmpOut.InterpolationMode = InterpolationMode.HighQualityBilinear;
            gBmpOut.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            gBmpOut.DrawString(SText, FText, brFore, iWidth / 2, iWidth / 2);
            return bmpOut;
        }

        private Image getImgFromTxt()
        {
            Bitmap bmpOut = null; // bitmap we are creating and will return from this function.
            if (FText == null || SText == null)
                return bmpOut;
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF sz = g.MeasureString(SText, FText);
                Bitmap bmp = new Bitmap((int)sz.Width, (int)sz.Height);
                Graphics gBmp = Graphics.FromImage(bmp);
                SolidBrush brBack = new SolidBrush(Color.FromArgb(255, CStroke.R, CStroke.G, CStroke.B));
                using (SolidBrush brFore = new SolidBrush(CText))
                {
                    gBmp.SmoothingMode = SmoothingMode.HighQuality;
                    gBmp.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gBmp.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    gBmp.DrawString(SText, FText, brBack, 0, 0);

                    // make bitmap we will return.
                    bmpOut = new Bitmap(bmp.Width + iWidth, bmp.Height + iWidth);
                    using (Graphics gBmpOut = Graphics.FromImage(bmpOut))
                    {
                        gBmpOut.SmoothingMode = SmoothingMode.HighQuality;
                        gBmpOut.InterpolationMode = InterpolationMode.HighQualityBilinear;
                        gBmpOut.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                        // smear image of background of text about to make blurred background "halo"
                        for (int x = 0; x <= iWidth; x++)
                            for (int y = 0; y <= iWidth; y++)
                                gBmpOut.DrawImageUnscaled(bmp, x, y);

                        // draw actual text
                        gBmpOut.DrawString(SText, FText, brFore, iWidth / 2, iWidth / 2);
                    }
                }
            }

            return bmpOut;
        }

        
        private void ImageButton_EnabledChanged(object sender, EventArgs e)
        {
            Refresh();            
        }

        private void ImageButton_MouseLeave(object sender, EventArgs e)
        {
            drawImg();
            Refresh();
        }

        private void ImageButton_MouseEnter(object sender, EventArgs e)
        {
            if (Enabled)
            {
                Graphics.FromImage(buffer).DrawImage(Constants.theme.HoverButton, new Point(0, 0));
                Graphics.FromImage(buffer).DrawImage(getImgFromTxt(), PText);
            }
            Refresh();
        }

        private void ImageButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (Enabled)
            {
                Graphics.FromImage(buffer).DrawImage(Constants.theme.ClickButton, new Point(0, 0));
                Graphics.FromImage(buffer).DrawImage(getImgFromTxt(), PText);
            }
            Refresh();
        }

        private void ImageButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.X > 0 && e.X < Width && e.Y > 0 && e.Y < Height)
            {
                Button_Click();
            }
            drawImg();
            Refresh();   
        }
    }
}
