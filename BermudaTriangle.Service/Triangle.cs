using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BermudaTriangle.Service
{
    public class Triangle : Image, IImage
    {
        private Coordinate _top = null;
        private Coordinate _corner = null;
        private Coordinate _bottom = null;

        public Triangle()
        {
            ImageSide = 10;
        }

        public Triangle(int size)
        {
            ImageSide = size;
        }

        public void SortVertices(List<Coordinate> locations)
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
            SortVertices(locations);
            int row;
            int col;
            if (_top.Y == _corner.Y)//top triangle
            {
                //0
                row = (_corner.Y / ImageSide) + 1;
            }
            else
            {
                row = (_corner.Y / ImageSide);
            }

            if (_top.X == _corner.X)//bottom triangle
            {
                col = ((_corner.X / ImageSide) * 2) + 1;
            }
            else
            {
                col = (_corner.X / ImageSide) * 2;
            }
            return string.Format("{0}{1}", Grid.Number2String(row, true), col);
        }

        public List<Coordinate> WhereAmI(string gRef)
        {
            List<Coordinate> myCords = new List<Coordinate>();

            int col = Grid.ConvertColumn(gRef);
            int row = Grid.ConvertRow(gRef);

            if (col % 2 == 0)
            {
                //strategy for top triangles
                int topLeftX = (col / 2 - 1) * ImageSide;
                int topLeftY = (row - 1) * ImageSide;

                int topRightX = topLeftX + ImageSide;
                int topRightY = topLeftY;

                int bottomRightX = topRightX;
                int bottomRightY = topRightY + ImageSide;

                myCords.Add(new Coordinate(topLeftX, topLeftY));
                myCords.Add(new Coordinate(topRightX, topRightY));
                myCords.Add(new Coordinate(bottomRightX, bottomRightY));
            }
            else
            {
                //strategy for bottom triangles
                int topLeftX = ((col - 1) * ImageSide) / 2;
                int topLeftY = (row - 1) * ImageSide;

                int bottomLeftX = topLeftX;
                int bottomLeftY = row * ImageSide;

                int bottomRightX = bottomLeftX + ImageSide;
                int bottomRightY = bottomLeftY;

                myCords.Add(new Coordinate(topLeftX, topLeftY));
                myCords.Add(new Coordinate(bottomLeftX, bottomLeftY));
                myCords.Add(new Coordinate(bottomRightX, bottomRightY));
            }

            return myCords;
        }
    }
}