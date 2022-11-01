using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DrawingEnvironment
{
    public class Parser
    {
        // TODO: create attributes. Adding command and parameters in the attributes and using them to parse directly inside the methods.
        /// <summary>
        /// The command and parameters
        /// </summary>
        protected string command;
        protected int[] parameters;
        
        /// <summary>
        /// This method takes a string and separates the elements by spacing.
        /// </summary>
        /// <param name="command"> it is the string to split by spacing</param>
        public List<string> SpaceParser(string command)
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
            var cmd = userInput.ToUpper().Trim().Split(' ');
            var commands = Enum.GetNames(typeof(Command.Commands));
            var shapes = Enum.GetNames(typeof(Shape.Shapes));
            var availableColours = Enum.GetNames(typeof(Colors.ColorTypes));
            try
            {
                if (cmd.Length > 3 || !commands.Contains(cmd[0]) && !shapes.Contains(cmd[0]) && !availableColours.Contains(cmd[0]))
                {
                    throw new ArgumentException("Invalid command");

                }
                else { return true; }
            }

            catch (ArgumentException)
            {               
                return false;
            }
        }

        /// <summary>
        /// Method which checks if a parameter could be converted into a number to avoid errors.
        /// </summary>
        /// <param name="parameter">the parameter in string we are trying to convert.</param>
        /// <returns></returns>
        public bool CheckNumbers(string parameter)
        {
            int number;
            bool success = Int32.TryParse(parameter, out number);

            if (!success)
            {
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Method which validates eventual numerical parameters provided from the user
        /// </summary>
        /// <param name="userInput">the input the users inserts in the command line</param>
        /// <returns>A list of integers which represents the parameters provided</returns>
        public List<int> AssigningParameters(string userInput)
        {
            List<int> parameterList = new List<int>();
            string[] commandArray = userInput.ToUpper().Trim().Split(' ');

            foreach (var element in commandArray.Skip(1))
            {
                if (!CheckNumbers(element))
                {
                    throw new FormatException();
                }
                else
                {
                    int parameter = Convert.ToInt32(element);
                    parameterList.Add(parameter);
                }            
            }
            return parameterList;

        } // End of method


        /// <summary>
        /// Method that returns a list of elements in the command line dividing the string by the space.
        /// This will be used to determine the commands and the parameters.
        /// </summary>
        /// <param name="userInput">the user input</param>
        /// <returns>returns a list of strings with the command and parameters the user wants to execute</returns>
        public string[] ParseCommand(string userInput)
        {
            List<string> command = new List<string>();
            var cmd = userInput.ToUpper().Trim().Split(' ');

            foreach(var element in cmd)
            {
                command.Add(element);
            }

            return command.ToArray();
        }
        
        /// <summary>
        /// Method that parses multiple lines of commands and it will determine the list of commands to run.
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public string[] ParseCommandLines(string userInput)
        {
            List<string> commands = new List<string>();

            // TODO: It will not work as it will have another special character \r to check with TextBox.Lines method.
            var cmd = userInput.ToUpper().Trim().Split('\n');
            // TODO : Sorting the logic out
            foreach(var element in cmd)
            {
                commands.Add(element);
            }
            return commands.ToArray();
        }

        // Constructor

        public Parser()
        {            
        }

    }
}
