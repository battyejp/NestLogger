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
using NestLogger.Dtos;
using NestLogger.Models;

namespace NestLogger.Controllers
{
    public class ThermostateReadingsServiceController : ApiController
    {
        private NestLoggerContext db = new NestLoggerContext();

        // GET: api/ThermostateReadingsService
        public IQueryable<ThermostateReading> GetThermostateReadings()
        {
            return db.ThermostateReadings;
        }

        /*// GET: api/ThermostateReadingsService/5
        [ResponseType(typeof(ThermostateReading))]
        public IHttpActionResult GetThermostateReading(int id)
        {
            ThermostateReading thermostateReading = db.ThermostateReadings.Find(id);
            if (thermostateReading == null)
            {
                return NotFound();
            }

            return Ok(thermostateReading);
        }

        // PUT: api/ThermostateReadingsService/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutThermostateReading(int id, ThermostateReading thermostateReading)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thermostateReading.Id)
            {
                return BadRequest();
            }

            db.Entry(thermostateReading).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThermostateReadingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }*/

        // POST: api/ThermostateReadingsService
        [ResponseType(typeof(ThermostateReading))]
        public IHttpActionResult PostThermostateReading(ThermostateReading thermostateReading)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ThermostateReadings.Add(thermostateReading);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = thermostateReading.Id }, thermostateReading);
        }

        // DELETE: api/ThermostateReadingsService/5
        /*[ResponseType(typeof(ThermostateReading))]
        public IHttpActionResult DeleteThermostateReading(int id)
        {
            ThermostateReading thermostateReading = db.ThermostateReadings.Find(id);
            if (thermostateReading == null)
            {
                return NotFound();
            }

            db.ThermostateReadings.Remove(thermostateReading);
            db.SaveChanges();

            return Ok(thermostateReading);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThermostateReadingExists(int id)
        {
            return db.ThermostateReadings.Count(e => e.Id == id) > 0;
        }*/
    }
}