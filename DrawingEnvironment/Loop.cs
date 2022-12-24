using System;
using System.Collections.Generic;

namespace DrawingEnvironment
{
    /// <summary>
    /// This simulates a for loop into the Drawing environment.
    /// </summary>
    internal class Loop : Command
    {
        internal Dictionary<string, int> PresentVariables = new Dictionary<string, int>();
        internal Expression condition;
        internal List<Command> loopBody; // TODO: implementing the list to execute
        internal string UpdateExpression; // The increment or decrement expression
        internal bool IsExecuting = true;

        /// <summary>
        /// It check if the condition given by the expression is met, this allows the execution of the loop
        /// </summary>
        /// <param name="expression">the second element of the for loop</param>
        /// <returns>true if the condition is not met the loop can still go, false otherwise</returns>
        public void SetCondition(Expression expression)
        {
            string variableName = expression.ExpressionElements[0];
            int variableValue = Convert.ToInt32(expression.ExpressionElements[1]);

            switch (expression.operation)
            {
                case ">":
                    if (PresentVariables[variableName] > variableValue)
                    {
                        IsExecuting = false;
                        break;
                    }
                    else
                    {
                        IsExecuting = true;
                        break;
                    }

                case "<":
                    if (PresentVariables[variableName] < variableValue)
                    {
                        IsExecuting = false;
                        break;
                    }
                    else
                    {
                        IsExecuting = true;
                        break;
                    }

                default:
                    IsExecuting = true;
                    break;
            }
        }

        /// <summary>
        /// It updates the Variable to meet the condition for execution
        /// </summary>
        /// <param name="updateComponent">the component of the loop to update which is like a variable</param>
        /// <exception cref="ArgumentException">If there is no value it will throw an error</exception>
        public void UpdateVariableValue(string updateComponent)
        {
            string[] updateElements = updateComponent.Split('=');
            if (PresentVariables.ContainsKey(updateElements[0]))
            {
                Expression expression = new Expression(updateElements[0], PresentVariables);
                string result = expression.CalculateExpression();
                int calculateValue = Convert.ToInt32(result);

                PresentVariables[updateElements[0]] = calculateValue;
            }

            else { throw new ArgumentException("Variable not found!"); }
        }

        public Loop(Dictionary<string, int> dictionaryVariables, List<Command> loopBody, Expression condition, string updateComponent)
        {
            this.loopBody = loopBody;
            PresentVariables = dictionaryVariables;
            this.condition = condition;
            this.UpdateExpression = updateComponent;
        }
    }
}
