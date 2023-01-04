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
        /// It sets the values for the variables in order of index
        /// </summary>
        /// <param name="parametersValue">the values of the variables</param>
        public void SetParametersValues(int[] parametersValue)
        {
            for (int i = 0; i < MethodBody.Count; i++)
            {
                // Updating the Variable dictionary with the declared value in the method
                AssignValues(parametersValue);
                List<int> values = new List<int>();
                // Assigning the value to the right variable based on its name
                foreach (var parameter in MethodBody[i].stringParameters)
                {
                    // If the variable is present it will then assign the right value to the right key
                    if (Variables.ContainsKey(parameter))
                    {                        
                        if (MethodBody[i].stringParameters.Length == 1)
                        {
                            values.Add(Variables[parameter]);
                            //int[] varValue = { Variables[parameter] };
                            MethodBody[i].Parameters = values.ToArray();
                        }

                        else if (MethodBody[i].stringParameters.Length >= 2)
                        {                            
                            foreach (var variable in Variables)
                            {
                                if (variable.Key.Equals(parameter))
                                {
                                    values.Add(Variables[parameter]);
                                }                                
                                //int[] varValue = { Variables[variable.Key] };                                
                            }
                            // Updating the command parameters in the method block
                            MethodBody[i].Parameters = values.ToArray();
                        }
                    }

                    else { throw new ArgumentException("Value not correct"); }
                }
            }

        } // End Method

        /// <summary>
        /// It assign the appropriate values based on the name to the dictionary of variables
        /// </summary>
        /// <param name="parameterValues">the values parsed as integers</param>
        public void AssignValues(int[] parameterValues)
        {
            for (int i = 0; i < MethodBody.Count; i++)
            {
                // Adding the value preserving the order of declaration
                string varName = Variables.ElementAt(i).Key;
                Variables[varName] = parameterValues[i];
            }
        }

        /// <summary>
        /// Overridden method for toString which displays the name of the method
        /// </summary>
        /// <returns>the name of the method</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Method constructor taking the name and the Parameters
        /// </summary>
        /// <param name="name">name of the method delcared</param>
        /// <param name="Parameters">parameters declared in the method</param>
        public Method(string name, string Parameters) : base(name)
        {
            this.Name = name;
            this.Parameters = Parameters;

            SetParameters(Parameters);
        }
        /// <summary>
        /// Empty Constructor for the Method class
        /// </summary>
        public Method()
        {

        }
    }
}
