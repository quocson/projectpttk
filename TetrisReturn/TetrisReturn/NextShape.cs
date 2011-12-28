﻿using System;
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
        private Shape shapeNext;
        private bool drawabled;
        private Bitmap buffer;
        private Bitmap imgBack;
        private int iTopShape;

        public Shape ShapeNext
        {
            get { return shapeNext; }
            set
            {
                shapeNext = value;
                if (Drawabled)
                {
                    Graphics.FromImage(buffer).DrawImage(ImgBack, new Point(0, 0));
                    Graphics.FromImage(buffer).DrawImage(getImgFromTxt(), PText);
                    SizeF sz = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(SText, FText);
                    iTopShape = 0;
                    if (Width - 4 * Constants.blockSize + 3 * Constants.blockDelta > 0)
                        iTopShape = (Width - 4 * Constants.blockSize + 3 * Constants.blockDelta) / 2;
                    shapeNext = new Shape(shapeNext, iTopShape, (int)sz.Height);
                    shapeNext.drawShape(Graphics.FromImage(buffer));
                }
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
            set{sText = value;}
        }
        public bool Drawabled
        {
            get { return drawabled; }
            set { 
                drawabled = value;
                if (!Drawabled)
                    return;
                buffer = new Bitmap(Width, Height);
                SizeF sz = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(SText, FText);

                iTopShape = 0;
                if (Width - 4 * Constants.blockSize + 3 * Constants.blockDelta > 0)
                    iTopShape = (Width - 4 * Constants.blockSize + 3 * Constants.blockDelta) / 2;
                shapeNext = new Shape(shapeNext, iTopShape, (int)sz.Height);

                if (Width - (int)sz.Width < 0)
                    PText = new Point(0, 0);
                else
                    PText = new Point((Width - (int)sz.Width) / 2, 0);
                shapeNext.drawShape(Graphics.FromImage(buffer));
                Graphics.FromImage(buffer).DrawImage(ImgBack, new Point(0, 0));
                Graphics.FromImage(buffer).DrawImage(getImgFromTxt(), PText);
                Refresh();
            }
        }
        public NextShape()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!Drawabled)
                return;
            e.Graphics.DrawImage(buffer, new Point(0,0));
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