using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    /// <summary>
    /// The if Statement class which allows the execution of logical operations
    /// Use of Chain of resposibility pattern in Loops and Ifs
    /// </summary>
    internal class IfStatement : Command
    {
        /// <summary>
        /// The if Body containing the commands to execute
        /// </summary>
        internal List<Command> IfBody = new List<Command>();
        /// <summary>
        /// The list of variables declared
        /// </summary>
        internal List<Variable> Variables = new List<Variable>();
        /// <summary>
        /// The Dictionary containing the keys and values for the variables
        /// </summary>
        internal Dictionary<string, int> PresentVariables = new Dictionary<string, int>();
        /// <summary>
        /// The if condition
        /// </summary>
        internal Expression IfExpression;
        /// <summary>
        /// The flag for the if condition if executing or not
        /// </summary>
        internal bool IsExecuting = true;

        /// <summary>
        /// It evaluates the expression and checks if it can execute the body of the if
        /// </summary>
        /// <param name="expression">the expression to evaluate</param>
        public void EvaluateExpression(Expression expression)
        {
            int variableValue;
            string variableName = expression.ExpressionElements[0];

            // Checking if the second element of the expression is a Variable
            if (PresentVariables.ContainsKey(expression.ExpressionElements[1]))
            {
                variableValue = PresentVariables[expression.ExpressionElements[1]];
            }
            // if not it will convert the value to integer
            
            else { variableValue = Convert.ToInt32(expression.ExpressionElements[1]); }

            switch (expression.operation)
            {
                case ">":
                    if (PresentVariables[variableName] > variableValue)
                    {
                        IsExecuting = true;
                        break;
                    }
                    else
                    {
                        IsExecuting = false;
                        break;
                    }

                case "<":
                    if (PresentVariables[variableName] < variableValue)
                    {
                        IsExecuting = true;
                        break;
                    }
                    else
                    {
                        IsExecuting = false;
                        break;
                    }

                default:
                    IsExecuting = true;
                    break;
            }
        }

        /// <summary>
        /// Constructor for the If statement.
        /// </summary>
        /// <param name="presentVariables">the variables declared</param>
        /// <param name="ifExpression">the condition set by the if statement</param>
        /// <param name="IfBody">the body of the if statement to execute</param>
        public IfStatement(Dictionary<string, int> presentVariables, Expression ifExpression, List<Command> IfBody)
        {
            this.PresentVariables = presentVariables;
            this.IfExpression = ifExpression;
            this.IfBody = IfBody;
        }              
    }
}
