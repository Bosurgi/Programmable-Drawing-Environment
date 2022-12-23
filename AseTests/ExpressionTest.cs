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
    /// Testing the expressions generated for Part 2
    /// </summary>
    [TestClass]
    public class ExpressionTest
    {
        Dictionary<string, int> dummyDictionary= new Dictionary<string, int>();

        /// <summary>
        /// Testing wheter the appropriate operator is set for the expression.
        /// </summary>
        [TestMethod]
        public void testExpression_Operators()
        {
            // Set up
            string input = "a/5";
            string input2 = "b>10";
            string input3 = "1+5";

            // Act
            Expression divisionExpression = new Expression(input, dummyDictionary);
            Expression greaterThanExpression = new Expression(input2, dummyDictionary);
            Expression additionExpression = new Expression(input3, dummyDictionary);

            // Assert
            Assert.AreEqual("/", divisionExpression.operation);
            Assert.AreEqual(">", greaterThanExpression.operation);
            Assert.AreEqual("+", additionExpression.operation);
        }

    }
}
