using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AseTests
{
    /// <summary>
    /// It tests the methods declaration and variables stored, also the method body
    /// </summary>
    [TestClass]
    public class MethodTests
    {
        /// <summary>
        /// It tests the method declaration
        /// </summary>
        [TestMethod]
        public void Test_MethodDeclaration()
        {
            // Set up
            Parser parser = new Parser();
            string input = "method testingmethod(a,b)\ncircle a\ntriangle b\nendmethod";

            // Act
            parser.ParseCommandMultiLine(input);
            Method actualMethod = parser.Methods.Single();
            
            // Assert
            Assert.IsNotNull(actualMethod);
            Assert.AreEqual(actualMethod.Name, "TESTINGMETHOD");
            Assert.AreEqual(actualMethod.Parameters, "A,B");
            // Checking the variables which by default would be value 0 when not used
            Assert.AreEqual(actualMethod.Variables.Count, 2);
            Assert.IsTrue(actualMethod.Variables.ContainsKey("A"));
            Assert.IsTrue(actualMethod.Variables.ContainsKey("B"));
            Assert.AreEqual(actualMethod.Variables["A"], 0);
            Assert.AreEqual(actualMethod.Variables["B"], 0);
        }

        /// <summary>
        /// Testing the method variables assignment
        /// </summary>
        [TestMethod]
        public void Test_MethodVariables()
        {
            // Set up
            Parser parser = new Parser();
            string input = "method testingmethod(a,b)\ncircle a\ntriangle b\nendmethod\ntestingmethod(10,15)";

            // Act
            parser.ParseCommandMultiLine(input);
            Method actualMethod = parser.Methods.Single();
            
            // Assert
            Assert.IsTrue(parser.CommandList.Count == 1);
            Assert.IsTrue(parser.CommandList[0].GetType().Equals( typeof(Method)));
            Assert.IsTrue(parser.CommandList[0].Name.Equals("TESTINGMETHOD"));
            // Checking the updated variables when method called
            Assert.AreEqual(actualMethod.Variables["A"], 10);
            Assert.AreEqual(actualMethod.Variables["B"], 15);
            // Asserting if the commands in the method body have the right parameters
            Assert.AreEqual(actualMethod.MethodBody[0].Name, "CIRCLE");
            Assert.AreEqual(actualMethod.MethodBody[0].Parameters[0], 10);
            Assert.AreEqual(actualMethod.MethodBody[1].Name, "TRIANGLE");
            Assert.AreEqual(actualMethod.MethodBody[1].Parameters[0], 15);
        }
    }
}
