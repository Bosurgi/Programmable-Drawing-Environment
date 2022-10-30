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
    abstract class Shape : IShape
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
        internal int X { get; set; }
        internal int Y { get; set; }

        internal bool isFill;

        // Color of the shape
        internal Color colour;

        // Pen to draw the shape
        protected Pen pen;
        
        // Brush used to fill shapes
        protected Brush brush;

        public abstract void Draw(Graphics graphics);

        /// <summary>
        /// Setter method to set the colour and the paramters of the shape.
        /// It is inherited by the Interface IShape
        /// </summary>
        /// <param name="color">the color of the shape</param>
        /// <param name="parametersList">List of parameters with index 0 as X and index 1 as Y</param>
        public virtual void Set (Color color, params int[] parametersList)
        {
            pen = new Pen(color);
            brush = new SolidBrush(color);
            colour = color;
            this.X = parametersList[0];
            this.Y = parametersList[1];            
        }

        /// <summary>
        /// Virtual method to set just the colour of the shape.
        /// </summary>
        /// <param name="color">the color of the shape to be set</param>
        public virtual void SetColour(Color color)
        {
            colour = color;
            brush = new SolidBrush(color);
            pen = new Pen(color);
        }

        /// <summary>
        /// Constructor of the Class Shape.
        /// </summary>
        /// <param name="x">It's starting position on X axis</param>
        /// <param name="y">It's starting position on Y axis</param>
        /// <param name="colour">The color of the shape</param>
        public Shape(Color colour, int x, int y)
        {
            this.colour = colour;
            pen = new Pen(colour);
            brush = new SolidBrush(colour);
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Constructor to make a shape with just its position
        /// </summary>
        /// <param name="x"> the position in the x axis</param>
        /// <param name="y"> the position in the y axis</param>
        public Shape(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        /// <summary>
        /// Empty constructor to create a new shape with no values
        /// </summary>
        public Shape()
        {
            
        }

    }

}
