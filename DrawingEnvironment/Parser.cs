using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
        public Variable loopVar;
        public List<Variable> VariableList = new List<Variable>();
        public List<Command> LoopBody = new List<Command>();
        public List<Command> IfBody = new List<Command>();
        public List<Command> MethodBody = new List<Command>();
        public List<Method> Methods = new List<Method>();
        public List<Command> CommandList = new List<Command>();
        public Loop loop;
        public IfStatement ifStatement;
        public string[] LoopElements;

        // Dictionary which will store unique key pairs for the Variables stored in memory
        public Dictionary<string, int> VariableDictionary = new Dictionary<string, int>();

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
            string command = "";
            string parameters = "";

            var line = cmd.ToUpper().Trim(); // Tidying and standardizing the line of command
            var splitLine = line.Split(' '); // Splitting the command and Parameters [0] command and [1] param            
            List<int> parsedParameters = new List<int>();

            // If variable detected in user input it will parse into a Variable
            if (CheckVariables(cmd) && !cmd.ToUpper().Contains("FOR"))
            {
                Variable variable = ParseVariable(cmd);

                if (!VariableDictionary.ContainsKey(variable.Name))
                {
                    VariableDictionary.Add(variable.Name, variable.Parameters[0]); // Update the dictionary
                    LineCounter++;
                }

                // If key already there updating its value to avoid ArgumentExeption as Dictionary can take only one key
                else
                {
                    VariableDictionary[variable.Name] = variable.Parameters[0];
                    LineCounter++;
                }
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

                // For each parameter after the split it checks if is a variable or number
                for (int i = 0; i < splitParam.Length; i++)
                {
                    // Checking if the variable name matches the one contained in the Dictionary
                    if (VariableDictionary.ContainsKey(splitParam[i]))
                    {
                        // Adding the values into the parameters list
                        parsedParameters.Add(VariableDictionary[splitParam[i]]);
                    }
                    /*
                    // TODO: This causes a bug if a command is issued after declaring a variable
                    // If the variable is not present, it will throw an error only if there are variables
                    else if (!VariableDictionary.ContainsKey(splitParam[i]) && VariableDictionary.Count != 0)
                    {
                        throw new ArgumentException("Variable not found");
                    }
                    */
                    // Handling the only command with literals Parameters (ON and OFF)
                    else if (command.Equals("FILL") && parameters != null)
                    {
                        // Sets value 1 for On and Value 0 to OFF
                        if (parameters.Equals("ON")) { parsedParameters.Add(1); }
                        else if (parameters.Equals("OFF")) { parsedParameters.Add(0); }
                    }

                    // Checking if the string passed on the parameters are valid integers
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

            else if (splitLine[0].Contains('('))
            {
                string[] methodSplit = splitLine[0].Split('(');
                for (int i = 0; i < Methods.Count; i++)
                {
                    if (Methods[i].Name.StartsWith(methodSplit[0]))
                    {
                        // Dividing the parameters of the Method
                        string pattern = @"(?<=\()[^()]*(?=\))";
                        Regex rg = new Regex(pattern, RegexOptions.Compiled);

                        // The parameters are matching the regex declared before inside the parenthesis
                        string parametersMethods = rg.Match(splitLine[0]).ToString();
                        string[] parametersSplit = parametersMethods.Split(',');
                        
                        // Converting the array to int array
                        int[] intsParameter = Array.ConvertAll(parametersSplit, int.Parse);
                        
                        // Setting the method values as integers
                        Methods[i].SetParametersValues(intsParameter);
                        command = methodSplit[0];                                              
                        
                        // Returning the method so it will be added to the list
                        return Methods[i];
                        
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
        public void ParseCommandMultiLine(string commands)
        {

            var splitCommands = commands.Split('\n');
            LineCounter = 0;

            for (int i = 0; i < splitCommands.Length; i++)
            {
                // If does not contain the keyword For it adds the commands to execute in the normal Command List
                if (!splitCommands[i].ToUpper().Trim().Contains("FOR")
                    && !splitCommands[i].ToUpper().Trim().Contains("IF")
                    && !splitCommands[i].ToUpper().Trim().Contains("METHOD"))
                {
                    LineCounter++; // Updating LineCounter to keep track of the line executing.
                    CommandList.Add(ParseCommands(splitCommands[i])); // applying the single line parsecommand to the current line and adding it to the list.
                }

                // If a loop is detected the program needs to create the loop body
                else if (splitCommands[i].ToUpper().Trim().Contains("FOR"))
                {
                    // Parsing the elements of the loop
                    LoopElements = ParseLoopElements(splitCommands[i]);

                    // Instantiating the Expression for the loop
                    Expression loopExpression = new Expression(LoopElements[1]);

                    // Instantiating the variable present in the loop
                    loopVar = ParseLoopVariable(splitCommands[i]);

                    // Adding the variable into the Dictionary
                    VariableDictionary.Add(loopVar.Name, loopVar.Parameters[0]);


                    // Nested for loop to populate the commands for the For loop body. 

                    for (int j = i + 1; j < splitCommands.Length; j++)
                    {
                        if (splitCommands[j].ToUpper().Trim().Equals("ENDFOR"))
                        {
                            LineCounter++;
                            i = j; // Updating i to avoid OutOfBound
                            break;
                        }
                        else
                        {
                            LoopBody.Add(ParseCommands(splitCommands[j]));
                            LineCounter++;
                        }
                    } // End for
                      // Instantiating the loop

                    loop = new Loop(VariableDictionary, LoopBody, loopExpression, LoopElements[2]);
                } // End else if

                // Determine if there is an IF statement to parse
                else if (splitCommands[i].ToUpper().Trim().Contains("IF"))
                {
                    string IfExpression = ParseIfStatement(splitCommands[i]);
                    Expression ifExpression = new Expression(IfExpression, VariableDictionary);

                    for (int j = i + 1; j < splitCommands.Length; j++)
                    {
                        if (splitCommands[j].ToUpper().Trim().Equals("ENDIF"))
                        {
                            LineCounter++;
                            i = j; // Updating i to avoid OutOfBound
                            break;
                        }
                        else
                        {
                            IfBody.Add(ParseCommands(splitCommands[j]));
                            LineCounter++;
                        }
                    } // End for

                    // Instantiating the If Statement
                    ifStatement = new IfStatement(VariableDictionary, ifExpression, IfBody);
                }

                // Determine if there is a Method declaration to parse TODO: implement this
                else if (splitCommands[i].ToUpper().Trim().Contains("METHOD"))
                {
                    Method method = ParseMethod(splitCommands[i]);

                    for (int j = i + 1; j < splitCommands.Length; j++)
                    {
                        if (splitCommands[j].ToUpper().Trim().Equals("ENDMETHOD"))
                        {
                            LineCounter++;
                            i = j; // Updating i to avoid OutOfBound
                            break;
                        }
                        else
                        {
                            MethodBody.Add(ParseMethodCommands(splitCommands[j]));
                            LineCounter++;
                        }
                    } // End for

                    // Set the body of the method to execute
                    method.SetBody(MethodBody);
                    Methods.Add(method);
                }
            }
        } // End Method


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
        /// It parses commands for the Methods which will not have variables declared hence
        /// they need to be parsed differently.
        /// </summary>
        /// <param name="input">the user input</param>
        /// <returns>A command with Name and Variable</returns>
        public Command ParseMethodCommands(string input)
        {           
            string commandName;
            string commandParameters;

            // Splitting the input - index 0 command name and index 1 parameters
            string[] splitLine = input.Trim().ToUpper().Split(' ');

            // The command that will be parsed
            Command command;

            if (splitLine.Length > 2)
            {
                throw new ArgumentException("Invalid number of Parameters");
            }
            // If line has arguments then dividing Parameters and commands accordingly
            else if (splitLine.Length == 2)
            {
                // Splitting the commands: 0 command and 1 for Parameters.
                commandName = splitLine[0];
                commandParameters = splitLine[1];

                // Splitting Parameters with comma
                var splitParam = commandParameters.ToUpper().Split(',');

                command = new Command(commandName, splitParam);
            }
            // if only command storing just command

            else
            {
                commandName = splitLine[0];
                command = new Command(commandName);
            }

            return command;
        }
        /// <summary>
        /// It parses the element contained in a loop dividing the expressions by semicolumns.
        /// </summary>
        /// <param name="loopDeclaration">the declaration of the loop, the first element of the loop</param>
        /// <returns>the elements of the loop as string array</returns>
        public string[] ParseLoopElements(string loopDeclaration)
        {
            // Splitting the for statement from the body
            string[] loopDeclarationSplit = loopDeclaration.Split(' ');
            // Splitting the operations of the for loop [0] as the variable, [1] condition, [2] increment
            string[] loopElements = loopDeclarationSplit[1].Split(';');

            return loopElements;
        }

        /// <summary>
        /// It parses the if statement by dividing the declaration from the expression
        /// </summary>
        /// <param name="ifDeclaration">the declaration of If statement</param>
        /// <returns>the if statement condition as a string</returns>
        public string ParseIfStatement(string ifDeclaration)
        {
            string[] ifStatementSplit = ifDeclaration.Split(' ');

            return ifStatementSplit[1];
        }

        /// <summary>
        /// It parses the variable found in a loop declaration
        /// </summary>
        /// <param name="loopDeclaration">the loop declaration divided by semicolumns</param>
        /// <returns>The variable declared</returns>
        public Variable ParseLoopVariable(string loopDeclaration)
        {
            // Setting the loop elements
            string[] loopElements = ParseLoopElements(loopDeclaration);

            // Returning the first element which is going to be the declared variable
            return ParseVariable(loopElements[0]); // The Variable declaration for the loop
        }

        /// <summary>
        /// It parses eventual methods dividing name and parameters
        /// </summary>
        /// <param name="methodDeclaration">the declaration of the methods by the user</param>
        /// <returns>returns the method</returns>
        public Method ParseMethod(string methodDeclaration)
        {
            // It contains the elements of the method, at index 1 it should be name of method and its parameters
            string[] MethodsElements = methodDeclaration.ToUpper().Trim().Split(' ');

            // Dividing the parameters of the Method
            string pattern = @"(?<=\()[^()]*(?=\))";
            Regex rg = new Regex(pattern, RegexOptions.Compiled);

            // Getting the method name by dividing for the first parenthesis
            string methodName = MethodsElements[1].Trim().ToUpper().Split('(').FirstOrDefault();
            
            // The parameters are matching the regex declared before inside the parenthesis
            string parameters = rg.Match(MethodsElements[1]).ToString().ToUpper();

            // Instantiating the Method
            Method method = new Method(methodName, parameters);

            return method;
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
        /// It parses the user input to assign a value and a variable name, it then updates the list of Variables
        /// </summary>
        /// <param name="input">the user input</param>
        /// <returns>the variable the user wants to assign the value to</returns>
        public Variable ParseVariable(string input)
        {
            // Parsing the input and normalize it
            string[] parsedInput = input.Trim().ToUpper().Split('=');

            // Checking if the variable is assigned through a mathematical operation
            if (CheckExpression(parsedInput[1]))
            {
                // Initialising a new expression by passing eventual variables
                Expression expression = new Expression(parsedInput[1], VariableDictionary);
                // Calculating the result of the expression
                string result = expression.CalculateExpression();

                // Storing the result as Integer as a Variable
                int calculatedValue = Convert.ToInt32(result);
                int[] parsedValue = { calculatedValue };
                Variable variable = new Variable(parsedInput[0], parsedValue);
                return variable;

            }
            // If the value is an accepted integer then the value will be assigned.
            else if (Int32.TryParse(parsedInput[1], out int value))
            {
                value = Convert.ToInt32(parsedInput[1].Trim());
                int[] parsedValue = { value };

                // Initialising the variables with the parsed values
                Variable variable = new Variable(parsedInput[0], parsedValue);
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
        /// Checks if the input passed by the user has mathematical operators
        /// </summary>
        /// <param name="input">the user input</param>
        /// <returns>true if there is an expression, false otherwise</returns>
        public bool CheckExpression(string input)
        {
            // Using Regex to find if one of the mathematical operators is part of the input
            string pattern = @"-|\+|\*|\/";
            Regex rg = new Regex(pattern);

            if (rg.IsMatch(input)) { return true; }

            else { return false; }
        }

        /// <summary>
        /// It checks if there is a loop in the user input
        /// </summary>
        /// <param name="input">the user's input</param>
        /// <returns>true if there is a form of loop, false otherwise</returns>
        public bool CheckLoop(string input)
        {
            if (input.Contains("FOR")) { return true; }
            else { return false; }
        }
        /// <summary>
        /// Empty constructor to initialise the parser
        /// </summary>
        public Parser()
        {
        }
    }
}