using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    internal class ServiceExecute
    {
        Graphics g;
        Pen pen;
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
                        pointer.SetColour(Color.White);

                        // Updating the cursor
                        PositionLabel.Text = "X: " + pointer.X.ToString() + " ,Y: " + pointer.Y.ToString();
                    }
                    catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                    catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Moveto <x Value> <y Value>"; }

                }
                // Command Circle draw a circle
                try
                {
                    if (organizedCommands[0].Equals("CIRCLE"))
                    {
                        List<int> parameters = parser.AssigningParameters(command);
                        Circle circle = new Circle(pointer.X, pointer.Y, parameters[0]);

                        /*
                        // New code to test
                        shapeDrawn = true;
                        */

                        circle.Draw(g);
                    }
                }
                catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Circle <Radius>"; }

                try
                {
                    if (organizedCommands[0].Equals("TRIANGLE"))
                    {
                        List<int> parameters = parser.AssigningParameters(command);
                        Triangle tri = new Triangle(parameters[0], pen, pointer.X, pointer.Y);
                        tri.Draw(g);
                    }
                }
                catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Circle <Radius>"; }

                // Command to draw a line from the pointer to a set point
                // TODO: adding try catch to deal with invalid parameters.
                try
                {
                    if (organizedCommands[0].Equals("DRAWTO"))
                    {
                        List<int> parameters = parser.AssigningParameters(command);
                        g.DrawLine(pen, pointer.X, pointer.Y, parameters[0], parameters[1]);
                        pointer.UpdatePosition(parameters[0], parameters[1], g);
                        // Update label positions
                        PositionLabel.Text = "X: " + pointer.X.ToString() + " ,Y: " + pointer.Y.ToString();
                    }
                }
                catch (FormatException) { errorLabel.Text = "Invalid Parameter"; }
                catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - drawTo <x Value> <y Value>"; }

                try
                {
                    if (organizedCommands[0].Equals("CLEAR"))
                    {
                        // Refreshing the canvas without deleting the pointer.                      
                        g.Clear(Color.Black);
                        pointer.Draw(g);

                    }
                }
                catch (FormatException) { errorLabel.Text = "Invalid Command"; }
                catch (ArgumentOutOfRangeException) { errorLabel.Text = "Invalid parameters - Clear"; }
            }
            else
            {
                errorLabel.Text = "Invalid command";
            }
        } // End of method

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="parser"></param>
        /// <param name="cmd"></param>
        /// <param name="organizedCommands"></param>
        /// <param name="factory"></param>
        /// <param name="pointer"></param>
        /// <param name="errorLabel"></param>
        /// <param name="xPosition"></param>
        /// <param name="yPosition"></param>
        public ServiceExecute(Graphics g, Pen pen, Parser parser, string command, string[] organizedCommands, CustomCursor pointer, Label errorLabel, Label LablePosition)
        {
            this.g = g;
            this.pen = pen;
            this.parser = parser;
            this.organizedCommands = organizedCommands;
            //this.factory = factory;
            this.pointer = pointer;
            this.errorLabel = errorLabel;
            PositionLabel = LablePosition;
        }

        public ServiceExecute(Graphics g)
        {
            this.g = g;
        }
    }
}
