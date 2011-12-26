using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MapPluginInterface;

namespace TheStairwayToHeavenMapPlugin
{
    class TheStairwayToHeavenMap : Map
    {
        public TheStairwayToHeavenMap()
        {
            reset();

            iMap = new Bitmap(TheStairwayToHeavenMapPlugin.Properties.Resources.StairwayToHeavenMap);
        }

        //override method reset.
        public override void reset()
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    if ((i == 3 || i == 4 || i == 8 || i == 9 || i == 12 ||
                        i == 13 || i == 16 || i == 17 || i == 19 || i == 20) &&
                        (j < 5 || j > 10))
                        statusMap[i, j] = -2;
                    else
                        statusMap[i, j] = -1;
        }
    }
}
