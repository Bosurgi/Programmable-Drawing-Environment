using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    /// <summary>
    /// This class represents a Rectangle which inherits from Shape class.
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// Rectangle properties, width and Height which defines the Rectangle shape
        /// </summary>
        private int Width { get; set; }
        private int Height { get; set; }

        /// <summary>
        /// Constructor for Rectangle taking four Parameters
        /// </summary>
        /// <param name="x">Position X of the rectangle</param>
        /// <param name="y">Position Y of the rectangle</param>
        /// <param name="w">width of the rectangle which defines its dimension</param>
        /// <param name="h">height of the rectangle which defines its dimension</param>
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
        public override void Draw(Graphics graphics)
        {            
            if (!isFill)
            {
                pen = new Pen(colour);
                // It uses the Method to Draw a rectangle taking the position of the Shape and properties from the Rectangle class
                graphics.DrawRectangle(pen, X, Y, Width, Height);
                pen.Dispose();
            }
            else 
            {
                brush = new SolidBrush(colour);
                graphics.FillRectangle(brush, X, Y, Width, Height);               
                brush.Dispose();
            }           
        }

        /// <summary>
        /// Method which sets the colors and Parameters of the Rectangle
        /// </summary>
        /// <param name="color">the color of the rectangle</param>
        /// <param name="parametersList">Parameters passed for the rectangle</param>
        public override void Set(Color color, params int[] parametersList)
        {
            base.Set(color, parametersList[0], parametersList[1]);
            this.Width = parametersList[2];
            this.Height = parametersList[3];
        }
    }
}
