using System;
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
            Location = new Point(0, 0);
            Size = new Size(0, 0);
            imageBuffer = new Bitmap(Constants.map.ImageMap);
            currShape = null;
            nextShape = null;
            ghostShape = null;
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

                //for exScreentend shape...
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
        void setCurrShapeToEndMap()
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
