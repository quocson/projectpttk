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
    public partial class MainForm : Form
    {
        private bool enableGhostShape;
        private bool playing;
        private bool sound;
        private string languageDisplay;
        private int modeShape;
        private int arrowUp;
        private Option option;
        private GameControl gameControl;
        private SoundControl soundControl;
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

        public bool Playing
        {
            get { return playing; }
            set { playing = value; }
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
            nextShape1.FText = Constants.getFont(20.0f);
            nextShape1.SText = "Next Shape";

            playing = false;
            enableGhostShape = false;
            sound = false;
        }

        public void setTheme()
        {
            System.Drawing.Font f = Constants.getFont(20);

           
            imageButton1.FText = f;
            imageButton2.FText = f;
            imageButton3.FText = f;
            imageButton4.FText = f;
            imageButton5.FText = f;
            imageButton6.FText = f;
            imageButton7.FText = f;
            nextShape1.FText = f;
            showInformation1.FTitle = f;
            showInformation2.FTitle = f;
            showInformation3.FTitle = f;
            showInformation4.FTitle = f;
            showInformation1.FInfo = f;
            showInformation2.FInfo = f;
            showInformation3.FInfo = f;
            showInformation4.FInfo = f;

            BackgroundImage = Constants.theme.MainBackground;

            imageButton1.Image = Constants.theme.Button;
            imageButton2.Image = Constants.theme.Button;
            imageButton3.Image = Constants.theme.Button;
            imageButton4.Image = Constants.theme.Button;
            imageButton5.Image = Constants.theme.Button;
            imageButton6.Image = Constants.theme.Button;
            imageButton7.Image = Constants.theme.Button;

            imageButton3.Enabled = false;
            imageButton4.Enabled = false;
            imageButton5.Enabled = false;

            Controls.Add(gameControl);

            nextShape1.ImgBack = Constants.theme.NextShape;
            showInformation1.ImgBack = Constants.theme.Informations;
            showInformation2.ImgBack = Constants.theme.Informations;
            showInformation3.ImgBack = Constants.theme.Informations;
            showInformation4.ImgBack = Constants.theme.Informations;

            imageButton1.SText = Constants.language.newgame;
            imageButton2.SText = Constants.language.conti;
            imageButton3.SText = Constants.language.save;
            imageButton4.SText = Constants.language.pause;
            imageButton5.SText = Constants.language.sound;
            imageButton6.SText = Constants.language.ghost;
            imageButton7.SText = Constants.language.exit;
            nextShape1.SText = Constants.language.next;
            showInformation4.STitle = Constants.language.score;
            showInformation3.STitle = Constants.language.level;
            showInformation2.STitle = Constants.language.line;
            showInformation1.STitle = Constants.language.piece;
        }

        //check if lost all files, close game.
        private void checkLostAllFiles()
        {
            if (Constants.themeService.AvailableThemes.Count == 0 || Constants.mapService.AvailableMaps.Count == 0)
            {
                //lost all files.
                MessageBox.Show(this, Constants.language.loaddll, Constants.language.captionDll, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            Constants.language.load(languageDisplay + ".lng");

            checkLostAllFiles();

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
                if (MessageBox.Show(this, Constants.language.loadconfig, Constants.language.captionConfig, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
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
        public void exitGame()
        {
            //dispose element.
            Constants.themeService.closeThemes();
            Constants.mapService.closeMaps();
            Dispose();
            Application.Exit();
        }

        public void newGame()
        {
            gameControl.reset();
            imageButton3.Enabled = true;
            imageButton4.Enabled = true;
            imageButton5.Enabled = true;
            timer.Enabled = true;
            timer.Interval = 200;
            gameControl.createShape(modeShape);
            showInformation1.SInfo = (++Constants.SaveInfo.IPiece).ToString();
            showInformation2.SInfo = (Constants.SaveInfo.ILine).ToString();
            showInformation3.SInfo = (Constants.SaveInfo.ILevel).ToString();
            showInformation4.SInfo = (Constants.SaveInfo.IScore).ToString();
            nextShape1.ShapeNext = gameControl.NextShape;
            playing = true;
            enableGhostShape = true;
            sound = true;
            timer.Enabled = true;
            timer.Interval = 600;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gameControl.refresh();
            if (!gameControl.currShapeFall(enableGhostShape))
            {
                gameControl.lockShape();
                gameControl.createShape(modeShape);
                showInformation1.SInfo = (++Constants.SaveInfo.IPiece).ToString();

                nextShape1.ShapeNext = gameControl.NextShape;
                if (Constants.map.checkOverflow())
                {
                    timer.Enabled = false;
                    playing = false;
                }
                int dx = 0;
                while (Constants.map.getFullLines().Count > 0)
                {
                    showInformation2.SInfo = (++Constants.SaveInfo.ILine).ToString();
                    //add score
                    Constants.SaveInfo.IScore += Constants.scorePerLine;
                    if(Constants.map.getFullLines().Count == 4)
                        Constants.SaveInfo.IScore += 100;
                    this.showInformation4.SInfo = Constants.SaveInfo.IScore.ToString();

                    int line = Constants.map.getFullLines().Pop();
                    Constants.map.updateMap(line, ref dx);
                    gameControl.removeLine(line);
                }

            }
        }

        private void pauseGame()
        {
            imageButton4.SText = Constants.language.resume;
            imageButton5.Enabled = false;
            imageButton6.Enabled = false;
            timer.Enabled = false;
        }

        public void resumeGame()
        {
            imageButton4.SText = Constants.language.pause;
            playing = true;
            imageButton5.Enabled = true;
            imageButton6.Enabled = true;
            timer.Enabled = true;
        }

        private void imageButton1_MouseEnter(object sender, EventArgs e)
        {
            imageButton1.CText = Color.LightSeaGreen;
            //sound here.
        }

        private void imageButton2_MouseEnter(object sender, EventArgs e)
        {

            imageButton2.CText = Color.LightSeaGreen;
            //sound here.
        }

        private void imageButton3_MouseEnter(object sender, EventArgs e)
        {
            imageButton3.CText = Color.LightSeaGreen;
            //sound here.
        }

        private void imageButton4_MouseEnter(object sender, EventArgs e)
        {
            imageButton4.CText = Color.LightSeaGreen;
            //sound here.
        }

        private void imageButton5_MouseEnter(object sender, EventArgs e)
        {
            imageButton5.CText = Color.LightSeaGreen;
            //sound here.
        }

        private void imageButton6_MouseEnter(object sender, EventArgs e)
        {
            imageButton6.CText = Color.LightSeaGreen;
            //sound here.
        }

        private void imageButton7_MouseEnter(object sender, EventArgs e)
        {
            imageButton7.CText = Color.LightSeaGreen;
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
            Help help = new Help(this);
            help.ShowDialog();
        }

        private void optionAppear()
        {
            pauseGame();
            option = new Option(this);
            setFontOption();

            //set them.
            foreach (Types.AvailableTheme theme in Constants.themeService.AvailableThemes)
                option.comboBox1.Items.Add(theme.Instance.Name);
            option.comboBox1.SelectedIndex = option.comboBox1.Items.IndexOf(Constants.theme.Name);

            //set map.
            foreach (Types.AvailableMap map in Constants.mapService.AvailableMaps)
                option.comboBox2.Items.Add(map.Instance.Name);
            option.comboBox2.SelectedIndex = option.comboBox2.Items.IndexOf(Constants.map.Name);

            option.comboBox3.Items.Add(Constants.language.language1);
            option.comboBox3.Items.Add(Constants.language.language2);

            if (languageDisplay.CompareTo("English") == 0)
                option.comboBox3.SelectedIndex = 0;
            else
                option.comboBox3.SelectedIndex = 1;

            //set label.
            option.label1.Text = Constants.language.option;
            option.label2.Text = Constants.language.theme;
            option.label3.Text = Constants.language.map;
            option.label4.Text = Constants.language.language;
            option.label5.Text = Constants.language.sound;
            option.label6.Text = Constants.language.shape;
            option.label7.Text = Constants.language.shape1;
            option.label8.Text = Constants.language.shape2;
            option.label9.Text = Constants.language.ghost;
            option.label10.Text = Constants.language.up;
            option.label11.Text = Constants.language.up1;
            option.label12.Text = Constants.language.up2;

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
            switch (arrowUp)
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

        public void setFontOption()
        {
            System.Drawing.Font f = Constants.getFont(16);
            option.label1.Font = f;
            f = Constants.getFont(12);
            option.label2.Font = f;
            option.label3.Font = f;
            option.label4.Font = f;
            option.label5.Font = f;
            option.label6.Font = f;
            option.label7.Font = f;
            option.label8.Font = f;
            option.label9.Font = f;
            option.label10.Font = f;
            option.label11.Font = f;
            option.label12.Font = f;
            f = Constants.getFont(10);
            option.comboBox1.Font = f;
            option.comboBox2.Font = f;
            option.comboBox3.Font = f;
        }

        private void highScoresAppear()
        {
            pauseGame();
            HighScores highScores = new HighScores(this);
            highScores.ShowDialog();
        }

        private void aboutAppear()
        {
            pauseGame();
            About about = new About(this);
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
                    gameControl.CurrentShape.rotate();
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
                                showInformation4.SInfo = (++Constants.SaveInfo.IScore).ToString();

                            }
                            else
                                if (e.KeyCode == Keys.Enter && gameControl.CurrentShape.canFall())
                                {
                                    gameControl.setCurrShapeToEndMap();
                                    showInformation4.SInfo = (Constants.SaveInfo.IScore += 15).ToString();
                                }
                if(enableGhostShape)
                    gameControl.drawGhostShape();
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

        private void imageButton1_MouseDown(object sender, MouseEventArgs e)
        {
            imageButton1.CText = Color.LawnGreen;

        }

        private void imageButton1_MouseUp(object sender, MouseEventArgs e)
        {
            imageButton1.CText = Color.Red;
            newGame();
        }

        private void imageButton1_MouseLeave(object sender, EventArgs e)
        {
            imageButton1.CText = Color.Red;
        }

        private void imageButton2_MouseLeave(object sender, EventArgs e)
        {
            imageButton2.CText = Color.Red;

        }

        private void imageButton2_MouseUp(object sender, MouseEventArgs e)
        {
            imageButton2.CText = Color.Red;

        }

        private void imageButton2_MouseDown(object sender, MouseEventArgs e)
        {

            imageButton2.CText = Color.LawnGreen;
        }

        private void imageButton3_MouseLeave(object sender, EventArgs e)
        {
            imageButton3.CText = Color.Red;

        }

        private void imageButton3_MouseUp(object sender, MouseEventArgs e)
        {
            imageButton3.CText = Color.Red;

        }

        private void imageButton3_MouseDown(object sender, MouseEventArgs e)
        {
            imageButton3.CText = Color.LawnGreen;

        }

        private void imageButton4_MouseDown(object sender, MouseEventArgs e)
        {

            imageButton4.CText = Color.LawnGreen;
        }

        private void imageButton4_MouseUp(object sender, MouseEventArgs e)
        {
            imageButton4.CText = Color.Red;
            if (playing)
            {
                pauseGame();
            }
            else
            {
                resumeGame();
            }
        }

        private void imageButton4_MouseLeave(object sender, EventArgs e)
        {

            imageButton4.CText = Color.Red;
        }

        private void imageButton5_MouseDown(object sender, MouseEventArgs e)
        {
            imageButton5.CText = Color.LawnGreen;

        }

        private void imageButton5_MouseLeave(object sender, EventArgs e)
        {
            imageButton5.CText = Color.Red;

        }

        private void imageButton5_MouseUp(object sender, MouseEventArgs e)
        {
            imageButton5.CText = Color.Red;
            if (enableGhostShape)
            {
                enableGhostShape = false;
                gameControl.eraseGhostShape();
            }
            else
            {
                enableGhostShape = true;
                gameControl.drawGhostShape();
            }
            gameControl.refresh();
        }

        private void imageButton6_MouseDown(object sender, MouseEventArgs e)
        {
            imageButton6.CText = Color.LawnGreen;

        }

        private void imageButton6_MouseUp(object sender, MouseEventArgs e)
        {

            imageButton6.CText = Color.Red;
        }

        private void imageButton6_MouseLeave(object sender, EventArgs e)
        {

            imageButton6.CText = Color.Red;
        }

        private void imageButton7_MouseDown(object sender, MouseEventArgs e)
        {
            imageButton7.CText = Color.LawnGreen;

        }

        private void imageButton7_MouseLeave(object sender, EventArgs e)
        {

            imageButton7.CText = Color.Red;
        }

        private void imageButton7_MouseUp(object sender, MouseEventArgs e)
        {

            imageButton7.CText = Color.Red;
            if (playing)
                playing = false;
            pauseGame();
            ExitConfirm exitConfirm = new ExitConfirm(this);
            exitConfirm.ShowDialog();
        }
    }
}
