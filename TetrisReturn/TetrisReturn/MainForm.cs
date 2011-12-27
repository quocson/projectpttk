using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TetrisReturn
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Bitmap a = new Bitmap(100, 100);
            Graphics.FromImage(a).FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, 100, 100));
            imageButton1.IEnabled = a;
            a.Dispose();
            a = new Bitmap(100, 100);
            Graphics.FromImage(a).FillRectangle(new SolidBrush(Color.Red), new Rectangle(0, 0, 100, 100));
            imageButton1.IHover = a;
            a.Dispose();
            a = new Bitmap(100, 100);
            Graphics.FromImage(a).FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, 0, 100, 100));
            imageButton1.IOnclick = a;
            a.Dispose();
            a = new Bitmap(100, 100);
            imageButton1.Height = imageButton1.Width = 100;

            imageButton1.TFont = new Font("Arial", 20);
            imageButton1.SText = "SON";
            imageButton1.TPos = new Point(0, 0);
            imageButton1.Drawabled = true;
            
        }
    }
}
