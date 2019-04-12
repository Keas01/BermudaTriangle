using System;
using System.Collections.Generic;
using System.Linq;

namespace BermudaTriangle.Service
{
    public abstract class Grid : IGrid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int CellSize { get; set; }

        public Grid(int height, int width, int cellsize)
        {
            Width = width;
            Height = height;
            CellSize = cellsize;
        }

        /// <summary>
        /// Converts a string to a Row number
        ///https://stackoverflow.com/questions/20044730/convert-character-to-its-alphabet-integer-position
        /// </summary>
        /// <param name="gRef"></param>
        /// <returns>Row Number<returns>
        public static int ConvertRow(string gRef)
        {
            char letter = gRef.ToCharArray().FirstOrDefault();

            int index = (int)letter % 32;

            return index;
        }

        public static int ConvertColumn(string gRef)
        {
            int col;
            int.TryParse(gRef.Substring(1), out col);
            return col;
        }

        public virtual int GetRowCount()
        {
            return Height / CellSize;
        }

        public virtual int GetColumnCount()
        {
            return Width / CellSize;
        }

        public abstract bool ValidGridReference(string gRef);

        public bool ValidLocations(List<Coordinate> coordinates)
        {
            foreach (Coordinate location in coordinates)
            {
                if (location.X < 0 || location.X > Width || location.Y < 0 || location.Y > Height)
                {
                    return false;
                }
            }

            return true;
        }
    }
}