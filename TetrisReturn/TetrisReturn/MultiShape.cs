using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TetrisReturn
{
    class MultiShape : Shape
    {
        public MultiShape()
        {
            row = Constants.r.Next(1, 5);
            col = Constants.r.Next(1, 5);
            for (int i = 0; i < row; i++)
            {
                int n = Constants.r.Next(1, col / 2 + 1);
                for (int j = 0; j < n; j++)
                {
                    int m = Constants.r.Next(0, col);
                    statusArr[i, m] = true;
                }
            }

            for (int i = 0; i < col; i++)
            {
                int n = Constants.r.Next(1, row / 2 + 1);
                for (int j = 0; j < n; j++)
                {
                    int m = Constants.r.Next(0, row);
                    statusArr[i, m] = true;
                }
            }

            yScreen = row * Constants.blockSize;

            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    if (statusArr[i, j])
                    {
                        cube.Add(new Block(xScreen + j * Constants.blockSize, yScreen + i * Constants.blockSize, color, Constants.r.Next(0, 7)));
                    }
                }
        }
    }
}
