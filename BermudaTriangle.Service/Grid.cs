using System;
using System.Collections.Generic;
using System.Linq;

namespace BermudaTriangle.Service
{
    public class Grid
    {
        public string GridReference { get; set; }
        public List<Coordinate> Coordinates { get; set; }

        public int ImageSide { get; set; }

        private void CalculateOddCoords(List<Coordinate> myCords, int col, int row)
        {
        }
    }
}