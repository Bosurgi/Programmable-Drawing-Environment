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
            rect.SetColour(Color.White);
            rect.Draw(graphics);
        }

        /// <summary>
        /// Method to refresh the position of the cursor.
        /// Making the previous one transparent and drawing a new one.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="g"></param>
        public void UpdatePosition(int x, int y, Graphics g)
        { 
            
            Bitmap updatedCursor = new Bitmap(10, 10);
            cursor.MakeTransparent();
            cursor.SetPixel(0, 0, Color.Transparent);           
            g.DrawImageUnscaled(updatedCursor, x, y);
            Rectangle rect = new Rectangle(x, y, 5, 5);
            rect.SetColour(Color.White);
            rect.Draw(g);                     

            X = x;
            Y = y;
            location = new Point(X, Y);            
        }
    }
}
