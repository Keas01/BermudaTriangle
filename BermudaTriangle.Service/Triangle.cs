using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BermudaTriangle.Service
{
    public class Triangle : IImage
    {
        public Triangle()
        {
            ImageSide = 10;
        }

        public int ImageSide { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public string WhoAmI(List<Coordinate> locations)
        {
            Coordinate top = locations.First();
            Coordinate corner = locations.Skip(1).Take(1).First();
            Coordinate bottom = locations.Last();
            if (top.Y == corner.Y)
            {
                //0
                Row = (corner.Y / ImageSide) + 1;
            }
            else
            {
                Row = (corner.Y / ImageSide);
            }

            if (top.X == corner.X)//bottom triangle
            {
                Col = ((corner.X / ImageSide) * 2) + 1;
            }
            else
            {
                Col = (corner.X / ImageSide) * 2;
            }
            return string.Format("{0}{1}", Number2String(Row, true), Col);
        }

        /// <summary>
        /// Idea from
        /// https://social.msdn.microsoft.com/Forums/vstudio/en-US/78e75d1a-0795-4bdb-8a62-ae6faa909986/convert-number-to-alphabet?forum=csharpgeneral
        /// </summary>
        /// <param name="number"></param>
        /// <param name="isCaps"></param>
        /// <returns></returns>
        private String Number2String(int number, bool isCaps)
        {
            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
            return c.ToString();
        }

        public int ConvertRow(string gRef)
        {
            //A2
            char letter = gRef.ToCharArray().FirstOrDefault();

            //returns A
            //https://stackoverflow.com/questions/20044730/convert-character-to-its-alphabet-integer-position
            int index = (int)letter % 32;

            return index;
        }

        public int ConvertColumn(string gRef)
        {
            int col;
            int.TryParse(gRef.Substring(1), out col);
            return col;
        }

        public List<Coordinate> WhereAmI(string gRef)
        {
            List<Coordinate> myCords = new List<Coordinate>();

            int col = ConvertColumn(gRef);
            int row = ConvertRow(gRef);
            ImageSide = 10;

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