﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingEnvironment
{
    internal class Parser
    {
        /// <summary>
        /// Parser has a property - LineCounter which will be used to count the lines for multiple line commands.
        /// This will help to keep track where an error is thrown.
        /// </summary>
        public int LineCounter { get; set; }

        /// <summary>
        /// Command parser which will divide the command and Parameters passed and store them into the attributes.
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

            if (splitLine.Length > 2)
            {
                throw new ArgumentException("Invalid number of Parameters");
            }
            // If line has arguments then dividing Parameters and commands accordingly
            else if( splitLine.Length == 2)
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

                    else if (!CheckNumbers(splitParam[i]))
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

            Command parsedCommand = new Command(command, parsedParameters.ToArray());

            return parsedCommand;
        }

        /// <summary>
        /// This method parses different lines of code in sequence by dividing the commands using \n new line key.
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
        public Parser()
        {
        }
    }
}
