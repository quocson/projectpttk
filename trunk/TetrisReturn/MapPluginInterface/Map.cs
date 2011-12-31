﻿using System;
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

        public Map()
        {
            row = 26;
            col = 16;

            statusMap = new int[row, col];

            //xScreen = ?;
            //yScreen = ?;
        }

        public Map(Map m)
        {
            row = m.row;
            col = m.col;

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
                if (statusMap[4, i] != -1)
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
                    statusMap[i, j] = 0;
                }
            }
        }

        //update the map.
        public void updateMap(int rol, ref int dxLine)
        {
            int i, j;
            for (i = rol; i >= 0; i--)
                for (j = 0; j < col; j++)
                {
                    if (i != 0)
                        statusMap[i, j] = statusMap[i - 1, j];
                }
            dxLine++;
        }
        //get full-lines numbers
        public Stack<int> getFullLines()
        {
            Stack<int> res = new Stack<int>();
            for (int i = 0; i < row; i++)
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