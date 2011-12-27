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
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < col; j++)
                    statusMap[i, j] = -1;
            //top
            for (int i = 4; i < 11; i++)
                for (int j = 0; j < col; j++)
                    if ((j < i - 4) || 15 - j < i - 4)
                        statusMap[i, j] = -2;
                    else
                        statusMap[i, j] = -1;
            //middle
            for (int i = 11; i < 19; i++)
                for (int j = 0; j < col; j++)
                    if (j < 2 || j > 13 || ((i - 4) % 3 == 0 && (j < 6 || j > 9)))
                        statusMap[i, j] = -2;
                    else
                        statusMap[i, j] = -1;
            //bottom
            for (int i = 19; i < 26; i++)
                for (int j = 0; j < col; j++)
                    if ((j + (i - 4) - 15 < 6) || 15 - j < 21 - (i - 4))
                        statusMap[i, j] = -2;
                    else
                        statusMap[i, j] = -1;
        }
    }
}
