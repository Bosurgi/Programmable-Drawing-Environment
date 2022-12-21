using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace DrawingEnvironment
{
    /// <summary>
    /// Representation of a mathematical expression using normal operators.
    /// </summary>
    internal class Expression
    {
        /// <summary>
        /// The expression contained as a string
        /// </summary>
        string Espressione;

        /// <summary>
        /// Dictionary where the variables are stored to evaluate them
        /// </summary>
        public Dictionary<string, int> VariableDictionary = new Dictionary<string, int>();

        /// <summary>
        /// The single elements of the expression divided
        /// </summary>
        string[] ExpressionElements;

        /// <summary>
        /// It calculates the mathematical expression for between numbers and variables
        /// </summary>
        /// <returns>the result of the mathematical expression</returns>
        public string CalculateExpression()
        {
            // TODO: implementing error handling
            // If there is no variables the method will process numerical values
            if (VariableDictionary.Count > 0)
            {
                for (int i = 0; i < ExpressionElements.Length; i++)
                {
                    /* If a variable with the name of the specific element is found it will convert
                     * get the value corresponding to that variable and
                     * replace the element of the expression with its value converted to string
                     * then it will proceed with the normal operation.
                     */
                    if (VariableDictionary.ContainsKey(ExpressionElements[i]))
                    {
                        string valueToString = Convert.ToString(VariableDictionary[ExpressionElements[i]]);
                        Espressione = Espressione.Replace(ExpressionElements[i], valueToString);
                    }                   
                }
            }
            // Computing the expression with Compute method
            string result = new DataTable().Compute(Espressione, "").ToString();
            return result;
        }

        /// <summary>
        /// It divides the operands found in the expression by mathematical operators.
        /// </summary>
        /// <param name="expression">the mathematical expression passed by the user.</param>
        /// <returns>an array of strings with each single element of the expression</returns>
        public string[] DivideOperands(string expression)
        {
            string pattern = @"-|\+|\*|\/|\<|\>";
            Regex rg = new Regex(pattern);

            return rg.Split(expression);
        }

        /// <summary>
        /// Constructor defining the expression
        /// </summary>
        /// <param name="input">the user's input</param>
        /// <param name="variableDictionary">the stored variables</param>
        public Expression(string input, Dictionary<string, int> variableDictionary)
        {
            VariableDictionary = variableDictionary;
            Espressione = input;
            ExpressionElements = DivideOperands(input);
        }
    }
}
