using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    /// <summary>
    /// Custom Canvas to draw shapes and other graphical objects on it.
    /// </summary>
    public class CanvasCustom
    {
        Graphics g;
        Pen pen;
        int X { get; set; } = 0;
        int Y { get; set; } = 0;

        /// <summary>
        /// Constructor for the Canvas class, where the drawings will be drawn.
        /// </summary>
        /// <param Name="g">the graphical object that will be drawn</param>
        public CanvasCustom(Graphics g)
        {
            this.g = g;
            pen = new Pen(Color.White);
        }

        /// <summary>
        /// Getter method for the graphics context
        /// </summary>
        /// <returns>the graphic context to draw</returns>
        public Graphics GetGraphics()
        {
            return g;
        }
    }
}
