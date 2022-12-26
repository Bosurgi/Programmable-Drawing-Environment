using System;
using System.Collections.Generic;

namespace DrawingEnvironment
{
    /// <summary>
    /// This simulates a for loop into the Drawing environment.
    /// </summary>
    internal class Loop : Command
    {
        internal List<Variable> variables = new List<Variable>();
        internal Variable variable;

        internal Dictionary<string, int> PresentVariables = new Dictionary<string, int>();
        internal Expression condition; // the comparison condition
        internal List<Command> loopBody; // Commands part of the loop body
        internal string UpdateExpression; // The increment or decrement expression
        internal bool IsExecuting = true; // Executing flag

        /// <summary>
        /// It check if the condition given by the expression is met, this allows the execution of the loop
        /// </summary>
        /// <param name="expression">the second element of the for loop</param>
        /// <returns>true if the condition is not met the loop can still go, false otherwise</returns>
        public void SetCondition(Expression expression)
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
        /// It updates the Variable to meet the condition for execution
        /// </summary>
        /// <param name="updateComponent">the component of the loop to update which is a variable value</param>
        /// <exception cref="ArgumentException">If there is no value it will throw an error</exception>
        public void UpdateVariableValue(string updateComponent)
        {
            string[] updateElements = updateComponent.ToUpper().Trim().Split('=');
            // Checking if the variable is in the dictionary
            if (PresentVariables.ContainsKey(updateElements[0]))
            {   
                // If it is it will calculate the expression and update its value in the dictionary
                Expression expression = new Expression(updateElements[1], PresentVariables);
                string result = expression.CalculateExpression();
                int calculateValue = Convert.ToInt32(result);
                int[] valueArray = { calculateValue };
                // Updating its value in the dictionary
                PresentVariables[updateElements[0]] = calculateValue;
                // Updating the variables present for the loop
                variable = new Variable(updateElements[0], valueArray);
                // Adding it into the list
                variables.Add(variable);
            }

            else { throw new ArgumentException("Variable not found!"); }
        }

        /// <summary>
        /// Constructor representing the loop.
        /// </summary>
        /// <param name="dictionaryVariables">the variables presents in the loop</param>
        /// <param name="loopBody">the commands that needs to be executed</param>
        /// <param name="condition">the loop condition to be executed</param>
        /// <param name="updateComponent">the increment or decrement component of the loop</param>
        public Loop(Dictionary<string, int> dictionaryVariables, List<Command> loopBody, Expression condition, string updateComponent)
        {
            this.loopBody = loopBody;
            PresentVariables = dictionaryVariables;
            this.condition = condition;
            this.UpdateExpression = updateComponent;
        }
    }
}
