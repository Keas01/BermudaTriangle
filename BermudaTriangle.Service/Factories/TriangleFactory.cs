﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BermudaTriangle.Service
{
    public class TriangleFactory : ImageFactory
    {
        public override IImage CreateImage()
        {
            return new RightAngleTriangle();
        }
    }
}