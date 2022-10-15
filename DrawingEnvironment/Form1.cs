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
            Parser parser = new Parser();
            if(parser.CheckCommand(userInput.Text))
            {
                string cmd = userInput.Text;
                string[] userCommand = parser.ValidateCommand(cmd);
                Graphics areaGraphics = drawingArea.CreateGraphics();
                areaGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen pen = new Pen(Color.White);
                
                if (userInput.Text != null)
                {
                    if (userCommand[0].Equals("RECTANGLE"))
                    {
                        // TODO: throwing error if parameters not correct
                        List<int> dimensions = parser.ValidateParameters(cmd);
                        Rectangle rect = new Rectangle(pointer.X, pointer.Y, dimensions[0], dimensions[1]);
                        rect.Draw(areaGraphics, pen);
                    }
                    switch (cmd.ToUpper())
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
                        */
                        case "CIRCLE":
                            Circle circle = new Circle(pointer.X, pointer.Y, 50);
                            circle.Draw(areaGraphics, pen);
                            break;
                    } // End of switch
                }// End of if text null

            }
                
        } // End of Method

        private void userInput_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void drawingArea_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void drawingArea_Click(object sender, EventArgs e)
        {

        }

        private void userInput_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Parser parser = new Parser();
                if (parser.CheckCommand(userInput.Text))
                {
                    string cmd = userInput.Text;
                    string[] userCommand = parser.ValidateCommand(cmd);
                    Graphics areaGraphics = drawingArea.CreateGraphics();
                    areaGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Pen pen = new Pen(Color.White);

                    if (userInput.Text != null)
                    {
                        if (userCommand[0].Equals("RECTANGLE"))
                        {
                            // TODO: throwing error if parameters not correct
                            List<int> dimensions = parser.ValidateParameters(cmd);
                            Rectangle rect = new Rectangle(pointer.X, pointer.Y, dimensions[0], dimensions[1]);
                            rect.Draw(areaGraphics, pen);
                        }
                        switch (cmd.ToUpper())
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
                            */
                            case "CIRCLE":
                                Circle circle = new Circle(pointer.X, pointer.Y, 50);
                                circle.Draw(areaGraphics, pen);
                                break;
                        } // End of switch
                    }// End of if text null
                }
                else
                {
                    return;
                }
            }
        }
    }
}
