using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MapPluginInterface
{
    public class Map : IDisposable
    {
        protected int[,] statusMap;//status of blocks on the map.

        protected Bitmap iMap;//image of map

        protected int row;//row of map.
        protected int col;//colum of map.

        protected int xScreen;//x position of shape on the screen.
        protected int yScreen;//y position of shape on the screen.
        protected string name;//name of map.

        public Map()
        {
            row = 26;
            col = 16;

            statusMap = new int[row, col];
        }

        public Map(Map m)
        {
            row = m.row;
            col = m.col;

            name = m.name;

            statusMap = new int[row, col];

            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    statusMap[i, j] = m.statusMap[i, j];

            iMap = new Bitmap(m.iMap);

            xScreen = m.xScreen;
            yScreen = m.yScreen;
        }

        public void Dispose()
        {
            if(iMap != null)
                iMap.Dispose();
            GC.SuppressFinalize(this);
        }

        //Status Map properties.
        public int[,] StatusMap
        {
            get { return statusMap; }
            set { statusMap = value; }
        }

        //name Map properties.
        public string Name
        {
            get { return name; }
        }

        //Image Map properties.
        public Bitmap ImageMap { get { return iMap; } }

        //Row Map properties.
        public int Row { get { return row; } }

        //Colum properties.
        public int Column { get { return col; } }

        //check point on map.
        public bool checkOnMap(int x, int y)
        {
            if ((x >= 0 && x < row) && (y >= 0 && y < col))
                return true;
            return false;
        }

        //check overflow map.
        public bool checkOverflow()
        {
            for (int i = 0; i < col; i++)
                if (statusMap[3, i] > -1)
                    return true;
            return false;
        }

        //reset the map.
        public virtual void reset()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (statusMap[i, j] > -2)
                        statusMap[i, j] = -1;
                }
            }
        }

        //update the map.
        public void updateMap(int rol)
        {
            int i, j;
            bool[] unfall = new bool[col];
            for (j = 0; j < col; j++ )
                unfall[j] = false;
            for (i = rol; i >= 0; i--)
                for (j = 0; j < col; j++)
                {
                    if (statusMap[i, j] == -2)
                        unfall[j] = true;
                    if (i != 0 && !unfall[j])
                        if (statusMap[i - 1, j] == -2)
                            statusMap[i, j] = -1;
                        else
                            statusMap[i, j] = statusMap[i - 1, j];
                }
        }
        //get full-lines numbers
        public Stack<int> getFullLines()
        {
            Stack<int> res = new Stack<int>();
            for (int i = 0; i <row; i++)
            {
                bool full = true;
                for (int j = 0; j < col; j++)
                    if (statusMap[i, j] == -1)
                        full = false;
                if (full == true)
                    res.Push(i);
            }
            return res;
        }
    }
}
