using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MapPluginInterface;

namespace TheRazorBladeMapPlugin
{
    class TheRazorBladeMap : Map
    {
        public TheRazorBladeMap()
        {
            reset();

            iMap = new Bitmap(TheRazorBladeMapPlugin.Properties.Resources.RazorBladeMap);

        }

        //override method reset.
        public override void reset()
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    if ((i % 2 == 0) && (j == 0 || j == 15))
                        statusMap[i, j] = -2;
                    else
                        statusMap[i, j] = -1;
        }
    }
}
