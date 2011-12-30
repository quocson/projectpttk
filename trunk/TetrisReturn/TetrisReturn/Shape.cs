using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisReturn
{
    public class Shape : IDisposable
    {
        protected bool[,] statusArr;//status of blocks on the shape.
        protected int row;//row of shape.
        protected int col;//colum of shape.
        protected int xScreen;//x position of shape on the screen.
        protected int yScreen;//y position of shape on the screen.
        protected int color;//color of shape.
        protected List<Block> cube = new List<Block>();//blocks of shape.

        public Shape()
        {
            xScreen = Constants.xStart;
            yScreen = row = col = 0;

            statusArr = new bool[4, 4];
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    statusArr[i, j] = false;
                }

            color = Constants.r.Next(0, Constants.theme.NumColorBlock);
        }

        public Shape(Shape s)
        {
            row = s.row;
            col = s.col;
            xScreen = s.xScreen;
            yScreen = s.yScreen;
            color = s.color;

            statusArr = new bool[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    statusArr[i, j] = s.statusArr[i, j];
                }

            int n = s.cube.Count;
            for (int i = 0; i < n; i++)
            {
                cube.Add(new Block(s.cube[i]));
            }
        }

        public Shape(Shape s, int x, int y)
        { 
            row = s.row;
            col = s.col;
            xScreen = x;
            yScreen = y;
            color = s.color;

            statusArr = new bool[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    statusArr[i, j] = s.statusArr[i, j];
                }

            int n = s.cube.Count;
            for (int i = 0; i < n; i++)
            {
                cube.Add(new Block(s.cube[i], x, y));
            }
        }

        public void Dispose()
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                cube[i].Dispose();
            }
            GC.SuppressFinalize(this);
        }

        //draw shape on the graphics.
        public void drawShape(Graphics gr)
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                cube[i].drawBlock(gr);
            }
        }

        //draw ghost shape on the graphics.
        public void drawGhostShape(Graphics gr)
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                cube[i].drawGhostBlock(gr);
            }
        }

        //move shape go to end map.
        public void goToEndMap()
        {
            while (canFall())
                moveDown();
        }

        //erase shape on the graphics.
        public void eraseShape(Graphics gr)
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                cube[i].eraseBlock(gr);
            }
        }

        //check shape can move left.
        public bool canMoveLeft()
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                if (!cube[i].canMoveLeft())
                    return false;
            }
            return true;
        }

        //check shape can move right.
        public bool canMoveRight()
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                if (!cube[i].canMoveRight())
                    return false;
            }
            return true;
        }

        //check shape can rotate.
        public bool canRotate()
        {
            bool rotatable = true;
            int tmpRow = col;
            int tmpCol = row;
            bool[,] tmpArr = new bool[4, 4];

            for (int i = row - 1; i >= 0; i--)
                for (int j = col - 1; j >= 0; j--)
                {
                    tmpArr[j, row - i - 1] = statusArr[i, j];
                    if (tmpArr[j, row - i - 1])
                    {
                        Block tmpBlock = new Block(xScreen + (row - i - 1) * Constants.blockSize, yScreen + j * Constants.blockSize, 0, 0);
                        if (!tmpBlock.rightPosition())
                            rotatable = false;
                        tmpBlock.Dispose();
                    }
                }

            if (rotatable)
                return true;

            int dx = (xScreen + Constants.blockSize * tmpCol - Constants.map.Column * Constants.blockSize) / Constants.blockSize;
            if(dx < 0) dx = 0;
            int tmpX = xScreen - Constants.blockSize;
            int tmpY = yScreen;
            rotatable = true;
            do
            {
                for (int i = 0; i < tmpRow; i++)
                    for (int j = 0; j < tmpCol - dx; j++)
                    {
                        if (tmpArr[i, j])
                        {
                            Block tmpBlock = new Block(tmpX + j * Constants.blockSize, tmpY + i * Constants.blockSize, 0, 0);
                            if (!tmpBlock.rightPosition())
                                return false;
                            tmpBlock.Dispose();
                        }
                    }

                tmpX -= Constants.blockSize;
                dx--;
            } while (dx > 0);
            xScreen = tmpX + Constants.blockSize;
            return true;
        }

        //lock shape on static map.
        public void lockShapeOnMap()
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                cube[i].lockBlockOnMap();
            }
        }

        //check shape can move down.
        public bool canFall()
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                if (!cube[i].canMoveDown())
                    return false;
            }

            return true;
        }

        //move shape to the left.
        public void moveLeft()
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                cube[i].moveLeft();
            }

            xScreen -= Constants.blockSize;
        }

        //move shape to the right.
        public void moveRight()
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                cube[i].moveRight();
            }

            xScreen += Constants.blockSize;
        }

        //move shape down.
        public void moveDown()
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                cube[i].moveDown();
            }

            yScreen += Constants.blockSize;
        }

        //rotate statusArr of shape.
        protected void rotateStatusArr()
        {
            int tmpRow = col;
            int tmpCol = row;
            bool[,] tmpArr = new bool[4, 4];
            for (int i = row - 1; i >= 0; i--)
                for (int j = col - 1; j >= 0; j--)
                {
                    tmpArr[j, row - i - 1] = statusArr[i, j];
                }

            row = tmpRow;
            col = tmpCol;
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    statusArr[i, j] = tmpArr[i, j];
                }
            tmpArr = null;
        }

        //rotate shape.
        public void rotate()
        {
            if (!canRotate())
                return;

            int tmpRow = col;
            int tmpCol = row;
            bool[,] tmpArr = new bool[4, 4];
            for (int i = row - 1; i >= 0; i--)
                for (int j = col - 1; j >= 0; j--)
                {
                    tmpArr[j, row - i - 1] = statusArr[i, j];
                }

            row = tmpRow;
            col = tmpCol;
            int index = 0;
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    statusArr[i, j] = tmpArr[i, j];
                    if (statusArr[i, j])
                    {
                        cube[index].X = xScreen + j * Constants.blockSize;
                        cube[index++].Y = yScreen + i * Constants.blockSize;
                    }
                }
            tmpArr = null;
        }

        //get full lines.
        public Stack<int> getFullLines()
        {
            Stack<int> fullLines = new Stack<int>();

            int rootLine = yScreen / Constants.blockSize + 4;
            int counter, n = rootLine + row;
            for (int i = rootLine; i < n; i++)
            {
                counter = 0;
                for (int j = 0; j < Constants.map.Column; j++)
                {
                    if (Constants.map.checkOnMap(i, j) && Constants.map.StatusMap[i, j] != -1)
                        counter++;
                }
                if (counter == Constants.map.Column)
                {
                    fullLines.Push(i);
                }
            }

            return fullLines;
        }
    }
}
