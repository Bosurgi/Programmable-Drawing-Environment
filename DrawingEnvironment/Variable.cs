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
        /// Constructor for variables which assigns name and values
        /// </summary>
        /// <param name="name">the name of the variable</param>
        /// <param name="parameters">the value of the variable</param>
        public Variable(string name, int[] parameters) : base(name, parameters)
        {
            this.Name = name;
            this.Parameters = parameters;
        }

        /// <summary>
        /// Empty constructor for a Variable
        /// </summary>
        public Variable()
        {
        }
    }
}
