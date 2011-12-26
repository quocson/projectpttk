using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisReturn
{
    class Shape : IDisposable
    {
        protected int[,] statusArr;//status of blocks on the shape.
        protected int row;//row of shape.
        protected int col;//colum of shape.
        protected int xScreen;//x position of shape on the screen.
        protected int yScreen;//y position of shape on the screen.
        protected int color;//color of shape.
        protected List<Block> cube;//blocks of shape.

        public Shape()
        {
            statusArr = new int[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    statusArr[i, j] = 0;
                }

            color = Constants.r.Next(0, 7);
        }

        public Shape(Shape s)
        {
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
            while (canFallDown())
                fallDown();
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
            return false;
        }

        //check shape can move right.
        public bool canMoveRight()
        {
            return false;
        }

        //check shape can rotate.
        public bool canRotate()
        {
            return false;
        }

        //lock shape on static map.
        public void lockShapOnMap()
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                cube[i].lockBlockOnMap();
            }
        }

        //check shape can move down.
        public bool canFallDown()
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                if (!cube[i].checkDown())
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
        public void fallDown()
        {
            int n = cube.Count;
            for (int i = 0; i < n; i++)
            {
                cube[i].moveDown();
            }

            yScreen += Constants.blockSize;
        }

        //rotate statusArr of shape.
        protected void rotateArr()
        {
        }

        //rotate shape.
        public void rotate()
        {
        }
    }
}
