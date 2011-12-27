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
    public partial class ShowInformation : UserControl
    {
        //title 
        private String sText;// button text
        public System.String SText
        {
            get { return sText; }
            set { sText = value; }
        }
        private Color tColor = Color.White; // text color
        public System.Drawing.Color TColor
        {
            get { return tColor; }
            set { tColor = value; }
        }
        private Color strokeColor = Color.Black; //stroke color
        public System.Drawing.Color StrokeColor
        {
            get { return strokeColor; }
            set { strokeColor = value; }
        }
        private int strokeWidth = 2; //stroke width

        public int StrokeWidth
        {
            get { return strokeWidth; }
            set { strokeWidth = value; }
        }
        private Font fText; // font of text
        public System.Drawing.Font FText
        {
            get { return fText; }
            set { fText = value; }
        }
        private Point pText; //pos of text
        public System.Drawing.Point PText
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
        public System.Drawing.Color CNumber
        {
            get { return cNumber; }
            set { cNumber = value; }
        }
        //Image
        private Bitmap image;
        public System.Drawing.Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }
        public ShowInformation()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!Enabled)
                return;
            Font TFont = new Font("Transformers Movie", 20, FontStyle.Bold);
            Point TPos;
            SizeF sz = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(SText, TFont);
            picBox.Top = (int)sz.Height;
            //sap xep vi tri cua text
            if (picBox.Height - (int)sz.Height < 0 || picBox.Width - (int)sz.Width < 0)
                TPos = new Point(0, 0);
            else
                TPos = new Point((picBox.Width - (int)sz.Width) / 2, 0);
            e.Graphics.DrawString("Next Shape", TFont, new SolidBrush(Color.Red), TPos);
            //Graphics.FromImage(picBox.Image)
        }
    }
}
