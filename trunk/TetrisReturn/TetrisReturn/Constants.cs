using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;
using ThemePluginInterface;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace TetrisReturn
{
    public static class Constants
    {
        public const int blockSize = 25;//size of block.
        public const int blockDelta = 1;//size between two block.
        public const int xStart = blockSize * 7 + 6;//position x start of shape.
        public const int scorePerLine = 30;
        public static Random r = new Random(unchecked((int)DateTime.Now.Ticks));//static variable random.

        public static Map map = new Map();//static map of game.
        public static Theme theme = new Theme();//static theme of game.
        public static Language language = new Language();
        public static PluginMapServices mapService = new PluginMapServices();//static plugin map services.
        public static PluginThemeServices themeService = new PluginThemeServices();//static plugin theme services.
        public static PrivateFontCollection fonts = null;
        public static FontFamily family = null;
        private static SaveDTO saveInfo = new SaveDTO();
        public static TetrisReturn.SaveDTO SaveInfo
        {
            get { return saveInfo; }
            set { saveInfo = value; }
        }
        //set type for the static map.
        public static void setMap(Map m)
        {
            map.Dispose();
            map = new Map(m);
            saveInfo.SMap = map.Name;
        }

        //set type for the static theme.
        public static void setTheme(Theme t)
        {
            theme.Dispose();
            theme = new Theme(t);
            saveInfo.STheme = theme.Name;

        }
        public static Font getFont(float size)
        {
            if (theme.Name == "Transformers")
            {

                if (family == null)
                {
                    fonts = new PrivateFontCollection();
                    fonts.AddFontFile(AppDomain.CurrentDomain.BaseDirectory + @"\Fonts\Transformers Movie.ttf");
                    family = fonts.Families[0];
                }
                return new Font(family, size, FontStyle.Bold);

            }
            if (theme.Name == "Sketch")
            {

                if (family == null)
                {
                    fonts = new PrivateFontCollection();
                    fonts.AddFontFile(AppDomain.CurrentDomain.BaseDirectory + @"\Fonts\Sketch_Block.ttf");
                    family = fonts.Families[0];
                }
                return new Font(family, size);
            }
            else
                return new Font("Arial", size);
        }
        //find map.
        public static void findMap()
        {
            mapService.findMaps(Application.StartupPath + @"\Maps");
        }

        //find theme.
        public static void findTheme()
        {
            themeService.findThemes(Application.StartupPath + @"\Themes");
        }
    }
}
