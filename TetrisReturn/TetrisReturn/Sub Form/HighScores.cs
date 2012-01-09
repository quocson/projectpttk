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
            AddEventHandler(this.listView1);
            AddEventHandler(this.showInformation1);
            this.showInformation1.ImgBack = new Bitmap(showInformation1.Width, showInformation1.Height);
            Graphics.FromImage(this.showInformation1.ImgBack).DrawImage(
                Constants.theme.HighScoresBackground, new Rectangle(new Point(0, 0), showInformation1.Size),
            new Rectangle(showInformation1.Location, showInformation1.Size), GraphicsUnit.Pixel);
            showInformation1.Visible = false;
            listView1.Visible = false;
        }

        private void HighScores_MouseUp(object sender, MouseEventArgs e)
        {     
            if ((Math.Abs(e.X - toClose.X) < 100) && ((toClose.Y - e.Y) >= 200))
            {
                Constants.soundControl.playSoundDis_appear();
                showInformation1.Visible = false;
                listView1.Visible = false;
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
            for (i = 1; i <= 90; i++)
            {
                this.SetDesktopLocation(mainForm.Location.X + 240, mainForm.Location.Y + 8 * i - 500);
                Refresh();
            }
            for (i = 90; i >= 78; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + 240, mainForm.Location.Y + 8 * i - 500);
                System.Threading.Thread.Sleep(10);
                Refresh();
            }

            showInformation1.Visible = true;
            listView1.Visible = true;
        }

        private void disappear()
        {
            for (int i = 78; i >= 1; i--)
            {
                this.SetDesktopLocation(mainForm.Location.X + 240, mainForm.Location.Y + 8 * i - 500);
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
        private void AddEventHandler(Control ctl)
        {
            ctl.MouseDown += new MouseEventHandler(HighScores_MouseDown);
            ctl.MouseUp += new MouseEventHandler(HighScores_MouseUp);
        }
        private void HighScores_Load(object sender, EventArgs e)
        {

            System.Drawing.Font f = Constants.getFont(50);

            showInformation1.FTitle = f;
            showInformation1.STitle = Constants.language.high;
            showInformation1.CText = Color.CadetBlue;
            f = Constants.getFont(10);
            listView1.Font = f;
            HighScore hg = new HighScore();
            SaveDTO[] slist = hg.readRecords();
            for (int i = 0; i < 10; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(slist[i].IScore.ToString());
                item.SubItems.Add(slist[i].ILevel.ToString());
                item.SubItems.Add(slist[i].ILine.ToString());
                item.SubItems.Add(slist[i].IPiece.ToString());
                this.listView1.Items.Add(item);


            }
        }

    }
}