using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BermudaTriangle.Service.Test
{
    [TestClass]
    internal class WebAPITests
    {
        private string _url = "http://sean/api/image";
        private HttpClient _client;

        public WebAPITests()
        {
            _client = new HttpClient();
        }

        [TestMethod]
        public void GetByGridRef_ValidGridRef_LocationsReturned()
        {
            var result = _client.GetAsync(_url).Result;
        }
    }
}