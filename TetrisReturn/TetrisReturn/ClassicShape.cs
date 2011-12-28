using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TetrisReturn
{
    class ClassicShape : Shape
    {
        public ClassicShape()
        {
            int kind = Constants.r.Next(0, 7);
            switch (kind)
            {
                case 0://shape I.
                    row = 4;
                    col = 1;
                    statusArr[0, 0] = statusArr[0, 1] = true;
                    statusArr[0, 2] = statusArr[0, 3] = true;
                    break;

                case 1://shape O.
                    row = col = 2;
                    statusArr[0, 0] = statusArr[0, 1] = true;
                    statusArr[1, 0] = statusArr[1, 1] = true;
                    break;

                case 2://shape T.
                    row = 2;
                    col = 3;
                    statusArr[0, 0] = statusArr[0, 1] = true;
                    statusArr[0, 2] = statusArr[1, 1] = true;
                    break;

                case 3://shape J.
                    row = 2;
                    col = 3;
                    statusArr[0, 0] = statusArr[0, 1] = true;
                    statusArr[0, 2] = statusArr[1, 2] = true;
                    break;

                case 4://shape L.
                    row = 2;
                    col = 3;
                    statusArr[0, 0] = statusArr[0, 1] = true;
                    statusArr[0, 2] = statusArr[1, 0] = true;
                    break;

                case 5://shape Z.
                    row = 2;
                    col = 3;
                    statusArr[0, 0] = statusArr[0, 1] = true;
                    statusArr[1, 1] = statusArr[1, 2] = true;
                    break;

                case 6://shape S.
                    row = 2;
                    col = 3;
                    statusArr[0, 1] = statusArr[0, 2] = true;
                    statusArr[1, 0] = statusArr[1, 1] = true;
                    break;
            }

            int n = Constants.r.Next(0, 4);
            for (int i = 0; i < n; i++)
            {
                rotateStatusArr();
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
