using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MapPluginInterface;

namespace TheClassicMapPlugin
{
    class TheClassicMap : Map
    {
        public TheClassicMap()
        {
            reset();

            iMap = new Bitmap(TheClassicMapPlugin.Properties.Resources.ClassicMap);
        }

        //override method reset.
        public override void reset()
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    statusMap[i, j] = -1;
        }
    }
}
