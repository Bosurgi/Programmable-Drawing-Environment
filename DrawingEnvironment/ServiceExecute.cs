using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    internal class ServiceExecute
    {
        Graphics g;
        Pen pen;
        bool isFilling;
        
        Parser parser = new Parser();
        //ShapeFactory factory = new ShapeFactory();

        CustomCursor pointer = new CustomCursor();
        Label ErrorLabel = new Label();
        Label PositionLabel;

        TextBox programmingArea;
        List<Command> CommandList;
        int lineCounter = 1;

        public void ExecuteService(string command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentException("Insert a valid command");
                }

                else
                {                   
                    CommandList = parser.ParseCommandMultiLine(command);
                    for (int i = 0; i < CommandList.Count; i++)
                    {
                        if (parser.isValidCommand(CommandList[i].name))
                        {                         
                            Execute(CommandList[i].name, CommandList[i].parameters.ToList());
                            lineCounter++;
                        }
                        else { throw new FormatException("Error at line: " + lineCounter + "\n" + CommandList[i].name + " is not a valid command."); }
                    }
                }
            }
            catch (ArgumentException ex) { ErrorLabel.Text = ex.Message; }
            catch(FormatException ex) { ErrorLabel.Text = ex.Message; }
        }

        /// <summary>
        /// Methods which takes a command name and a list of parameters to execute the right command based on command name and its parameters.
        /// </summary>
        /// <param name="command">the name of the command</param>
        /// <param name="parameters">the list of parameters passed</param>
        public void Execute(string command, List<int> parameters)
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
                catch (FormatException) { ErrorLabel.Text = "Invalid Parameter"; }
                catch (ArgumentOutOfRangeException) { ErrorLabel.Text = "Invalid parameters at line:  " + lineCounter + "\nRectangle <width> , <height> NOTE: Use the comma between parameters."; }
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
                catch (ArgumentOutOfRangeException) { ErrorLabel.Text = "Invalid parameters at line: " + lineCounter + "\nMoveto <x Value> , <y Value> NOTE: Use the comma between parameters."; }

            }
            // Command Circle draw a circle
            if (command.Equals("CIRCLE"))
            {
                try
                {
                    Circle circle = new Circle(pen.Color, pointer.X, pointer.Y, parameters[0]);

                    if (isFilling)
                    {
                        SetFill(circle);
                    }
                    circle.Draw(g);
                }

                catch (FormatException) { ErrorLabel.Text = "Invalid Parameter"; }
                catch (ArgumentOutOfRangeException) { ErrorLabel.Text = "Invalid parameters at line: " + lineCounter + "\nCircle <Radius>"; }
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
                catch (FormatException) { ErrorLabel.Text = "Invalid parameters at line: " + lineCounter + "\nTriangle <Length>"; }
                catch (ArgumentOutOfRangeException) { ErrorLabel.Text = "Invalid parameters - Triangle <Length>"; }
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
                catch (ArgumentOutOfRangeException) { ErrorLabel.Text = "Invalid parameters at line: " + lineCounter + "\ndrawTo <x Value> , <y Value> NOTE: Use the comma between parameters."; }
            }

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
                catch (ArgumentOutOfRangeException) { ErrorLabel.Text = "Invalid parameters at line: " + lineCounter + "\nClear"; }
            }

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
                    if (parameters.Count == 0)
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
            catch (FormatException) { ErrorLabel.Text = "Invalid parameters at line: " + lineCounter + "\nFill <ON> or <OFF>"; }
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
        /// Setting a shape to be fillable changing its attribute.
        /// </summary>
        /// <param name="shape">the shape we want to change the parameter</param>
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
        /// Constructor for the service which will be used to execute the commands out of the Form context
        /// </summary>
        /// <param name="g">Graphical element</param>
        /// <param name="pen">the pen used to draw</param>
        /// <param name="factory">TO BE IMPLEMENTED: The shape factory which will create shapes</param>
        /// <param name="pointer">the cursor</param>
        /// <param name="errorLabel">the error label to display the messages on the form</param>
        /// <param name="LablePosition">the label which manages the current position of the cursor</param>
        /// <param name="isFilling">the current state of the filling function</param>
        public ServiceExecute(Graphics g, Pen pen, string command, CustomCursor pointer, Label errorLabel, Label LablePosition, bool isFilling, TextBox programmingArea)
        {
            this.g = g;
            this.pen = pen;
            //this.factory = factory;
            this.pointer = pointer;
            this.ErrorLabel = errorLabel;
            PositionLabel = LablePosition;
            this.isFilling = isFilling;
            this.programmingArea = programmingArea;
        }
    }
}
