using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DrawingEnvironment
{
    internal class CustomCursor : Shape
    {

        Point location = new Point();
        Bitmap cursor = new Bitmap(10, 10);
        
        public CustomCursor()
        {
            location = new Point(X, Y);
        }

        //TODO need to modify this method.
        public void Draw(Graphics g, PaintEventArgs e)
        {

            /*
            Circle circle = new Circle(X, Y, 15);
            Bitmap myBitmap = new Bitmap(20, 20);
            g = Graphics.FromImage(myBitmap);            
            Pen p = new Pen(Color.White, 2);
            circle.Draw(g);
            Graphics windowG = e.Graphics;
            windowG.DrawImageUnscaled(myBitmap, 20, 20);
            p.Dispose();
            */

        }

        /// <summary>
        /// Method to draw the cursor in the canvas.
        /// </summary>
        /// <param name="graphics">the graphic elements where the method will draw</param>
        public override void Draw(Graphics graphics)
        {
            Rectangle rect = new Rectangle(X, Y, 5, 5);
            graphics.DrawImageUnscaled(cursor, X, Y);
            rect.Draw(graphics);
            
        }

        public void UpdatePosition(int x, int y)
        {
            X = x;
            Y = y;
            location = new Point(X, Y);            
        }

    }
}
