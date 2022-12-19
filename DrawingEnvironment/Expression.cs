using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        /// It calculates the mathematical expression.
        /// </summary>
        /// <returns></returns>
        public string CalculateExpression()
        {
            string result = new DataTable().Compute(Espressione, "").ToString();

            return result;
        }

        /// <summary>
        /// Constructor which defines what an expression is.
        /// </summary>
        /// <param name="input">the expression as user input</param>
        public Expression(string input)
        {
            Espressione= input;
        }
    }
}
