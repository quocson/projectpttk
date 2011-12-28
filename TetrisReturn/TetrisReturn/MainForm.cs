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
            Bitmap a = new Bitmap(showInformation1.Width, showInformation1.Height);
            Graphics.FromImage(a).FillRectangle(new SolidBrush(Color.Brown), new Rectangle(0, 0, showInformation1.Width, showInformation1.Height));
            showInformation1.ImgBack = a;
            showInformation1.FText = new Font("Transformers", 25);
            showInformation1.SText = "tT";
            showInformation1.FNumber = new Font("DS-Digital", 30);
            showInformation1.Number = 100;
            showInformation1.Drawabled = true;
        }
    }
}
