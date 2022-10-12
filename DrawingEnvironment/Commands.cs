using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    public abstract class Commands : ICommand
    {
        private string name { get; set; }
        private string parameters { get; set; }

        public abstract bool Execute();

        public Commands(string name, string parameters)
        {
            name = this.name;
            parameters = this.parameters;
        }

        public Commands()
        {

        }

    }


}
