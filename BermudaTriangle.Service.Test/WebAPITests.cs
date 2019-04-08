using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BermudaTriangle.Service.Test
{
    [TestClass]
    public class WebAPITests
    {
        private string _url = "http://seanapps.azurewebsites.net/api/image/";
        private HttpClient _client;

        public WebAPITests()
        {
            _client = new HttpClient();
        }

        [TestMethod, TestCategory("WepAPI")]
        public void GetByGridRef_ValidGridRef_LocationsReturned()
        {
            //Arrange
            string getUrl = string.Format("{0}/Location/a1", _url);
            Coordinate expectedTop = new Coordinate { X = 0, Y = 0 };
            Coordinate expectedCorner = new Coordinate { X = 0, Y = 10 };
            Coordinate expectedBottom = new Coordinate { X = 10, Y = 10 };

            //Act
            HttpResponseMessage response = _client.GetAsync(getUrl).Result;

            string loc = response.Content.ReadAsStringAsync().Result;
            List<Coordinate> result = JsonConvert.DeserializeObject<List<Coordinate>>(loc);

            Coordinate actualTop = result.First();
            Coordinate actualCorner = result.Skip(1).Take(1).First();
            Coordinate actualBottom = result.Last();

            //Assert
            Assert.AreEqual(expectedTop.X, actualTop.X);
            Assert.AreEqual(expectedTop.Y, actualTop.Y);

            Assert.AreEqual(expectedCorner.X, actualCorner.X);
            Assert.AreEqual(expectedCorner.Y, actualCorner.Y);

            Assert.AreEqual(expectedBottom.X, actualBottom.X);
            Assert.AreEqual(expectedBottom.Y, actualBottom.Y);
        }

        [TestMethod, TestCategory("WepAPI")]
        public void GetByGridRef_InValidGridRef_500Returned()
        {
            //Arrange
            string getUrl = string.Format("{0}/GridReference/InvalidParamets", _url);
            HttpStatusCode expected = HttpStatusCode.InternalServerError;

            //Act
            HttpResponseMessage response = _client.GetAsync(getUrl).Result;

            HttpStatusCode actual = response.StatusCode;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("WepAPI")]
        public void GetByLocation_ValidLocations_GridRefReturned()
        {
            //Arrange
            String expected = "A1";
            List<Coordinate> locations = new List<Coordinate>
            {
                new Coordinate { X = 0, Y = 0 },
                new Coordinate { X = 0, Y = 10 },
                new Coordinate { X = 10, Y = 10 }
            };

            string getUrl = string.Format("{0}/GridReference/{1}", _url, JsonConvert.SerializeObject(locations));

            //Act
            HttpResponseMessage response = _client.GetAsync(getUrl).Result;

            string actual = response.Content.ReadAsStringAsync().Result;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}