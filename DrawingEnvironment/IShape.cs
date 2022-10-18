using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    /// <summary>
    /// This represent a generic interface for a Shape.
    /// This will be used as a base for different other shapes.
    /// </summary>
    interface IShape
    {
        /// <summary>
        /// Set method to set the Color and the parameters of the shape.
        /// </summary>
        /// <param name="color">the color of the shape</param>
        /// <param name="parametersList">the list of parameters such as X, Y and possibility to add more</param>
        void Set (Color color, params int[] parametersList);
        
        /// <summary>
        /// Draw method to draw the shape in a graphics environment.
        /// </summary>
        /// <param name="g">the graphics environment GDI+</param>
        void Draw(Graphics g);

    }
}
