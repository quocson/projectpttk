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
    public partial class ShowInformation : UserControl
    {
        //title 
        private String sText;// button text
        public String SText
        {
            get { return sText; }
            set { sText = value; }
        }
        private Color cText = Color.White; // text color
        public Color CText
        {
            get { return cText; }
            set { cText = value; }
        }
        private Color cStroke = Color.Black; //stroke color
        public Color CStroke
        {
            get { return cStroke; }
            set { cStroke = value; }
        }
        private int iWidth = 2; //stroke width

        public int IWidth
        {
            get { return iWidth; }
            set { iWidth = value; }
        }
        private Font fText; // font of text
        public Font FText
        {
            get { return fText; }
            set { fText = value; }
        }
        private Point pText; //pos of text
        public Point PText
        {
            get { return pText; }
            set { pText = value; }
        }
        // number
        private int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        private Point pNumber;
        public Point PNumber
        {
            get { return pNumber; }
            set { pNumber = value; }
        }
        private Font fNumber;
        public Font FNumber
        {
            get { return fNumber; }
            set { fNumber = value; }
        }
        private Color cNumber;
        public Color CNumber
        {
            get { return cNumber; }
            set { cNumber = value; }
        }
        //Image
        private Bitmap imgBack;

        public Bitmap ImgBack
        {
            get { return imgBack; }
            set { imgBack = value; }
        }
  
        private bool drawabled;
        public bool Drawabled
        {
            get { return drawabled; }
            set
            {
                drawabled = value;
                if (!Drawabled)
                    return;

                SizeF sz = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(SText, FText);
                if (Width - (int)sz.Width < 0)
                    PText = new Point(0, 0);
                else
                    PText = new Point((Width - (int)sz.Width) / 2, 0);
                Refresh();
            }
        }
        public ShowInformation()
        {
            InitializeComponent();
            Drawabled = false;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!Drawabled)
                return;
            SizeF sz = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(SText, FText);
            //sap xep vi tri cua title
            if (Width - (int)sz.Width < 0)
                PText = new Point(0, 0);
            else
                PText = new Point((Width - (int)sz.Width) / 2, 0);
            SizeF szn = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(Number.ToString(), FNumber);
            if (Width - (int)szn.Width < 0)
                PNumber= new Point(0, 0);
            else
                PNumber = new Point((Width - (int)szn.Width) / 2, (int)sz.Width);
            e.Graphics.DrawImage(ImgBack, new Point(0, 0));
            e.Graphics.DrawImage(getImgFromTxt(), PText);
            e.Graphics.DrawImage(getImgFromNo(), PNumber);
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
        private Image getImgFromNo()
        {
            Bitmap bmpOut = null; // bitmap we are creating and will return from this function.
            if (FNumber == null || Number.ToString() == null)
                return bmpOut;
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF sz = g.MeasureString(Number.ToString(), FNumber);
                Bitmap bmp = new Bitmap((int)sz.Width, (int)sz.Height);
                Graphics gBmp = Graphics.FromImage(bmp);
                SolidBrush brBack = new SolidBrush(Color.FromArgb(255, CStroke.R, CStroke.G, CStroke.B));
                using (SolidBrush brFore = new SolidBrush(CNumber))
                {
                    gBmp.SmoothingMode = SmoothingMode.HighQuality;
                    gBmp.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gBmp.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    gBmp.DrawString(Number.ToString(), FNumber, brBack, 0, 0);

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
                        gBmpOut.DrawString(Number.ToString(), FNumber, brFore, iWidth / 2, iWidth / 2);
                    }
                }
            }

            return bmpOut;
        }
    }
}
