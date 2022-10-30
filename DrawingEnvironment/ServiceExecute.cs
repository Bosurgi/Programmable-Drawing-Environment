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
        string[] organizedCommands;
        //ShapeFactory factory = new ShapeFactory();

        CustomCursor pointer = new CustomCursor();
        Label errorLabel = new Label();
        Label PositionLabel;

        public void executeService(string command)
        {
            if (parser.CheckCommand(command))
            {
                organizedCommands = parser.ValidateCommand(command);
                if (organizedCommands[0].Equals("RECTANGLE"))
                {
                    List<int> dimensions = new List<int>();
                    try
                    {
                        dimensions = parser.AssigningParameters(command);
                        Rectangle rect = new Rectangle(pointer.X, pointer.Y, dimensions[0], dimensions[1]);
                        if (isFilling)
                        {
                            setFill(rect);
                        }
                        rect.SetColour(pen.Color);
                        rect.Draw(g);
                    }
                    catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                    catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Rectangle <width> <height>"; }
                }

                if (organizedCommands[0].Equals("MOVETO"))
                {
                    try
                    {
                        List<int> parameters = parser.AssigningParameters(command);
                        // assigning X and Y values to the pointer
                        pointer.UpdatePosition(parameters[0], parameters[1], g);
                        pointer.SetColour(pointer.colour);

                        // Updating the cursor
                        PositionLabel.Text = "X: " + pointer.X.ToString() + " ,Y: " + pointer.Y.ToString();
                    }
                    catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                    catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Moveto <x Value> <y Value>"; }

                }
                // Command Circle draw a circle
                if (organizedCommands[0].Equals("CIRCLE"))
                {
                    try
                    {
                        List<int> parameters = parser.AssigningParameters(command);
                        Circle circle = new Circle(pen.Color, pointer.X, pointer.Y, parameters[0]);
                        
                        if (isFilling)
                        {
                            setFill(circle);
                        }
                        circle.Draw(g);
                    }

                    catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                    catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Circle <Radius>"; }
                }


                // Triangle figure
                if (organizedCommands[0].Equals("TRIANGLE"))
                {
                    try
                    {
                        List<int> parameters = parser.AssigningParameters(command);
                        Triangle tri = new Triangle(parameters[0], pen, pointer.X, pointer.Y);
                        if (isFilling)
                        {
                            setFill(tri);
                        }
                        tri.SetColour(pen.Color);
                        tri.Draw(g);
                    }
                    catch (FormatException) { errorLabel.Text = "Invalid Parameter - Triangle <Length>"; }
                    catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Triangle <Length>"; }
                }


                // Command to draw a line from the pointer to a set point
                if (organizedCommands[0].Equals("DRAWTO"))
                {
                    try
                    {
                        List<int> parameters = parser.AssigningParameters(command);
                        g.DrawLine(pen, pointer.X, pointer.Y, parameters[0], parameters[1]);
                        pointer.UpdatePosition(parameters[0], parameters[1], g);
                        // Update label positions
                        PositionLabel.Text = "X: " + pointer.X.ToString() + " ,Y: " + pointer.Y.ToString();
                    }

                    catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                    catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - drawTo <x Value> <y Value>"; }
                }

                if (organizedCommands[0].Equals("CLEAR"))
                {
                    try
                    {
                        {
                            // Refreshing the canvas without deleting the pointer.                 
                            g.Clear(Color.Black);
                            pointer.Draw(g);
                        }
                    }
                    catch (FormatException) { errorLabel.Text = "Invalid Command"; }
                    catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Clear"; }
                }

                if (organizedCommands[0].Equals("RESET"))
                {
                    try
                    {
                        {
                            // Refreshing the canvas without deleting the pointer.                      
                            pointer.X = 0;
                            pointer.Y = 0;
                            PositionLabel.Text = "X: " + pointer.X.ToString() + " ,Y: " + pointer.Y.ToString();
                            g.Clear(Color.Black);
                            pointer.Draw(g);
                        }
                    }
                    catch (FormatException) { errorLabel.Text = "Invalid Command"; }
                }

                // Filling commands options
                try
                {
                    if (organizedCommands[0].Equals("FILL"))
                    {
                        if (organizedCommands[1].Equals("ON"))
                        {
                            isFilling = true;
                        }
                        else if (organizedCommands[1].Equals("OFF"))
                        {
                            isFilling = false;
                        }
                        // TODO: Implementing try catch to catch this exception
                        else { throw new FormatException("Invalid parameter"); }
                    }
                }
                catch (FormatException) { errorLabel.Text = "Invalid Command - Fill <ON> <OFF>"; }
                //***************
                //  COLOURS
                //***************
                if (organizedCommands[0].Equals("RED"))
                {
                    pointer.SetColour(Color.Red);
                    pen.Color = Color.Red;
                }

                if (organizedCommands[0].Equals("GREEN"))
                {
                    pointer.SetColour(Color.Green);
                    pen.Color = Color.Green;
                }

                if (organizedCommands[0].Equals("BLUE"))
                {
                    pointer.SetColour(Color.Blue);
                    pen.Color = Color.Blue;
                }

                if (organizedCommands[0].Equals("WHITE"))
                {
                    pointer.SetColour(Color.White);
                    pen.Color = Color.White;
                }
            } // End of CheckCommand

            else
            {
                errorLabel.Text = "Invalid command";
            }
        } // End of method

        /// <summary>
        /// Setting a shape to be fillable changing its attribute.
        /// </summary>
        /// <param name="shape">the shape we want to change the parameter</param>
        private void setFill(Shape shape)
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
        internal bool getFill()
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
        /// <param name="parser">the parser used to fetch the commands</param>
        /// <param name="organizedCommands">the list of commands after parsing</param>
        /// <param name="factory">TO BE IMPLEMENTED: The shape factory which will create shapes</param>
        /// <param name="pointer">the cursor</param>
        /// <param name="errorLabel">the error label to display the messages on the form</param>
        /// <param name="LablePosition">the label which manages the current position of the cursor</param>
        /// <param name="isFilling">the current state of the filling function</param>
        public ServiceExecute(Graphics g, Pen pen, Parser parser, string command, string[] organizedCommands, CustomCursor pointer, Label errorLabel, Label LablePosition, bool isFilling)
        {
            this.g = g;
            this.pen = pen;
            this.parser = parser;
            this.organizedCommands = organizedCommands;
            //this.factory = factory;
            this.pointer = pointer;
            this.errorLabel = errorLabel;
            PositionLabel = LablePosition;
            this.isFilling = isFilling;
        }
    }
}
