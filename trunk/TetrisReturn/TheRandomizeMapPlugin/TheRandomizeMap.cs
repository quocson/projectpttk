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

            statusMap[0, 0] = -2;
            statusMap[2, 0] = statusMap[2, 13] = statusMap[2, 14] = statusMap[2, 15] = -2;
            statusMap[3, 14] = statusMap[3, 15] = -2;
            statusMap[4, 0] = statusMap[4, 1] = statusMap[4, 2] = -2;
            statusMap[5, 13] = statusMap[5, 14] = statusMap[5, 15] = -2;
            statusMap[6, 0] = statusMap[6, 1] = -2;
            statusMap[7, 13] = statusMap[7, 14] = statusMap[7, 15] = -2;
            statusMap[8, 0] = statusMap[8, 1] = -2;
            statusMap[9, 14] = statusMap[9, 15] = -2;
            statusMap[10, 0] = -2;
            statusMap[11, 13] = statusMap[11, 14] = statusMap[11, 15] = -2;
            statusMap[12, 0] = statusMap[12, 1] = -2;
            statusMap[13, 0] = statusMap[13, 1] = statusMap[13, 15] = -2;
            statusMap[15, 0] = statusMap[15, 1] = statusMap[15, 2] = statusMap[15, 15] = -2;
            statusMap[16, 14] = statusMap[16, 15] = -2;
            statusMap[17, 0] = statusMap[17, 1] = statusMap[17, 15] = -2;
            statusMap[19, 0] = statusMap[19, 15] = -2;
            statusMap[20, 0] = statusMap[20, 1] = -2;
        }
    }
}
