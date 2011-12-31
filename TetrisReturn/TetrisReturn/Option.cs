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
    public partial class Option : Form
    {
        private MainForm mainForm;
        private Point toClose = new Point(0, 0);

        public Option(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Option_MouseUp(object sender, MouseEventArgs e)
        {
            if ((Math.Abs(e.Y - toClose.Y) < 100) && ((toClose.X - e.X) >= 200))
            {
                disappear();
                Close();
            }

        }

        private void Option_Shown(object sender, EventArgs e)
        {
            appear();

        }

        private void Option_MouseDown(object sender, MouseEventArgs e)
        {
            
            toClose = new Point(e.X, e.Y);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Constants.theme.OptionBackground, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
        private void appear()
        {
            int i;
            for (i = 1; i <= 126; i++)
            {
                this.SetDesktopLocation(mainForm.Location.X - 800 + 10 * i, mainForm.Location.Y + 110);
                Refresh();
            }
            for (i = 126; i >= 104; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X - 800 + 10 * i, mainForm.Location.Y + 110);
                Refresh();
            }
        }

        private void disappear()
        {
            for (int i = 104; i >= 1; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X - 800 + 10 * i, mainForm.Location.Y + 110);
                Refresh();
            }
        }
    }
}