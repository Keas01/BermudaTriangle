using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BermudaTriangle.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BermudaTriangle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        public List<Coordinate> Get(string gRef)
        {
            IImage t = new Triangle();
            List<Coordinate> locations = t.WhereAmI(gRef);

            return locations;
        }
    }
}