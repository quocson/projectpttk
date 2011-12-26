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
            Bitmap a = new Bitmap(this.Width, this.Height);
            Graphics.FromImage(a).FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, 0, this.Width, this.Height));
            this.imageButton1.IHover = a;
            Bitmap b = new Bitmap(this.Width, this.Height);
            Graphics.FromImage(b).FillRectangle(new SolidBrush(Color.Red), new Rectangle(0, 0, this.Width, this.Height));
            this.imageButton1.IEnabled = b;
            imageButton1.SText = "Pro";

        }
    }
}
