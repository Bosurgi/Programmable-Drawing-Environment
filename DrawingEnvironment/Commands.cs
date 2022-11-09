using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    public class Command
    {
        /// <summary>
        /// Command class properties, names and parameters.
        /// </summary>
        internal string name { get; set; }
        internal int[] parameters { get; set; }

        /// <summary>
        /// Enumerator for commands available
        /// All the commands to be implemented need to be inserted here first.
        /// The parser will check if the command is among these before executing.
        /// </summary>
        public enum Commands
        {
            MOVETO, // 1
            CLEAR,  // 2
            DRAWTO, // 3
            RESET,  // 4           
            FILL,   // 5
            RUN,    // 6
        }

        public override string ToString()
        {
            return name;
        }

        /// <summary>
        /// Constructor for the Command class
        /// </summary>
        /// <param name="name">the name of the command</param>
        /// <param name="parameters">the parameters passed for the command</param>
        public Command(string name, int[] parameters)
        {
            this.name = name;
            this.parameters = parameters;
        }

        /// <summary>
        /// Empty Constructor for command class.
        /// </summary>
        public Command()
        {

        }

    }


}
