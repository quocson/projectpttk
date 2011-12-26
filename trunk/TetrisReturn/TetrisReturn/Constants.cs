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
        public const int blockSize = 25;//size of block.
        public const int blockDelta = 2;//size between two block.

        public static Random r = new Random(unchecked((int)DateTime.Now.Ticks));//static variable random.

        public static Map map = new Map();//static map of game.
        public static Theme theme = new Theme();//static theme of game.

        public static PluginMapServices mapService = new PluginMapServices();//static plugin map services.
        public static PluginThemeServices themeService = new PluginThemeServices();//static plugin theme services.

        public static int numColorBlock;//number color of block.
        public static int numTypeBlock;//number type of block.

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
            numColorBlock = t.NumColorBlock;
            numTypeBlock = t.NumTypeBlock;
        }
    }
}
