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
    public class RecipiesController : ApiController
    {
        private FoodPlannerAPIContext db = new FoodPlannerAPIContext();

        // GET: api/Recipies
        public IQueryable<Recipies> GetRecipies()
        {
            return db.Recipies;
        }

        // GET: api/Recipies/5
        [ResponseType(typeof(Recipies))]
        public async Task<IHttpActionResult> GetRecipies(int id)
        {
            Recipies recipies = await db.Recipies.FindAsync(id);
            if (recipies == null)
            {
                return NotFound();
            }

            return Ok(recipies);
        }

        // PUT: api/Recipies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRecipies(int id, Recipies recipies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipies.Id)
            {
                return BadRequest();
            }

            db.Entry(recipies).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipiesExists(id))
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

        // POST: api/Recipies
        [ResponseType(typeof(Recipies))]
        public async Task<IHttpActionResult> PostRecipies(Recipies recipies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recipies.Add(recipies);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = recipies.Id }, recipies);
        }

        // DELETE: api/Recipies/5
        [ResponseType(typeof(Recipies))]
        public async Task<IHttpActionResult> DeleteRecipies(int id)
        {
            Recipies recipies = await db.Recipies.FindAsync(id);
            if (recipies == null)
            {
                return NotFound();
            }

            db.Recipies.Remove(recipies);
            await db.SaveChangesAsync();

            return Ok(recipies);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipiesExists(int id)
        {
            return db.Recipies.Count(e => e.Id == id) > 0;
        }
    }
}