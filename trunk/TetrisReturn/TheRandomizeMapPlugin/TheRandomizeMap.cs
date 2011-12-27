using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MapPluginInterface;

namespace TheRandomizeMapPlugin
{
    class TheRandomizeMap : Map
    {
        public TheRandomizeMap()
        {
            reset();

            iMap = new Bitmap(TheRandomizeMapPlugin.Properties.Resources.RandomizeMap);

        }

        //override method reset.
        public override void reset()
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    statusMap[i, j] = -1;

            statusMap[4, 0] = -2;
            statusMap[6, 0] = statusMap[6, 13] = statusMap[6, 14] = statusMap[6, 15] = -2;
            statusMap[7, 14] = statusMap[7, 15] = -2;
            statusMap[8, 0] = statusMap[8, 1] = statusMap[8, 2] = -2;
            statusMap[9, 13] = statusMap[9, 14] = statusMap[9, 15] = -2;
            statusMap[10, 0] = statusMap[10, 1] = -2;
            statusMap[11, 13] = statusMap[11, 14] = statusMap[11, 15] = -2;
            statusMap[12, 0] = statusMap[12, 1] = -2;
            statusMap[13, 14] = statusMap[13, 15] = -2;
            statusMap[14, 0] = -2;
            statusMap[15, 13] = statusMap[15, 14] = statusMap[15, 15] = -2;
            statusMap[16, 0] = statusMap[16, 1] = -2;
            statusMap[17, 0] = statusMap[17, 1] = statusMap[17, 15] = -2;
            statusMap[19, 0] = statusMap[19, 1] = statusMap[19, 2] = statusMap[19, 15] = -2;
            statusMap[20, 14] = statusMap[20, 15] = -2;
            statusMap[21, 0] = statusMap[21, 1] = statusMap[21, 15] = -2;
            statusMap[23, 0] = statusMap[23, 15] = -2;
            statusMap[24, 0] = statusMap[24, 1] = -2;
        }
    }
}
