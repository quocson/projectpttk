using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;
using ThemePluginInterface;
using System.Windows.Forms;

namespace TetrisReturn
{
    public static class Constants
    {
        public const int blockSize = 24;//size of block.
        public const int blockDelta = 1;//size between two block.
        public const int xStart = blockSize * 7;//position x start of shape.

        public static Random r = new Random(unchecked((int)DateTime.Now.Ticks));//static variable random.

        public static Map map = new Map();//static map of game.
        public static Theme theme = new Theme();//static theme of game.

        public static PluginMapServices mapService = new PluginMapServices();//static plugin map services.
        public static PluginThemeServices themeService = new PluginThemeServices();//static plugin theme services.

        //set type for the static map.
        public static void setMap(Map m)
        {
            map.Dispose();
            map = new Map(m);
        }

        //set type for the static theme.
        public static void setTheme(Theme t)
        {
            theme.Dispose();
            theme = new Theme(t);
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
