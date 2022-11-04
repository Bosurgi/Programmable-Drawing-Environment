using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    /// <summary>
    /// This is a class which manages the commands related to drawing.
    /// This class takes two parameters. The name of the command and the parameters, and also the Canvas to draw into.
    /// </summary>
    public class CommandsDraw : Command
    {
        // Attributes
        string name;
        int[] parameters;
        bool execute = false;
        // List containing available commands
        List<string> commandList = new List<string>
        {
            "RECTANGLE",
            "CIRCLE"
        };

        // Constructor
        public CommandsDraw(string name, int[] parameters, Graphics g) : base(name, parameters)
        {
            name = this.name;
            parameters = this.parameters;
            
        }

        public CommandsDraw()
        {

        }

        /// <summary>
        /// Methods which checks if the command typed is the correct one.
        /// </summary>
        /// <param name="name">the command name</param>
        /// <returns>true if the command is valid and false if the command is not.</returns>
        /// <exception cref="NotImplementedException"></exception>
        /*public bool CheckValidCommand(string name)
        {
            if (!commandList.Contains(name))
            {
                this.execute = false;
                
            }
            else if (commandList.Contains(name)) 
            {
                return Execute(); 
            }

            else
            {
                throw new NotImplementedException();
                return false;
            }
        }
        */
        public void executeDrawing(PictureBox pb)
        {
            
            if (this.execute && this.name.Equals("RECTANGLE"))
            {
                Graphics g = pb.CreateGraphics();
                Pen pen = new Pen(Color.White);
                g.DrawRectangle(pen, 10, 10, 3, 3);
            }
        }
    }
}
