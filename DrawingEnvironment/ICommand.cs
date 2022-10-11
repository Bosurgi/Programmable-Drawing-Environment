using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEnvironment
{
    /// <summary>
    /// Interface which will be the base for the various commands.
    /// </summary>
    interface ICommand
    {
        bool Execute();
    }
}
