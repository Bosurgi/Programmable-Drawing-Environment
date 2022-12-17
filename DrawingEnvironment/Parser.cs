using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingEnvironment
{
    /// <summary>
    /// The Parser class is used to parse user inputs appropriately, and it will standarizing the user inputs,
    /// eventually it will generate a command dividing the input and the parameters, checking if the parameters are valid numbers.
    /// </summary>
    internal class Parser
    {
        /// <summary>
        /// Parser has a property - LineCounter which will be used to count the lines for multiple line commands.
        /// This will help to keep track where an error is thrown.
        /// </summary>
        public int LineCounter { get; set; }
        public List<Variable> VariableList = new List<Variable>();

        /// <summary>
        /// Command parser which will divide the command and Parameters passed and store them into the attributes.
        /// 
        /// <example>Initialising the parser and then passing a string of commands in the ParseCommands method:
        ///     <code>
        ///         // Initialising parser and declaring Command
        ///         Parser parser = new Parser();
        ///         Command parsedCommand;
        ///         
        ///         // Taking user input
        ///         string input = "Rectangle 100,200";
        ///         
        ///         // Parsed command
        ///         parsedCommand = parser.ParseCommands(command);
        ///     </code>
        /// </example>
        /// </summary>
        /// <param name="cmd">the command the user writes in the command line</param>
        /// <exception cref="FormatException">exception thrown when parameter not numerical or invalid no. of Parameters</exception>
        /// <returns>the command with its Name and parameter stored.</returns>
        public Command ParseCommands(string cmd)
        {
            string command;
            string parameters;

            var line = cmd.ToUpper().Trim(); // Tidying and standardizing the line of command
            var splitLine = line.Split(' '); // Splitting the command and Parameters [0] command and [1] param            
            List<int> parsedParameters = new List<int>();

            // TODO: Checking for variables
            if (CheckVariables(cmd))
            {
                Variable variable = ParseVariable(cmd);
                return variable;
            }

            // More than two elements will need to throw an error as we expect only a command and a list of parameters.
            else if (splitLine.Length > 2)
            {
                throw new ArgumentException("Invalid number of Parameters");
            }
            // If line has arguments then dividing Parameters and commands accordingly
            else if (splitLine.Length == 2)
            {
                // Splitting the commands: 0 command and 1 for Parameters.
                command = splitLine[0];
                parameters = splitLine[1];

                // Splitting Parameters with comma
                var splitParam = parameters.Split(',');

                // For each parameter after the split
                for (int i = 0; i < splitParam.Length; i++)
                {
                    // Handling the only command with literals Parameters (ON and OFF)
                    if (command.Equals("FILL") && parameters != null)
                    {
                        // Sets value 1 for On and Value 0 to OFF
                        if (parameters.Equals("ON")) { parsedParameters.Add(1); }
                        else if (parameters.Equals("OFF")) { parsedParameters.Add(0); }
                    }

                    // TODO: Implement this
                    else if (VariableList.Count > 0)
                    {
                        parsedParameters.Add(VariableList[0].Parameters[0]);
                    }

                    // Checking if the string passed on the parameters are valid integers
                    else if (!CheckNumbers(splitParam[i]) && VariableList.Count.Equals(0))
                    {
                        throw new ArgumentException("Not numerical parameter");
                    }

                    else
                    {
                        // Converting the Parameters and adding them to the list
                        parsedParameters.Add(Convert.ToInt32(splitParam[i]));
                    }
                }
            }
            // if only command storing just command
            else { command = splitLine[0]; }

            // Initialising the command based on the parsed values
            Command parsedCommand = new Command(command, parsedParameters.ToArray());

            return parsedCommand;
        }

        /// <summary>
        /// This method parses different lines of code in sequence by dividing the commands using \n new line key.
        /// <example>
        ///     Storing a list of Commands taken from multi line input:
        ///         <code>
        ///             // Initialising parser and list
        ///             
        ///             Parser parser = new Parser();
        ///             List &lt;Command&gt; commands = new List&lt;Command&gt;();
        ///             
        ///             // The user input
        ///             string multiLineInput = "Circle 100\nTriangle 30\nRectangle 30,40";
        ///             
        ///             // Parsing input
        ///             commands = parser.ParseCommandMultiLine(multiLineInput);       
        ///         </code>
        /// </example>
        /// </summary>
        /// <param name="commands">the user input</param>
        /// <exception cref="FormatException">exception thrown when parameter not numerical or invalid no. of Parameters</exception>
        /// <returns>a list of different commands with their Parameters.</returns>
        public List<Command> ParseCommandMultiLine(string commands)
        {
            List<Command> commandList = new List<Command>();
            var splitCommands = commands.Split('\n');
            LineCounter = 0;

            for (int i = 0; i < splitCommands.Length; i++)
            {
                LineCounter++; // Updating LineCounter to keep track of the line executing.
                commandList.Add(ParseCommands(splitCommands[i])); // applying the single line parsecommand to the current line and adding it to the list.
            }
            return commandList;
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
        /// It checks if in the user input there is a possible variable.
        /// </summary>
        /// <param name="input">the user input passed on command line</param>
        /// <returns>true if there is an assign sign false otherwise</returns>
        public bool CheckVariables(string input)
        {
            if (!input.Contains('='))
            {
                return false;
            }

            else { return true; }
        }

        /// <summary>
        /// Methods which checks if the commands is valid among the options available
        /// <example>Checking if the command passed is a valid command:
        ///     <code>
        ///         // Initialising parser and boolean variable
        ///         Parser parser = new Parser();
        ///         bool isValid;
        ///         
        ///         // User Input
        ///         string command = "Circle";
        ///         
        ///         // Storing the variable with parser method
        ///         isValid = parser.isValidCommand(command);
        ///     </code>
        /// </example>
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
        /// It parses the user input to assign a value and a variable name.
        /// </summary>
        /// <param name="input">the user input</param>
        /// <returns>the variable the user wants to assign the value to</returns>
        public Variable ParseVariable(string input)
        {
            // Parsing the input and normalize it
            string[] parsedInput = input.Trim().ToUpper().Split('=');

            // If the value is an accepted integer then the value will be assigned.
            if (Int32.TryParse(parsedInput[1], out int value))
            {
                value = Convert.ToInt32(parsedInput[1].Trim());
                int[] parsedValue = { value };
                
                // returning the variable
                Variable variable = new Variable(parsedInput[0], parsedValue);
                VariableList.Add(variable);
                return variable;
            }
            else { return null; }
        }

        /// <summary>
        /// It returns the list of variables to be used.
        /// </summary>
        /// <returns>the list of variables</returns>
        public List<Variable> GetVariables()
        {
            return VariableList;
        }

        /// <summary>
        /// Setter for the Variable list
        /// </summary>
        /// <param name="listVariable"></param>
        public void SetListVariable(List<Variable> listVariable)
        {
            this.VariableList = listVariable;
        }

        /// <summary>
        /// Empty constructor to initialise the parser
        /// </summary>
        public Parser()
        {
        }
    }
}
