using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemePluginInterface;

namespace TheSketchThemePlugin
{
    class TheSketchThemeInterface : ThemeInterface
    {
        private Theme theme = new Theme(TheSketchThemePlugin.Properties.Resources.MainBackground,
                                        TheSketchThemePlugin.Properties.Resources.HelpBackground,
                                        TheSketchThemePlugin.Properties.Resources.AboutBackground,
                                        TheSketchThemePlugin.Properties.Resources.HighScoresBackground,
                                        TheSketchThemePlugin.Properties.Resources.OptionBackground,
                                        TheSketchThemePlugin.Properties.Resources.Blocks,
                                        TheSketchThemePlugin.Properties.Resources.NormalButton,
                                        TheSketchThemePlugin.Properties.Resources.HoverButton,
                                        TheSketchThemePlugin.Properties.Resources.ClickButton,
                                        TheSketchThemePlugin.Properties.Resources.DisableButton,
                                        TheSketchThemePlugin.Properties.Resources.Informations);

        public string VietNameseName { get { return TheSketchThemePlugin.Properties.Resources.vietNameseName; } }
        public string VietNameseDescription { get { return TheSketchThemePlugin.Properties.Resources.vietNameseDescription; } }
        public string EnglishName { get { return TheSketchThemePlugin.Properties.Resources.englishName; } }
        public string EnglishDescription { get { return TheSketchThemePlugin.Properties.Resources.englishDescription; } }

        public Theme Theme { get { return theme; } }

        public void Initialize()
        {
        }

        public void Dispose()
        {
            theme.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
