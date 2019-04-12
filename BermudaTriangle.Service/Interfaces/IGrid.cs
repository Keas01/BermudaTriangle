using System;
using System.Collections.Generic;
using System.Text;

namespace BermudaTriangle.Service
{
    public interface IGrid
    {
        int GetRowCount();

        int GetColumnCount();

        bool ValidGridReference(string gRef);

        bool ValidLocations(List<Coordinate> coordinates);
    }
}