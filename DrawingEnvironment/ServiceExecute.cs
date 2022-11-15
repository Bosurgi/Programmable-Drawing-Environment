using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    /// <summary>
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
        List<Command> CommandList;

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
                    // Parsing the commands from the user
                    CommandList = parser.ParseCommandMultiLine(command);
                    for (int i = 0; i < CommandList.Count; i++)
                    {
                        if (parser.isValidCommand(CommandList[i].Name))
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
                //   SHAPES
                //******************

                // Rectangle
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

                // Circle
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

                // Triangle
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

                //*******************
                // GENERAL COMMANDS
                //*******************

                // Moving the cursor
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

                // Command to draw a line from the pointer to a set point
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

                // Clear function.
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

                // Reset Function
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

                // FIlling command options
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

                // Run command
                case "RUN":
                    ExecuteService(programmingArea.Text);
                    break;

                //***************
                //  COLOURS
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
        /// <param Name="shape">the shape we want to change the parameter</param>
        private void SetFill(Shape shape)
        {
            if (isFilling)
            {
                shape.isFill = true;
            }
            else { shape.isFill = false; }
        }

        /// <summary>
        /// Getter method to retrieve the status of the Filling flag.
        /// </summary>
        /// <returns>true if needs filling, false if it doesn't</returns>
        internal bool GetFill()
        {
            if (isFilling)
            {
                return true;
            }
            else { return false; }
        }


        /// <summary>
        /// Deprecated method which takes a command Name and a list of Parameters to execute the right command based on command Name and its Parameters.
        /// </summary>
        /// <param Name="command">the Name of the command</param>
        /// <param Name="Parameters">the list of Parameters passed</param>
        public void ExecuteIfs(string command, int[] parameters)
        {
            if (command.Equals("RECTANGLE"))
            {
                try
                {
                    Rectangle rect = new Rectangle(pointer.X, pointer.Y, parameters[0], parameters[1]);
                    if (isFilling)
                    {
                        SetFill(rect);
                    }
                    rect.SetColour(pen.Color);
                    rect.Draw(g);
                }
                catch (ArgumentException) { ErrorLabel.Text = "Line: " + lineCounter + "\nInvalid parameter"; }
                catch (IndexOutOfRangeException) { ErrorLabel.Text = "Invalid Parameters at line:  " + lineCounter + "\nRectangle <width> , <height> NOTE: Use the comma between Parameters."; }
            }

            if (command.Equals("MOVETO"))
            {
                try
                {
                    // assigning X and Y values to the pointer
                    pointer.UpdatePosition(parameters[0], parameters[1], g);
                    pointer.SetColour(pointer.colour);

                    // Updating the cursor
                    PositionLabel.Text = "X: " + pointer.X.ToString() + " ,Y: " + pointer.Y.ToString();
                }
                catch (FormatException) { ErrorLabel.Text = "Invalid Parameter"; }
                catch (IndexOutOfRangeException) { ErrorLabel.Text = "Invalid Parameters at line: " + lineCounter + "\nMoveto <x Value> , <y Value> NOTE: Use the comma between Parameters."; }

            }
            // Command Circle draw a circle
            if (command.Equals("CIRCLE"))
            {
                try
                {
                    Circle circle = new Circle(pointer.X, pointer.Y, parameters[0]);

                    if (isFilling)
                    {
                        SetFill(circle);
                    }
                    circle.SetColour(pen.Color);
                    circle.Draw(g);
                }

                catch (FormatException) { ErrorLabel.Text = "Invalid Parameter"; }
                catch (IndexOutOfRangeException) { ErrorLabel.Text = "Invalid Parameters at line: " + lineCounter + "\nCircle <Radius>"; }
            }


            // Triangle figure
            if (command.Equals("TRIANGLE"))
            {
                try
                {
                    Triangle tri = new Triangle(parameters[0], pointer.X, pointer.Y);
                    if (isFilling)
                    {
                        SetFill(tri);
                    }
                    tri.SetColour(pen.Color);
                    tri.Draw(g);
                }
                catch (FormatException) { ErrorLabel.Text = "Invalid Parameters at line: " + lineCounter + "\nTriangle <Length>"; }
                catch (IndexOutOfRangeException) { ErrorLabel.Text = "Invalid parameter - Triangle <Length>"; }
            }


            // Command to draw a line from the pointer to a set point
            if (command.Equals("DRAWTO"))
            {
                try
                {
                    g.DrawLine(pen, pointer.X, pointer.Y, parameters[0], parameters[1]);
                    pointer.UpdatePosition(parameters[0], parameters[1], g);
                    // Update label positions
                    PositionLabel.Text = "X: " + pointer.X.ToString() + " ,Y: " + pointer.Y.ToString();
                }

                catch (FormatException) { ErrorLabel.Text = "Invalid Parameter"; }
                catch (IndexOutOfRangeException) { ErrorLabel.Text = "Invalid Parameters at line: " + lineCounter + "\ndrawTo <x Value> , <y Value> NOTE: Use the comma between Parameters."; }
            }

            // Clear function.
            if (command.Equals("CLEAR"))
            {
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
            }

            // Reset Function
            if (command.Equals("RESET"))
            {
                try
                {
                    {
                        // Refreshing the canvas without deleting the pointer.                      
                        pointer.X = 0;
                        pointer.Y = 0;
                        PositionLabel.Text = "X: " + pointer.X.ToString() + " ,Y: " + pointer.Y.ToString();
                        isFilling = false;
                        g.Clear(Color.Black);
                        pen.Color = Color.White;
                        pointer.SetColour(pen.Color);
                        pointer.Draw(g);
                    }
                }
                catch (FormatException) { ErrorLabel.Text = "Invalid Command"; }
            }

            // Filling commands options
            try
            {
                if (command.Equals("FILL"))
                {
                    if (parameters.Length == 0)
                    {
                        throw new FormatException("Invalid parameter");
                    }
                    // If command 1 it should be ON
                    else if (parameters[0] == 1)
                    {
                        isFilling = true;
                    }
                    // If command 0 = it should be OFF
                    else if (parameters[0] == 0)
                    {
                        isFilling = false;
                    }
                }
            }
            catch (FormatException) { ErrorLabel.Text = "Invalid Parameters at line: " + lineCounter + "\nFill <ON> or <OFF>"; }
            //***************
            //  COLOURS
            //***************
            if (command.Equals("RED"))
            {
                pointer.SetColour(Color.Red);
                pen.Color = Color.Red;
            }

            if (command.Equals("GREEN"))
            {
                pointer.SetColour(Color.Green);
                pen.Color = Color.Green;
            }

            if (command.Equals("BLUE"))
            {
                pointer.SetColour(Color.Blue);
                pen.Color = Color.Blue;
            }

            if (command.Equals("WHITE"))
            {
                pointer.SetColour(Color.White);
                pen.Color = Color.White;
            }
        } // End of Method


        /// <summary>
        /// Constructor for the service which will be used to execute the commands out of the Form context
        /// </summary>
        /// <param name="g">Graphical element</param>
        /// <param name="pen">the pen used to draw</param>
        /// <param name="pointer">the cursor</param>
        /// <param name="errorLabel">the error label to display the messages on the form</param>
        /// <param name="LablePosition">the label which manages the current position of the cursor</param>
        /// <param name="isFilling">the current state of the filling function</param>
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
