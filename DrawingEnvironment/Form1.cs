using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DrawingEnvironment
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// Initialising the parser;
        /// </summary>
        Parser parser = new Parser();

        CustomCursor pointer = new CustomCursor();

        /// <summary>
        /// Entry point for initialising the Form and it's components
        /// </summary>
        public Form1()
        {
            InitializeComponent();

        }


        private void helpButton_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void variousColorsPlaceholderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void variousShapesPlaceholderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Method which manages the Run button each time is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runButton_Click(object sender, EventArgs e)
        {


            if (parser.CheckCommand(userInput.Text))
            {
                string cmd = userInput.Text; // The user input
                string[] userCommand = parser.ValidateCommand(cmd); // The array with the commands of the user
                Graphics areaGraphics = drawingArea.CreateGraphics(); // The area where to draw
                areaGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen pen = new Pen(Color.White); // The pen

                if (userInput.Text != null)
                {
                    if (userCommand[0].Equals("RECTANGLE"))
                    {
                        // TODO: throwing error if parameters not correct
                        // TODO: refactor the code
                        List<int> dimensions = parser.ValidateParameters(cmd);
                        Rectangle rect = new Rectangle(pointer.X, pointer.Y, dimensions[0], dimensions[1]);
                        rect.Draw(areaGraphics);
                    }

                    if (userCommand[0].Equals("MOVETO"))
                    {
                        List<int> parameters = parser.ValidateParameters(cmd);
                        // assigning X and Y values to the pointer
                        pointer.X = parameters[0];
                        pointer.Y = parameters[1];

                        // Updating pointer position
                        XPosition.Text = "X: " + pointer.X.ToString();
                        YPositon.Text = "Y: " + pointer.Y.ToString();
                    }
                    if (userCommand[0].Equals("CIRCLE"))
                    {
                        List<int> parameters = parser.ValidateParameters(cmd);
                        Circle circle = new Circle(pointer.X, pointer.Y, parameters[0]);
                        circle.Draw(areaGraphics);
                    }

                    /*
                    switch (userCommand[0].ToUpper())
                    {
                        case "CLEAR":
                            areaGraphics.Clear(drawingArea.BackColor);
                            break;
                        /*
                        case userCommand[0].Equals("RECTANGLE"):
                            List<int> dimensions = parser.ValidateParameters(cmd);
                            Rectangle rect = new Rectangle(pointer.X, pointer.Y, dimensions[0], dimensions[1]);
                            rect.Draw(areaGraphics, pen);
                            break;
                        
                        case "CIRCLE":
                            List<int> radius = parser.ValidateParameters(cmd);
                            Circle circle = new Circle(pointer.X, pointer.Y, radius[0]);
                            circle.Draw(areaGraphics, pen);
                            break;
                    } // End of switch
                */
                }// End of if text null

            }

        } // End of Method

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void drawingArea_Paint(object sender, PaintEventArgs e)
        {
            // Bitmap for cursor - Testing it out
            Graphics g = e.Graphics;
            pointer.Draw(g, e);
            Invalidate();
        }

        private void drawingArea_Click(object sender, EventArgs e)
        {

        }

        private void userInput_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                runBtn.PerformClick();
            }
            else
            {
                return;
            }
        }
    }
}
