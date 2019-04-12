using System;
using System.Collections.Generic;
using System.Text;

namespace BermudaTriangle.Service
{
    public class TriangularGrid : Grid, IGrid
    {
        public TriangularGrid(int height, int width, int cellsize)
            : base(height, width, cellsize)
        {
        }

        public override bool ValidGridReference(string gRef)
        {
            int row = Grid.ConvertRow(gRef);
            int col = Grid.ConvertColumn(gRef);

            if (col % 2 == 0)
            {
                col = (col / 2);
            }
            else
            {
                col = (col / 2) + 1;
            }

            if (row > GetRowCount() || col > GetColumnCount())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}