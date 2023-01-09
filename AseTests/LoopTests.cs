using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseTests
{
    /// <summary>
    /// This class represents tests for the Loops introduced for the Drawing Environment program.
    /// It tests the Loop body parsed correctly, the expressions, and the variable assignment.
    /// </summary>
    [TestClass]
    public class LoopTests
    {
        /// <summary>
        /// Testing if a loop block is detected and parsed correctly
        /// </summary>
        [TestMethod]
        public void LoopTest_TestParseTheLoopDeclaration()
        {
            // Set up
            Parser parser = new Parser();
            string input = "for a=10;a>0;a=a-1\nendfor";
            Variable a = new Variable("A", new int[] { 10 } );
            
            // Act
            parser.ParseCommandMultiLine(input);

            // Assert
            // Testing the for loops elements are divided properly
            Assert.AreEqual("a=10", parser.LoopElements[0]);
            Assert.AreEqual("a>0", parser.LoopElements[1]);
            Assert.AreEqual("a=a-1", parser.LoopElements[2]);
            // Testing the variable
            Assert.AreEqual( a.Name, parser.loopVar.Name);
            Assert.AreEqual(a.Parameters[0], parser.loopVar.Parameters[0]);
        }

        /// <summary>
        /// It tests if the loop block works and detects the right element stored into the parser.
        /// </summary>
        [TestMethod]
        public void LoopTest_TestLoopBlock()
        {
            // Set up
            Parser parser = new Parser();
            string input = "for a=10;a>0;a=a-1\ncircle a\nrectangle a,a\nendfor";            

            // Act
            parser.ParseCommandMultiLine(input);
            Loop actualLoop = parser.loop;

            // Assert
            Assert.IsTrue(actualLoop.PresentVariables.ContainsKey("A"));
            Assert.IsTrue(actualLoop.PresentVariables["A"].Equals(10));
            Assert.AreEqual(actualLoop.loopBody.Count, 2);
            Assert.AreEqual(actualLoop.loopBody[0].Name, "CIRCLE");
            Assert.AreEqual(actualLoop.loopBody[1].Name, "RECTANGLE");
        }

    }
}
