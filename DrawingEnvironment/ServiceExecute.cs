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
