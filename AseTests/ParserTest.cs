using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AseTests
{
    [TestClass]
    public class ParserTest
    {
        DrawingEnvironment.Parser parser = new Parser();
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

        [TestMethod]
        public void isNotValid_withValidCommandsLowerCase()
        {
            // Set up
            var input = "dra 10,40";

            // Act
            Command command = parser.ParseCommands(input);
            bool actual = parser.isValidCommand(input);

            // Assert
            Assert.IsNotNull(command);
            Assert.IsNotNull(actual);
            Assert.IsFalse(actual);
        }

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
    }
}
