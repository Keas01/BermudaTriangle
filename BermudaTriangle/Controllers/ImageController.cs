using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BermudaTriangle.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BermudaTriangle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IImageFactory factory;

        public ImageController(IImageFactory fac)
        {
            factory = fac;
        }

        [HttpGet("{gRef}")]
        public ActionResult<List<Coordinate>> Get(string gRef)
        {
            IImage t = factory.GetImage();
            List<Coordinate> locations = t.WhereAmI(gRef);

            return locations;
        }

        [HttpGet]
        public ActionResult<string> Get(JToken locations)
        {
            if (locations == null)
            {
                return BadRequest("Please provide Image Vertices");
            }

            List<Coordinate> loc = JsonConvert.DeserializeObject<List<Coordinate>>(locations.ToString());

            IImage t = factory.GetImage();
            string gridRef = t.WhoAmI(loc);

            return gridRef;
        }
    }
}