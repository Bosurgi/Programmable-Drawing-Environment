using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AseTests
{
    /// <summary>
    /// Tests designed for part 2.
    /// They will be implemented now but they are expected to fail at the moment.
    /// During the development of part 2, the aim will be them to pass.
    /// </summary>
    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void TestVariables()
        {
            // set up
            Parser parser = new Parser();

            // act
            Variable variable = (Variable) parser.ParseCommands("x = 5");

            // assert
            Assert.AreEqual(variable.parameters, 5);
        }
    }
}
