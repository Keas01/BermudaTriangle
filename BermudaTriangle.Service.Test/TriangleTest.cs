using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BermudaTriangle.Service.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCoordinates_ValidFirstColCoordinates_CoordinatesReturned()
        {
            //Arrange
            IImage gTotest = new Triangle();
            Coordinate expectedTop = new Coordinate { X = 0, Y = 0 };
            Coordinate expectedCorner = new Coordinate { X = 0, Y = 10 };
            Coordinate expectedBottom = new Coordinate { X = 10, Y = 10 };

            //Act
            List<Coordinate> result = gTotest.WhereAmI("A1");
            Coordinate top = result.First();
            Coordinate corner = result.Skip(1).Take(1).First();
            Coordinate bottom = result.Last();

            //Assert
            Assert.AreEqual(expectedTop.X, top.X);
            Assert.AreEqual(expectedTop.Y, top.Y);

            Assert.AreEqual(expectedCorner.X, corner.X);
            Assert.AreEqual(expectedCorner.Y, corner.Y);

            Assert.AreEqual(expectedBottom.X, bottom.X);
            Assert.AreEqual(expectedBottom.Y, bottom.Y);
        }

        [TestMethod]
        public void WhoAmI_ValidCoordinates_GridReferenceReturned()
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

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhoAmI_ValidEventCoordinates_GridReferenceReturned()
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

            Assert.AreEqual(expected, actual);
        }
    }
}