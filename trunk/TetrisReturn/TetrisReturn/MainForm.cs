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
    public partial class MainForm : Form
    {
        private bool enableGhostShape;
        private bool playing;
        private int soundVolume;
        private int modeShape;
        private GameControl gameControl;
        private SoundControl soundControl;
        private string languageDisplay;
        private About about;
        private Help help;
        private HighScores highScores;
        private Option option;
        private bool mousePressed = false;
        private Point diff = new Point(0, 0);

        public MainForm()
        {
            InitializeComponent();
        }
        private void AddEventHandler(Control ctl)
        {
            ctl.MouseDown += new MouseEventHandler(MainForm_MouseDown);
            ctl.MouseMove += new MouseEventHandler(MainForm_MouseMove);
            ctl.MouseUp += new MouseEventHandler(MainForm_MouseUp);
            ctl.KeyDown += new KeyEventHandler(MainForm_KeyDown);
            ctl.KeyPress += new KeyPressEventHandler(MainForm_KeyPress);
            ctl.KeyUp += new KeyEventHandler(MainForm_KeyUp);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Constants.findMap();
            Constants.findTheme();

            checkLostAllFiles();

            setLastConfig();

            gameControl = new GameControl();
            soundControl = new SoundControl();

            setTheme();
            this.AddEventHandler(this.showInformation1);
            this.AddEventHandler(this.showInformation2);
            this.AddEventHandler(this.showInformation3);
            this.AddEventHandler(this.showInformation4);
            this.AddEventHandler(this.nextShape1);
            this.AddEventHandler(this.gameControl);
        }

        private void setTheme()
        {
            BackgroundImage = Constants.theme.MainBackground;

            imageButton1.Image = Constants.theme.NormalButton;
            imageButton2.Image = Constants.theme.DisableButton;
            imageButton3.Image = Constants.theme.NormalButton;
            imageButton4.Image = Constants.theme.NormalButton;
            imageButton5.Image = Constants.theme.NormalButton;
            imageButton6.Image = Constants.theme.NormalButton;
            imageButton7.Image = Constants.theme.NormalButton;

            Controls.Add(gameControl);

            nextShape1.ImgBack = Constants.theme.NextShape;

            showInformation1.ImgBack = Constants.theme.Informations;
            showInformation2.ImgBack = Constants.theme.Informations;
            showInformation3.ImgBack = Constants.theme.Informations;
            showInformation4.ImgBack = Constants.theme.Informations;
        }

        //check if lost all files, close game.
        private void checkLostAllFiles()
        {
            if (Constants.themeService.AvailableThemes.Count == 0 || Constants.mapService.AvailableMaps.Count == 0)
            {
                //lost all files.
                MessageBox.Show(this, "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Constants.themeService.closeThemes();
                Constants.mapService.closeMaps();
                Application.Exit();
            }
        }

        //set Last config for game.
        private void setLastConfig()
        {
            bool success = true;
            Config config = new Config();
            config.load();
            //load theme.
            Types.AvailableTheme lastTheme = Constants.themeService.AvailableThemes.Find(config.STheme);

            if (lastTheme == null)
            {
                success = false;
                lastTheme = Constants.themeService.AvailableThemes.getFirst();
            }

            //load map.
            Types.AvailableMap lastMap = Constants.mapService.AvailableMaps.Find(config.SMap);

            if (lastMap == null)
            {
                success = false;
                lastMap = Constants.mapService.AvailableMaps.getFirst();
            }

            //set theme, map.            
            Constants.setTheme(lastTheme.Instance.Theme);
            Constants.setMap(lastMap.Instance.Map);


            //set ghost.
            enableGhostShape = config.BGhost;

            //set sound volume.
            soundVolume = config.ISound;

            //set language display.
            languageDisplay = config.SLanguage;

            //...

            //if (!success)
            //    if (MessageBox.Show(this, "", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
            //    {
            //        //lost a few files.
            //        Constants.themeService.closeThemes();
            //        Constants.mapService.closeMaps();
            //        Constants.theme.Dispose();
            //        Constants.map.Dispose();
            //        Application.Exit();
            //    }
        }

        //exit game.
        private void exitGame()
        {
            //dispose element.
            Application.Exit();
        }

        private void imageButton7_Click(object sender, EventArgs e)
        {
            exitGame();
        }

        private void imageButton1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            timer.Interval = 200;
            modeShape = 0;
            gameControl.createShape(modeShape);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gameControl.refresh();
            if (!gameControl.currShapeFall())
            {
                gameControl.lockShape();
                gameControl.createShape(modeShape);
            }
        }

        private void pauseGame()
        {
            timer.Enabled = false;
        }

        private void imageButton1_MouseEnter(object sender, EventArgs e)
        {
            imageButton1.Image = Constants.theme.HoverButton;
            //sound here.
        }

        private void imageButton2_MouseEnter(object sender, EventArgs e)
        {

            imageButton2.Image = Constants.theme.HoverButton;
            //sound here.
        }

        private void imageButton3_MouseEnter(object sender, EventArgs e)
        {

            imageButton3.Image = Constants.theme.HoverButton;
            //sound here.
        }

        private void imageButton4_MouseEnter(object sender, EventArgs e)
        {

            imageButton4.Image = Constants.theme.HoverButton;
            //sound here.
        }

        private void imageButton5_MouseEnter(object sender, EventArgs e)
        {

            imageButton5.Image = Constants.theme.HoverButton;
            //sound here.
        }

        private void imageButton6_MouseEnter(object sender, EventArgs e)
        {

            imageButton6.Image = Constants.theme.HoverButton;
            //sound here.
        }

        private void imageButton7_MouseEnter(object sender, EventArgs e)
        {

            imageButton7.Image = Constants.theme.HoverButton;
            //sound here.
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePressed && (e.Button & MouseButtons.Left) != 0)
            {
                Point p = new Point(e.X, e.Y);
                p = PointToScreen(p);
                p.X -= diff.X;
                p.Y -= diff.Y;
                DesktopLocation = p;
            } 
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePressed = true;

                Point p = new Point(e.X, e.Y);
                p = PointToScreen(p);
                diff.X = p.X - DesktopLocation.X;
                diff.Y = p.Y - DesktopLocation.Y;
            }

        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {

            mousePressed = false;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            Graphics gr = Graphics.FromImage(gameControl.ImageBuffer);
            gameControl.CurrentShape.eraseShape(gr);
            if (e.KeyValue == (int)System.Windows.Forms.Keys.Left && gameControl.CurrentShape.canMoveLeft())
            {
                gameControl.CurrentShape.moveLeft();
            }
            else
                if (e.KeyValue == (int)System.Windows.Forms.Keys.Up && gameControl.CurrentShape.canRotate())
                {
                    gameControl.CurrentShape.rotate();
                }
                else
                    if (e.KeyValue == (int)System.Windows.Forms.Keys.Right && gameControl.CurrentShape.canMoveRight())
                    {
                        gameControl.CurrentShape.moveRight();
                    }
                    else
                        if (e.KeyValue == (int)System.Windows.Forms.Keys.Down && gameControl.CurrentShape.canFall())
                        {
                            gameControl.CurrentShape.moveDown();
                        }
                        else
                            if (e.KeyValue == (int)System.Windows.Forms.Keys.Enter && gameControl.CurrentShape.canFall())
                            {
                                gameControl.setCurrShapeToEndMap();
                            }
            gameControl.CurrentShape.drawShape(gr);
            Refresh();
            gr.Dispose();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
