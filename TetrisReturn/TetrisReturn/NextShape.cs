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
    public partial class NextShape : UserControl
    {
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
            set
            {
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
                    
                }
            }
        }
        public NextShape()
        {
            InitializeComponent();
            
            picBox.Height = Height;
            picBox.Width = Width;
            picBox.Image = new Bitmap(picBox.Width, picBox.Height);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Font TFont = new Font("Transformers Movie", 20, FontStyle.Bold);
            Point TPos;
            SizeF sz = Graphics.FromImage(new Bitmap(2, 2)).MeasureString(SText, TFont);
            picBox.Top = (int) sz.Height;
                    //sap xep vi tri cua text
            if (picBox.Height - (int)sz.Height < 0 || picBox.Width - (int)sz.Width < 0)
                TPos = new Point(0, 0);
            else
                TPos = new Point((picBox.Width - (int)sz.Width) / 2, 0);
            e.Graphics.DrawString("Next Shape", TFont, new SolidBrush(Color.Red), TPos);
            //Graphics.FromImage(picBox.Image)
        }
        private bool canDraw()
        {
            if (TFont == null)
                return false;
            if (SText == null)
                return false;
            if (TColor == null)
                return false;
            if (StrokeColor == null)
                return false;
            if (TPos == null)
                return false;

            return true;
        }
    }
}
