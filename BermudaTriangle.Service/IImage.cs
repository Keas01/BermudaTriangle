using System;
using System.Collections.Generic;
using System.Text;

namespace BermudaTriangle.Service
{
    public interface IImage
    {
        void SortVertices(List<Coordinate> locations);

        List<Coordinate> WhereAmI(string gRef);

        string WhoAmI(List<Coordinate> location);
    }
}