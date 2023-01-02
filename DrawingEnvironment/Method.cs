using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingEnvironment
{
    /// <summary>
    /// It represents a Method that can be declared for later execution in the program
    /// </summary>
    internal class Method : Command
    {
        internal List<Command> MethodBody = new List<Command>();

        internal Dictionary<string, int> Variables = new Dictionary<string, int>();

        internal string MethodName;

        internal string Parameters;

        /// <summary>
        /// Setter for the Body of the Method to execute
        /// </summary>
        /// <param name="MethodBody">the method block</param>
        public void SetBody(List<Command> MethodBody)
        {
            this.MethodBody = MethodBody;
        }

        /// <summary>
        /// It sets the parameters into the Dictionary of variables with default value 0
        /// </summary>
        /// <param name="Parameters">the string with parameters</param>
        public void SetParameters(string Parameters)
        {
            string[] splitParameters = Parameters.Split(',');

            foreach (var parameter in splitParameters)
            {
                Variables.Add(parameter.Trim(), 0);
            }
        }

        /// <summary>
        /// It sets the value on method execution with the values declared
        /// </summary>
        /// <param name="parametersValue">the values declared in the method execution</param>
        public void SetParametersValues(int[] parametersValue)
        {

            foreach (var command in MethodBody)
            {
                for(int i = 0; i < command.stringParameters.Length; i++)
                {
                    if (Variables.ContainsKey(command.stringParameters[i]))
                    {
                        Variables[command.stringParameters[i]] = parametersValue[i];
                    }
                    else { throw new FormatException("Variable not present"); }
                }
            }
        }

        /// <summary>
        /// Method constructor taking the name and the Parameters
        /// </summary>
        /// <param name="name">name of the method delcared</param>
        /// <param name="Parameters">parameters declared in the method</param>
        public Method(string name, string Parameters)
        {
            this.MethodName = name;
            this.Parameters = Parameters;
        }
        /// <summary>
        /// Empty Constructor for the Method class
        /// </summary>
        public Method()
        {

        }
    }
}
