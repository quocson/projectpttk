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
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            this.mainForm = mainForm;
            this.showInformation1.ImgBack = new Bitmap(showInformation1.Width, showInformation1.Height);
            Graphics.FromImage(this.showInformation1.ImgBack).DrawImage(
                Constants.theme.HelpBackground, new Rectangle(new Point(0, 0), showInformation1.Size),
            new Rectangle(showInformation1.Location, showInformation1.Size), GraphicsUnit.Pixel);
            this.showInformation1.FTitle = Constants.getFont(50);
            this.showInformation1.STitle = Constants.language.help;
            this.showInformation2.ImgBack = new Bitmap(showInformation2.Width, showInformation2.Height);
            Graphics.FromImage(this.showInformation2.ImgBack).DrawImage(
                Constants.theme.HelpBackground, new Rectangle(new Point(0, 0), showInformation2.Size),
            new Rectangle(showInformation2.Location, showInformation2.Size), GraphicsUnit.Pixel);
            this.showInformation2.FTitle = Constants.getFont(15);
            this.showInformation2.STitle = Constants.language.helpinfo;
            this.showInformation2.Visible = false;
            this.showInformation1.Visible = false;
            AddEventHandler(showInformation1);
            AddEventHandler(showInformation2);

        }
        private void AddEventHandler(Control ctl)
        {
            ctl.MouseDown += new MouseEventHandler(Help_MouseDown);
            ctl.MouseUp += new MouseEventHandler(Help_MouseUp);
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

                this.showInformation2.Visible = false;
                this.showInformation1.Visible = false;
                disappear();
                Close();
            }
        
        }

        private void appear()
        {
            int i;
            for (i = 1; i <= 129; i++)
            {
                this.SetDesktopLocation(mainForm.Location.X + 1280 - 10 * i, mainForm.Location.Y + 110);
                Refresh();
            }
            for (i = 129; i >= 104; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + 1280 - 10 * i, mainForm.Location.Y + 110);
                Refresh();
                System.Threading.Thread.Sleep(10);
            }
            this.showInformation1.ImgBack = new Bitmap(2, 2);
            this.showInformation1.FTitle = Constants.getFont(50);
            this.showInformation2.Visible = true;
            this.showInformation1.Visible = true;
            Refresh();
        }

        private void disappear()
        {
            for (int i = 104; i >= 1; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + 1280 - 10 * i, mainForm.Location.Y + 110);
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