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
    public partial class About : Form
    {
        private MainForm mainForm;
        public About(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void About_Shown(object sender, EventArgs e)
        {
            appear();
        }

        private void appear()
        {
            for (int i = 0; i < 40; i++)
            {
                this.SetDesktopLocation(mainForm.Location.X + 200, mainForm.Location.Y + 720 - 20 * i);
                System.Threading.Thread.Sleep(20); Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Constants.theme.MainBackground, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
    }
}
