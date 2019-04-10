﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BermudaTriangle.Service
{
    public interface IImage
    {
        void ResolveVertices(List<Coordinate> locations);

        List<Coordinate> WhereAmI(string gRef);

        string WhoAmI(List<Coordinate> location);
    }
}