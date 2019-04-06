using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BermudaTriangle.Service.Test
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void WhereAmI_ValidBottomTriangleGridReference_CoordinatesReturned()
        {
            //Arrange
            IImage gTotest = new Triangle();
            Coordinate expectedTop = new Coordinate { X = 0, Y = 0 };
            Coordinate expectedCorner = new Coordinate { X = 0, Y = 10 };
            Coordinate expectedBottom = new Coordinate { X = 10, Y = 10 };

            //Act
            List<Coordinate> result = gTotest.WhereAmI("A1");
            Coordinate actualTop = result.First();
            Coordinate actualCorner = result.Skip(1).Take(1).First();
            Coordinate actualBottom = result.Last();

            //Assert
            Assert.AreEqual(expectedTop.X, actualTop.X);
            Assert.AreEqual(expectedTop.Y, actualTop.Y);

            Assert.AreEqual(expectedCorner.X, actualCorner.X);
            Assert.AreEqual(expectedCorner.Y, actualCorner.Y);

            Assert.AreEqual(expectedBottom.X, actualBottom.X);
            Assert.AreEqual(expectedBottom.Y, actualBottom.Y);
        }

        [TestMethod]
        public void WhereAmI_ValidTopTriangleGridReference_CoordinatesReturned()
        {
            //Arrange
            IImage gTotest = new Triangle();
            Coordinate expectedTop = new Coordinate { X = 10, Y = 20 };
            Coordinate expectedCorner = new Coordinate { X = 20, Y = 20 };
            Coordinate expectedBottom = new Coordinate { X = 20, Y = 30 };

            //Act
            List<Coordinate> result = gTotest.WhereAmI("C4");
            Coordinate actualTop = result.First();
            Coordinate actualCorner = result.Skip(1).Take(1).First();
            Coordinate actualBottom = result.Last();

            //Assert
            Assert.AreEqual(expectedTop.X, actualTop.X);
            Assert.AreEqual(expectedTop.Y, actualTop.Y);

            Assert.AreEqual(expectedCorner.X, actualCorner.X);
            Assert.AreEqual(expectedCorner.Y, actualCorner.Y);

            Assert.AreEqual(expectedBottom.X, actualBottom.X);
            Assert.AreEqual(expectedBottom.Y, actualBottom.Y);
        }

        [TestMethod]
        public void WhoAmI_ValidBottomTriangleCoordinates_GridReferenceReturned()
        {
            //Arrange
            IImage gTotest = new Triangle();
            string expected = "E9";
            List<Coordinate> locations = new List<Coordinate>
            {
                new Coordinate { X = 40, Y = 40 },
                new Coordinate { X = 40, Y = 50 },
                new Coordinate { X = 50, Y = 50 }
            };

            //Act
            string actual = gTotest.WhoAmI(locations);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhoAmI_ValidTopTriangleCoordinates_GridReferenceReturned()
        {
            //Arrange
            IImage gTotest = new Triangle();
            string expected = "F4";
            List<Coordinate> locations = new List<Coordinate>
            {
                new Coordinate { X = 10, Y = 50 },
                new Coordinate { X = 20, Y = 50 },
                new Coordinate { X = 20, Y = 60 }
            };

            //Act
            string actual = gTotest.WhoAmI(locations);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}