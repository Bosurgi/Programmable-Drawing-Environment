using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AseTests
{
    [TestClass]
    public class ParserTest
    {
        DrawingEnvironment.Parser parser = new DrawingEnvironment.Parser();
        [TestMethod]
        public void TestMethod1()
        {
            // Setting up           
            string phrase = "Hello my name is Andrea";
            int expectedCount = 5;
            List<string> words = new List<string>();

            // Act
            words = parser.spaceParser(phrase);

            // Assert
            Assert.IsNotNull(words);
            Assert.AreEqual(expectedCount, words.Count);

        }

        [TestMethod]
        public void TestValidating()
        {
            // Setting up
            string example = "Moveto 100 200";
            string example2 = "Error";
            List<int> expectedInt = new List<int>{ 100, 200 };

            // Act
            List<int> parameters = parser.ValidateParameters(example);
            
            // Assert
            Assert.IsTrue(parser.CheckCommand(example));
            Assert.IsFalse(parser.CheckCommand(example2));            
            Assert.IsTrue(!parser.CheckCommand(example2));

            Assert.IsTrue(expectedInt.Count == parameters.Count);
            // Expecting the right parameters from the group
            Assert.AreEqual(expectedInt[0], parameters[0]);
            Assert.AreEqual(expectedInt[1], parameters[1]);
            Assert.AreEqual(expectedInt[0], 100);
            Assert.AreEqual(expectedInt[1], 200);
           
            // Assert.AreEqual(0, parser.ValidateParameters(example2));
        }

    }
}
