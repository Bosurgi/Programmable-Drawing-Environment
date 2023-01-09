using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AseTests
{
    /// <summary>
    /// It tests the evaluation of if statements, assignment and expressions
    /// </summary>
    [TestClass]
    public class IfTest
    {
        /// <summary>
        /// Testing the declaration of if statement and if block
        /// </summary>
        [TestMethod]
        public void TestIfDeclaration_withFalseLogicExpression()
        {
            // Set up
            Parser parser = new Parser();
            string input = "a=10\nb=50\nif a>b\ncircle a\nendif";

            // Act
            parser.ParseCommandMultiLine(input);
            IfStatement ifStatement = parser.ifStatement;
            ifStatement.EvaluateExpression(ifStatement.IfExpression);

            // Assert
            Assert.IsTrue(ifStatement != null);
            Assert.IsTrue(ifStatement.IfExpression != null);
            Assert.AreEqual("A", ifStatement.IfExpression.ExpressionElements[0]);
            Assert.AreEqual("B", ifStatement.IfExpression.ExpressionElements[1]);
            Assert.AreEqual(">", ifStatement.IfExpression.operation);
            Assert.AreEqual(false, ifStatement.IsExecuting);
        }

        /// <summary>
        /// Testing the declaration of if statement and if block
        /// </summary>
        [TestMethod]
        public void TestIfDeclaration_withTrueLogicExpression()
        {
            // Set up
            Parser parser = new Parser();
            string input = "a=10\nb=50\nif a<b\ncircle a\nendif";

            // Act
            parser.ParseCommandMultiLine(input);
            IfStatement ifStatement = parser.ifStatement;
            ifStatement.EvaluateExpression(ifStatement.IfExpression);

            // Assert
            Assert.IsTrue(ifStatement != null);
            Assert.IsTrue(ifStatement.IfExpression != null);
            Assert.AreEqual("A", ifStatement.IfExpression.ExpressionElements[0]);
            Assert.AreEqual("B", ifStatement.IfExpression.ExpressionElements[1]);
            Assert.AreEqual("<", ifStatement.IfExpression.operation);
            Assert.AreEqual(true, ifStatement.IsExecuting);
            Assert.IsTrue(ifStatement.IfBody != null);
            Assert.IsTrue(ifStatement.IfBody.Count == 1);
            Assert.AreEqual("CIRCLE", ifStatement.IfBody[0].Name);
            Assert.AreEqual(10, ifStatement.IfBody[0].Parameters[0]);
        }
    }
}
