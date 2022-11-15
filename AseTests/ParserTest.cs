using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AseTests
{
    [TestClass]
    public class ParserTest
    {
        /// <summary>
        /// This test will test the Parser class present in the Drawing environment program.
        /// It will test the ParseCommand, Multiline parser, isValid method.
        /// </summary>
        DrawingEnvironment.Parser parser = new Parser();
        
        /// <summary>
        /// Testing if a command is a valid command.
        /// If it is it will return true, if not false
        /// </summary>
        [TestMethod]       
        public void TestValidating()
        {
            // Setting up
            string example = "Moveto 100,200";
            int[] expectedInt = { 100, 200 };

            // Act
            Command command = parser.ParseCommands(example);

            // Assert
            Assert.IsNotNull(command.parameters);
            Assert.AreEqual(command.parameters[0], expectedInt[0]);
            Assert.AreEqual(command.parameters[1], expectedInt[1]);
            Assert.AreNotEqual(command.parameters[0], expectedInt[1]);
            Assert.IsTrue(command.parameters.Length == 2);
            Assert.AreEqual(command.name, "MOVETO");
        }

        /// <summary>
        /// Testing the standardization of the command. It will be passed a lowercase command.
        /// </summary>
        [TestMethod]
        public void isValid_withValidCommandsLowerCase()
        {
            // Set up
            var input = "drawto 10,40";

            // Act
            Command command = parser.ParseCommands(input);
            bool actual = parser.isValidCommand(input);

            // Assert
            Assert.IsNotNull(command);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// Testing the standardization of the command. It will be passed an uppercase command.
        /// </summary>
        [TestMethod]
        public void isValid_withValidCommandsUpperCase()
        {
            // Set up
            var input = "DRAWTO 20,50";

            // Act
            Command command = parser.ParseCommands(input);
            bool actual = parser.isValidCommand(input);

            // Assert
            Assert.IsNotNull(command);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// Testing if the parser recognize an invalid command.
        /// </summary>
        [TestMethod]
        public void isNotValid_withCommandLowerCase()
        {
            // Set up
            var input = "dra 10,40";
            int[] expectedParameters = { 10, 40 };

            // Act
            Command command = parser.ParseCommands(input);
            bool actual = parser.isValidCommand(input);

            // Assert
            Assert.IsNotNull(command);
            Assert.IsNotNull(actual);
            Assert.IsFalse(actual);
            Assert.AreEqual(command.parameters[0], expectedParameters[0]);
            Assert.AreEqual(command.parameters[1], expectedParameters[1]);
        }

        /// <summary>
        /// Testing if the parser recognize an invalid command with uppercase command.
        /// </summary>
        [TestMethod]
        public void isNotValid_withValidCommandsUpperCase()
        {
            // Set up
            var input = "DRA 10,40";

            // Act
            Command command = parser.ParseCommands(input);
            bool actual = parser.isValidCommand(input);

            // Assert
            Assert.IsNotNull(command);
            Assert.IsNotNull(actual);
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// Testing if the parser sets up the Fill on option correctly.
        /// </summary>
        [TestMethod]
        public void parseCommand_withFillOptionOn()
        {
            // Set up
            var input = "Fill on";
            int[] parameter = { 1 };

            // Act
            Command actualCommand = parser.ParseCommands(input);
            Command expectedCommand = new Command("FILL", parameter);

            // Assert
            Assert.IsNotNull(actualCommand);
            Assert.IsTrue(parser.isValidCommand(input));
            Assert.AreEqual(actualCommand.name, expectedCommand.name);
            Assert.AreEqual(actualCommand.parameters[0], expectedCommand.parameters[0]);
        }
        /// <summary>
        /// Testing if the parser sets up the Fill off option correctly.
        /// </summary>
        [TestMethod]
        public void parseCommand_withFillOptionOff()
        {
            // Set up
            var input = "Fill off";
            int[] parameter = { 0 };

            // Act
            Command actualCommand = parser.ParseCommands(input);
            Command expectedCommand = new Command("FILL", parameter);

            // Assert
            Assert.IsNotNull(actualCommand);
            Assert.IsTrue(parser.isValidCommand(input));
            Assert.AreEqual(actualCommand.name, expectedCommand.name);
            Assert.AreEqual(actualCommand.parameters[0], expectedCommand.parameters[0]);
        }

        /// <summary>
        /// Testing if the parser sets up an invalid parameter in fill command.
        /// </summary>
        [TestMethod]
        public void parseCommand_withInvalidFillOption()
        {
            // Set up
            var input = "Fill c";
            int[] parameter = { };

            // Act
            Command actualCommand = parser.ParseCommands(input);
            Command expectedCommand = new Command("FILL", parameter);

            // Assert
            Assert.IsNotNull(actualCommand);
            Assert.IsTrue(parser.isValidCommand(input));
            Assert.AreEqual(actualCommand.name, expectedCommand.name);
            Assert.IsTrue(actualCommand.parameters.Length == 0);
        }

        /// <summary>
        /// Testing if the parser is able to parse multiple lines of commands.
        /// </summary>
        [TestMethod]
        public void parseMultipleCommands_lowerCase()
        {
            // Set up
            var input = "drawto 10,30\nrectangle 10,20\ncircle 20";

            Command drawCommand = new Command("DRAWTO", new int[] { 10, 30 });
            Command rectangleCommand = new Command("RECTANGLE", new int[] { 10, 20 });
            Command circleCommand = new Command("CIRCLE", new int[] { 20 });

            // Act
            List<Command> actualCommand = parser.ParseCommandMultiLine(input);

            // Assert
            // Testing if it returns a list of commands
            Assert.IsNotNull(actualCommand);
            Assert.IsInstanceOfType(actualCommand, typeof(List<Command>));
            // Testing the name of the commands
            Assert.AreEqual(actualCommand[0].name, drawCommand.name);
            Assert.AreEqual(actualCommand[1].name, rectangleCommand.name);
            Assert.AreEqual(actualCommand[2].name, circleCommand.name);
            // Testing the parameters
            Assert.IsNotNull(actualCommand);
            Assert.AreEqual(actualCommand[0].parameters[0], drawCommand.parameters[0]);
            Assert.AreEqual(actualCommand[0].parameters[1], drawCommand.parameters[1]);
            Assert.AreEqual(actualCommand[1].parameters[0], rectangleCommand.parameters[0]);
            Assert.AreEqual(actualCommand[1].parameters[1], rectangleCommand.parameters[1]);
            Assert.AreEqual(actualCommand[2].parameters[0], circleCommand.parameters[0]);
            // Passing the parameters manually for each parameter
            Assert.AreEqual(actualCommand[0].parameters[0], 10);
            Assert.AreEqual(actualCommand[0].parameters[1], 30);
            Assert.AreEqual(actualCommand[1].parameters[0], 10);
            Assert.AreEqual(actualCommand[1].parameters[1], 20);
            Assert.AreEqual(actualCommand[2].parameters[0], 20);
        }

        /// <summary>
        /// Testing if the parser is able to parse multiple lines of commands in uppercase
        /// </summary>
        [TestMethod]
        public void parseMultipleCommands_UpperCase()
        {
            // Set up
            var input = "DRAWTO 10,30\nRECTANGLE 10,20\nCIRCLE 20";

            Command drawCommand = new Command("DRAWTO", new int[] { 10, 30 });
            Command rectangleCommand = new Command("RECTANGLE", new int[] { 10, 20 });
            Command circleCommand = new Command("CIRCLE", new int[] { 20 });

            // Act
            List<Command> actualCommand = parser.ParseCommandMultiLine(input);

            // Assert
            // Testing if it returns a list of commands
            Assert.IsNotNull(actualCommand);
            Assert.IsInstanceOfType(actualCommand, typeof(List<Command>));
            // Testing the name of the commands
            Assert.AreEqual(actualCommand[0].name, drawCommand.name);
            Assert.AreEqual(actualCommand[1].name, rectangleCommand.name);
            Assert.AreEqual(actualCommand[2].name, circleCommand.name);
            // Testing the parameters
            Assert.IsNotNull(actualCommand);
            Assert.AreEqual(actualCommand[0].parameters[0], drawCommand.parameters[0]);
            Assert.AreEqual(actualCommand[0].parameters[1], drawCommand.parameters[1]);
            Assert.AreEqual(actualCommand[1].parameters[0], rectangleCommand.parameters[0]);
            Assert.AreEqual(actualCommand[1].parameters[1], rectangleCommand.parameters[1]);
            Assert.AreEqual(actualCommand[2].parameters[0], circleCommand.parameters[0]);
            // Passing the parameters manually for each parameter
            Assert.AreEqual(actualCommand[0].parameters[0], 10);
            Assert.AreEqual(actualCommand[0].parameters[1], 30);
            Assert.AreEqual(actualCommand[1].parameters[0], 10);
            Assert.AreEqual(actualCommand[1].parameters[1], 20);
            Assert.AreEqual(actualCommand[2].parameters[0], 20);
        }

        /// <summary>
        /// Testing if the parser is able to parse multiple lines of commands displaying the error.
        /// </summary>
        [TestMethod]
        public void parseSingleCommand_WithInvalidNumberParameters()
        {
            // Set up
            var input = "circle 30 40";

            // Act
            try
            {
                List<Command> actualCommand = parser.ParseCommandMultiLine(input);
            }
            catch (ArgumentException e)
            {
                // Assert
                Assert.AreEqual("Invalid number of parameters", e.Message);
            }

        }
    }
}
