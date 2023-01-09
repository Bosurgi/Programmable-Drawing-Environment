using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AseTests
{
    /// <summary>
    /// Testing the expressions, the operators declared and the mathematical operation
    /// using DataTables, with division, substraction, addition and multiplications.
    /// </summary>
    [TestClass]
    public class ExpressionTest
    {
        Dictionary<string, int> dummyDictionary = new Dictionary<string, int>();

        /// <summary>
        /// Testing wheter the appropriate operator is set for the expressionAddition.
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

        /// <summary>
        /// Testing the calculation of the expressionAddition declared with Addition
        /// </summary>
        [TestMethod]
        public void TestExpression_CalculatingExpressions_Addition()
        {
            // Set up
            Dictionary<string, int> Variables = new Dictionary<string, int>()
            {
                {"A", 10},
                {"B", 50},
            };
            string addition = "a+b";

            // Act
            Expression expressionAddition = new Expression(addition, Variables);

            // Assert
            Assert.IsTrue(expressionAddition.ExpressionElements.Length == 2);
            Assert.IsTrue(expressionAddition.operation.Equals("+"));
            Assert.AreEqual("60", expressionAddition.CalculateExpression());
        }

        /// <summary>
        /// Testing the calculation of the expressionAddition declared with Substraction
        /// </summary>
        [TestMethod]
        public void TestExpression_CalculatingExpressions_Substraction()
        {
            // Set up
            Dictionary<string, int> Variables = new Dictionary<string, int>()
            {
                {"A", 10},
                {"B", 50},
            };

            string substraction = "b-a";

            // Act
            Expression expression = new Expression(substraction, Variables);

            // Assert
            Assert.IsTrue(expression.ExpressionElements.Length == 2);
            Assert.IsTrue(expression.operation.Equals("-"));
            Assert.AreEqual("40", expression.CalculateExpression());
        }

        /// <summary>
        /// Testing the calculation of the expressionAddition declared with Multiplication
        /// </summary>
        [TestMethod]
        public void TestExpression_CalculatingExpressions_Multiplication()
        {
            // Set up
            Dictionary<string, int> Variables = new Dictionary<string, int>()
            {
                {"A", 10},
                {"B", 50},
            };

            string multiplication = "b*a";

            // Act
            Expression expression = new Expression(multiplication, Variables);

            // Assert
            Assert.IsTrue(expression.ExpressionElements.Length == 2);
            Assert.IsTrue(expression.operation.Equals("*"));
            Assert.AreEqual("500", expression.CalculateExpression());
        }

        /// <summary>
        /// Testing the calculation of the expressionAddition declared with Division
        /// </summary>
        [TestMethod]
        public void TestExpression_CalculatingExpressions_Division()
        {
            // Set up
            Dictionary<string, int> Variables = new Dictionary<string, int>()
            {
                {"A", 20},
                {"B", 5},
            };

            string substraction = "a/b";

            // Act
            Expression expression = new Expression(substraction, Variables);

            // Assert
            Assert.IsTrue(expression.ExpressionElements.Length == 2);
            Assert.IsTrue(expression.operation.Equals("/"));
            Assert.AreEqual("4", expression.CalculateExpression());
        }

    }
}
