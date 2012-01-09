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
    public partial class ExitConfirm : Form
    {
        private MainForm mainForm;

        public ExitConfirm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void imageButton1_MouseDown(object sender, MouseEventArgs e)
        {

            imageButton1.CText = Color.LawnGreen;
        }

        private void imageButton1_MouseEnter(object sender, EventArgs e)
        {

            imageButton1.CText = Color.LightSeaGreen;
            Constants.soundControl.playSoundHover();
        }

        private void imageButton1_MouseUp(object sender, MouseEventArgs e)
        {
            imageButton2.CText = Color.Red;
            mainForm.exitGame();

        }

        private void imageButton1_MouseLeave(object sender, EventArgs e)
        {

            imageButton1.CText = Color.Red;
        }

        private void imageButton2_MouseDown(object sender, MouseEventArgs e)
        {
            imageButton2.CText = Color.LawnGreen;

        }

        private void imageButton2_MouseUp(object sender, MouseEventArgs e)
        {
            imageButton2.CText = Color.Red;
            Constants.soundControl.playSoundDis_appear();
            disAppear();
            if (mainForm.Playing)
                mainForm.resumeGame();
            this.Close();

        }

        private void imageButton2_MouseEnter(object sender, EventArgs e)
        {

            imageButton2.CText = Color.LightSeaGreen;
            Constants.soundControl.playSoundHover();
        }

        private void imageButton2_MouseLeave(object sender, EventArgs e)
        {
            imageButton2.CText = Color.Red;

        }

        private void ExitConfirm_Load(object sender, EventArgs e)
        {
            System.Drawing.Font f = Constants.getFont(20);

            showInformation1.FTitle = f;
            imageButton1.FText = f;
            imageButton2.FText = f;

            showInformation1.ImgBack = Constants.theme.ExitConfirm;
            imageButton1.Image = Constants.theme.Button;
            imageButton2.Image = Constants.theme.Button;

            showInformation1.STitle = Constants.language.exitConfirm;
            imageButton1.SText = Constants.language.yes;
            imageButton2.SText = Constants.language.no;

        }

        private void appear()
        {
            for (int i = 1; i <= 50; i++)
            {
                this.SetDesktopLocation(mainForm.Location.X + mainForm.Size.Width / 2 - 6 * i, mainForm.Location.Y + mainForm.Size.Height / 2 - 2 * i);
                Size = new System.Drawing.Size(12 * i, 4 * i);
                Refresh();
            }
        }

        private void disAppear()
        {
            for (int i = 50; i > 0; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + mainForm.Size.Width / 2 - 6 * i, mainForm.Location.Y + mainForm.Size.Height / 2 - 2 * i);
                Size = new System.Drawing.Size(12 * i, 4 * i);
                Refresh();
            }
        }

        private void ExitConfirm_Shown(object sender, EventArgs e)
        {
            Constants.soundControl.playSoundDis_appear();
            appear();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Constants.theme.ExitConfirm, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
    }
}
