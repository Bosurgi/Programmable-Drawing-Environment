using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    /// <summary>
    /// This a class which defines a Canvas to where users can draw shapes and line.
    /// It will be used as the actual drawing environment to picture the shapes.
    /// Also, it will be integrated through Managed Code in the Drag and drop section in the Toolbox.
    /// </summary>
    public partial class Canvas : UserControl
    {
        /// <summary>
        /// Constructor which initialise the Canvas.
        /// </summary>
        public Canvas()
        {
            InitializeComponent();
            // Method called to prevent flickering and general optimization of the canvas.
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            // Enabling support to transparency colour.
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            // Enabling the user to use the Paint commands.
            SetStyle(ControlStyles.UserPaint, true);
        }

        private void Canvas_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Method which allows to paint in the canvas.
        /// This allows to pass commands to draw on the blank canvas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {

            // Command to the canvas will be passed here.
            Graphics g = e.Graphics;
            Color black = Color.Black;
            Pen pen = new Pen(black, 3);

        }

        public void canvasPaint(PaintEventArgs e, int x, int y)
        {
            Graphics g = e.Graphics;
            Color black = Color.Black;
            Pen pen = new Pen(black, 3);
            Point initialPoint = new Point(0, 0);
            Point destination = new Point(x, y);
            g.DrawLine(pen, initialPoint, destination);
        }
    }
}
