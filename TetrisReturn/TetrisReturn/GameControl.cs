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
        public void createShape(int modeShape, bool change)
        {
            if (!change)
            {
                currShape.rotate();
                return;
            }
            int x, y;
            x = currShape.XScreen;
            y = currShape.YScreen;
            Shape temp = new Shape(currShape, x, y);
            if (currShape != null)
                currShape.Dispose();

            switch (modeShape)
            {
                case 0://classic shape.
                    {
                        temp = new ClassicShape();
                        
                    }
                    break;

                case 1://multi shape.
                    {
                        temp = new MultiShape();
                    }
                    break;

                //for exScreentend shape...
            }
            if ((x - 6) / Constants.blockSize + temp.Col >= Constants.map.Column)
                x = (Constants.map.Column - temp.Col) * Constants.blockSize + 6;
            while ((x - 6) / Constants.blockSize < 0)
                x += Constants.blockSize;
            for (int i = 0; i < temp.Col; i++)
                for (int j = 0; j < temp.Row; j++)
                    if (y < 0 || (y - 6) / Constants.blockSize + j + 4 >= Constants.map.Row || Constants.map.StatusMap[(y - 6) / Constants.blockSize + j + 4, (x - 6) / Constants.blockSize + i] > -1)
                        return;

            if ((y - 6) / Constants.blockSize + temp.Row >= Constants.map.Row - 4)
                return;
            

            currShape = new Shape(temp, x, y);
            temp.Dispose();

            
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
                new Rectangle(435, 80, Constants.map.Column * Constants.blockSize, (line - 3) * Constants.blockSize), GraphicsUnit.Pixel);

            for (int i = line ; i >= 0; i--)
            {
                for (int j = 0; j < Constants.map.Column; j++)
                {
                    if (Constants.map.StatusMap[i, j] > -1)
                    {
                        g.DrawImage(Constants.theme.Blocks,
                        new Rectangle(j * Constants.blockSize + 5 + Constants.blockDelta, (i - 4) * Constants.blockSize + 5 + Constants.blockDelta, Constants.blockSize - Constants.blockDelta, Constants.blockSize - Constants.blockDelta),
                        new Rectangle((Constants.map.StatusMap[i, j]) * Constants.blockSize, 0, Constants.blockSize, Constants.blockSize),
                        GraphicsUnit.Pixel);
                    }
                }
            }
            Refresh();
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
