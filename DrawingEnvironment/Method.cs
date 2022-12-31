using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{    
    internal class Method
    {
        internal List<Command> MethodBody = new List<Command>();
        
        internal Dictionary<string,int> Variables = new Dictionary<string,int>();

        internal string MethodName;

        internal string Parameters;

        public void SetBody(List<Command> MethodBody)
        {
            this.MethodBody = MethodBody;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Parameters"></param>
        public Method(string name, string Parameters)
        {
            this.MethodName = name;
            this.Parameters = Parameters;
        }
        /// <summary>
        /// Empty Constructor for the Method class
        /// </summary>
        public Method() 
        { 
        
        }
    }
}
