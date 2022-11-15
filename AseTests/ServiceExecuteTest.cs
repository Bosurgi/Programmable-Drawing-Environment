using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AseTests
{
    /// <summary>
    /// This class will test the ServiceExecute class, which executes various commands.
    /// In this way other classes will be tested as the service will take from a parsed commands its parameters and the commands.
    /// It will then execute the command if valid and return a shape or other functions.
    /// </summary>
    [TestClass]
    public class ServiceExecuteTest
    {
        /// <summary>
        /// Initialising the component needed for the service to be initialised.
        /// </summary>
        Graphics g;
        Pen pen = new Pen(Color.White);
        Parser parser = new Parser();
        CustomCursor cursor = new CustomCursor();
        Label ErrorLabel = new Label();
        Label LabelPosition = new Label();
        bool isFilling;
        TextBox programArea = new TextBox();
        PictureBox pictureBox = new PictureBox();

        /// <summary>
        /// Testing the Service executing with empty commands.
        /// </summary>
        [TestMethod]
        public void executingServiceWithEmptyCommand()
        {
            // Set up
            ServiceExecute ex = new ServiceExecute(g, pen, cursor, ErrorLabel, LabelPosition, isFilling, programArea);
            string command = "";
            string errorMessage;

            // Act
            try
            {
                ex.ExecuteService(command);
            }
            catch (ArgumentException e)
            {
                errorMessage = e.Message;
                // Assert
                Assert.AreEqual("Insert a valid command", errorMessage);
            }
        }
        /// <summary>
        /// Testing Parameter errors - Single line
        /// </summary>
        [TestMethod]
        public void executingService_WithParameterError()
        {
            // Set up
            ServiceExecute ex = new ServiceExecute(g, pen, cursor, ErrorLabel, LabelPosition, isFilling, programArea);
            string command = "moveto x,x";

            // Act
            try
            {
                ex.ExecuteService(command);
            }
            catch (FormatException e)
            {

                // Assert
                Assert.AreEqual(ErrorLabel, "Invalid Parameter");
            }
        }
        /// <summary>
        /// Testing Command Error - Single line
        /// </summary>
        [TestMethod]
        public void executingService_WithCommandError()
        {
            // Set up
            ServiceExecute ex = new ServiceExecute(g, pen, cursor, ErrorLabel, LabelPosition, isFilling, programArea);
            string command = "move 100,20";
            string ErrorMessage = "Error at line: 1" + "\n" + "MOVE is not a valid command.";
            // Act
            try
            {
                ex.ExecuteService(command);
            }
            catch (FormatException e)
            {
                // Assert
                Assert.AreEqual(ErrorMessage, e.Message);
            }
        }

        /// <summary>
        /// Testing Parameter error - With single line
        /// </summary>
        [TestMethod]
        public void executingService_WithParameterError_SingleLineParameter()
        {
            // Set up
            g = pictureBox.CreateGraphics();
            ServiceExecute ex = new ServiceExecute(g, pen, cursor, ErrorLabel, LabelPosition, isFilling, programArea);

            string command = "circle x";
            string ErrorMessage = "Line: 1 Not numerical parameter";
            // Act
            ex.ExecuteService(command);

            // Assert
            Assert.AreEqual(ErrorMessage, ErrorLabel.Text);
        }

        /// <summary>
        /// Testing Parameter error - Multiple lines
        /// </summary>
        [TestMethod]
        public void executingService_WithParameterError_multilineParameter()
        {
            // Set up
            g = pictureBox.CreateGraphics();
            ServiceExecute ex = new ServiceExecute(g, pen, cursor, ErrorLabel, LabelPosition, isFilling, programArea);

            string command = "moveto 100,20\ncircle x";
            string ErrorMessage = "Line: 2 Not numerical parameter";
            // Act
            ex.ExecuteService(command);

            // Assert
            Assert.AreEqual(ErrorMessage, ErrorLabel.Text);
        }

        /// <summary>
        /// Testing Command Error - multiple lines
        /// </summary>
        [TestMethod]
        public void executingService_WithCommandError_multilineCommand()
        {
            // Set up
            g = pictureBox.CreateGraphics();
            ServiceExecute ex = new ServiceExecute(g, pen, cursor, ErrorLabel, LabelPosition, isFilling, programArea);

            string command = "moveto 100,20\ncir 30";
            string ErrorMessage = "Error at line: 2" + "\n" + "CIR is not a valid command.";
            // Act
            try
            {

                ex.ExecuteService(command);
            }
            catch (ArgumentOutOfRangeException)
            {
                // Assert
                Assert.AreEqual(ErrorLabel.Text, ErrorMessage);
            }
        }

        /// <summary>
        /// Testing the Execute method to execute commands.
        /// </summary>
        [TestMethod]

        /// Testing Rectangle
        public void executeCommand_Rectangle_withWrongInput()
        {
            // Set up
            g = pictureBox.CreateGraphics();
            ServiceExecute ex = new ServiceExecute(g, pen, cursor, ErrorLabel, LabelPosition, isFilling, programArea);


            // Act
            try
            {
                Command rectCommand = parser.ParseCommands("Rectangle 40,x");
                //ex.Execute(rectCommand.name, rectCommand.parameters);
                ex.Execute(rectCommand);
            }

            catch (ArgumentException e)
            {
                // Assert
                Assert.AreEqual("Not numerical parameter", e.Message);
            }
        }

        /// <summary>
        /// Testing the rectangle with an empty parameter
        /// </summary>
        [TestMethod]

        /// Testing Rectangle
        public void executeCommand_Rectangle_withEmptyInput()
        {
            // Set up
            g = pictureBox.CreateGraphics();
            ServiceExecute ex = new ServiceExecute(g, pen, cursor, ErrorLabel, LabelPosition, isFilling, programArea);
            Command rectCommand = parser.ParseCommands("Rectangle ");

            // Act
            try
            {
                ex.Execute(rectCommand);
            }

            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                Assert.AreEqual("Not numerical parameter", e.Message);
            }
        }

        /// <summary>
        /// Testing circle with wrong non numerical input.
        /// </summary>
        [TestMethod]

        /// Testing Circle
        public void executeCommand_Circle_withWrongInput()
        {
            // Set up
            g = pictureBox.CreateGraphics();
            ServiceExecute ex = new ServiceExecute(g, pen, cursor, ErrorLabel, LabelPosition, isFilling, programArea);

            // Act
            try
            {
                Command rectCommand = parser.ParseCommands("Circle x");
                ex.Execute(rectCommand);
            }

            catch (ArgumentException e)
            {
                // Assert
                Assert.AreEqual("Not numerical parameter", e.Message);
            }
        }

        /// <summary>
        /// Testing Error of parameter with wrong number on second line
        /// </summary>
        [TestMethod]
        public void executingService_WithCommandError_multilineCommandWithWrongNumOfParameters()
        {
            // Set up
            g = pictureBox.CreateGraphics();
            ServiceExecute ex = new ServiceExecute(g, pen, cursor, ErrorLabel, LabelPosition, isFilling, programArea);

            string command = "moveto 100,20\ncircle 30,20";
            string ErrorMessage = "Invalid parameters at line: 2\nCircle <Radius>";
            // Act
            ex.ExecuteService(command);
            // Assert
            Assert.AreEqual(ErrorLabel.Text, ErrorMessage);
        }
    }
}
