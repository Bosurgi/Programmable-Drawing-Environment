using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    internal class ParserUpdate
    {
        /// <summary>
        /// Command property and parameters stored to be processed.
        /// And as well a list of parsed parameters inserted if they are valid numbers.
        /// </summary>
        internal string command { get; set; }
        internal string parameters { get; set; }
        internal List<int> parsedParameters = new List<int>();

        /// <summary>
        /// Command parser which will divide the command and parameters passed and store them into the attributes.
        /// </summary>
        /// <param name="cmd">the command the user writes in the command line</param>
        /// <exception cref="FormatException">exception thrown when parameter not numerical</exception>
        public KeyValuePair<string, List<int>> ParseCommands(string cmd)
        {
            var line = cmd.ToUpper().Trim(); // Tidying and standardizing the line of command
            var splitLine = line.Split(' '); // Splitting the command and parameters [0] command and [1] param            

            // If line has arguments then dividing parameters and commands accordingly
            if (splitLine.Length > 1)
            {
                // Splitting the commands 0 command and 1 for parameters.
                command = splitLine[0];
                parameters = splitLine[1];

                var splitParam = parameters.Split(',');

                for (int i = 0; i < splitParam.Length; i++)
                {
                    if (CheckNumbers(splitParam[i]))
                    {
                        // Converting the parameters and adding them to the list
                        parsedParameters.Add(Convert.ToInt32(splitParam[i]));
                    }
                    // Handling the only command with literals parameters (ON and OFF)
                    else if (command.Equals("FILL") || parameters != null)
                    {
                        parameters = splitLine[1];
                    }

                    else { throw new FormatException("Invalid parameter parsed"); }
                }
            }
            // if only command storing just command
            else { command = splitLine[0]; }

            KeyValuePair<string, List<int>> result = new KeyValuePair<string, List<int>>(command, parsedParameters);

            return result;
        }

        /// <summary>
        /// This method parses different lines of code in sequence by dividing the commands using \n new line key.
        /// </summary>
        /// <param name="commands">the commands to parse.</param>
        public List<KeyValuePair<string, List<int>>> ParseCommandMultiLine(string commands)
        {
            
            List<KeyValuePair<string, List<int>>> KeyValueList = new List<KeyValuePair<string, List<int>>>();

            var standardCommand = commands.Trim().ToUpper();
            var splitCommands = commands.Split('\n');
            for (int i = 0; i < splitCommands.Length; i++)
            {
               KeyValueList.Add(ParseCommands(splitCommands[i]));
            }
            return KeyValueList;           
        }

        /// <summary>
        /// Method which checks if a parameter could be converted into a number to avoid errors.
        /// </summary>
        /// <param name="param">the parameter in string we are trying to convert.</param>
        /// <returns>true if successful, false if not</returns>
        public bool CheckNumbers(string param)
        {
            int number;
            bool success = Int32.TryParse(param, out number);

            if (!success)
            {
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Methods which checks if the commands is valid among the options available
        /// </summary>
        /// <param name="userInput">the input inserted by the user</param>
        /// <returns>true if the command is present, and false if is not</returns>
        public bool isValidCommand(string userInput)
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
        /// Empty constructor to initialise the parser
        /// </summary>
        public ParserUpdate()
        {
        }
    }
}
