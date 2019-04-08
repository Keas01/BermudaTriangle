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
        public IActionResult Get(string gRef)
        {
            try
            {
                IImage t = factory.GetImage();

                if (Helper.AmIAGridRef(gRef))
                {
                    List<Coordinate> locations = t.WhereAmI(gRef);
                    return Ok(locations);
                }//incase locations are sent as parameter not in body
                else if (Helper.AmICoordinates(gRef, out List<Coordinate> loc))
                {
                    string gridRef = t.WhoAmI(loc);
                    return Ok(gridRef);
                }
                else
                {
                    return BadRequest("Please provide either grid coordinates or grid reference of image");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(JToken locations)
        {
            try
            {
                if (locations == null)
                {
                    return BadRequest("Please provide Image Vertices");
                }

                IImage t = factory.GetImage();
                List<Coordinate> loc = JsonConvert.DeserializeObject<List<Coordinate>>(locations.ToString());

                string gridRef = t.WhoAmI(loc);

                return Ok(gridRef);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}