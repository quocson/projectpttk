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

                foreach (Types.AvailableMap map in Constants.mapService.AvailableMaps)
                    if (map.Instance.Name.CompareTo(comboBox2.Text) == 0)
                        Constants.setMap(map.Instance.Map);

                if(comboBox3.SelectedIndex == 0)
                    mainForm.Language = "English";
                else
                    mainForm.Language = "VietNamese";


                if (checkBox1.Checked)
                    mainForm.Sound = true;
                else
                    mainForm.Sound = false;

                if (checkBox2.Checked)
                    mainForm.Ghost = true;
                else
                    mainForm.Ghost = false;

                int i = 0;
                if (checkBox2.Checked)
                    i += 1;
                if (checkBox3.Checked)
                    i += 2;
                mainForm.ModeShape = i;

                i = 0;
                if (checkBox5.Checked)
                    i += 1;
                if (checkBox6.Checked)
                    i += 2;
                mainForm.ArrowUp = i;

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
            if (!checkBox2.Checked && !checkBox3.Checked)
                checkBox3.Checked = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (!checkBox2.Checked && !checkBox3.Checked)
                checkBox2.Checked = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

            if (!checkBox5.Checked && !checkBox6.Checked)
                checkBox6.Checked = true;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

            if (!checkBox5.Checked && !checkBox6.Checked)
                checkBox5.Checked = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (Types.AvailableTheme theme in Constants.themeService.AvailableThemes)
                if (theme.Instance.Name.CompareTo(comboBox1.Text) == 0)
                    Constants.setTheme(theme.Instance.Theme);
            Refresh();
            mainForm.setFontOption();
            mainForm.Refresh();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}