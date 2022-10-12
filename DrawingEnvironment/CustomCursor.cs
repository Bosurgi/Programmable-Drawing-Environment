using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DrawingEnvironment
{
    internal class CustomCursor : Shape
    {
        
        Pen pen = new Pen(Color.White);
        /// <summary>
        /// Constructor for the class Cursor.
        /// </summary>
        /// <param name="x">The position on the X axis where it is.</param>
        /// <param name="y">The position on the X axis where it is.</param>
        /// <param name="colour">The color of the cursor</param>
        public CustomCursor(Pen pen, int x, int y) : base(x, y)
        {
            this.pen = pen;
            var cursorBitmap = new Bitmap(x, y);
            Graphics g = Graphics.FromImage(cursorBitmap);
            g.DrawRectangle(pen, new System.Drawing.Rectangle(10, 10, cursorBitmap.Width +2 , cursorBitmap.Height + 2));

            IntPtr ptr = cursorBitmap.GetHicon();
            var c = new Cursor(ptr);
            
        }

        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine( this.pen, 10, 10, 4, 4);
        }

        public void moveTo(int x, int y, Graphics graphics)
        {

        }

    }

}
