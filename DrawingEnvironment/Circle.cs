using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    internal class Circle : Shape
    {
        /// <summary>
        /// Radius property of the circle
        /// </summary>
        private float radius { get; set; }

        /// <summary>
        /// Drawing method to display a circle in a canvas
        /// </summary>
        /// <param name="graphics">the graphic object where to draw</param>
        /// <param name="pen">the pen to draw the circle</param>
        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawEllipse(pen, X - radius, Y - radius, 2 * radius, 2 * radius);
        }

        /// <summary>
        /// Circle shape constructor
        /// </summary>
        /// <param name="radius">the radius of the circle</param>
        /// <param name="x">the x position of the circle</param>
        /// <param name="y">the y position of the circle</param>
        public Circle(int x, int y, float radius)
        {
            x = X;
            x = Y;
            this.radius = radius;
        }

    }
}
