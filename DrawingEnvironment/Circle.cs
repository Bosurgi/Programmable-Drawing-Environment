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
    /// <summary>
    /// Class representing a circle, inherited from the Shape class.
    /// </summary>
    internal class Circle : Shape
    {
        /// <summary>
        /// Radius property of the circle
        /// </summary>
        private float Radius { get; set; }

        /// <summary>
        /// Drawing method to display a circle in a canvas if fill on it will fill the area if not just drawing the shape empty.
        /// </summary>
        /// <param Name="graphics">the graphic object where to draw</param>
        /// <param Name="pen">the pen to draw the circle</param>
        public override void Draw(Graphics graphics)
        {
            if (!isFill)
            {
                pen = new Pen(this.colour);
                graphics.DrawEllipse(pen, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
                pen.Dispose();
            }
            else
            {
                brush = new SolidBrush(colour);               
                graphics.FillEllipse(brush, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);               
                brush.Dispose();
            }
        }
        /// <summary>
        /// Set method for the circle, it sets the color and coordinates of the specified circle shape.
        /// </summary>
        /// <param Name="colour">the color of the circle</param>
        /// <param Name="parameterList">the list of Parameters the circle takes.
        /// 0 - X , 1 - Y, 2 - Radius</param>
        public override void Set(Color colour, params int[] parameterList)
        {
            base.Set(colour, parameterList[0], parameterList[1]);
            this.Radius = parameterList[2];
        }

        /// <summary>
        /// Circle shape constructor
        /// </summary>
        /// <param Name="radius">the radius of the circle</param>
        /// <param Name="x">the x position of the circle</param>
        /// <param Name="y">the y position of the circle</param>
        public Circle(Color colour, int x, int y, float radius) : base(colour, x, y)
        {
            this.Radius = radius;
        }
        
        /// <summary>
        /// Constructor for the Circle with just position and radius.
        /// </summary>
        /// <param Name="x">X position</param>
        /// <param Name="y">y position</param>
        /// <param Name="radius">the radius of the circle</param>
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
    }
}
