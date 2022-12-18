using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    /// <summary>
    /// This simulates a While loop into the Drawing environment.
    /// </summary>
    internal class Loop : Command
    {
        Parser parser = new Parser();

        // TODO: Implement a for loop with variables

        public Loop(string name, int[] parameters) : base(name, parameters)
        {

        }
    }
}
