using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    internal class IfStatement : Command
    {
        internal List<Command> IfBody = new List<Command>();

        internal List<Variable> Variables = new List<Variable>();

        internal Dictionary<string, int> PresentVariables = new Dictionary<string, int>();

        internal Expression IfExpression;

        internal bool IsExecuting = true;

        /// <summary>
        /// It evaluates the expression and checks if it can execute the body of the if
        /// </summary>
        /// <param name="expression">the expression to evaluate</param>
        public void EvaluateExpression(Expression expression)
        {
            string variableName = expression.ExpressionElements[0].ToUpper().Trim();
            int variableValue = Convert.ToInt32(expression.ExpressionElements[1]);

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
