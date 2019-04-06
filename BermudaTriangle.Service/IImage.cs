using System;
using System.Collections.Generic;
using System.Text;

namespace BermudaTriangle.Service
{
    public interface IImage
    {
        List<Coordinate> WhereAmI(string gRef);

        string WhoAmI(List<Coordinate> location);
    }
}