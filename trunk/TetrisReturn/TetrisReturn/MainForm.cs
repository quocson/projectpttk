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
            //ctl.KeyDown += new KeyEventHandler(MainForm_KeyDown);
            //ctl.KeyPress += new KeyPressEventHandler(MainForm_KeyPress);
            //ctl.KeyUp += new KeyEventHandler(MainForm_KeyUp);
        }
        private void AddKeyEventHandler(Control ctl)
        {
            ctl.KeyDown += new KeyEventHandler(MainForm_KeyDown);
            ctl.KeyPress += new KeyPressEventHandler(MainForm_KeyPress);
            ctl.KeyUp += new KeyEventHandler(MainForm_KeyUp);
            ctl.PreviewKeyDown += new PreviewKeyDownEventHandler(MainForm_PreviewKeyDown);
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
            nextShape1.ShapeNext = gameControl.NextShape;
            playing = true;
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
                gameControl.removeLine(25);
                int a = 0;
                Constants.map.updateMap(25, ref a);
                //if (gameControl.isEndGame())
                //{
                //    this.timer.Enabled = false;
                //    bool newgame = false;
                //    if (bSound)
                //        playSound.playSoundGameOver();
                //    int rank = Constant.saver.saveRecords(gameScore.Score);
                //    if ( rank > 0)
                //    {
                //        if (MessageBox.Show("New High Score: " + gameScore.Score + "\nRank: " + rank  + "\nDo you want to play again?",
                //            "Game Over!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                //        {
                //            newgame = true;
                //        }
                //    }

                //    else
                //        if (MessageBox.Show("Your score: " + gameScore.Score + "\nDo you want to play again?",
                //            "Game Over!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                //        {
                //            newgame = true;
                //        }
                //    if (newgame)
                //    {
                //        gameControl.resetGame();

                //        gameScore.Score = 0;
                //        gameLevel.Level = 1;
                //        gameLine.Line = 0;
                //        gamePiece.Piece = 0;
                //        gameControl.gameInitObj(out  shapeNext, out  colorNext, out  rotaterNext);
                //        gameControl.setShape(shapeNext, colorNext, rotaterNext);
                //        nextShape.drawNextShape(shapeNext, colorNext, rotaterNext);
                //        gamePiece.Piece++;

                //        timer.Interval = 500;
                //        menuItem2.Enabled = true;
                //        menuItem2.Text = "Pause";
                //        if (bSound)
                //            playSound.playSoundTheme();
                //        changeMode(ModeGame.Playing);
                //        timer.Enabled = true;
                //    }
                //    else
                //    {
                //        changeMode(ModeGame.Ready);
                //        playSound.stopSoundTheme();
                //        timer.Enabled = true;
                //        menuItem2.Enabled = false;
                //        return;
                //    }
                //}   
                //int val, i = 0;
                //bool isfull;
                //isfull = ((full = gameControl.fullLine()).Count > 0);


                //tempScore += (full.Count / 4) * 100;
                //gameLine.Line += full.Count;
                //int c = 0;
                //int numRow = 0;
                //if(full.Count != 0)
                //    numRow = Constant.rd.Next(1, 8);
                //if (bSound)
                //    switch (numRow)
                //    {
                //        case 1: playSound.playSoundAmazing(); break;
                //        case 2: playSound.playSoundVeryGood(); break;
                //        case 3: playSound.playSoundBrilliant(); break;
                //        case 4: playSound.playSoundWonderful(); break;
                //        case 5: playSound.playSoundWow(); break;
                //        case 6: playSound.playSoundExcellent(); break;
                //        case 7: playSound.playSoundClear(); break;
                //    }
                //while (full.Count > 0)
                //{
                //    c++;
                //    val = full.Pop() + i;
                //    tempScore += c * (Constant.yMax / Constant.d) * (24 - val);
                //    gameControl.deleteLine(val);
                //    Constant.updateMap(val, ref i);
                //}
                //gameScore.Score += tempScore;
                //levelUp();
                //tempScore = 0;


                //if (gameLevel.Level == 99)
                //{
                //    this.timer.Enabled = false;
                //    bool newgame = false;
                //    if (bSound)
                //        playSound.playSoundGameWin();
                //    int rank = Constant.saver.saveRecords(gameScore.Score);
                //    if (rank > 0)
                //    {
                //        if (MessageBox.Show("New High Score: " + gameScore.Score + "\nRank: " + rank + "\nDo you want to play again?",
                //            "You Win!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                //        {
                //            newgame = true;
                //        }
                //    }

                //    else
                //        if (MessageBox.Show("Your score: " + gameScore.Score + "\nDo you want to play again?",
                //            "You Win!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                //        {
                //            newgame = true;
                //        }
                //    if (newgame)
                //    {
                //        gameControl.setGhostNull();
                //        gameControl.resetGame();

                //        gameScore.Score = 0;
                //        gameLevel.Level = 1;
                //        gameLine.Line = 0;
                //        gamePiece.Piece = 0;
                //        gameControl.gameInitObj(out  shapeNext, out  colorNext, out  rotaterNext);
                //        gameControl.setShape(shapeNext, colorNext, rotaterNext);
                //        nextShape.drawNextShape(shapeNext, colorNext, rotaterNext);
                //        gamePiece.Piece++;

                //        timer.Interval = 500;
                //        menuItem2.Enabled = true;
                //        menuItem2.Text = "Pause";
                //        if (bSound)
                //            playSound.playSoundTheme();
                //        changeMode(ModeGame.Playing);
                //        timer.Enabled = true;
                //    }
                //    else
                //    {
                //        changeMode(ModeGame.Ready);
                //        playSound.stopSoundTheme();
                //        timer.Enabled = true;
                //        return;
                //    }
                //}
                //else
                //{

                //    gameControl.gameInitObj(out  shapeNext, out  colorNext, out  rotaterNext);
                //    gameControl.setShape(shapeNext, colorNext, rotaterNext);
                //    nextShape.drawNextShape(shapeNext, colorNext, rotaterNext);
                //    gameControl.drawGhostShape(bGhost);
                //    gamePiece.Piece++;
                //}
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
            if (playing)
            {
                Graphics gr = Graphics.FromImage(gameControl.ImageBuffer);
                gameControl.CurrentShape.eraseShape(gr);
                if (e.KeyValue == (int)System.Windows.Forms.Keys.Up)
                {
                    gameControl.CurrentShape.rotate();
                }
                else
                    if (e.KeyCode == Keys.Left && gameControl.CurrentShape.canMoveLeft())
                    {
                        gameControl.CurrentShape.moveLeft();
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
                gameControl.refresh();
                gr.Dispose();
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
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
    }
}