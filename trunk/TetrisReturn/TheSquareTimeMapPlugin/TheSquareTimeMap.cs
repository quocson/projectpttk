using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MapPluginInterface;

namespace TheSquareTimeMapPlugin
{
    class TheSquareTimeMap : Map
    {
        public TheSquareTimeMap()
        {
            reset();

            iMap = new Bitmap(TheSquareTimeMapPlugin.Properties.Resources.SquareTimeMap);

        }

        //override method reset.
        public override void reset()
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    if ((i == 2 || i == 3 || i == 6 || i == 7 || i == 10 ||
                        i == 11 || i == 14 || i == 15 || i == 18 || i == 19) &&
                        (j < 2 || j > 13))
                        statusMap[i, j] = -2;
                    else
                        statusMap[i, j] = -1;
        }
    }
}
