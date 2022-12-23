using System;
using System.CodeDom;
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
        public bool ExecutionFlag = true;
        int LineCounter = 0;
        int NumberLoops = 0;
        internal Variable LoopVariable;
        public Expression Expression;
        public Dictionary<string, int> DictionaryVariables = new Dictionary<string, int>();
        public List<Command> CommandsToExecute = new List<Command>();
        public string[] Body;
        public string Operator;

        /// <summary>
        /// It checks when the loop reaches its end
        /// </summary>
        public bool IsExecuting()
        {
            return ExecutionFlag;
        }

        /// <summary>
        /// It parses the condition to follow for the loop and sets up the variables
        /// </summary>
        /// <param name="condition">the condition to follow</param>
        public void ParseCondition(string[] condition)
        {
            foreach (var element in condition)
            {
                if (condition.Contains("<"))
                {
                    Operator = "<";
                }
                else if (condition.Contains(">"))
                {
                    Operator = ">";
                }
            }
            // Initialising a new expression and updating the Loop expression
            Expression expression = new Expression(condition[1], parser.VariableDictionary);
            Expression = expression;
            /* Dividing the elements of the expression. Example a>10
             * where a is loopOperands[0] and 10 is loopOperands[1]
             */
            string[] loopOperands = expression.DivideOperands(condition[1]);
            // Converting the parameter of the expression
            int[] parameter = { Convert.ToInt32(loopOperands[1]) };
            // Initialising the Loop variable
            LoopVariable = new Variable(loopOperands[0], parameter);
        }

        public void ExecuteCondition(string Operator, Dictionary<string,int> dictionaryVariables)
        {
            switch (Operator)
            {
                case ">":
                    if (dictionaryVariables[LoopVariable.Name] > LoopVariable.Parameters[0])
                    {
                        ExecutionFlag = false;
                    }
                    break;

                case "<":
                    if (dictionaryVariables[LoopVariable.Name] < LoopVariable.Parameters[0])
                    {
                        ExecutionFlag = false;
                    }
                    break;

                default:
                    ExecutionFlag = true;
                    break;
            }
        }

        /// <summary>
        /// Parsing the body of the loop into commands to execute until it finds ENDFOR
        /// </summary>
        /// <param name="input">the user input in the programming line</param>
        public List<Command> ParseBody(string[] input)
        {
            return parser.ParseCommandMultiLine(Convert.ToString(input));
        }

        /// <summary>
        /// Representing the loop with a condition and a body
        /// </summary>
        /// <param name="condition">the condition set for the loop</param>
        /// <param name="body">the body of the loop until keyword expressed</param>
        public Loop(string[] condition, string[] body, Dictionary<string, int> dictionaryVariables)
        { 
            ParseCondition(condition);
            DictionaryVariables = dictionaryVariables;            
        }


        public Loop(Dictionary<string, int> dictionaryVariables, Expression condition)
        {

        }
    }
}
