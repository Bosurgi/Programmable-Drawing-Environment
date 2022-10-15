using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DrawingEnvironment
{
    public class Parser
    {
        List<string> commands = new List<string>();        
        
        /// <summary>
        /// This method takes a string and separates the elements by spacing.
        /// </summary>
        /// <param name="command"> it is the string to split by spacing</param>
        public List<string> spaceParser(string command)
        {
            List<string> commands = new List<string>();
            string[] commandArray = command.ToUpper().Split(' ');
            foreach (var word in commandArray)
            {
                commands.Add(word);
            }
            return commands;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public bool ValidateCommand(string userInput)
        {
            var cmd = userInput.ToUpper().Split(' ');
            
            var commands = Enum.GetNames(typeof(Command.Commands));
            var shapes = Enum.GetNames(typeof(Shape.Shapes));
            
            if (cmd.Length > 3 || !commands.Contains(cmd[0]) && !shapes.Contains(cmd[0]))
            {
                MessageBox.Show("Enter a valid command");
                return false;
            }
            else { return true; }           
        }

        /// <summary>
        /// Method which validates eventual numerical parameters provided from the user
        /// </summary>
        /// <param name="userInput">the input the users inserts in the command line</param>
        /// <returns>A list of integers which represents the parameters provided</returns>
        public List<int> ValidateParameters(string userInput)
        {
            List<int> parameterList = new List<int>();
            string[] commandArray = userInput.ToUpper().Split(' ');
            // Excluding the first element which is going to be the command
            for(int i = 1; i < commandArray.Length; i++)
            {
                try
                {
                    // It adds the parameters in the list if they are valid integers
                    parameterList.Add(Convert.ToInt32(commandArray[i]));

                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Parameter");
                }
            } // End of for
            return parameterList;
        }
        // Constructor

        public Parser()
        {
            List<string> commands = this.commands;
        }

    }
}
