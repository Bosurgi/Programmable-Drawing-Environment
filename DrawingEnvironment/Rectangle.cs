using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    internal class Rectangle : Shape
    {
        // Rectangle properties
        private int width { get; set; }
        private int height { get; set; }

        public Rectangle(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            width = w;
            height = h;
        }
        /// <summary>
        /// Draw method to draw a rectangle on the canvas.
        /// </summary>
        /// <param name="graphics">the canvas where to draw</param>
        /// <param name="pen">the pen used to draw</param>
        public override void Draw(Graphics graphics, Pen pen)
        {
            // It uses the Method to Draw a rectangle taking the position of the Shape and properties from the Rectangle class
            graphics.DrawRectangle(pen, x, y, width, height);
        }
    }
}
