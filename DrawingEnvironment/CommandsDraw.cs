using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    /// <summary>
    /// This is a class which manages the commands related to drawing.
    /// This class takes two parameters. The name of the command and the parameters, and also the Canvas to draw into.
    /// </summary>
    public class CommandsDraw : Commands
    {
        // Attributes
        string name, parameters;
        bool execute = false;
        // List containing available commands
        List<string> commandList = new List<string>
        {
            "PENDOWN",
            "DRAW"
        };

        // Constructor
        public CommandsDraw(string name, string parameters, Canvas canvas) : base(name, parameters)
        {
            name = this.name;
            parameters = this.parameters;
            
        }

        public override bool Execute()
        {
            return this.execute = true;
        }

        /// <summary>
        /// Methods which checks if the command typed is the correct one.
        /// </summary>
        /// <param name="name">the command name</param>
        /// <returns>true if the command is valid and false if the command is not.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool checkValidCommand(string name)
        {
            if (!commandList.Contains(name))
            {
                this.execute = false;
                throw new NotImplementedException();
            }
            else { return true; }
        }

        public void executeDrawing(Canvas canvas, PaintEventArgs e)
        {
            if (this.execute && this.name.Equals("DRAW"))
            {
                canvas.canvasPaint(e, 3, 10);
            }
        }
    }
}
