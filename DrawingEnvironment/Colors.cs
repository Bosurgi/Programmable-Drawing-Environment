using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    abstract class Colors : Command
    {
        public enum ColorTypes
        {
            RED,
            GREEN,
            BLUE,
            WHITE,
        }
    }
}
