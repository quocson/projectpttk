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
        private String sTitle;// button text
        public String STitle
        {
            get { return sTitle; }
            set
            {
                sTitle = value;
                if (value != null)
                    Refresh();
            }
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
        private Font fTitle; // font of text
        public Font FTitle
        {
            get { return fTitle; }
            set
            {
                fTitle = value; 
                if (value != null)
                    Refresh();
            }
        }
        // info
        private string sInfo;
        public string SInfo
        {
            get { return sInfo; }
            set 
            { 
                sInfo = value;
                if (value != null)
                    Refresh();
            }
        }
        
        private Font fInfo;
        public Font FInfo
        {
            get { return fInfo; }
            set
            {
                fInfo = value; 
                if (value != null)
                    Refresh();
            }
        }
        private Color cInfo = Color.White;
        public Color CInfo
        {
            get { return cInfo; }
            set { cInfo = value; }
        }
        //Image
        private Bitmap imgBack;

        public Bitmap ImgBack
        {
            get { return imgBack; }
            set { imgBack = value;
            if (value != null)
                Refresh();
            }
        }
        public ShowInformation()
        {
            InitializeComponent();

            FTitle = new Font("Arial", 15);

            FInfo = new Font("Arial", 15);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }
        
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (ImgBack == null )
                return;
            e.Graphics.DrawImage(ImgBack, new Point(0, 0));
             if (STitle == null || FTitle == null || STitle.Length <=0)
                 return;
            SizeF sz = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(STitle, FTitle);
            //sap xep vi tri cua title
            Point PTitle = new Point(0, 0);
            if (Width - (int)sz.Width > 0 )
                PTitle = new Point((Width - (int)sz.Width) / 2, 0);

            e.Graphics.DrawImage(getImgFromTxt(), PTitle);
            if (SInfo == null || FInfo == null || SInfo.Length <= 0)
                return;
            SizeF szn = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(SInfo.ToString(), FInfo);

            Point PInfo = new Point(0,(int) sz.Height);
            if (Width - (int)szn.Width > 0)
                PInfo = new Point((Width - (int)szn.Width) / 2, (int)sz.Height);
            e.Graphics.DrawImage(getImgFromNo(), PInfo);
        }
        private Image getImgFromTxt()
        {
            Bitmap bmpOut = null; // bitmap we are creating and will return from this function.
            if (FTitle == null || STitle == null)
                return bmpOut;
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF sz = g.MeasureString(STitle, FTitle);
                Bitmap bmp = new Bitmap((int)sz.Width, (int)sz.Height);
                Graphics gBmp = Graphics.FromImage(bmp);
                SolidBrush brBack = new SolidBrush(Color.FromArgb(255, CStroke.R, CStroke.G, CStroke.B));
                using (SolidBrush brFore = new SolidBrush(CText))
                {
                    gBmp.SmoothingMode = SmoothingMode.HighQuality;
                    gBmp.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gBmp.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    gBmp.DrawString(STitle, FTitle, brBack, 0, 0);

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
                        gBmpOut.DrawString(STitle, FTitle, brFore, iWidth / 2, iWidth / 2);
                    }
                }
            }

            return bmpOut;
        }
        private Image getImgFromNo()
        {
            Bitmap bmpOut = null; // bitmap we are creating and will return from this function.
            if (FInfo == null || SInfo.ToString() == null)
                return bmpOut;
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF sz = g.MeasureString(SInfo, FInfo);
                Bitmap bmp = new Bitmap((int)sz.Width, (int)sz.Height);
                Graphics gBmp = Graphics.FromImage(bmp);
                SolidBrush brBack = new SolidBrush(Color.FromArgb(255, CStroke.R, CStroke.G, CStroke.B));
                using (SolidBrush brFore = new SolidBrush(CInfo))
                {
                    gBmp.SmoothingMode = SmoothingMode.HighQuality;
                    gBmp.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gBmp.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    gBmp.DrawString(SInfo.ToString(), FInfo, brBack, 0, 0);

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
                        gBmpOut.DrawString(SInfo, FInfo, brFore, iWidth / 2, iWidth / 2);
                    }
                }
            }

            return bmpOut;
        }

        
    

    }
}
