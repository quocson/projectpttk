﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TetrisReturn
{
    public partial class About : Form
    {
        private MainForm mainForm;
        private Point toClose = new Point(0, 0);
        public About(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void About_Shown(object sender, EventArgs e)
        {
            if (mainForm.Sound)
                mainForm.SoundControl.playSoundDis_appear();
            appear();
        }

        private void appear()
        {
            int i;
            for (i = 1; i <= 180; i++)
            {
                this.SetDesktopLocation(mainForm.Location.X + 240, mainForm.Location.Y + 720 - 4 * i);
                Refresh();
            }
            for (i = 180; i >= 157; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + 240, mainForm.Location.Y + 720 - 4 * i);
                System.Threading.Thread.Sleep(10);
                Refresh();
            }
        }

        private void disappear()
        {
            for (int i = 157; i >= 1; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + 240, mainForm.Location.Y + 720 - 4 * i);
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Constants.theme.AboutBackground, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        private void About_MouseDown(object sender, MouseEventArgs e)
        {

            toClose = new Point(e.X, e.Y);

        }

        private void About_MouseUp(object sender, MouseEventArgs e)
        {
            if ((Math.Abs(e.X - toClose.X) < 100) && ((e.Y - toClose.Y) >= 200))
            {
                if (mainForm.Sound)
                    mainForm.SoundControl.playSoundDis_appear();
                disappear();
                Close();
            }
        }
    }
}
