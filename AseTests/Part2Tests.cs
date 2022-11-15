using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AseTests
{
    /// <summary>
    /// Tests designed for part 2.
    /// They will be implemented now but they are expected to fail at the moment.
    /// During the development of part 2, the aim will be them to pass.
    /// </summary>
    [TestClass]
    public class Part2Tests
    {
        /// <summary>
        /// Testing the variables if they take a specific value
        /// </summary>
        [TestMethod]
        public void TestVariables()
        {
            // set up
            Parser parser = new Parser();

            // act
            Variable variable = (Variable)parser.ParseCommands("x = 5");

            // assert
            Assert.AreEqual(variable.parameters, 5);
        }

        /// <summary>
        /// Testing if a variable will be associated to a command.
        /// In this case x and y will be allocated a value and the command will use the value to use a command.
        /// </summary>
        [TestMethod]
        public void TestVariables_With_CommandsTakingVariables()
        {
            // set up
            Parser parser = new Parser();
            string input = "x=5\ny=10\ndrawto x,y";
            // act
            Variable variable = (Variable)parser.ParseCommands(input);
            Command command = (Command)parser.ParseCommands(input);
            // Assert
            Assert.AreEqual(variable.parameters[0], 5);
            Assert.AreEqual(variable.parameters[1], 10);
            Assert.IsTrue(variable.name == "DRAWTO");
        }

        /// <summary>
        /// Testing if statement and assigning right variables to the commands in use.
        /// </summary>
        [TestMethod]
        public void TestVariables_With_IfStatement()
        {
            // set up
            Parser parser = new Parser();
            string input = "if x=5\nrectangle 5,5\ncircle 5\nendif";
            Rectangle rectangle = new Rectangle(0, 0, 5,5);
            // act
            Variable var = (Variable)parser.ParseCommands(input);
            List<Command> command = parser.ParseCommandMultiLine(input);
            // assert
            Assert.AreEqual("RECTANGLE", command[0].name);
            Assert.AreEqual(new int[] {5,5}, var.parameters);
            Assert.AreEqual("CIRCLE", command[1].name);
        }
    }
}
