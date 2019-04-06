using System;
using System.Collections.Generic;
using System.Text;

namespace BermudaTriangle.Service
{
    public abstract class ImageFactory : IImageFactory
    {
        public abstract IImage GetImage();
    }
}