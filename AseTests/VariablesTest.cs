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
    public class VariablesTest
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
            parser.ParseCommandMultiLine(input);
            Dictionary<string, int> variableValues = parser.VariableDictionary;
            // Assert
            Assert.AreEqual(2, variableValues.Count);
            Assert.AreEqual(5, variableValues["X"]);
            Assert.AreEqual(10, variableValues["Y"]);
            Assert.AreEqual(5, parser.CommandList[2].Parameters[0]);
            Assert.AreEqual(10, parser.CommandList[2].Parameters[1]);
            Assert.AreEqual("DRAWTO", parser.CommandList[2].Name);
        }
    }
}
