namespace DrawingEnvironment
{
    /// <summary>
    /// The command class represents the actual available commands in the Drawing Environment.
    /// Other commands can be added below.
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Command class properties, names and Parameters.
        /// </summary>
        internal string Name { get; set; }
        internal int[] Parameters { get; set; }

        /// <summary>
        /// Enumerator for commands available
        /// All the commands to be implemented need to be inserted here first.
        /// The parser will check if the command is among these before executing.
        /// </summary>
        public enum Commands
        {
            /// <summary>
            /// MoveTo command to move the cursor
            /// </summary>
            MOVETO, // 1

            /// <summary>
            /// Clear command to clear the canvas
            /// </summary>
            CLEAR,  // 2

            /// <summary>
            /// DrawTO draws a line from cursor to specified position
            /// </summary>
            DRAWTO, // 3

            /// <summary>
            /// Resets the cursor
            /// </summary>
            RESET,  // 4                    

            /// <summary>
            /// Fill option on and off for the brush
            /// </summary>
            FILL,   // 5

            /// <summary>
            /// Run to execute the command in the multiline
            /// </summary>
            RUN,    // 6
        }

        /// <summary>
        /// Overriding the ToString method.
        /// </summary>
        /// <returns>the Name of the command.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Constructor for the Command class
        /// </summary>
        /// <param Name="name">the Name of the command</param>
        /// <param Name="Parameters">the Parameters passed for the command</param>
        public Command(string name, int[] parameters)
        {
            this.Name = name;
            this.Parameters = parameters;
        }

        /// <summary>
        /// Empty Constructor for command class.
        /// </summary>
        public Command()
        {

        }

    }


}
