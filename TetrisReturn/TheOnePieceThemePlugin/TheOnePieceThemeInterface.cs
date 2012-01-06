using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemePluginInterface;

namespace TheOnePieceThemePlugin
{
    public class TheOnePieceThemeInterface : ThemeInterface
    {
        private Theme theme = new Theme(TheOnePieceThemePlugin.Properties.Resources.MainBackground,
                                        TheOnePieceThemePlugin.Properties.Resources.HelpBackground,
                                        TheOnePieceThemePlugin.Properties.Resources.AboutBackground,
                                        TheOnePieceThemePlugin.Properties.Resources.HighScoresBackground,
                                        TheOnePieceThemePlugin.Properties.Resources.OptionBackground,
                                        TheOnePieceThemePlugin.Properties.Resources.Blocks,
                                        TheOnePieceThemePlugin.Properties.Resources.Button,
                                        TheOnePieceThemePlugin.Properties.Resources.GameOver,
                                        TheOnePieceThemePlugin.Properties.Resources.GameWin,
                                        TheOnePieceThemePlugin.Properties.Resources.Exit,
                                        TheOnePieceThemePlugin.Properties.Resources.Informations,
                                        TheOnePieceThemePlugin.Properties.Resources.NextShape,
                                        TheOnePieceThemePlugin.Properties.Resources.ExitConfirm,
                                        7,
                                        1,
                                        TheOnePieceThemePlugin.Properties.Resources.name,
                                        TheOnePieceThemePlugin.Properties.Resources.font);

        public string VietNameseDescription { get { return TheOnePieceThemePlugin.Properties.Resources.vietNameseDescription; } }
        public string Name { get { return TheOnePieceThemePlugin.Properties.Resources.name; } }
        public string EnglishDescription { get { return TheOnePieceThemePlugin.Properties.Resources.englishDescription; } }

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
