using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisReturn
{
    public class Block : IDisposable
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

        public Block(Block b)
        {
            xScreen = b.xScreen;
            yScreen = b.yScreen;
            color = b.color;
            type = b.type;
        }

        public Block(Block b, int x, int y)
        {
            xScreen = x;
            yScreen = y;
            color = b.color;
            type = b.type;
        }

        //xScreen properties.
        public int X
        {
            get { return xScreen; }
            set { xScreen = value; }
        }

        //yScreen properties.
        public int Y
        {
            get { return yScreen; }
            set { yScreen = value; }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //return position block on map.
        public Point mapPosotion()
        {
            return new Point((yScreen + 4 * Constants.blockSize) / Constants.blockSize, xScreen / Constants.blockSize);
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
                new Rectangle(color * Constants.blockSize, (type + Constants.theme.NumTypeBlock) * Constants.blockSize, Constants.blockSize, Constants.blockSize),
                GraphicsUnit.Pixel);
        }

        //erase block on the graphics.
        public void eraseBlock(Graphics gr)
        {

            gr.DrawImage(Constants.theme.MainBackground,
                         new Rectangle(xScreen, yScreen, Constants.blockSize, Constants.blockSize),
                         new Rectangle(xScreen + 440, yScreen + 115, Constants.blockSize, Constants.blockSize),
                         GraphicsUnit.Pixel);
        }

        //check right position block.
        public bool rightPosition()
        {
            int x = mapPosotion().X;
            int y = mapPosotion().Y;

            if ((y >= 0 && y < Constants.map.Column) &&
                (x >= 0 && x < Constants.map.Row) &&
                Constants.map.StatusMap[x, y] == -1)
                return true;

            return false;
        }

        //check block can move left.
        public bool canMoveLeft()
        {
            int x = mapPosotion().X;
            int y = mapPosotion().Y;

            if ((y > 0 && y < Constants.map.Column) &&
                (x >= 0 && x < Constants.map.Row - 1) &&
                Constants.map.StatusMap[x - 1, y] == -1)
                return true;

            return false;
        }

        //check block can move right.
        public bool canMoveRight()
        {
            int x = mapPosotion().X;
            int y = mapPosotion().Y;
            
            if ((y >= 0 && y < Constants.map.Column - 1) &&
                (x >= 0 && x < Constants.map.Row - 1) &&
                Constants.map.StatusMap[x + 1, y] == -1)
                return true;

            return false;
        }

        //check block can move down.
        public bool canMoveDown()
        {
            int x = mapPosotion().X;
            int y = mapPosotion().Y;

            if ((y >= 0 && y < Constants.map.Column) &&
                (x >= 0 && x < Constants.map.Row - 1) &&
                Constants.map.StatusMap[x + 1, y] == -1)
                return true;

            return false;
        }

        //lock block on static map.
        public void lockBlockOnMap()
        {
            int x = mapPosotion().X;
            int y = mapPosotion().Y;

            if (Constants.map.StatusMap[x, y] == -1)
                Constants.map.StatusMap[x, y] = color;
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
