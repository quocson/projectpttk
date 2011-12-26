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
        private Bitmap iNormalButton;
        private Bitmap iHoverButton;
        private Bitmap iClickButton;
        private Bitmap iDisableButton;
        private Bitmap iInformations;

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
            iNormalButton = new Bitmap(t.iNormalButton);
            iHoverButton = new Bitmap(t.iHoverButton);
            iClickButton = new Bitmap(t.iClickButton);
            iDisableButton = new Bitmap(t.iDisableButton);
            iInformations = new Bitmap(t.iInformations);
        }

        public Theme(Image iMainBackground,
                    Image iHelpBackground,
                    Image iAboutBackground,
                    Image iHighScoresBackground,
                    Image iOptionBackground,
                    Image iBlocks,
                    Image iNormalButton,
                    Image iHoverButton,
                    Image iClickButton,
                    Image iDisableButton,
                    Image iInformations)
        {
            this.iMainBackground = new Bitmap(iMainBackground);
            this.iHelpBackground = new Bitmap(iHelpBackground);
            this.iAboutBackground = new Bitmap(iAboutBackground);
            this.iHighScoresBackground = new Bitmap(iHighScoresBackground);
            this.iOptionBackground = new Bitmap(iOptionBackground);
            this.iBlocks = new Bitmap(iBlocks);
            this.iNormalButton = new Bitmap(iNormalButton);
            this.iHoverButton = new Bitmap(iHoverButton);
            this.iClickButton = new Bitmap(iClickButton);
            this.iDisableButton = new Bitmap(iDisableButton);
            this.iInformations = new Bitmap(iInformations);
        }

        public void Dispose()
        {
            iMainBackground.Dispose();
            iHelpBackground.Dispose();
            iAboutBackground.Dispose();
            iHighScoresBackground.Dispose();
            iOptionBackground.Dispose();
            iBlocks.Dispose();
            iNormalButton.Dispose();
            iHoverButton.Dispose();
            iClickButton.Dispose();
            iDisableButton.Dispose();
            iInformations.Dispose();
            GC.SuppressFinalize(this);
        }

        public Bitmap MainBackground { get { return iMainBackground; } }
        public Bitmap HelpBackground { get { return iHelpBackground; } }
        public Bitmap AboutBackground { get { return iAboutBackground; } }
        public Bitmap HighScoresBackground { get { return iHighScoresBackground; } }
        public Bitmap OptionBackground { get { return iOptionBackground; } }
        public Bitmap Blocks { get { return iBlocks; } }
        public Bitmap NormalButton { get { return iNormalButton; } }
        public Bitmap HoverButton { get { return iHoverButton; } }
        public Bitmap ClickButton { get { return iClickButton; } }
        public Bitmap DisableButton { get { return iDisableButton; } }
        public Bitmap Informations { get { return iInformations; } }
    }
}
