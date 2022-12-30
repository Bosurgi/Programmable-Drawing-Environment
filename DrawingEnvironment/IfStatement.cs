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



        public IfStatement(Dictionary<string, int> presentVariables, Expression ifExpression, List<Command> IfBody)
        {
            this.PresentVariables = presentVariables;
            this.IfExpression = ifExpression;
            this.IfBody = IfBody;
        }
    }
}
