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
        private bool sound;
        private string languageDisplay;
        private int modeShape;
        private int arrowUp;
        private GameControl gameControl;
        private SoundControl soundControl;
        private About about;
        private Help help;
        private HighScores highScores;
        private Option option;
        private bool mousePressed = false;
        private Point toMove = new Point(0, 0);
        private Point toCallForm = new Point(0, 0);

        public MainForm()
        {
            InitializeComponent();
        }

        public string Language
        {
            get { return languageDisplay; }
            set { languageDisplay = value; }
        }

        public int ModeShape
        {
            get { return modeShape; }
            set { modeShape = value; }
        }

        public int ArrowUp
        {
            get { return arrowUp; }
            set { arrowUp = value; }
        }

        public bool Sound
        {
            get { return sound; }
            set { sound = value; }
        }

        public bool Ghost
        {
            get { return enableGhostShape; }
            set { enableGhostShape = value; }
        }

        private void AddEventHandler(Control ctl)
        {
            ctl.MouseDown += new MouseEventHandler(MainForm_MouseDown);
            ctl.MouseMove += new MouseEventHandler(MainForm_MouseMove);
            ctl.MouseUp += new MouseEventHandler(MainForm_MouseUp);
        }
        private void AddKeyEventHandler(Control ctl)
        {
            ctl.KeyDown += new KeyEventHandler(MainForm_KeyDown);
            ctl.PreviewKeyDown += new PreviewKeyDownEventHandler(MainForm_PreviewKeyDown);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Constants.findMap();
            Constants.findTheme();
            Constants.language.load("English.lng");
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

            this.AddKeyEventHandler(this.showInformation1);
            this.AddKeyEventHandler(this.showInformation2);
            this.AddKeyEventHandler(this.showInformation3);
            this.AddKeyEventHandler(this.showInformation4);
            this.AddKeyEventHandler(this.imageButton1);
            this.AddKeyEventHandler(this.imageButton2);
            this.AddKeyEventHandler(this.imageButton3);
            this.AddKeyEventHandler(this.imageButton4);
            this.AddKeyEventHandler(this.imageButton5);
            this.AddKeyEventHandler(this.imageButton6);
            this.AddKeyEventHandler(this.imageButton7);
            this.AddKeyEventHandler(this.gameControl);

            this.AddKeyEventHandler(this.nextShape1);

            nextShape1.SText = "Next Shape";
            playing = false;
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

            //set language display.
            languageDisplay = config.SLanguage;

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
            sound = config.BSound;

            //set mode shape.
            modeShape = config.ModeShape;

            //set arrow up.
            arrowUp = config.ArrowUp;

            if (!success)
                if (MessageBox.Show(this, "", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                {
                    //lost a few files.
                    Constants.themeService.closeThemes();
                    Constants.mapService.closeMaps();
                    Constants.theme.Dispose();
                    Constants.map.Dispose();
                    Application.Exit();
                }
        }

        //exit game.
        private void exitGame()
        {
            //dispose element.
            Constants.themeService.closeThemes();
            Constants.mapService.closeMaps();
            Dispose();
            Application.Exit();
        }

        private void imageButton7_Click(object sender, EventArgs e)
        {
            exitGame();
        }

        private void imageButton1_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void newGame()
        {
            modeShape = 1;
            timer.Enabled = true;
            timer.Interval = 200;
            gameControl.createShape(modeShape);
            nextShape1.ShapeNext = gameControl.NextShape;
            playing = true;
            timer.Enabled = true;
            timer.Interval = 600;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gameControl.refresh();
            if (!gameControl.currShapeFall())
            {
                gameControl.lockShape();
                gameControl.createShape(modeShape);
                nextShape1.ShapeNext = gameControl.NextShape;
                if (Constants.map.checkOverflow())
                {
                    timer.Enabled = false;
                    playing = false;
                }
                int dx = 0;
                while (Constants.map.getFullLines().Count > 0)
                {
                    int line = Constants.map.getFullLines().Pop();
                    Constants.map.updateMap(line, ref dx);
                    gameControl.removeLine(line);
                }
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
                p.X -= toMove.X;
                p.Y -= toMove.Y;
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
                toMove.X = p.X - DesktopLocation.X;
                toMove.Y = p.Y - DesktopLocation.Y;
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    mousePressed = false;

                    toCallForm = new Point(e.X, e.Y);
                }

        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if(!mousePressed)
                if ((Math.Abs(e.X - toCallForm.X) < 100) && ((toCallForm.Y - e.Y) >= 200))
                {
                    aboutAppear();
                }
                else
                    if ((Math.Abs(e.X - toCallForm.X) < 100) && ((e.Y - toCallForm.Y) >= 200))
                    {
                        highScoresAppear();
                    }
                    else
                        if ((Math.Abs(e.Y - toCallForm.Y) < 100) && ((e.X - toCallForm.X) >= 200))
                        {
                            optionAppear();
                        }
                        else
                            if ((Math.Abs(e.Y - toCallForm.Y) < 100) && ((toCallForm.X - e.X) >= 200))
                            {
                                helpAppear();
                            }

            mousePressed = false;
        }

        private void helpAppear()
        {
            pauseGame();
            help = new Help(this);
            help.ShowDialog();
        }

        private void optionAppear()
        {
            pauseGame();
            option = new Option(this);
            Config config = new Config();
            config.load();

            //set them.
            foreach (Types.AvailableTheme theme in Constants.themeService.AvailableThemes)
                option.comboBox1.Items.Add(theme.Instance.Name);
            option.comboBox1.SelectedIndex = option.comboBox1.Items.IndexOf(Constants.theme.Name);

            //set map.
            foreach (Types.AvailableMap map in Constants.mapService.AvailableMaps)
                option.comboBox2.Items.Add(map.Instance.Name);
            option.comboBox2.SelectedIndex = option.comboBox2.Items.IndexOf(Constants.map.Name);

            if (languageDisplay.CompareTo("English") == 0)
            {
                //set label.


                //set language.
                option.comboBox3.Items.Add("English");
                option.comboBox3.Items.Add("VietNamese");
                option.comboBox3.SelectedIndex = 0;
            }
            else
            {
                //set label.

                //set language.
                option.comboBox3.Items.Add("Tiếng Anh");
                option.comboBox3.Items.Add("Tiếng Việt");
                option.comboBox3.SelectedIndex = 1;
            }

            //set sound.
            option.checkBox1.Checked = sound;

            //set ghost.
            option.checkBox4.Checked = enableGhostShape;

            //set mode shape.
            switch (modeShape)
            {
                case 1:
                    option.checkBox2.Checked = true; break;
                case 2:
                    option.checkBox3.Checked = true; break;
                case 3:
                    option.checkBox2.Checked = true;
                    option.checkBox3.Checked = true; break;
            }

            //set arrow up.
            switch (modeShape)
            {
                case 1:
                    option.checkBox5.Checked = true; break;
                case 2:
                    option.checkBox6.Checked = true; break;
                case 3:
                    option.checkBox5.Checked = true;
                    option.checkBox6.Checked = true; break;
            }
            

            option.ShowDialog();
        }

        private void highScoresAppear()
        {
            pauseGame();
            highScores = new HighScores(this);
            highScores.ShowDialog();
        }

        private void aboutAppear()
        {
            pauseGame();
            about = new About(this);
            about.ShowDialog();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (playing)
            {
                Graphics gr = Graphics.FromImage(gameControl.ImageBuffer);
                gameControl.CurrentShape.eraseShape(gr);
                if (e.KeyCode == Keys.Up)
                {
                    gameControl.createShape(modeShape, true);
                }
                else
                    if (e.KeyCode == Keys.Left && gameControl.CurrentShape.canMoveLeft())
                    {
                        gameControl.CurrentShape.moveLeft();
                    }
                    else
                        if (e.KeyCode == Keys.Right && gameControl.CurrentShape.canMoveRight())
                        {
                            gameControl.CurrentShape.moveRight();
                        }
                        else
                            if (e.KeyCode == Keys.Down && gameControl.CurrentShape.canFall())
                            {
                                gameControl.CurrentShape.moveDown();
                            }
                            else
                                if (e.KeyCode == Keys.Enter && gameControl.CurrentShape.canFall())
                                {
                                    gameControl.setCurrShapeToEndMap();
                                }
                gameControl.CurrentShape.drawShape(gr);
                gameControl.refresh();
                gr.Dispose();
            }
        }

        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Right:
                case Keys.Left:
                    e.IsInputKey = true;
                    break;
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
