using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    /// <summary>
    /// Class representing colours. Other colours can be added here.
    /// All the available colors are collected in this class and it allows to 
    /// </summary>
    abstract class Colors : Command
    {
        /// <summary>
        /// Special enumeration class defining the available colours.
        /// </summary>
        public enum ColorTypes
        {
            RED,    // 1
            GREEN,  // 2
            BLUE,   // 3
            WHITE,  // 4
        }
    }
}
