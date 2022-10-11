using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AseTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Setting up
            DrawingEnvironment.Parser parser = new DrawingEnvironment.Parser();
            string phrase = "Hello my name is Andrea";
            int expectedCount = 5;
            
            List<string> words = new List<string>();
            
            // Act
            words = parser.spaceParser(phrase);

            // Assert
            Assert.IsNotNull(words);
            Assert.AreEqual(expectedCount, words.Count);
            
            
        }
    }
}
