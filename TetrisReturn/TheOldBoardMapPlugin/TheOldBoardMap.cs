using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MapPluginInterface;

namespace TheOldBoardMapPlugin
{
    class TheOldBoardMap : Map
    {
        public TheOldBoardMap()
        {
            reset();

            iMap = new Bitmap(TheOldBoardMapPlugin.Properties.Resources.OldBoardMap);

        }

        //override method reset.
        public override void reset()
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    statusMap[i, j] = -1;

            statusMap[3, 3] = statusMap[3, 4] = -2;
            statusMap[6, 11] = statusMap[6, 12] = -2;
            statusMap[9, 3] = statusMap[9, 4] = -2;
            statusMap[12, 11] = statusMap[12, 12] = -2;
            statusMap[15, 3] = statusMap[15, 4] = -2;
            statusMap[18, 11] = statusMap[18, 12] = -2;
        }
    }
}
