using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    /// <summary>
    /// Windows form where the actual GUI of the Drawing Environment is.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Canvas size Parameters set as constants.
        /// </summary>
        public const int canX = 480;
        public const int canY = 270;
        /// <summary>
        /// Initialising the parser;
        /// </summary>
        Parser parser = new Parser();
        string cmd;

        CustomCursor pointer = new CustomCursor();
        Bitmap OutputBitmap = new Bitmap(canX, canY);

        // My canvas
        CanvasCustom myCanvas;
        // Pen in use and default color
        Color penColour = Color.White;
        Pen pen;
        bool isFilling = false;

        /// <summary>
        /// Entry point for initialising the Form and it's components
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            myCanvas = new CanvasCustom(Graphics.FromImage(OutputBitmap)); // Initialise the Canvas which will handle the drawing
            pointer.SetColour(penColour);
            pointer.Draw(Graphics.FromImage(OutputBitmap));
            PositionLabel.Text = "X: " + pointer.X.ToString() + " - Y: " + pointer.Y.ToString();
            LabelFill.Text = "Fill: " + isFilling.ToString();
            pen = new Pen(penColour, 1);            
        }

        /// <summary>
        /// Clicking the help button will display all the available commands to the user.
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void helpButton_Click(object sender, EventArgs e)
        {
            string BoxTitle = "Available Commands";
            string HelpCommands = "MoveTo <X>,<Y> - Moving the cursor from actual position to X and Y\n" +
                "\nClear - it clears the canvas\n" +
                "\nReset - it clears and reset the cursor to original position 0 , 0\n" +
                "\nFill <ON> or <OFF> - Toggles the Filling on or off function\n" +
                "\nRun - it runs the commands on the programming area\n" +
                "\nDrawTo <X>,<Y> - It draws a line with the current colour from present position to X,Y\n" +
                "\nRectangle <Width>,<Height> - Draws a rectangle at the current position with Width W and height H\n" +
                "\nCircle <Radius> - It draws a Circle with specified radius\n" +
                "\nTriangle <Length> - It draws a Triangle with specified length\n" +
                "\nWhite - Changes colour to white\n" +
                "\nRed - Changes colour to red\n" +
                "\nGreen - Changes colour to green\n" +
                "\nBlue - Changes colour to blue";

            MessageBox.Show(HelpCommands, BoxTitle); // Showing the Box with the commands
        }

        /// <summary>
        /// Method which manages the Run button each time is clicked
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void runButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = ""; // Resetting the error label
            //string cmd = userInput.Text; // The user input
            //string multiCmd = programmingArea.Text; // The user input in Multiline
            
            if (!programmingArea.Text.Equals(""))
            {
                cmd = programmingArea.Text;
            }
            else 
            { 
                cmd = userInput.Text;
            }
            Graphics areaGraphics = drawingArea.CreateGraphics(); // The area where to draw                             
            areaGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;         

            // Initialising the service which will manage all the input and execution of commands
            ServiceExecute ex = new ServiceExecute(areaGraphics, pen, pointer, errorLabel, PositionLabel, isFilling, programmingArea);
            ex.ExecuteService(cmd); // Executing the service
            isFilling = ex.GetFill(); // Updating form filling flag
            userInput.Text = ""; // Resetting the user input text field to empty text
            BoxCurrentColor.BackColor = pointer.colour; // Updating the color of the current colour picture box
            LabelFill.Text = "Fill: " + isFilling.ToString();
        }

        /// <summary>
        /// Paint Method
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void drawingArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            pointer.SetColour(penColour);
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
            Graphics areaGraphics = drawingArea.CreateGraphics();
            areaGraphics.Clear(Color.Black);
            pointer.Draw(areaGraphics);
            errorLabel.Text = "";
        }

        private void syntaxCheckButton_Click(object sender, EventArgs e)
        {
            // TODO: Implement syntax check for PART 2
        }

        private void ToolsRedItem_Click(object sender, EventArgs e)
        {
            pointer.SetColour(Color.Red); // Pointer colour to red
            pen.Color = Color.Red;         // Pen colour to red
            BoxCurrentColor.BackColor = Color.Red; // Updating the current colour box                      
        }

        private void ToolsGreenItem_Click(object sender, EventArgs e)
        {
            pointer.SetColour(Color.Green); // Pointer colour to Green
            pen.Color = Color.Green;         // Pen colour to Green
            BoxCurrentColor.BackColor = Color.Green; // Updating the current colour box   
        }

        private void ToolsBlueItem_Click(object sender, EventArgs e)
        {
            pointer.SetColour(Color.Blue); // Pointer colour to Blue
            pen.Color = Color.Blue;         // Pen colour to Blue
            BoxCurrentColor.BackColor = Color.Blue; // Updating the current colour box   
        }

        private void ToolsWhiteItem_Click(object sender, EventArgs e)
        {
            pointer.SetColour(Color.White); // Pointer colour to white
            pen.Color = Color.White;         // Pen colour to white
            BoxCurrentColor.BackColor = Color.White; // Updating the current colour box   
        }
        /// <summary>
        /// Handler for the button to draw a default circle on canvas.
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void ToolsCircleItem_Click(object sender, EventArgs e)
        {
            Graphics areaGraphics = drawingArea.CreateGraphics();
            Shape circle = new Circle(penColour, pointer.X, pointer.Y, 50);
            circle.SetColour(pen.Color);
            circle.Draw(areaGraphics);
        }
        
        private void ToolsTriangleItem_Click(object sender, EventArgs e)
        {
            Graphics areaGraphics = drawingArea.CreateGraphics();
            Shape tri = new Triangle(50, pointer.X, pointer.Y);
            tri.SetColour(pen.Color);
            tri.Draw(areaGraphics);
        }

        private void ToolsSquareItem_Click(object sender, EventArgs e)
        {
            Graphics areaGraphics = drawingArea.CreateGraphics();
            Shape square = new Rectangle(pointer.X, pointer.Y, 50, 50);
            square.SetColour(pen.Color);
            square.Draw(areaGraphics);
        }

        private void ToolsRectangleItem_Click(object sender, EventArgs e)
        {
            Graphics areaGraphics = drawingArea.CreateGraphics();
            Shape rect = new Rectangle(pointer.X, pointer.Y, 100, 50);
            rect.SetColour(pen.Color);
            rect.Draw(areaGraphics);
        }

        /// <summary>
        /// Save File command from Menu strip
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void saveFileStripItem_Click(object sender, EventArgs e)
        {
            // Opening the save dialog and save the file as TXT extension
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "*.txt|*.txt";
            saveDialog.RestoreDirectory = true;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveDialog.FileName, programmingArea.Text);
            }
        }

        /// <summary>
        /// Load File command from Meny strip
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void loadFileStripItem_Click(object sender, EventArgs e)
        {
            // Load dialog to load a file previously saved.
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "*.txt|*.txt";
            openDialog.RestoreDirectory = true;
            if(openDialog.ShowDialog() == DialogResult.OK)
            {                
                programmingArea.Text = File.ReadAllText(openDialog.FileName);
            }
        }
    }
}
