using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MapPluginInterface;

namespace TheHourglassMapPlugin
{
    class TheHourglassMap : Map
    {
        public TheHourglassMap()
        {
            reset();

            iMap = new Bitmap(TheHourglassMapPlugin.Properties.Resources.HourglassMap);

        }

        //override method reset.
        public override void reset()
        {
            //top
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < col; j++)
                    if ((j < i) || 15 - j < i)
                        statusMap[i, j] = -2;
                    else
                        statusMap[i, j] = -1;
            //middle
            for (int i = 7; i < 15; i++)
                for (int j = 0; j < col; j++)
                    if (j < 2 || j > 13 || (i % 3 == 0 && (j < 6 || j > 9)))
                        statusMap[i, j] = -2;
                    else
                        statusMap[i, j] = -1;
            //bottom
            for (int i = 15; i < 22; i++)
                for (int j = 0; j < col; j++)
                    if ((j + i - 15 < 6) || 15 - j < 21 - i)
                        statusMap[i, j] = -2;
                    else
                        statusMap[i, j] = -1;
        }
    }
}
