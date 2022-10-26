using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    /// <summary>
    /// The triangle class is inherited from the shape class.
    /// It has a length and 4 points from where lines will be drawn.
    /// </summary>
    internal class Triangle : Shape
    {
        private int lenght { get; set; }
        private Point A { get; set; }
        private Point B { get; set; }
        private Point C { get; set; }
        private Point D { get; set; }

        Pen pen;
        
        /// <summary>
        /// It draws the triangle into a graphic context.
        /// </summary>
        /// <param name="graphics">the graphic context we want to draw into</param>
        public override void Draw(Graphics graphics)
        {
            Point[] vertices = { A, B, C, D }; // Array of points where the lines are going to be
            graphics.DrawLines(pen, vertices); // drawing the lines using the method which takes a pen and an array of points.

        }

        /// <summary>
        /// Constructor for the class Triangle.
        /// </summary>
        /// <param name="lenght">the length of the sides</param>
        /// <param name="pen">the pen used to draw</param>
        /// <param name="x">the X position of the shape on the canvas based on where the cursor is</param>
        /// <param name="y">the Y position of the shape on the canvas based on where the cursor is</param>
        public Triangle(int lenght, Pen pen, int x, int y) : base(x, y)
        {
            this.lenght = lenght;
            this.pen = pen;
            A = new Point(X, Y);
            B = new Point(X, Y + lenght);
            C = new Point(X + lenght, Y + lenght);
            D = new Point(X, Y);
        }   
    }
}
