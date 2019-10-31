using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineRatingTC.Models;

namespace OnlineRatingTC.Controllers
{
    public class ServiceTypesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ServiceTypesApi
        public HttpResponseMessage GetServiceTypes()
        {
            var servicesTypes = db.ServiceTypes.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, servicesTypes, Configuration.Formatters.JsonFormatter);
        }

        // GET: api/ServiceTypesApi/5
        [ResponseType(typeof(ServiceType))]
        public IHttpActionResult GetServiceType(int id)
        {
            ServiceType serviceType = db.ServiceTypes.Find(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            return Ok(serviceType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceTypeExists(int id)
        {
            return db.ServiceTypes.Count(e => e.ServiceTypeCd == id) > 0;
        }
    }
}