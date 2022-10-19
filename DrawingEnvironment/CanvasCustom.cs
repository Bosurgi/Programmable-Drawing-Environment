using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    public class CanvasCustom
    {
        Graphics g;
        Pen pen;
        int X { get; set; } = 0;
        int Y { get; set; } = 0;

        /// <summary>
        /// Constructor for the Canvas class, where the drawings will be drawn.
        /// </summary>
        /// <param name="g">the graphical object that will be drawn</param>
        public CanvasCustom(Graphics g)
        {
            this.g = g;
            pen = new Pen(Color.White);
        }


    }
}
