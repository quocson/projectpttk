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
    public partial class NextShape : UserControl
    {
        private String sText;// button text
        private Color cText = Color.White; // text color
        private Color cStroke = Color.Black; //stroke color
        private int iWidth = 2; //stroke width
        private Font fText; // font of text
        private Point pText; //pos of text
        private Shape shapeNext = null;
        private Bitmap imgBack;
        private int iTopShape;

        public Shape ShapeNext
        {
            get { return shapeNext; }
            set
            {
                shapeNext = value;
                if (value != null)
                    Refresh();                   
            }
        }
        public Bitmap ImgBack
        {
            get { return imgBack; }
            set
            {
                if (value == null)
                    return;
                imgBack = new Bitmap(value.Width, value.Height);
                Graphics.FromImage(imgBack).DrawImage(value, new Point(0, 0));
                if (value != null)
                    Refresh();
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
            set{fText = value;}
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
            set{
                sText = value;
            if (value != null)
                Refresh();
            }
        }
        
        public NextShape()
        {
            InitializeComponent();
            FText = new Font("Arial", 20);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if(ImgBack == null)
                return;
            e.Graphics.DrawImage(ImgBack, new Point(0, 0));

            if(SText == null)
                return;
            SizeF sz = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(SText, FText);
            if (Width - (int)sz.Width > 0 && Height - (int)sz.Height > 0)
                PText = new Point((Width - (int)sz.Width) / 2, 0);
            else
                PText = new Point(0, 0);

            e.Graphics.DrawImage(getImgFromTxt(), PText);

            if(shapeNext == null)
                return;
            iTopShape = 0;
            if (Width - shapeNext.Col * Constants.blockSize  > 0)
                iTopShape = (Width - shapeNext.Col * Constants.blockSize) / 2;
            shapeNext = new Shape(shapeNext, iTopShape, (int)sz.Height +  Constants.blockSize);
            shapeNext.drawShape(e.Graphics);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
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
    }
}
