using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    /// <summary>
    /// The service class uses the Dependency injection design patter.
    /// The service class is used to process the information provided by the form.
    /// The service will take most of the elements from the form and it will process it.
    /// It will take care of executing the commands and drawing on the graphical object.
    /// </summary>
    internal class ServiceExecute
    {
        /// <summary>
        /// Properties of the Service class
        /// </summary>
        Graphics g;
        Pen pen;
        bool isFilling;

        // Initialising the Parser.
        Parser parser = new Parser();
        ShapeFactory factory = new ShapeFactory(); // Factory for generating the shapes.
        // Initialising Cursor, Error and Position Labels to display in the Form.
        CustomCursor pointer = new CustomCursor();
        Label ErrorLabel = new Label();
        Label PositionLabel;
        TextBox programmingArea;
        // The list where the commands are going to be stored
       public List<Command> CommandList;
       public List<Command> LoopCommands = new List<Command>();
        
       public Loop loop;

        // The list of variables and variables flag
       public List<Variable> VariableList = new List<Variable>();

        // The line counter for the multiline execution
        int lineCounter = 1;

        /// <summary>
        /// Method which allows the user input to be parsed and executed if there are no errors.
        /// </summary>
        /// <param name="command">the user input</param>
        public void ExecuteService(string command)
        {
            try
            {
                // If no input throwing an error.
                if (command == "")
                {
                    throw new ArgumentException("Insert a valid command");
                }

                else
                {
                    // TODO: Setting a Loop list to separate it from the normal one

                    // Updating the parser's list of commands
                    parser.ParseCommandMultiLine(command);
                    // Updating the Service List of commands
                    CommandList = parser.CommandList;
                    LoopCommands = parser.LoopBody;
                    // Updating the Variables taken from the parser
                    parser.SetListVariable(VariableList);

                    for (int i = 0; i < CommandList.Count; i++)
                    {
                        // Checking if there are variables in Command list - Variables are inherited from Commands
                        if (CommandList[i].GetType().Equals(typeof(Variable)))
                        {
                            // Refreshing the parser's list of variables in use
                            parser.SetListVariable(VariableList);
                        }
                        // TODO: If it is a valid loop execute the loop Command List

                        else if (parser.isValidCommand(CommandList[i].Name))
                        {
                            // Executing the command with Execute method
                            Execute(CommandList[i]);
                            lineCounter++;
                        }
                        else { throw new FormatException("Error at line: " + lineCounter + "\n" + CommandList[i].Name + " is not a valid command."); }
                    }
                }
            }
            catch (ArgumentException ex) { ErrorLabel.Text = "Line: " + parser.LineCounter + " " + ex.Message; }
            catch (FormatException ex) { ErrorLabel.Text = ex.Message; }
        }

        /// <summary>
        /// Method which executes the specified command based on its Name and Parameters.
        /// </summary>
        /// <param name="command">the command to execute</param>
        /// <exception cref="IndexOutOfRangeException">it throws this error if there is no Parameters available</exception>
        public void Execute(Command command)
        {
            switch (command.Name)
            {
                //******************
                //      SHAPES
                //******************

                //------------
                //  Rectangle
                //------------
                case "RECTANGLE":
                    try
                    {
                        if (command.Parameters.Length > 2)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        else
                        {
                            // Using the factory to create the shape
                            Shape shape = factory.GetShape(command.Name);
                            shape.Set(pen.Color, pointer.X, pointer.Y, command.Parameters[0], command.Parameters[1]);

                            if (isFilling)
                            {
                                SetFill(shape);
                            }
                            shape.SetColour(pen.Color);
                            shape.Draw(g);
                        }
                    }
                    catch (ArgumentException) { ErrorLabel.Text = "Line: " + lineCounter + "\nInvalid parameter"; }
                    catch (IndexOutOfRangeException) { ErrorLabel.Text = "Invalid Parameters at line:  " + lineCounter + "\nRectangle <width> , <height> NOTE: Use the comma between Parameters."; }
                    break;

                //----------
                //  Circle
                //----------
                case "CIRCLE":
                    try
                    {
                        if (command.Parameters.Length > 1)

                        {
                            throw new IndexOutOfRangeException();
                        }

                        else
                        {
                            Shape circ = factory.GetShape(command.Name);
                            circ.Set(pen.Color, pointer.X, pointer.Y, command.Parameters[0]);

                            if (isFilling)
                            {
                                SetFill(circ);
                            }
                            circ.Draw(g);
                        }
                    }
                    catch (FormatException) { ErrorLabel.Text = "Invalid Parameter"; }
                    catch (IndexOutOfRangeException) { ErrorLabel.Text = "Invalid Parameters at line: " + lineCounter + "\nCircle <Radius>"; }
                    break;


                //------------
                //  Triangle
                //------------
                case "TRIANGLE":

                    try
                    {
                        if (command.Parameters.Length > 1)

                        {
                            throw new IndexOutOfRangeException();
                        }
                        else
                        {
                            Shape tri = factory.GetShape(command.Name);
                            tri.Set(pen.Color, pointer.X, pointer.Y, command.Parameters[0]);
                            if (isFilling)
                            {
                                SetFill(tri);
                            }
                            tri.Draw(g);
                        }
                    }
                    catch (FormatException) { ErrorLabel.Text = "Invalid Parameters at line: " + lineCounter + "\nTriangle <Length>"; }
                    catch (IndexOutOfRangeException) { ErrorLabel.Text = "Invalid parameter - Triangle <Length>"; }
                    break;

                //*********************
                //  GENERAL COMMANDS
                //*********************

                //--------------------
                //  Moving the cursor
                //--------------------
                case "MOVETO":
                    // Max Parameters 2 - X, Y
                    if (command.Parameters.Length > 2)

                    {
                        throw new IndexOutOfRangeException();
                    }
                    else
                    {
                        try
                        {
                            // assigning X and Y values to the pointer
                            pointer.UpdatePosition(command.Parameters[0], command.Parameters[1], g);
                            pointer.SetColour(pointer.colour);

                            // Updating the cursor
                            PositionLabel.Text = "X: " + pointer.X.ToString() + " ,Y: " + pointer.Y.ToString();
                        }
                        catch (FormatException) { ErrorLabel.Text = "Invalid Parameter"; }
                        catch (IndexOutOfRangeException) { ErrorLabel.Text = "Invalid Parameters at line: " + lineCounter + "\nMoveto <x Value> , <y Value> NOTE: Use the comma between Parameters."; }
                        break;
                    }

                //---------------------
                //  Draw line to X, Y
                //---------------------
                case "DRAWTO":
                    if (command.Parameters.Length > 2)

                    {
                        throw new IndexOutOfRangeException();
                    }
                    else
                    {
                        try
                        {
                            g.DrawLine(pen, pointer.X, pointer.Y, command.Parameters[0], command.Parameters[1]);
                            pointer.UpdatePosition(command.Parameters[0], command.Parameters[1], g);
                            // Update label positions
                            PositionLabel.Text = "X: " + pointer.X.ToString() + " ,Y: " + pointer.Y.ToString();
                        }

                        catch (FormatException) { ErrorLabel.Text = "Invalid Parameter"; }
                        catch (IndexOutOfRangeException) { ErrorLabel.Text = "Invalid Parameters at line: " + lineCounter + "\ndrawTo <x Value> , <y Value> NOTE: Use the comma between Parameters."; }
                        break;
                    }

                //--------------------
                //  Clear the screen
                //--------------------
                case "CLEAR":
                    try
                    {
                        {
                            // Refreshing the canvas without deleting the pointer.                 
                            g.Clear(Color.Black);
                            pointer.Draw(g);
                            ErrorLabel.Text = "";
                        }
                    }
                    catch (FormatException) { ErrorLabel.Text = "Invalid Command"; }
                    catch (IndexOutOfRangeException) { ErrorLabel.Text = "Invalid Parameters at line: " + lineCounter + "\nClear"; }
                    break;

                //---------------------------
                //  Reset cursor and colour
                //---------------------------
                case "RESET":
                    try
                    {
                        {
                            // Refreshing the canvas without deleting the pointer.                      
                            pointer.X = 0;
                            pointer.Y = 0;
                            PositionLabel.Text = "X: " + pointer.X.ToString() + " ,Y: " + pointer.Y.ToString();
                            isFilling = false;
                            pen.Color = Color.White;
                            pointer.SetColour(pen.Color);
                            pointer.Draw(g);
                        }
                    }
                    catch (FormatException) { ErrorLabel.Text = "Invalid Command"; }
                    break;

                //---------------------
                //  Fill toggle ON/OFF
                //---------------------
                case "FILL":
                    try
                    {
                        if (command.Parameters.Length == 0)
                        {
                            throw new FormatException("Invalid parameter");
                        }
                        // If command 1 it should be ON
                        else if (command.Parameters[0] == 1)
                        {
                            isFilling = true;
                        }
                        // If command 0 = it should be OFF
                        else if (command.Parameters[0] == 0)
                        {
                            isFilling = false;
                        }
                    }
                    catch (FormatException) { ErrorLabel.Text = "Invalid Parameters at line: " + lineCounter + "\nFill <ON> or <OFF>"; }
                    break;
                //---------------
                //  Run command
                //---------------
                case "RUN":
                    ExecuteService(programmingArea.Text);
                    break;

                //***************
                //   COLOURS
                //***************

                case "RED":
                    pointer.SetColour(Color.Red);
                    pen.Color = Color.Red;
                    break;

                case "GREEN":
                    pointer.SetColour(Color.Green);
                    pen.Color = Color.Green;
                    break;


                case "BLUE":
                    pointer.SetColour(Color.Blue);
                    pen.Color = Color.Blue;
                    break;

                case "WHITE":
                    pointer.SetColour(Color.White);
                    pen.Color = Color.White;
                    break;
            }
        } // End of Method

        /// <summary>
        /// Setting a shape to be fillable changing its attribute.
        /// </summary>
        /// <param name="shape">the shape we want to change the parameter</param>
        private void SetFill(Shape shape)
        {
            if (isFilling)
            { shape.isFill = true; }

            else
            { shape.isFill = false; }
        }

        /// <summary>
        /// Getter method to retrieve the status of the Filling flag.
        /// </summary>
        /// <returns>true if needs filling, false if it doesn't</returns>
        internal bool GetFill()
        {
            if (isFilling)

            { return true; }

            else

            { return false; }
        }

        /// <summary>
        /// Constructor for the service which will be used to execute the commands out of the Form context
        /// </summary>
        /// <param name="g">Graphical element</param>
        /// <param name="pen">the pen used to draw</param>
        /// <param name="pointer">the cursor</param>
        /// <param name="errorLabel">the error label to display the messages on the form</param>
        /// <param name="LablePosition">the label which manages the current position of the cursor</param>
        /// <param name="isFilling">the current state of the filling function</param>
        /// <param name="programmingArea">the programming area text box from the form</param>
        public ServiceExecute(Graphics g, Pen pen, CustomCursor pointer, Label errorLabel, Label LablePosition, bool isFilling, TextBox programmingArea)
        {
            this.g = g;
            this.pen = pen;
            this.pointer = pointer;
            this.ErrorLabel = errorLabel;
            PositionLabel = LablePosition;
            this.isFilling = isFilling;
            this.programmingArea = programmingArea;
        }
    }
}
