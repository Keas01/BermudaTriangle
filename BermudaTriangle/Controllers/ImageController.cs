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

        [HttpGet("Location/{gRef}", Name = "loc")]
        public ActionResult<List<Coordinate>> Locations(string gRef)
        {
            try
            {
                IImage t = factory.GetImage();

                if (Helper.AmIAGridRef(gRef))
                {
                    List<Coordinate> locations = t.WhereAmI(gRef);
                    return Ok(locations);
                }
                else
                {
                    return BadRequest("Please provide grid reference of image");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GridReference/{locations}", Name = "gridref")]
        public IActionResult GridReference(string locations)
        {
            try
            {
                IImage t = factory.GetImage();

                if (Helper.AmICoordinates(locations, out List<Coordinate> loc))
                {
                    string gridRef = t.WhoAmI(loc);
                    return Ok(gridRef);
                }
                else
                {
                    return BadRequest("Please provide grid coordinates of image");
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