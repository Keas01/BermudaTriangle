using System;
using System.Collections.Generic;
using System.Text;

namespace BermudaTriangle.Service
{
    public abstract class GridFactory : IGridFactory
    {
        public abstract IGrid CreateGrid(int height, int width, int cellSize);
    }
}