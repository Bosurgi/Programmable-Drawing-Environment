using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    /// <summary>
    /// Class representing colours. Other colours can be added here.
    /// </summary>
    abstract class Colors : Command
    {
        /// <summary>
        /// Special enumeration class defining the available colours.
        /// </summary>
        public enum ColorTypes
        {
            RED,
            GREEN,
            BLUE,
            WHITE,
        }
    }
}
