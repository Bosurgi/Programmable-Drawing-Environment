using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        bool ExecutionFlag = true;
        int LineCounter = 0;
        int NumberLoops = 0;
        string LoopName;
        string[] LoopRules;
        Variable LoopVariable;
        Dictionary<string, int[]> DictionaryVariables;
        List<Command> CommandsToExecute;
        string[] Body;

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
        /// Constructor for the Loop
        /// </summary>
        /// <param name="input">the user input</param>
        public Loop(string input) 
        {
            LoopRules = input.Split(' ');

                        
        }


        public Loop(string name, int[] parameters) : base(name, parameters)
        {

        }
    }
}
