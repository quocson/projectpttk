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
    public partial class Help : Form
    {
        private MainForm mainForm;
        private Point toClose = new Point(0, 0);

        public Help(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Help_Shown(object sender, EventArgs e)
        {
            Constants.soundControl.playSoundDis_appear();
            appear();
        }

        private void Help_MouseDown(object sender, MouseEventArgs e)
        {
        
            toClose = new Point(e.X, e.Y);
        }

        private void Help_MouseUp(object sender, MouseEventArgs e)
        {
            if ((Math.Abs(e.Y - toClose.Y) < 100) && ((e.X - toClose.X) >= 200))
            {
                Constants.soundControl.playSoundDis_appear();
                disappear();
                Close();
            }
        
        }

        private void appear()
        {
            int i;
            for (i = 1; i <= 258; i++)
            {
                this.SetDesktopLocation(mainForm.Location.X + 1280 - 5 * i, mainForm.Location.Y + 110);
                Refresh();
            }
            for (i = 258; i >= 208; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + 1280 - 5 * i, mainForm.Location.Y + 110);
                Refresh();
                System.Threading.Thread.Sleep(10);
            }
            this.showInformation1.ImgBack = new Bitmap(2, 2);
            this.showInformation1.FTitle = Constants.getFont(50);
            Refresh();
        }

        private void disappear()
        {
            for (int i = 208; i >= 1; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + 1280 - 5 * i, mainForm.Location.Y + 110);
                Refresh();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Constants.theme.HelpBackground, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
    }
}