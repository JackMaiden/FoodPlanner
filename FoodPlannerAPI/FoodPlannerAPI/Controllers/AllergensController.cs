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
    public class AllergensController : ApiController
    {
        private FoodPlannerAPIContext db = new FoodPlannerAPIContext();

        // GET: api/Allergens
        public IQueryable<Allergens> GetAllergens()
        {
            return db.Allergens;
        }

        // GET: api/Allergens/5
        [ResponseType(typeof(Allergens))]
        public async Task<IHttpActionResult> GetAllergens(int id)
        {
            Allergens allergens = await db.Allergens.FindAsync(id);
            if (allergens == null)
            {
                return NotFound();
            }

            return Ok(allergens);
        }

        // PUT: api/Allergens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAllergens(int id, Allergens allergens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != allergens.ID)
            {
                return BadRequest();
            }

            db.Entry(allergens).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllergensExists(id))
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

        // POST: api/Allergens
        [ResponseType(typeof(Allergens))]
        public async Task<IHttpActionResult> PostAllergens(Allergens allergens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Allergens.Add(allergens);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = allergens.ID }, allergens);
        }

        // DELETE: api/Allergens/5
        [ResponseType(typeof(Allergens))]
        public async Task<IHttpActionResult> DeleteAllergens(int id)
        {
            Allergens allergens = await db.Allergens.FindAsync(id);
            if (allergens == null)
            {
                return NotFound();
            }

            db.Allergens.Remove(allergens);
            await db.SaveChangesAsync();

            return Ok(allergens);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AllergensExists(int id)
        {
            return db.Allergens.Count(e => e.ID == id) > 0;
        }
    }
}