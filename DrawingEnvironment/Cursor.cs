using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DrawingEnvironment
{
    internal class Cursor : Shape
    {
        /// <summary>
        /// Constructor for the class Cursor.
        /// </summary>
        /// <param name="x">The position on the X axis where it is.</param>
        /// <param name="y">The position on the X axis where it is.</param>
        /// <param name="colour">The color of the cursor</param>
        public Cursor(int x, int y, Color colour) : base(x, y, colour)
        {
            this.x = x;
            this.y = y;
            this.colour = colour;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.White, 2);
            SolidBrush brush = new SolidBrush(colour);
            graphics.DrawRectangle(pen, 10, 10, x + 2, y + 2);

        }

        public void moveTo(int x, int y, Graphics graphics)
        {
            this.x = x;
            this.y = y;
            // NOT WORKING graphics.TranslateClip(x, y);

        }

    }

}
