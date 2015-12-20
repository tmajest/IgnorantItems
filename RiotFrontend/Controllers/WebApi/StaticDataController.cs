using CoffeeCat.RiotCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RiotFrontend.Controllers.WebApi
{
    [RoutePrefix("api/static")]
    public class StaticDataController : ApiController
    {
        private IStaticData staticData;

        public StaticDataController(IStaticData staticData)
        {
            this.staticData = staticData;
        }

        [HttpGet]
        [Route("masteries")]
        public HttpResponseMessage GetMasteries()
        {
            var masteries = this.staticData.MasteryList.Data;
            return Request.CreateResponse(HttpStatusCode.OK, masteries);
        }

    }
}