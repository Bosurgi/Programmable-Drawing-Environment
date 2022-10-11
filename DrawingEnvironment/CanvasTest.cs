using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    public class CanvasTest
    {
        public CanvasTest()
        {
            PictureBox pictureBox = new PictureBox();
            Graphics g = pictureBox.CreateGraphics();
        }
    }
}
