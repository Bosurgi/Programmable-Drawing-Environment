using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingEnvironment;
using Rectangle = DrawingEnvironment.Rectangle;

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
        Pen pen;
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
        /// Testing Parameter error - Multiple lines
        /// </summary>
        [TestMethod]
        public void executingService_WithParameterError_multilineParameter()
        {
            // Set up
            g = pictureBox.CreateGraphics();
            ServiceExecute ex = new ServiceExecute(g, pen, cursor, ErrorLabel, LabelPosition, isFilling, programArea);
            
            string command = "moveto 100,20\ncircle x";
            string ErrorMessage = "Invalid parameters at line: 2\nCircle <Radius>";
            // Act
            try
            {
                
                ex.ExecuteService(command);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                Assert.AreEqual(ErrorLabel.Text, ErrorMessage);
            }
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
            catch (ArgumentOutOfRangeException e)
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
        public void executeCommand_Rectangle()
        {
            // Set up
            Rectangle rect;
            g = pictureBox.CreateGraphics();
            ServiceExecute ex = new ServiceExecute(g, pen, cursor, ErrorLabel, LabelPosition, isFilling, programArea);
            Command createRectangle = new Command("RECTANGLE", new int[] { 10, 30 });
            
            // Act
            ex.Execute(createRectangle.name, createRectangle.parameters);

            // Assert
            
        }
    }
}
