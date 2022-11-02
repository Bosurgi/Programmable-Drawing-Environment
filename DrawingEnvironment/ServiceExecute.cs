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
        // Testing new parser
        ParserUpdate parserUpdate = new ParserUpdate();
        //ShapeFactory factory = new ShapeFactory();

        CustomCursor pointer = new CustomCursor();
        Label errorLabel = new Label();
        Label PositionLabel;

        TextBox programmingArea;
        List<KeyValuePair<string, List<int>>> keyValuePairs;

        public void executeService(string command)
        {
            if (command.Contains('\n') || parserUpdate.isValidCommand(command))
            {
                keyValuePairs = parserUpdate.ParseCommandMultiLine(command);
                int lineCounter = 0;
                for (int i = 0; i < keyValuePairs.Count; i++)
                {
                    lineCounter += 1;
                    Execute(keyValuePairs[i].Key, keyValuePairs[i].Value);
                }
                
            }
            else
            {
                throw new FormatException("Invalid command at line: ");
            }
        } // If uncomment remove this

        public void Execute(string command, List<int> parameters)
        {
            if (command.Equals("RECTANGLE"))
            {
                try
                {
                    Rectangle rect = new Rectangle(pointer.X, pointer.Y, parameters[0], parameters[1]);
                    if (isFilling)
                    {
                        setFill(rect);
                    }
                    rect.SetColour(pen.Color);
                    rect.Draw(g);
                }
                catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Rectangle <width> , <height> NOTE: Use the comma between parameters."; }
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
                catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Moveto <x Value> , <y Value> NOTE: Use the comma between parameters."; }

            }
            // Command Circle draw a circle
            if (command.Equals("CIRCLE"))
            {
                try
                {
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
            if (command.Equals("TRIANGLE"))
            {
                try
                {
                    Triangle tri = new Triangle(parameters[0], pointer.X, pointer.Y);
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
            if (command.Equals("DRAWTO"))
            {
                try
                {
                    g.DrawLine(pen, pointer.X, pointer.Y, parameters[0], parameters[1]);
                    pointer.UpdatePosition(parameters[0], parameters[1], g);
                    // Update label positions
                    PositionLabel.Text = "X: " + pointer.X.ToString() + " ,Y: " + pointer.Y.ToString();
                }

                catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - drawTo <x Value> , <y Value> NOTE: Use the comma between parameters."; }
            }

            if (command.Equals("CLEAR"))
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

            if (command.Equals("RESET"))
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
                if (command.Equals("FILL"))
                {
                    if (parserUpdate.parameters == null)
                    {
                        throw new FormatException("Invalid parameter");
                    }
                    else if (parserUpdate.parameters.Equals("ON"))
                    {
                        isFilling = true;
                    }
                    else if (parserUpdate.parameters.Equals("OFF"))
                    {
                        isFilling = false;
                    }
                }
            }
            catch (FormatException) { errorLabel.Text = "Invalid Command - Fill <ON> or <OFF>"; }
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

            else { errorLabel.Text = "Invalid Command"; }
        } // End of Method

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
            this.errorLabel = errorLabel;
            PositionLabel = LablePosition;
            this.isFilling = isFilling;
            this.programmingArea = programmingArea;
        }
    }
}
