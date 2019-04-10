using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BermudaTriangle.Service
{
    public class RightAngleTriangle : Image, IImage
    {
        private Coordinate _top = null;
        private Coordinate _corner = null;
        private Coordinate _bottom = null;

        public RightAngleTriangle()
        {
            ImageSide = 10;
        }

        public RightAngleTriangle(int size)
        {
            ImageSide = size;
        }

        public void ResolveVertices(List<Coordinate> locations)
        {
            _top = locations.OrderBy(l => l.X).ThenBy(l => l.Y).First();

            _bottom = locations.Where(l => l.X == _top.X + ImageSide && l.Y == _top.Y + ImageSide).FirstOrDefault();

            _corner = locations.Where(l => l.X == _top.X + ImageSide && l.Y == _top.Y).FirstOrDefault();
            if (_corner == null)
            {
                _corner = locations.Where(l => l.Y == _top.Y + ImageSide && l.X == _top.X).FirstOrDefault();
            }

            if (_top == null || _bottom == null || _corner == null)
            {
                throw new InvalidOperationException("This aint a triangle");
            }
        }

        public string WhoAmI(List<Coordinate> locations)
        {
            ResolveVertices(locations);
            return string.Format("{0}{1}", Helper.Number2String(CalculateRow(), true), CalculateColumn());
        }

        private int CalculateColumn()
        {
            int col = (_corner.X / ImageSide) * 2;

            if (_top.X == _corner.X)
            {
                col++;
            }

            return col;
        }

        private int CalculateRow()
        {
            int row = (_corner.Y / ImageSide);
            if (_top.Y == _corner.Y)
            {
                //0
                row++;
            }

            return row;
        }

        public List<Coordinate> WhereAmI(string gRef)
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            int col = Grid.ConvertColumn(gRef);
            int row = Grid.ConvertRow(gRef);

            if (col % 2 == 0)
            {
                CalculateLeftSidedTriangle(coordinates, col, row);
            }
            else
            {
                CalculateRightSidedTriangle(coordinates, col, row);
            }

            return coordinates;
        }

        private void CalculateRightSidedTriangle(List<Coordinate> coordinates, int col, int row)
        {
            //strategy for bottom triangles
            int topLeftX = ((col - 1) * ImageSide) / 2;
            int topLeftY = (row - 1) * ImageSide;

            int bottomLeftX = topLeftX;
            int bottomLeftY = row * ImageSide;

            int bottomRightX = bottomLeftX + ImageSide;
            int bottomRightY = bottomLeftY;

            coordinates.Add(new Coordinate(topLeftX, topLeftY));
            coordinates.Add(new Coordinate(bottomLeftX, bottomLeftY));
            coordinates.Add(new Coordinate(bottomRightX, bottomRightY));
        }

        private void CalculateLeftSidedTriangle(List<Coordinate> coordinates, int col, int row)
        {
            //strategy for top triangles
            int topLeftX = (col / 2 - 1) * ImageSide;
            int topLeftY = (row - 1) * ImageSide;

            int topRightX = topLeftX + ImageSide;
            int topRightY = topLeftY;

            int bottomRightX = topRightX;
            int bottomRightY = topRightY + ImageSide;

            coordinates.Add(new Coordinate(topLeftX, topLeftY));
            coordinates.Add(new Coordinate(topRightX, topRightY));
            coordinates.Add(new Coordinate(bottomRightX, bottomRightY));
        }
    }
}