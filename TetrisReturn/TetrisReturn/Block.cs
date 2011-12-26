using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisReturn
{
    class Block : IDisposable
    {
        private int xScreen;//x position of block on the screen.
        private int yScreen;//y position of block on the screen.
        private int color;//color of block.
        private int type;//type of block.

        public Block()
        {
            xScreen = 0;
            yScreen = 0;
            color = 0;
            type = 0;
        }

        public Block(int x, int y, int c, int t)
        {
            xScreen = x;
            yScreen = y;
            color = c;
            type = t;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //return position block on map.
        public Point mapPosotion()
        {
            return new Point(xScreen / Constants.blockSize, (yScreen + Constants.blockSize * 4) / Constants.blockSize);
        }

        //draw block on the graphics.
        public void drawBlock(Graphics gr)
        {
            gr.DrawImage(Constants.theme.Blocks, 
                new Rectangle(xScreen, yScreen, Constants.blockSize - Constants.blockDelta, Constants.blockSize - Constants.blockDelta),
                new Rectangle(color * Constants.blockSize, type * Constants.blockSize, Constants.blockSize, Constants.blockSize),
                GraphicsUnit.Pixel);
        }

        //draw ghost block on the graphics.
        public void drawGhostBlock(Graphics gr)
        {
            gr.DrawImage(Constants.theme.Blocks,
                new Rectangle(xScreen, yScreen, Constants.blockSize - Constants.blockDelta, Constants.blockSize - Constants.blockDelta),
                new Rectangle(color * Constants.blockSize, (type + Constants.numTypeBlock) * Constants.blockSize, Constants.blockSize, Constants.blockSize),
                GraphicsUnit.Pixel);
        }

        //erase block on the graphics.
        public void eraseBlock(Graphics gr)
        {
            gr.DrawImage(Constants.map.ImageMap,
                         new Rectangle(xScreen, yScreen, Constants.blockSize, Constants.blockSize),
                         new Rectangle(xScreen, yScreen, Constants.blockSize, Constants.blockSize),
                         GraphicsUnit.Pixel);
        }

        //check right position block.
        public bool rightPosition()
        {
            //if

            return false;

        }

        //check block can move down.
        public bool checkDown()
        {
            //if

            return false;
        }

        //lock block on static map.
        public void lockBlockOnMap()
        {
        }

        //move block to the left.
        public void moveLeft()
        {
            xScreen -= Constants.blockSize;
        }

        //move block to the right.
        public void moveRight()
        {
            xScreen += Constants.blockSize;
        }

        //move block down.
        public void moveDown()
        {
            yScreen += Constants.blockSize;
        }
    }
}
