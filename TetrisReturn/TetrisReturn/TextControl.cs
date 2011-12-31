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
using System.Drawing.Imaging;

namespace TetrisReturn
{
    public partial class TextControl : UserControl
    {
        private Font tFont;
	    public System.Drawing.Font TFont
	    {
		    get { return tFont; }
            set
            {
                tFont = value;
                Refresh();
            }
	    }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Refresh();
            }
        }
        public TextControl()
        {
            InitializeComponent();
            TFont = new Font("Arial", 12);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Text == null || TFont == null)
            return;
            Point PText ;
            SizeF szn = e.Graphics.MeasureString(Text, TFont);
            if (Width - (int)szn.Width < 0)
                PText= new Point(0, 0);
            else
                PText = new Point((Width - (int)szn.Width) / 2, (Height - (int)szn.Height) / 2);
            if(getImgFromTxt() != null)
                e.Graphics.DrawImage(getImgFromTxt(), PText);
        }
        
        private Image getImgFromTxt()
        {
            Bitmap bmpOut = null; // bitmap we are creating and will return from this function.
            if (Text == null || TFont == null)
                return bmpOut;
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF sz = g.MeasureString(Text, TFont);
                if((int)sz.Width <= 0 ||(int)sz.Height <= 0)
                return null;
                Bitmap bmp = new Bitmap((int)sz.Width, (int)sz.Height);
                Graphics gBmp = Graphics.FromImage(bmp);
                SolidBrush brBack = new SolidBrush(Color.FromArgb(255, Color.Black));
                using (SolidBrush brFore = new SolidBrush(Color.White))
                {
                    gBmp.SmoothingMode = SmoothingMode.HighQuality;
                    gBmp.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gBmp.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    gBmp.DrawString(Text, TFont, brBack, 0, 0);

                    // make bitmap we will return.
                    bmpOut = new Bitmap(bmp.Width + 2, bmp.Height + 2);
                    using (Graphics gBmpOut = Graphics.FromImage(bmpOut))
                    {
                        gBmpOut.SmoothingMode = SmoothingMode.HighQuality;
                        gBmpOut.InterpolationMode = InterpolationMode.HighQualityBilinear;
                        gBmpOut.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                        // smear image of background of text about to make blurred background "halo"
                        for (int x = 0; x <= 2; x++)
                            for (int y = 0; y <= 2; y++)
                                gBmpOut.DrawImageUnscaled(bmp, x, y);

                        // draw actual text
                        gBmpOut.DrawString(Text, TFont, brFore, 1, 1);
                    }
                }
            }

            return bmpOut;
        }
    }
}
