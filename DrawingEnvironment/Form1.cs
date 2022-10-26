using System;
using System.Drawing;
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

        /// <summary>
        /// Entry point for initialising the Form and it's components
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            myCanvas = new CanvasCustom(Graphics.FromImage(OutputBitmap)); // Initialise the Canvas which will handle the drawing
            pointer.Draw(Graphics.FromImage(OutputBitmap));
            PositionLabel.Text = "X: " + pointer.X.ToString() + " - Y: " + pointer.Y.ToString();
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
            errorLabel.Text = ""; // Resetting the error label
            string cmd = userInput.Text; // The user input
            string[] userCommand = parser.ValidateCommand(cmd); // The array with the commands typed by the user
            Graphics areaGraphics = drawingArea.CreateGraphics(); // The area where to draw                             
            areaGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            Pen pen = new Pen(Color.White); // The pen

            // Initialising the service which will manage all the input and execution of commands
            ServiceExecute ex = new ServiceExecute(areaGraphics, pen, parser, cmd, userCommand, pointer, errorLabel, PositionLabel);
            ex.executeService(cmd); // Executing the service
            userInput.Text = ""; // Resetting the user input text field to empty text
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void drawingArea_Paint(object sender, PaintEventArgs e)
        {
            // Bitmap for cursor - Testing it out
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, pointer.X, pointer.Y);
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

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void syntaxCheckButton_Click(object sender, EventArgs e)
        {
        }
    }
}
