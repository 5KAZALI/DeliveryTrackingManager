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
using Driver.Models;

namespace Driver.Controllers
{
    public class DropOffPointsController : ApiController
    {
        private DropOffPointsContext db = new DropOffPointsContext();

        // GET: api/DropOffPoints
        public IQueryable<DropOffPoint> GetDropOffPoints()
        {
            return db.DropOffPoints;
        }

        // GET: api/DropOffPoints/5
        [ResponseType(typeof(DropOffPoint))]
        public IHttpActionResult GetDropOffPoint(int id)
        {
            DropOffPoint dropOffPoint = db.DropOffPoints.Find(id);
            if (dropOffPoint == null)
            {
                return NotFound();
            }

            return Ok(dropOffPoint);
        }

        // PUT: api/DropOffPoints/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDropOffPoint(int id, DropOffPoint dropOffPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dropOffPoint.Id)
            {
                return BadRequest();
            }

            db.Entry(dropOffPoint).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DropOffPointExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DropOffPoints
        [ResponseType(typeof(DropOffPoint))]
        public IHttpActionResult PostDropOffPoint(DropOffPoint dropOffPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DropOffPoints.Add(dropOffPoint);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dropOffPoint.Id }, dropOffPoint);
        }

        // DELETE: api/DropOffPoints/5
        [ResponseType(typeof(DropOffPoint))]
        public IHttpActionResult DeleteDropOffPoint(int id)
        {
            DropOffPoint dropOffPoint = db.DropOffPoints.Find(id);
            if (dropOffPoint == null)
            {
                return NotFound();
            }

            db.DropOffPoints.Remove(dropOffPoint);
            db.SaveChanges();

            return Ok(dropOffPoint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DropOffPointExists(int id)
        {
            return db.DropOffPoints.Count(e => e.Id == id) > 0;
        }
    }
}