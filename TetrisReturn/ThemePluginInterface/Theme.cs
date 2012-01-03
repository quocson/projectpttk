using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ThemePluginInterface
{
    public class Theme : IDisposable
    {
        private Bitmap iMainBackground;
        private Bitmap iHelpBackground;
        private Bitmap iAboutBackground;
        private Bitmap iHighScoresBackground;
        private Bitmap iOptionBackground;
        private Bitmap iBlocks;
        private Bitmap iButton;
        private Bitmap iGameOver;
        private Bitmap iGameWin;
        private Bitmap iExit;
        private Bitmap iInformations;
        private Bitmap iNextShape;
        private Bitmap iExitConfirm;
        private int numColorBlock;
        private int numTypeBlock;
        private string name;
        private string font;

        public Theme()
        {
        }

        public Theme(Theme t)
        {
            iMainBackground = new Bitmap(t.iMainBackground);
            iHelpBackground = new Bitmap(t.iHelpBackground);
            iAboutBackground = new Bitmap(t.iAboutBackground);
            iHighScoresBackground = new Bitmap(t.iHighScoresBackground);
            iOptionBackground = new Bitmap(t.iOptionBackground);
            iBlocks = new Bitmap(t.iBlocks);
            iButton = new Bitmap(t.iButton);
            iGameOver = new Bitmap(t.iGameOver);
            iGameWin = new Bitmap(t.iGameWin);
            iExit = new Bitmap(t.iExit);
            iInformations = new Bitmap(t.iInformations);
            iExitConfirm = new Bitmap(t.iExitConfirm);
            iNextShape = new Bitmap(t.iNextShape);
            numColorBlock = t.numColorBlock;
            numTypeBlock = t.numTypeBlock;
            name = t.name;
            font = t.font;
        }

        public Theme(Image iMainBackground,
                    Image iHelpBackground,
                    Image iAboutBackground,
                    Image iHighScoresBackground,
                    Image iOptionBackground,
                    Image iBlocks,
                    Image iButton,
                    Image iGameOver,
                    Image iGameWin,
                    Image iExit,
                    Image iInformations,
                    Image iNextShape,
                    Image iExitConfirm,
                    int numColorBlock,
                    int numTypeBlock,
                    string name,
                    string font)
        {
            this.iMainBackground = new Bitmap(iMainBackground);
            this.iHelpBackground = new Bitmap(iHelpBackground);
            this.iAboutBackground = new Bitmap(iAboutBackground);
            this.iHighScoresBackground = new Bitmap(iHighScoresBackground);
            this.iOptionBackground = new Bitmap(iOptionBackground);
            this.iBlocks = new Bitmap(iBlocks);
            this.iButton = new Bitmap(iButton);
            this.iGameOver = new Bitmap(iGameOver);
            this.iGameWin = new Bitmap(iGameWin);
            this.iExit = new Bitmap(iExit);
            this.iInformations = new Bitmap(iInformations);
            this.iNextShape = new Bitmap(iNextShape);
            this.iExitConfirm = new Bitmap(iExitConfirm);
            this.numColorBlock = numColorBlock;
            this.numTypeBlock = numTypeBlock;
            this.name = name;
            this.font = font;
        }

        public void Dispose()
        {
            if (iMainBackground != null)
                iMainBackground.Dispose();
            if (iHelpBackground != null)
                iHelpBackground.Dispose();
            if (iAboutBackground != null)
                iAboutBackground.Dispose();
            if (iHighScoresBackground != null)
                iHighScoresBackground.Dispose();
            if (iOptionBackground != null)
                iOptionBackground.Dispose();
            if (iBlocks != null)
                iBlocks.Dispose();
            if (iButton != null)
                iButton.Dispose();
            if (iGameOver != null)
                iGameOver.Dispose();
            if (iGameWin != null)
                iGameWin.Dispose();
            if (iExit != null)
                iExit.Dispose();
            if (iInformations != null)
                iInformations.Dispose();
            if (iNextShape != null)
                iNextShape.Dispose();
            if (iExitConfirm != null)
                iExitConfirm.Dispose();
            GC.SuppressFinalize(this);
        }

        public Bitmap MainBackground { get { return iMainBackground; } }
        public Bitmap HelpBackground { get { return iHelpBackground; } }
        public Bitmap AboutBackground { get { return iAboutBackground; } }
        public Bitmap HighScoresBackground { get { return iHighScoresBackground; } }
        public Bitmap OptionBackground { get { return iOptionBackground; } }
        public Bitmap Blocks { get { return iBlocks; } }
        public Bitmap Button { get { return iButton; } }
        public Bitmap GameOver { get { return iGameOver; } }
        public Bitmap GameWin { get { return iGameWin; } }
        public Bitmap Exit { get { return iExit; } }
        public Bitmap Informations { get { return iInformations; } }
        public Bitmap NextShape { get { return iNextShape; } }
        public Bitmap ExitConfirm { get { return iExitConfirm; } }
        public int NumColorBlock { get { return numColorBlock; } }
        public int NumTypeBlock { get { return numTypeBlock; } }
        public string Name { get { return name; } }
        public string Font { get { return font; } }
    }
}
