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
        private int Width { get; set; }
        private int Height { get; set; }

        /// <summary>
        /// Constructor for Rectangle taking four parameters
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public Rectangle(int x, int y, int w, int h) : base(x, y)
        {
            this.X = x;
            this.Y = y;
            Width = w;
            Height = h;
        }

        /// <summary>
        /// Empty Constructor for Rectangle used in Factory
        /// </summary>
        public Rectangle() : base()
        {

        }


        /// <summary>
        /// Draw method to draw a rectangle on the canvas.
        /// </summary>
        /// <param name="graphics">the canvas where to draw</param>
        /// <param name="pen">the pen used to draw</param>
        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.White);
            // It uses the Method to Draw a rectangle taking the position of the Shape and properties from the Rectangle class
            graphics.DrawRectangle(pen, X, Y, Width, Height);
        }

        public override void Set(Color color, params int[] parametersList)
        {
            base.Set(color, parametersList[0], parametersList[1]);
            this.Width = parametersList[2];
            this.Height = parametersList[3];
        }
    }
}
