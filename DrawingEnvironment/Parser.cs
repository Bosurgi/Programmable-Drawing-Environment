using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DrawingEnvironment
{
    public class Parser
    {
        List<string> commands = new List<string>();

        /// <summary>
        /// This method takes a string and separates the elements by spacing.
        /// </summary>
        /// <param name="command"> it is the string to split by spacing</param>
        public List<string> spaceParser(string command)
        {
            List<string> commands = new List<string>();
            string[] commandArray = command.ToUpper().Split(' ');
            foreach (var word in commandArray)
            {
                commands.Add(word);
            }
            return commands;
        }

        /// <summary>
        /// Methods which checks if the commands is valid among the options available
        /// </summary>
        /// <param name="userInput">the input inserted by the user</param>
        /// <returns>true if the command is present, and false if is not</returns>
        public bool CheckCommand(string userInput)
        {
            var cmd = userInput.ToUpper().Split(' ');
            var commands = Enum.GetNames(typeof(Command.Commands));
            var shapes = Enum.GetNames(typeof(Shape.Shapes));
            try
            {
                if (cmd.Length > 3 || !commands.Contains(cmd[0]) && !shapes.Contains(cmd[0]))
                {
                    throw new ArgumentException("Invalid command");

                }
                else { return true; }
            }

            catch (ArgumentException)
            {
                // MessageBox.Show("Invalid command");
                return false;
            }
        }

        /// <summary>
        /// Method which validates eventual numerical parameters provided from the user
        /// </summary>
        /// <param name="userInput">the input the users inserts in the command line</param>
        /// <returns>A list of integers which represents the parameters provided</returns>
        public List<int> ValidateParameters(string userInput)
        {
            List<int> parameterList = new List<int>();
            string[] commandArray = userInput.ToUpper().Split(' ');
                        
            try
            {
                for (int i = 1; i < commandArray.Length; i++)
                {
                    // If it can be converted to int from string it will add it to the list
                    int parameter = Convert.ToInt32(commandArray[i]);
                    parameterList.Add(parameter);
                }
                // returns the list of parameters in int
                return parameterList;
            }
            // Catching the error if can't be converted
            catch (FormatException)
            {
                return parameterList = new List<int>();
                // Messagebox
            }            
        } // End of method

        /// <summary>
        /// Method that returns the first element of the passed array, which will determine,
        /// which command the user is trying to invoke.
        /// </summary>
        /// <param name="userInput">the user input</param>
        /// <returns>returns a list of strings with the command the user wants to execute</returns>
        public string[] ValidateCommand(string userInput)
        {
            List<string> command = new List<string>();
            var cmd = userInput.ToUpper().Split(' ');
            command.Add(cmd[0]);

            return command.ToArray();
        }
        // Constructor

        public Parser()
        {
            List<string> commands = this.commands;
        }

    }
}
