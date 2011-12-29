using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MapPluginInterface;

namespace TheOldBoardMapPlugin
{
    public class TheOldBoardMap : Map
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

            statusMap[7, 3] = statusMap[7, 4] = -2;
            statusMap[10, 11] = statusMap[10, 12] = -2;
            statusMap[13, 3] = statusMap[13, 4] = -2;
            statusMap[16, 11] = statusMap[16, 12] = -2;
            statusMap[19, 3] = statusMap[19, 4] = -2;
            statusMap[22, 11] = statusMap[22, 12] = -2;
        }
    }
}
