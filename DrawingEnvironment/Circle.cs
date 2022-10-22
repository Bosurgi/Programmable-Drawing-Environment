using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    internal class Circle : Shape
    {

        Bitmap circle = new Bitmap(10, 10); // New bitmap

        /// <summary>
        /// Radius property of the circle
        /// </summary>
        private float Radius { get; set; }

        /// <summary>
        /// Drawing method to display a circle in a canvas
        /// </summary>
        /// <param name="graphics">the graphic object where to draw</param>
        /// <param name="pen">the pen to draw the circle</param>
        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.White);
            graphics.DrawImageUnscaled(circle, X, Y);
            graphics.DrawEllipse(pen, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
        }

        /// <summary>
        /// Circle shape constructor
        /// </summary>
        /// <param name="radius">the radius of the circle</param>
        /// <param name="x">the x position of the circle</param>
        /// <param name="y">the y position of the circle</param>
        public Circle(Color colour, int x, int y, float radius) : base(colour, x, y)
        {
            this.Radius = radius;
        }
        
        public Circle(int x, int y, float radius) : base(x, y)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Constructor for empty Circle shape for Factory class
        /// </summary>
        public Circle() : base()
        {

        }
        
        public override void Set(Color colour, params int[] parameterList)
        {
            base.Set(colour, parameterList[0], parameterList[1]);
            this.Radius = parameterList[2];
        }
    }
}
