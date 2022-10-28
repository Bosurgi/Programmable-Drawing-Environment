using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    abstract class Colors : Command
    {
        public override bool Execute()
        {
            throw new NotImplementedException();
        }

        public enum ColorTypes
        {
            RED,
            GREEN,
            BLUE,
            WHITE,
        }
    }
}
