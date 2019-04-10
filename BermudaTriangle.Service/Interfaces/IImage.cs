using System;
using System.Collections.Generic;
using System.Text;

namespace BermudaTriangle.Service
{
    public interface IImage
    {
        IList<Coordinate> Coordinates { get; set; }

        void ResolveVertices(List<Coordinate> locations);

        List<Coordinate> WhereAmI(string gRef);

        string WhoAmI(List<Coordinate> location);
    }
}