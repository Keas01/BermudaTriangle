using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BermudaTriangle.Service
{
    public abstract class Image
    {
        public int ImageSide { get; set; }

        public IList<Coordinate> Coordinates { get; set; }
    }
}