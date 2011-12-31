using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MapPluginInterface;

namespace TheStairwayToHeavenMapPlugin
{
    public class TheStairwayToHeavenMap : Map
    {
        public TheStairwayToHeavenMap()
        {
            reset();
            name = TheStairwayToHeavenMapPlugin.Properties.Resources.name;
            iMap = new Bitmap(TheStairwayToHeavenMapPlugin.Properties.Resources.StairwayToHeavenMap);
        }

        //override method reset.
        public override void reset()
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    if ((i == 7 || i == 8 || i == 12 || i == 13 || i == 16 ||
                        i == 17 || i == 20 || i == 21 || i == 23 || i == 24) &&
                        (j < 5 || j > 10))
                        statusMap[i, j] = -2;
                    else
                        statusMap[i, j] = -1;
        }
    }
}
