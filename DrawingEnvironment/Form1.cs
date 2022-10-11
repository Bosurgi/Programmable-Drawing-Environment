using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            // Storing the input from the first TextBox
            // Testing commands
            //TODO: Implementing a method which will parse the strings as commands that the user can use.
            
            // ExecuteCommand();
            
            /*string UserInput = userInput.Text;
            label1.Text = UserInput;*/
            
        }

        private void userInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Store the command into a container to check it
                string UserInput = userInput.Text;
                parser.spaceParser(UserInput);
                // checkCommand(ListOfCommand);
                // executeCommand(command);
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
            Graphics g = e.Graphics;
            Cursor cursor = new Cursor(2, 2, Color.White);
            cursor.Draw(g);
            cursor.moveTo(80, 90, g);

        }

        private void drawingArea_Click(object sender, EventArgs e)
        {

        }
    }
}
