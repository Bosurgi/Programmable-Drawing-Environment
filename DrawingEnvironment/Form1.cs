using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Canvas size parameters set as constants.
        /// </summary>
        public const int canX = 480;
        public const int canY = 270;
        /// <summary>
        /// Initialising the parser;
        /// </summary>
        Parser parser = new Parser();
        CustomCursor pointer = new CustomCursor();
        Bitmap OutputBitmap = new Bitmap(canX, canY);

        // My canvas
        CanvasCustom myCanvas;

        /*
        // Testing new images
        Bitmap testImage = new Bitmap(50, 50);
        Shape shape;
        bool shapeDrawn = false;
        */

        /// <summary>
        /// Entry point for initialising the Form and it's components
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            myCanvas = new CanvasCustom(Graphics.FromImage(OutputBitmap)); // Initialise the Canvas which will handle the drawing
            pointer.Draw(Graphics.FromImage(OutputBitmap));

            /*
            if (shapeDrawn)
            {
                CanvasCustom imageContext = new CanvasCustom(Graphics.FromImage(testImage));
                shape.Draw(Graphics.FromImage(testImage));
            }
            */
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
                errorLabel.Text = ""; // Resetting the error label

                string cmd = userInput.Text; // The user input
                string[] userCommand = parser.ValidateCommand(cmd); // The array with the commands of the user
                Graphics areaGraphics = drawingArea.CreateGraphics(); // The area where to draw                             
                areaGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen pen = new Pen(Color.White); // The pen

                if (userInput.Text != null)
                {
                    if (userCommand[0].Equals("RECTANGLE"))
                    {
                        List<int> dimensions = new List<int>();                        
                        // TODO: refactor the code
                        // Drawing a rectangle and catching errors. Displaying the error message.
                        try
                        {
                            dimensions = parser.AssigningParameters(cmd);
                            Rectangle rect = new Rectangle(pointer.X, pointer.Y, dimensions[0], dimensions[1]);
                            rect.SetColour(pen.Color);
                            rect.Draw(areaGraphics);
                        }
                        catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                        catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Rectangle <width> <height>"; }                        

                    }
                    // Move command
                    if (userCommand[0].Equals("MOVETO"))
                    {
                        try
                        {
                            List<int> parameters = parser.AssigningParameters(cmd);
                            // assigning X and Y values to the pointer
                            pointer.UpdatePosition(parameters[0], parameters[1], areaGraphics);
                            pointer.SetColour(Color.White);
                            //Refresh();

                            //pointer.X = parameters[0];
                            //pointer.Y = parameters[1];

                            // Updating pointer position
                            XPosition.Text = "X: " + pointer.X.ToString();
                            YPositon.Text = "Y: " + pointer.Y.ToString();
                        }
                        catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                        catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Moveto <x Value> <y Value>"; }
                    
                    }
                    // Command Circle draw a circle
                    if (userCommand[0].Equals("CIRCLE"))
                    {
                        List<int> parameters = parser.AssigningParameters(cmd);
                        Circle circle = new Circle(pointer.X, pointer.Y, parameters[0]);

                        /*
                        // New code to test
                        shapeDrawn = true;
                        */

                        circle.Draw(areaGraphics);
                    }

                    // Command to draw a line from the pointer to a set point
                    // TODO: adding try catch to deal with invalid parameters.
                    if (userCommand[0].Equals("DRAWTO"))
                    {
                        List<int> parameters = parser.AssigningParameters(cmd);
                        areaGraphics.DrawLine(pen, pointer.X, pointer.Y, parameters[0], parameters[1]);
                        pointer.UpdatePosition(parameters[0], parameters[1], areaGraphics);
                    }

                    if (userCommand[0].Equals("CLEAR"))
                    {
                        // Refreshing the canvas without deleting the pointer. IMPORTANT

                        Refresh();
                    }

                }// End of if text null

            }
            else
            {
                errorLabel.Text = "Invalid command";
            }
            userInput.Text = "";

        } // End of Method

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void drawingArea_Paint(object sender, PaintEventArgs e)
        {
            // Bitmap for cursor - Testing it out
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, pointer.X, pointer.Y);
            //Refresh();

            /*
            // Testing out other graphic context
            Graphics g2 = e.Graphics;
            //g2.DrawImageUnscaled(testImage, pointer.X, pointer.Y);
            //Refresh();
            //Invalidate();
            */
        }

        private void drawingArea_Click(object sender, EventArgs e)
        {

        }

        private void userInput_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                runBtn.PerformClick();
                e.SuppressKeyPress = true; // Suppressing the noise after key pressed
            }
            else
            {
                return;
            }
        }
    }
}
