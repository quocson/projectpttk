﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisReturn
{
    class GameControl : Panel
    {
        private Bitmap imageBuffer;
        private Shape currShape;
        private Shape nextShape;
        private Shape ghostShape;

        public GameControl()
        {
            Location = new Point(435, 80);
            Size = new Size(411, 561);
            imageBuffer = new Bitmap(Constants.map.ImageMap);
            currShape = null;
            nextShape = null;
            ghostShape = null;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        //get image buffer.
        public Bitmap ImageBuffer
        {
            get { return imageBuffer; }
        }

        //get current shape.
        public Shape CurrentShape
        {
            get { return currShape; }
        }

        //get next shape.
        public Shape NextShape
        {
            get { return nextShape; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;
                return cp;
            }
        }

        //reset statusMap and imageMap.
        public void resetMap()
        {
            Constants.map.reset();
            imageBuffer.Dispose();
            imageBuffer = new Bitmap(Constants.map.ImageMap);
            Refresh();
        }

        //create new shape.
        public void createShape(int modeShape)
        {
            if (currShape != null)
                currShape.Dispose();

            if (nextShape != null)
            {
                currShape = new Shape(nextShape);
                nextShape.Dispose();
            }
            else
                switch (modeShape)
                {
                    case 0://classic shape.
                        currShape = new ClassicShape();
                        break;

                    case 1://multi shape.
                        currShape = new MultiShape();
                        break;

                    //for exScreentend shape...
                }

            switch (modeShape)
            {
                case 0://classic shape.
                    nextShape = new ClassicShape();
                    break;

                case 1://multi shape.
                    nextShape = new MultiShape();
                    break;

                //for extend shape...
            }
        }

        //lock shape on map.
        public void lockShape()
        {
            currShape.lockShapeOnMap();
            ghostShape = null;
        }

        //check map overflow.
        public bool checkOverflow()
        {
            return Constants.map.checkOverflow();
        }

        //let current shape fall.
        public bool currShapeFall()
        {
            if (currShape.canFall())
            {
                Graphics gr = Graphics.FromImage(imageBuffer);
                currShape.eraseShape(gr);
                currShape.moveDown();
                currShape.drawShape(gr);
                gr.Dispose();
                return true;
            }
            return false;
        }

        //refresh map.
        public void refresh()
        {
            Refresh();
        }

        //set shape to end map.
        public void setCurrShapeToEndMap()
        {
            currShape.goToEndMap();
        }

        //get full lines.
        public Stack<int> getFullLines()
        {
            return currShape.getFullLines();
        }

        //remove line.
        public void removeLine(int line)
        {

            Graphics g = Graphics.FromImage(imageBuffer);

            g.DrawImage(Constants.theme.MainBackground, new Rectangle(5, 5, Constants.map.Column * Constants.blockSize, (line - 3) * Constants.blockSize),
                new Rectangle(445, 120, Constants.map.Column * Constants.blockSize, (line - 3) * Constants.blockSize), GraphicsUnit.Pixel);

            Refresh();
            for (int i = line - 1; i >= 0; i--)
            {
                bool max = true;
                for (int j = 0; j < Constants.map.Column; j++)
                {
                    if (Constants.map.StatusMap[i, j] > -1)
                    {
                        g.DrawImage(Constants.theme.Blocks,
                        new Rectangle(j * Constants.blockSize + 5 + Constants.blockDelta, (i - 3) * Constants.blockSize + 5 + Constants.blockDelta, Constants.blockSize - Constants.blockDelta, Constants.blockSize - Constants.blockDelta),
                        new Rectangle((Constants.map.StatusMap[i, j]) * Constants.blockSize, 0, Constants.blockSize, Constants.blockSize),
                        GraphicsUnit.Pixel);
                        max = false;
                        Refresh();
                    }
                }
                if (max) i = -1;
            }
            g.Dispose();
        }

        //draw ghost shape.
        public void drawGhostShape()
        {
            Graphics gr = Graphics.FromImage(imageBuffer);

            if (ghostShape != null)
            {
                ghostShape.eraseShape(gr);
                ghostShape.Dispose();
            }
            ghostShape = new Shape(currShape);
            ghostShape.goToEndMap();
            ghostShape.drawGhostShape(gr);
            refresh();
            gr.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(imageBuffer, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }
    }
}