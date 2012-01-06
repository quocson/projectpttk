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
    public partial class HighScores : Form
    {
        private MainForm mainForm;
        private Point toClose = new Point(0, 0);
        
        public HighScores(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void HighScores_MouseUp(object sender, MouseEventArgs e)
        {     
            if ((Math.Abs(e.X - toClose.X) < 100) && ((toClose.Y - e.Y) >= 200))
            {
                Constants.soundControl.playSoundDis_appear();
                disappear();
                Close();
            }

        }

        private void HighScores_Shown(object sender, EventArgs e)
        {
            Constants.soundControl.playSoundDis_appear();
            appear();
        }

        private void HighScores_MouseDown(object sender, MouseEventArgs e)
        {      
            toClose = new Point(e.X, e.Y);

        }

        private void appear()
        {
            int i;
            for (i = 1; i <= 180; i++)
            {
                this.SetDesktopLocation(mainForm.Location.X + 240, mainForm.Location.Y + 4 * i - 500);
                Refresh();
            }
            for (i = 180; i >= 157; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + 240, mainForm.Location.Y + 4 * i - 500);
                System.Threading.Thread.Sleep(10);
                Refresh();
            }
        }

        private void disappear()
        {
            for (int i = 157; i >= 1; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + 240, mainForm.Location.Y + 4 * i - 500);
                Refresh();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Constants.theme.HighScoresBackground, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

    }
}