using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FoodPlannerAPI.Models;
using FoodPlannerAPI.Models.RecipieModule;

namespace FoodPlannerAPI.Controllers
{
    public class MethodStepsController : ApiController
    {
        private FoodPlannerAPIContext db = new FoodPlannerAPIContext();

        // GET: api/MethodSteps
        public IQueryable<MethodSteps> GetMethodSteps()
        {
            return db.MethodSteps;
        }

        // GET: api/MethodSteps/5
        [ResponseType(typeof(MethodSteps))]
        public async Task<IHttpActionResult> GetMethodSteps(int id)
        {
            MethodSteps methodSteps = await db.MethodSteps.FindAsync(id);
            if (methodSteps == null)
            {
                return NotFound();
            }

            return Ok(methodSteps);
        }

        // PUT: api/MethodSteps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMethodSteps(int id, MethodSteps methodSteps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != methodSteps.Id)
            {
                return BadRequest();
            }

            db.Entry(methodSteps).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MethodStepsExists(id))
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

        // POST: api/MethodSteps
        [ResponseType(typeof(MethodSteps))]
        public async Task<IHttpActionResult> PostMethodSteps(MethodSteps methodSteps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MethodSteps.Add(methodSteps);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = methodSteps.Id }, methodSteps);
        }

        // DELETE: api/MethodSteps/5
        [ResponseType(typeof(MethodSteps))]
        public async Task<IHttpActionResult> DeleteMethodSteps(int id)
        {
            MethodSteps methodSteps = await db.MethodSteps.FindAsync(id);
            if (methodSteps == null)
            {
                return NotFound();
            }

            db.MethodSteps.Remove(methodSteps);
            await db.SaveChangesAsync();

            return Ok(methodSteps);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MethodStepsExists(int id)
        {
            return db.MethodSteps.Count(e => e.Id == id) > 0;
        }
    }
}