using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Personal.Entities;
using Personal.Persistence;

namespace Personal.WebApi.Controller
{
    public class JobsController : ApiController
    {
        private readonly IHrContext context;

        public JobsController(IHrContext ctx)
        {
            context = ctx;
        }
        public IHttpActionResult Get()
        {
            return Ok(context.Jobs);
        }

        public IHttpActionResult Get(string id)
        {
            var job = context.Jobs.Find(id);
            if (job != null)
            {
                return Ok(job);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Jobs
        public IHttpActionResult Post(Job job)
        {
            var addedJob = context.Jobs.Add(job);
            return CreatedAtRoute("DefaultApi", new {controller = "Jobs", addedJob.JobId}, addedJob);
        }

        // PUT: api/Jobs/5
        public IHttpActionResult Put(Job job)
        {
            var dbJob = context.Jobs.Find(job.JobId);

            if (dbJob != null)
            {
                dbJob.JobTitle = job.JobTitle;
                dbJob.MaxSalary = job.MaxSalary;
                dbJob.MinSalary = job.MinSalary;
            }
             
            return Ok(context.SaveChanges());
        }

        // DELETE: api/Jobs/5
        public IHttpActionResult Delete(string id)
        {
            var dbJob = context.Jobs.Find(id);
            if (dbJob != null)
            {
                return Ok(context.Jobs.Remove(dbJob));
            }
            else return NotFound();
        }
       
    }
}




       
