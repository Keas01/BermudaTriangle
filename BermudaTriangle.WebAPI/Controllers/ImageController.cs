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
        private IImageFactory _factory;
        private IGridFactory _gridFactory;
        private IGrid _grid;

        public ImageController(IImageFactory fac, IGridFactory gridFac)
        {
            _factory = fac;
            _gridFactory = gridFac;
            //This can be created from request params
            _grid = _gridFactory.CreateGrid(60, 60, 10);
        }

        [HttpGet("Location/{gRef}", Name = "loc")]
        public ActionResult<List<Coordinate>> Locations(string gRef)
        {
            try
            {
                if (!_grid.ValidGridReference(gRef)) return BadRequest("Invalid Grid Reference");
                if (!Helper.AmIAGridRef(gRef)) return BadRequest("Please provide grid reference of image");

                IImage t = _factory.CreateImage();

                List<Coordinate> locations = t.WhereAmI(gRef);
                return Ok(locations);
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
                if (!Helper.AmICoordinates(locations, out List<Coordinate> loc)) return BadRequest("Please provide grid coordinates of image");
                if (!_grid.ValidLocations(loc)) return BadRequest("Invalid Grid Coordinates");

                IImage t = _factory.CreateImage();

                string gridRef = t.WhoAmI(loc);
                return Ok(gridRef);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Method to handle Get request with Json body
        /// </summary>
        /// <param name="locations"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(JToken locations)
        {
            try
            {
                if (locations == null)
                {
                    return BadRequest("Please provide Image Vertices");
                }

                IImage t = _factory.CreateImage();
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