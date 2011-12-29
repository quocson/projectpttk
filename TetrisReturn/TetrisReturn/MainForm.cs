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
        private int soundVolume;
        private GameControl gameControl;
        private SoundControl soundControl;
        private string languageDisplay;
        private About about;
        private Help help;
        private HighScores highScores;
        private Option option;

        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Constants.findMap();
            Constants.findTheme();

            checkLostAllFiles();

            setLastConfig();
            imageButton1.Image = Constants.theme.NormalButton;
           // imageButton1.FText = new Font("Arial", 15);
            imageButton1.SText = "son";
            this.BackgroundImage = Constants.theme.MainBackground;
            imageButton2.Image = Constants.theme.NormalButton;
            imageButton3.Image = Constants.theme.NormalButton;
            imageButton4.Image = Constants.theme.NormalButton;
            imageButton5.Image = Constants.theme.NormalButton;
            imageButton6.Image = Constants.theme.NormalButton;
            imageButton7.Image = Constants.theme.NormalButton;
            gameControl = new GameControl();
            soundControl = new SoundControl();
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
            Application.Exit();
        }
    }
}
