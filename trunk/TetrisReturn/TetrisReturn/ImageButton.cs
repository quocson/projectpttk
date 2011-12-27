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
        private Bitmap iEnabled;
        private Bitmap iDisabled;
        private Bitmap iHover;
        private Bitmap iOnclick;
        //String 
        private String sText;// button text
        private Color tColor = Color.White; // text color
        private Color strokeColor = Color.Black; //stroke color
        private int strokeWidth = 2; //stroke width
        private Font tFont; // font of text
        private Point tPos; //pos of text
        //Drawable
        private bool drawabled;
        private Bitmap buffer;
        public bool Drawabled
        {
            get { return drawabled; }
            set { 
                drawabled = value;

                if (drawabled)
                {
                    buffer = new Bitmap(Height, Width);
                    SizeF sz = Graphics.FromImage(buffer).MeasureString(SText, TFont);
                    if (Width - (int)sz.Width > 0 && Height - (int)sz.Height > 0)
                        TPos = new Point((Width - (int)sz.Width) / 2, (Height - (int)sz.Height) / 2);
                    else
                        TPos = new Point(0, 0);
                    drawImg();
                    Refresh();
                }
            }
        }
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
                //SizeF sz = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(SText, TFont);
                ////sap xep vi tri cua text
                //if (picBox.Height - (int)sz.Height < 0 || picBox.Width - (int)sz.Width < 0)
                //    TPos = new Point(0, 0);
                //else
                //    TPos = new Point((picBox.Width - (int)sz.Width) / 2, (picBox.Height - (int)sz.Height) / 2);
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
                //if (TFont != null && SText != null)
                //{
                //    SizeF sz = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(SText, TFont);
                //    //sap xep vi tri cua text
                //    if (picBox.Height - (int)sz.Height < 0 || picBox.Width - (int)sz.Width < 0)
                //        TPos = new Point(0, 0);
                //    else
                //        TPos = new Point((picBox.Width - (int)sz.Width) / 2, (picBox.Height - (int)sz.Height) / 2);
                //    drawStr();
                //    drawImg();
                //}
            }
        }
        
        public Bitmap IEnabled
        {
            get { return iEnabled; }
            set
            {

                if (value == null)
                    return;
                iEnabled = new Bitmap(value.Width, value.Height);
                Graphics.FromImage(iEnabled).DrawImage(value, new Point(0, 0));
            }
        }
        public Bitmap IDisabled
        {
            get { return iDisabled; }
            set
            {
                if (value == null)
                    return;
                iDisabled = new Bitmap(value.Width, value.Height);
                Graphics.FromImage(iDisabled).DrawImage(value, new Point(0, 0));
            }
        }
        public Bitmap IHover
        {
            get { return iHover; }
            set
            {

                if (value == null)
                    return;
                iHover = new Bitmap(value.Width, value.Height);
                Graphics.FromImage(iHover).DrawImage(value, new Point(0, 0));
            }
        }
        public Bitmap IOnclick
        {
            get { return iOnclick; }
            set
            {

                if (value == null)
                    return;
                iOnclick = new Bitmap(value.Width, value.Height);
                Graphics.FromImage(iOnclick).DrawImage(value, new Point(0, 0));
            }
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
            SizeF sz = Graphics.FromImage(buffer).MeasureString(SText, TFont);
            if (Width - (int)sz.Width > 0 && Height - (int)sz.Height > 0)
                TPos = new Point((Width - (int)sz.Width) / 2, (Height - (int)sz.Height) / 2);
            else
                TPos = new Point(0, 0);
            if(Enabled)
            {
                Graphics.FromImage(buffer).DrawImage(IEnabled, new Point(0, 0));
                Graphics.FromImage(buffer).DrawImage(getImgFromTxt(), TPos);
            }
            else
            {
                Graphics.FromImage(buffer).DrawImage(IDisabled, new Point(0, 0));
                Graphics.FromImage(buffer).DrawImage(getImgFromTxtDis(), TPos);
            }
        }

        private Image getImgFromTxtDis() // ve text trong -  disable
        {
            if (TFont == null || SText == null)
                return null;
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
            if (TFont == null || SText == null)
                return bmpOut;
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF sz = g.MeasureString(SText, TFont);
                Bitmap bmp = new Bitmap((int)sz.Width, (int)sz.Height);
                Graphics gBmp = Graphics.FromImage(bmp);
                SolidBrush brBack = new SolidBrush(Color.FromArgb(255, StrokeColor.R, StrokeColor.G, StrokeColor.B));
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
                Graphics.FromImage(buffer).DrawImage(IHover, new Point(0, 0));
                Graphics.FromImage(buffer).DrawImage(getImgFromTxt(), TPos);
            }
            Refresh();
        }

        private void ImageButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (Enabled)
            {
                Graphics.FromImage(buffer).DrawImage(IOnclick, new Point(0, 0));
                Graphics.FromImage(buffer).DrawImage(getImgFromTxt(), TPos);
            }
            Refresh();
        }

        private void ImageButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.X > 0 && e.X < Width && e.Y > 0 && e.Y < Height)
            {

            }
            drawImg();
            Refresh();   
        }
    }
}
