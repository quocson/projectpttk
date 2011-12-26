using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;
using ThemePluginInterface;

namespace TetrisReturn
{
    public static class Constants
    {
        public const int blockSize = 30;//size of block.

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
    }
}
