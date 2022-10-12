using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
        /// <summary>
        /// Enumerating different types of shapes to be used as command.
        /// </summary>
       public enum Shapes
        {
            RECTANGLE, // 0
            ELLIPSE,   // 1
            CIRCLE,    // 2
            TRIANGLE,  // 3
            LINE       // 4
        }
        // Position of the shape
        protected int x { get; set; }
        protected int y { get; set; }

        // Color of the shape
        protected Color colour;

        public abstract void Draw(Graphics graphics, Pen pen);


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

        /// <summary>
        /// Constructor to make a shape with just its position
        /// </summary>
        /// <param name="x"> the position in the x axis</param>
        /// <param name="y"> the position in the y axis</param>
        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        /// <summary>
        /// Empty constructor to create a new shape with no values
        /// </summary>
        public Shape()
        {

        }

    }

}
