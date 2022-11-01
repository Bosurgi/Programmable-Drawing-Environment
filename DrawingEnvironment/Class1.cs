using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DrawingEnvironment
{
    internal class ParserTest
    {
        public void ParseCommands(string cmd)
        {
            List<string[]> commands = new List<string[]>();

            commands.Add(cmd.Trim().ToUpper().Split(' '));
        }
    }
}
