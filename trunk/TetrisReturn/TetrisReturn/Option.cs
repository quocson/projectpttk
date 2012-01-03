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

                //sound.
                if (checkBox1.Checked)
                    mainForm.Sound = true;
                else
                    mainForm.Sound = false;

                //ghost.
                if (mainForm.NewGame)
                {
                    if (!checkBox4.Checked)
                    {
                        mainForm.Ghost = false;
                        mainForm.GameControl.eraseGhostShape();
                    }
                    else
                    {
                        mainForm.Ghost = true;
                        mainForm.GameControl.drawGhostShape();
                    }
                    mainForm.GameControl.refresh();
                }

                //mode shape.
                int i = 0;
                if (checkBox2.Checked)
                    i += 1;
                if (checkBox3.Checked)
                    i += 2;
                mainForm.ModeShape = i;

                //arrow up.
                i = 0;
                if (checkBox5.Checked)
                    i += 1;
                if (checkBox6.Checked)
                    i += 2;
                mainForm.ArrowUp = i;

                //map.
                if (!mainForm.NewGame)
                {
                    Types.AvailableMap map = Constants.mapService.AvailableMaps.Find(comboBox2.Text);

                    if (map == null)
                    {
                        map = Constants.mapService.AvailableMaps.getFirst();
                    }
                    Constants.setMap(map.Instance.Map);
                    mainForm.GameControl.reset();
                }


                //language.
                if (comboBox3.SelectedIndex == 0)
                {
                    Constants.language.load("English.lng");
                    mainForm.Language = "English";
                }
                else
                {
                    Constants.language.load("VietNamese.lng");
                    mainForm.Language = "VietNamese";
                }

                //theme.
                Types.AvailableTheme theme = Constants.themeService.AvailableThemes.Find(comboBox1.Text);
                if (theme == null)
                {
                    theme = Constants.themeService.AvailableThemes.getFirst();
                }
                Constants.setTheme(theme.Instance.Theme);
                mainForm.setTheme();
                mainForm.Refresh();

                    if (mainForm.Playing)
                        mainForm.resumeGame();
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
            for (i = 1; i <= 129; i++)
            {
                this.SetDesktopLocation(mainForm.Location.X - 800 + 10 * i, mainForm.Location.Y + 110);
                Refresh();
            }
            for (i = 129; i >= 104; i--)
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
                if (!checkBox3.Checked)
                    checkBox3.Checked = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox3.Checked)
                if (!checkBox2.Checked)
                    checkBox2.Checked = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox5.Checked)
                if (!checkBox6.Checked)
                    checkBox6.Checked = true;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox6.Checked)
                if (!checkBox5.Checked)
                    checkBox5.Checked = true;
        }
    }
}