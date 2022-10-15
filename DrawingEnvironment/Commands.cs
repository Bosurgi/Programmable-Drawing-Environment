using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    public abstract class Command : ICommand
    {
        /// <summary>
        /// Command class properties, names and parameters.
        /// </summary>
        protected string name { get; set; }
        protected string[] parameters { get; set; }

        public abstract bool Execute();

        /// <summary>
        /// Enumerator for commands available
        /// </summary>
        public enum Commands
        {
            MOVETO, // 1
            CLEAR,  // 2
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
        public Command(string name, string[] parameters)
        {
            name = this.name;
            parameters = this.parameters;
        }

        /// <summary>
        /// Empty Constructor for command class
        /// </summary>
        public Command()
        {

        }

    }


}
