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
        /// Entry point for initialising the Form and it's components
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initialising the parser;
        /// </summary>
        Parser parser = new Parser();

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
            if(parser.validateCommand(userInput.Text))
            {
                string cmd = userInput.Text;
                Graphics areaGraphics = drawingArea.CreateGraphics();
                areaGraphics.Clear(Color.Black);
                areaGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen pen = new Pen(Color.White);
                if (userInput.Text != null)
                {
                    switch (cmd.ToUpper())
                    {
                        case "RECTANGLE":
                            Rectangle rect = new Rectangle(10, 10, 50, 100);
                            rect.Draw(areaGraphics, pen);
                            break;
                    }
                }

            }
                
        }
        
        private void userInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*
                // Store the command into a container to check it
                string UserInput = userInput.Text;
                List<string> parsedCommands = parser.spaceParser(UserInput);
                CommandsDraw commandsDraw = new CommandsDraw();

                commandsDraw.CheckValidCommand(parsedCommands[0]);
                commandsDraw.executeDrawing(drawingArea);
                
                */
            }    
        } 

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void userInput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void drawingArea_Paint(object sender, PaintEventArgs e)
        {

        }

        private void drawingArea_Click(object sender, EventArgs e)
        {
            
        }
    }
}
