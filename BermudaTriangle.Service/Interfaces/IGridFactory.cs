using System;
using System.Collections.Generic;
using System.Text;

namespace BermudaTriangle.Service
{
    public interface IGridFactory
    {
        IGrid CreateGrid(int height, int width, int cellSize);
    }
}