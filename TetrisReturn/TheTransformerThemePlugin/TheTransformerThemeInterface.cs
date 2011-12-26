using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemePluginInterface;

namespace TheTransformerThemePlugin
{
    class TheTransformerThemeInterface : ThemeInterface
    {
        private Theme theme = new Theme(TheTransformerThemePlugin.Properties.Resources.MainBackground,
                                        TheTransformerThemePlugin.Properties.Resources.HelpBackground,
                                        TheTransformerThemePlugin.Properties.Resources.AboutBackground,
                                        TheTransformerThemePlugin.Properties.Resources.HighScoresBackground,
                                        TheTransformerThemePlugin.Properties.Resources.OptionBackground,
                                        TheTransformerThemePlugin.Properties.Resources.Blocks,
                                        TheTransformerThemePlugin.Properties.Resources.NormalButton,
                                        TheTransformerThemePlugin.Properties.Resources.HoverButton,
                                        TheTransformerThemePlugin.Properties.Resources.ClickButton,
                                        TheTransformerThemePlugin.Properties.Resources.DisableButton,
                                        TheTransformerThemePlugin.Properties.Resources.Informations);

        public string VietNameseName { get { return TheTransformerThemePlugin.Properties.Resources.vietNameseName; } }
        public string VietNameseDescription { get { return TheTransformerThemePlugin.Properties.Resources.vietNameseDescription; } }
        public string EnglishName { get { return TheTransformerThemePlugin.Properties.Resources.englishName; } }
        public string EnglishDescription { get { return TheTransformerThemePlugin.Properties.Resources.englishDescription; } }

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
