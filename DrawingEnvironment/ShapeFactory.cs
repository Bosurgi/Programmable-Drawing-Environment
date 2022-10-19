using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{

    /// <summary>
    /// Shape factory to create shapes and manage them from one class.
    /// </summary>
    class ShapeFactory
    {
        /// <summary>
        /// Method which creates a shape based on the string passed.
        /// </summary>
        /// <param name="shape">the shape we want to create</param>
        /// <returns></returns>
        public Shape GetShape(string shape)
        {
            shape.ToUpper().Trim();
            if (shape.Equals("CIRCLE"))
            {
                return new Circle();
            }

            else if (shape.Equals("RECTANGLE"))
            {
                return new Rectangle();
            }

            // If the shape doesn't exist throwing an error.
            else
            {
                System.ArgumentException shapeException = new ArgumentException(shape + " is not a valid type of Shape.");
                throw shapeException;
            }
        }
    }
}
