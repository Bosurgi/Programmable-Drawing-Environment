using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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
        /// Testing the variables if they take a specific value in lower case
        /// </summary>
        [TestMethod]
        public void TestVariablesValues_LowerCase()
        {
            // set up
            Parser parser = new Parser();

            // act
            Variable x = parser.ParseVariable("x=10");
            Variable y = parser.ParseVariable("y=100");


            // assert
            Assert.AreEqual(10, x.Parameters[0]);
            Assert.AreEqual(100, y.Parameters[0]);
        }

        /// <summary>
        /// Testing the variables if they take a specific value in upper case
        /// </summary>
        [TestMethod]
        public void TestVariablesValues_UpperCase()
        {
            // set up
            Parser parser = new Parser();

            // act

            Variable x = parser.ParseVariable("X=50");
            Variable y = parser.ParseVariable("Y=150");

            // Assert
            Assert.AreEqual(50, x.Parameters[0]);
            Assert.AreEqual(150, y.Parameters[0]);
        }

        /// <summary>
        /// Testing the variables if they take a specific name
        /// </summary>
        [TestMethod]
        public void TestVariablesName()
        {
            // set up
            Parser parser = new Parser();

            // act

            Variable x = parser.ParseVariable("X=50");
            Variable y = parser.ParseVariable("Y=150");

            // Assert
            Assert.AreEqual("X", x.Name);
            Assert.AreEqual("Y", y.Name);
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
            Assert.AreEqual(variable.Parameters[0], 5);
            Assert.AreEqual(variable.Parameters[1], 10);
            Assert.IsTrue(variable.Name == "DRAWTO");
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
            Assert.AreEqual("RECTANGLE", command[0].Name);
            Assert.AreEqual(new int[] {5,5}, var.Parameters);
            Assert.AreEqual("CIRCLE", command[1].Name);
        }
    }
}
