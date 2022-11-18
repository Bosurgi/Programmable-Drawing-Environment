using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectangle = DrawingEnvironment.Rectangle;

namespace AseTests
{
    /// <summary>
    /// Test class to test the Factory of the shapes for the Drawing Environment project.
    /// This will test the production of the shapes, setters, getters and their attributes such as X, Y, and other relevant attributes.
    /// </summary>
    [TestClass]
    public class FactoryShapeTest
    {
        ShapeFactory factory = new ShapeFactory();
        Parser parser = new Parser();
        
        /// <summary>
        /// Testing the shape for rectangle
        /// </summary>
        [TestMethod]
        public void testFactory_Rectangle_withCorrectValues()
        {
            // Set up
            Command makeRectangle = parser.ParseCommands("rectangle 30,40");

            // act
            Shape shape = factory.GetShape(makeRectangle.Name);
            shape.Set(Color.White, 0 , 0, makeRectangle.Parameters[0], makeRectangle.Parameters[1]);

            // assert
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Rectangle));
            Assert.AreEqual(30, makeRectangle.Parameters[0]);
            Assert.AreEqual(40, makeRectangle.Parameters[1]);
        }
        /// <summary>
        /// Testing the shape for rectangle
        /// </summary>
        [TestMethod]
        public void testFactory_Rectangle_withCorrectValues_and_CaseSensitive()
        {
            // Set up
            Command makeRectangle = parser.ParseCommands("rEcTangLe 30,40");

            // act
            Shape shape = factory.GetShape(makeRectangle.Name);
            shape.Set(Color.White, 0, 0, makeRectangle.Parameters[0], makeRectangle.Parameters[1]);

            // assert
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Rectangle));
            Assert.AreEqual(30, makeRectangle.Parameters[0]);
            Assert.AreEqual(40, makeRectangle.Parameters[1]);
        }
        /// <summary>
        /// Testing the shape for Circle
        /// </summary>
        [TestMethod]

        public void testFactory_Circle_withCorrectValues()
        {
            // Set up
            Command makeCircle = parser.ParseCommands("Circle 30");

            // act
            Shape shape = factory.GetShape(makeCircle.Name);
            shape.Set(Color.White, 0, 10, makeCircle.Parameters[0]);

            // assert
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Circle)); // Testing the class - Polymorphism | Inheritance
            Assert.AreEqual(30, makeCircle.Parameters[0]);
            Assert.AreEqual(0, shape.X);
            Assert.AreEqual(10, shape.Y);
        }
        /// <summary>
        /// Testing the shape for Circle with correct value and testing the case sensitivity
        /// </summary>
        [TestMethod]

        public void testFactory_Circle_withCorrectValuesand_CaseSensitive()
        {
            // Set up
            Command makeCircle = parser.ParseCommands("cIrClE 30");

            // act
            Shape shape = factory.GetShape(makeCircle.Name);
            shape.Set(Color.White, 0, 10, makeCircle.Parameters[0]);


            // assert
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Circle));
            Assert.AreEqual(30, makeCircle.Parameters[0]);
            Assert.AreEqual(0, shape.X);
            Assert.AreEqual(10, shape.Y);
        }
        /// <summary>
        /// Testing the shape for Triangle with correct value
        /// </summary>
        [TestMethod]

        public void testFactory_Triangle_withCorrectValues()
        {
            // Set up
            Command makeTriangle = parser.ParseCommands("triangle 40");

            // act
            Shape shape = factory.GetShape(makeTriangle.Name);
            shape.Set(Color.White, 0, 10, makeTriangle.Parameters[0]);

            // assert
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Triangle));
            Assert.AreEqual(40, makeTriangle.Parameters[0]);
            Assert.AreEqual(0, shape.X);
            Assert.AreEqual(10, shape.Y);
        }
        /// <summary>
        /// Testing the shape for Triangle with correct value and case sensitivity
        /// </summary>
        [TestMethod]

        public void testFactory_Triangle_withCorrectValues_and_CaseSensitivity()
        {
            // Set up
            Command makeTriangle = parser.ParseCommands("tRiAnglE 40");

            // act
            Shape shape = factory.GetShape(makeTriangle.Name);
            shape.Set(Color.White, 0, 0, makeTriangle.Parameters[0]);

            // assert
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Triangle));
            Assert.AreEqual(40, makeTriangle.Parameters[0]);
        }

        /// <summary>
        /// Testing invalid input such as an invalid shape which does not exist in the Factory.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testFactory_TestingWrongTypeOfShapes()
        {
            // Set up
            Command makeNotValidShape = parser.ParseCommands("Octagon 50");

            // Act
            Shape shape = factory.GetShape(makeNotValidShape.Name);

            // assert
            Assert.IsNotNull(makeNotValidShape);
            Assert.IsInstanceOfType(shape, typeof(Shape));
        }

        /// <summary>
        /// Testing invalid input such as a null shape which does not exist in the Factory.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testFactory_TestingNullTypeOfShapes()
        {
            // Set up
            Command makeNotValidShape = parser.ParseCommands("");

            // Act
            Shape shape = factory.GetShape(makeNotValidShape.Name);

            // assert
            Assert.IsNull(makeNotValidShape);
            Assert.IsInstanceOfType(shape, typeof(Shape));
        }
    }
}
