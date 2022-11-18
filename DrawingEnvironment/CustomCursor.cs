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
    /// <summary>
    /// Class representing a custom cursor to display on the canvas.
    /// It represent the position where the actual cursor is from where the images will be drawn.
    /// </summary>
    internal class CustomCursor : Shape
    {
        Point location = new Point();
        Bitmap cursor = new Bitmap(10, 10);

        /// <summary>
        /// Constructor for the Cursor which contains the position of the cursor.
        /// </summary>
        public CustomCursor()
        {           
            location = new Point(X, Y);
        }

        /// <summary>
        /// Method to draw the cursor in the canvas.
        /// </summary>
        /// <param name="graphics">the graphic elements where the method will draw</param>
        public override void Draw(Graphics graphics)
        {
            Rectangle rect = new Rectangle(X, Y, 5, 5);
            rect.SetColour(colour);
            rect.Draw(graphics);
            graphics.DrawImageUnscaled(cursor, X, Y);            
        }

        /// <summary>
        /// Method to refresh the position of the cursor.
        /// Making the previous one transparent and drawing a new one.
        /// </summary>
        /// <param name="x">new X position of the cursor</param>
        /// <param name="y">new Y position of the cursor</param>
        /// <param name="g">the graphic element where to draw the cursor</param>
        public void UpdatePosition(int x, int y, Graphics g)
        {             
            Bitmap updatedCursor = new Bitmap(10, 10);
            Rectangle rect = new Rectangle(x, y, 5, 5);
            cursor.MakeTransparent();
            rect.SetColour(colour);
            rect.Draw(g);
            g.DrawImageUnscaled(updatedCursor, x, y);                               
            X = x;
            Y = y;
            location = new Point(X, Y);            
        }
    }
}
