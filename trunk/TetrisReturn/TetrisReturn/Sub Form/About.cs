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
        private Point toClose = new Point(0, 0);
        public About(MainForm mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            AddEventHandler(this.showInformation1);
            AddEventHandler(this.showInformation2);
            this.showInformation1.ImgBack = new Bitmap(showInformation1.Width, showInformation1.Height);
            Graphics.FromImage(this.showInformation1.ImgBack).DrawImage(
                Constants.theme.AboutBackground, new Rectangle(new Point(0, 0), showInformation1.Size),
            new Rectangle(showInformation1.Location, showInformation1.Size), GraphicsUnit.Pixel);
            this.showInformation2.ImgBack = new Bitmap(showInformation2.Width, showInformation2.Height);
            Graphics.FromImage(this.showInformation2.ImgBack).DrawImage(
                Constants.theme.AboutBackground, new Rectangle(new Point(0, 0), showInformation2.Size),
            new Rectangle(showInformation2.Location, showInformation2.Size), GraphicsUnit.Pixel);
            this.showInformation1.FTitle = Constants.getFont(50);
            this.showInformation1.STitle = Constants.language.about;
            this.showInformation2.FTitle = Constants.getFont(20);
            this.showInformation2.STitle = Constants.language.aboutinfo;
            this.showInformation2.Visible = false;
            this.showInformation1.Visible = false;
            Refresh();
        }
        private void AddEventHandler(Control ctl)
        {
            ctl.MouseDown += new MouseEventHandler(About_MouseDown);
            ctl.MouseUp += new MouseEventHandler(About_MouseUp);
        }
        private void About_Shown(object sender, EventArgs e)
        {
            Constants.soundControl.playSoundDis_appear();

            appear();
        }

        private void appear()
        {
            int i;
            for (i = 1; i <= 90; i++)
            {
                this.SetDesktopLocation(mainForm.Location.X + 240, mainForm.Location.Y + 720 - 8 * i);
                Refresh();
            }
            for (i = 90; i >= 78; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + 240, mainForm.Location.Y + 720 - 8 * i);
                System.Threading.Thread.Sleep(10);
                Refresh();
            }
            this.showInformation2.Visible = true;
            this.showInformation1.Visible = true;
            //=========================================================================
            
        }

        private void disappear()
        {
            for (int i = 78; i >= 1; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + 240, mainForm.Location.Y + 720 - 8 * i);
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
                Constants.soundControl.playSoundDis_appear();
                this.showInformation2.Visible = false;
                this.showInformation1.Visible = false;
                disappear();
                Close();
            }
        }

        
    }
}
