using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Personal.Entities;
using Personal.Persistence;

namespace Personal.WebApi.Controller
{
    public class LocationsController : ApiController
    {
        private readonly IHrContext context;

        public LocationsController(IHrContext ctx)
        {
            context = ctx;
        }
        // GET: api/Locations
        public IHttpActionResult Get()
        {
            return Ok(context.Locations);
        }

        // GET: api/Locations/5
        public IHttpActionResult Get(int id)
        {
            var location = context.Locations.Find(id);
            if (location != null)
            {
                return Ok(location);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Locations
        public IHttpActionResult Post(Location location)
        {
            var addedLocation = context.Locations.Add(location);
            return CreatedAtRoute("DefaultApi", new { controller = "Locations", addedLocation.LocationId }, addedLocation);
        }

        // PUT: api/Jobs/5
        public IHttpActionResult Put(Location location)
        {
            var dbLocation = context.Locations.Find(location.LocationId);

            if (dbLocation != null)
            {
                dbLocation.City = location.City;
                dbLocation.PostalCode = location.PostalCode;
                dbLocation.StateProvince= location.StateProvince;
                dbLocation.StreetAddress= location.StreetAddress;
            }

            return Ok(context.SaveChanges());
        }

        
        // DELETE: api/Locations/5
        public IHttpActionResult Delete(int id)
        {
            var dbLocation = context.Locations.Find(id);
            if (dbLocation != null)
            {
                return Ok(context.Locations.Remove(dbLocation));
            }
            else return NotFound();
        }
    }
}
 