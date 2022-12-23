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
        internal Dictionary<string,int> PresentVariables = new Dictionary<string,int>();
        internal Expression condition;
        internal List<Command> loopBody; // TODO: implementing the list to execute
        internal bool IsExecuting = true;


        public Loop(Dictionary<string, int> dictionaryVariables, string[] loopElements)
        {

        }
    }
}
