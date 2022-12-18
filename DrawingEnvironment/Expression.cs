using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    /// <summary>
    /// Class which handles expressions between variables and strings
    /// </summary>
    internal class Expression
    {
        Variable variable;
        string expression;
        string result;



        public Expression(string expression)
        {
            this.expression = expression;           
        }

        public Expression()
        {

        }
    }
}
