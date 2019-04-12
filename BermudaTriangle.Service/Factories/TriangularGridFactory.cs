using System;
using System.Collections.Generic;
using System.Text;

namespace BermudaTriangle.Service
{
    public class TriangularGridFactory : IGridFactory
    {
        public IGrid CreateGrid(int height, int width, int cellSize)
        {
            return new TriangularGrid(height, width, cellSize);
        }
    }
}