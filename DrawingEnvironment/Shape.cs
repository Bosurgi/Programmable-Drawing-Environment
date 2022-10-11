using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    /// <summary>
    /// This is an abstract class which represents a shape.
    /// It will be used for subsequent classes to implement various types of shape.
    /// </summary>
    abstract class Shape
    {
        // Position of the shape
        protected int x { get; set; }
        protected int y { get; set; }

        // Color of the shape
        protected Color colour;

        public abstract void Draw(Graphics graphics);

        /// <summary>
        /// Constructor of the Class Shape.
        /// </summary>
        /// <param name="x">It's starting position on X axis</param>
        /// <param name="y">It's starting position on Y axis</param>
        /// <param name="colour">The color of the shape</param>
        public Shape(int x, int y, Color colour)
        {
            this.x = x;
            this.y = y;
            this.colour = colour;
        }
    }
}
