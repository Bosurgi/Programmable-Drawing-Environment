using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingEnvironment
{
    internal class MoveCommand : Command
    {
        int position { get; set; }
        public MoveCommand()
        {
            this.name = "MOVETO";
            
        }

        /// <summary>
        /// Methods which tries to convert the parameter position to make the pointer moving
        /// </summary>
        /// <param name="stringPos">the parameter passed by the user in string</param>
        public void ConvertingParameter (string stringPos)
        {
            try
            {
                position = Convert.ToInt32(stringPos);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Parameters. Insert a valid number");
            }
        }
        public override bool Execute()
        {
            if(position.GetType() == typeof(int))
            {
                return true;
            }
            else { return false; }
        }
    }
}
