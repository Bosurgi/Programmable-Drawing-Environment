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
        public void TestSpaceParser()
        {
            // Setting up           
            string phrase = "Hello my name is Andrea";
            int expectedCount = 5;
            List<string> words = new List<string>();

            // Act
            words = parser.SpaceParser(phrase);

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
            List<int> expectedInt = new List<int> { 100, 200 };

            // Act
            List<int> parameters = parser.AssigningParameters(example);

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

        }

        [TestMethod]
        public void TestValidating_withAllLowerCase()
        {
            // Set up
            var test = "hello 300 test";
            var expected = new string[] { "HELLO", "300", "TEST" };

            // Act
            var result = parser.ParseCommand(test);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == 3);
            Assert.AreEqual(expected[0], result[0]);
            Assert.AreEqual(expected[1], result[1]);
            Assert.AreEqual(expected[2], result[2]);
            Assert.IsInstanceOfType(result, typeof(string[]));
            // Asserting that content is uppercase
            Assert.AreNotEqual(expected[0], test[0]);
            Assert.AreNotEqual(expected[1], test[1]);
            Assert.AreNotEqual(expected[2], test[2]);
        }

        [TestMethod]
        public void CheckNumberIfConvertible_whenNoNumbers()
        {
            // Set up
            var toTest = new string[] { "hello", "test", "anotherTest" };

            // Act
            foreach (var element in toTest)
            {
                // Assert
                Assert.IsNotNull(element);
                Assert.IsFalse(parser.CheckNumbers(element));
            }
        }
        [TestMethod]
        public void CheckNumberIfConvertible_whenNumbers()
        {
            // Set up
            var toTest = new[] { "130", "200", "400" };

            // Act
            foreach (var element in toTest)
            {
                // Assert
                Assert.IsNotNull(element);
                Assert.IsTrue(parser.CheckNumbers(element));
            }
        }

        [TestMethod]
        public void CheckNumberIfConvertible_whenMixed()
        {
            // Set up
            var toTest = new[] { "hello", "200", "test", "601" };

            // Assert
            Assert.IsNotNull(toTest);
            Assert.IsFalse(parser.CheckNumbers(toTest[0]));
            Assert.IsTrue(parser.CheckNumbers(toTest[1]));
            Assert.IsFalse(parser.CheckNumbers(toTest[2]));
            Assert.IsTrue(parser.CheckNumbers(toTest[3]));
        }

        [TestMethod]
        public void CheckIfCommandIsValid()
        {
            // Set up
            var input = new string[] { "Rectangle", "100", "200" };

            // Act
            var expected = parser.CheckCommand(input[0]);

            // Assert
            Assert.IsNotNull(expected);
            Assert.IsTrue(expected);
            Assert.IsFalse(parser.CheckCommand(input[1]));
        }


        [TestMethod]
        public void CheckIfCommandIsValid_whenElementNotCommand()
        {
            // Set up
            var input = new string[] { "random", "element", "test" };

            // Act
            var expected = parser.CheckCommand(input[0]);

            // Assert
            Assert.IsNotNull(expected);
            Assert.IsFalse(expected);
            Assert.IsFalse(parser.CheckCommand(input[1]));
        }

        [TestMethod]
        public void AssigningParameters_whenCommandOk_oneParameter()
        {
            // Set up
            var input = "Triangle 100";
            var expected = new List<int> { 100 };

            // Act
            var actual = parser.AssigningParameters(input);
            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count == 1);
            Assert.AreEqual(expected[0], actual[0]);
        }

        [TestMethod]
        public void AssigningParameters_whenCommandOk_moreThanOneParameter()
        {
            var input = "Moveto 100 200";
            var expected = new List<int> { 100, 200 };

            // Act
            var actual = parser.AssigningParameters(input);
            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count == 2);
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }


        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void AssigningParameters_whenNoValidCommand()
        {
            // Set up
            var input = "Try me out, I will throw errors";

            // Act
            var actual = parser.AssigningParameters(input);

        }
    }
}
