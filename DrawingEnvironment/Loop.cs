using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    /// <summary>
    /// This simulates a While loop into the Drawing environment.
    /// </summary>
    internal class Loop : Command
    {
        Parser parser = new Parser();

        // TODO: Implement a for loop with variables
        // TODO: Remove useless variables
        bool ExecutionFlag = true;
        int LineCounter = 0;
        int NumberLoops = 0;
        Variable LoopVariable;
        Expression Expression;
        Dictionary<string, int[]> DictionaryVariables = new Dictionary<string, int[]>();
        List<Command> CommandsToExecute = new List<Command>();
        string[] Body;
        char Operator;

        /// <summary>
        /// It checks when the loop reaches its end
        /// </summary>
        public void IsExecuting()
        {
            for (int i = 0; i < Body.Length; i++)
            {
                LineCounter++; // Updating the linecounter
                string element = Body[i];
                if (element.ToUpper().Trim().Equals("ENDFOR"))
                {
                    ExecutionFlag= false;
                }
                else
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// It parses the condition to follow for the loop and sets up the variables
        /// </summary>
        /// <param name="condition">the condition to follow</param>
        public void parseCondition(string condition)
        {
            string[] dividedCondition = condition.Split(' ');
            foreach (var element in dividedCondition)
            {
                if (dividedCondition.Contains("<"))
                {
                    Operator = '<';
                }
                else if (dividedCondition.Contains(">"))
                {
                    Operator = '>';
                }
            }
            // Initialising a new expression and updating the Loop expression
            Expression expression = new Expression(dividedCondition[1], parser.VariableDictionary);
            Expression = expression;
            /* Dividing the elements of the expression. Example a>10
             * where a is loopOperands[0] and 10 is loopOperands[1]
             */
            string[] loopOperands = expression.DivideOperands(dividedCondition[1]);
            // Converting the parameter of the expression
            int[] parameter = { Convert.ToInt32(loopOperands[1]) };
            // Initialising the Loop variable
            LoopVariable = new Variable(loopOperands[0], parameter);
        }

        /// <summary>
        /// Constructor for the Loop
        /// </summary>
        /// <param name="input">the user input</param>
        public Loop(string condition, string body) 
        {
                        
        }


        public Loop(string name, int[] parameters) : base(name, parameters)
        {

        }
    }
}
