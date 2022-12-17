using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    /// <summary>
    /// Class which defines Variables - Part 2
    /// Variables will allow users to set different variables and use the stored value later
    /// </summary>
    public class Variable : Command
    {
        /// <summary>
        /// The value of the variable
        /// </summary>
        private int value { get; set; }

        /// <summary>
        /// The name of the Variable
        /// </summary>
        private string name { get; set; }

        /// <summary>
        /// Constructor for Variable
        /// </summary>
        /// <param name="name">the name of the variable</param>
        /// <param name="value">the value of the variable</param>
        public Variable(string name, int value)
        {
            this.name = name;
            this.value = value;
        }

        /// <summary>
        /// Empty constructor for a Variable
        /// </summary>
        public Variable()
        {

        }
    }
}
