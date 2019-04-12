using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BermudaTriangle.Service.Test
{
    [TestClass]
    public class GridTests
    {
        [TestMethod, TestCategory("Grid")]
        public void ValidLocation_ValidLocations_TrueReturned()
        {
            //Arrange
            bool expected = true;
            TriangularGrid tGrid = new TriangularGrid(60, 60, 10);

            List<Coordinate> locations = new List<Coordinate>
            {
                new Coordinate { X = 10, Y = 50 },
                new Coordinate { X = 20, Y = 50 },
                new Coordinate { X = 20, Y = 60 }
            };

            //Act
            bool actual = tGrid.ValidLocations(locations);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Grid")]
        public void ValidLocation_InValidWidthLocations_FalseReturned()
        {
            //Arrange
            bool expected = false;
            int width = 60;
            TriangularGrid tGrid = new TriangularGrid(60, width, 10);

            List<Coordinate> locations = new List<Coordinate>
            {
                new Coordinate { X = width + 10, Y = 50 }
            };

            //Act
            bool actual = tGrid.ValidLocations(locations);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Grid")]
        public void ValidLocation_InValidHeightLocations_FalseReturned()
        {
            //Arrange
            bool expected = false;
            int height = 60;
            TriangularGrid tGrid = new TriangularGrid(height, 60, 10);

            List<Coordinate> locations = new List<Coordinate>
            {
                new Coordinate { X =  10, Y = height + 10 }
            };

            //Act
            bool actual = tGrid.ValidLocations(locations);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Grid")]
        public void ValidGridReference_ValidFirstReference_TrueReturned()
        {
            //Arrange
            bool expected = true;
            TriangularGrid tGrid = new TriangularGrid(60, 60, 10);
            string gRef = "A1";

            //Act
            bool actual = tGrid.ValidGridReference(gRef);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Grid")]
        public void ValidGridReference_ValidLastReference_TrueReturned()
        {
            //Arrange
            bool expected = true;
            TriangularGrid tGrid = new TriangularGrid(60, 60, 10);
            string gRef = "F12";

            //Act
            bool actual = tGrid.ValidGridReference(gRef);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Grid")]
        public void ValidGridReference_InvalidColumn_FalseReturned()
        {
            //Arrange
            bool expected = false;
            TriangularGrid tGrid = new TriangularGrid(60, 60, 10);
            string gRef = "G7";

            //Act
            bool actual = tGrid.ValidGridReference(gRef);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Grid")]
        public void ValidGridReference_InvalidRow_FalseReturned()
        {
            //Arrange
            bool expected = false;
            TriangularGrid tGrid = new TriangularGrid(60, 60, 10);
            string gRef = "A13";

            //Act
            bool actual = tGrid.ValidGridReference(gRef);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}