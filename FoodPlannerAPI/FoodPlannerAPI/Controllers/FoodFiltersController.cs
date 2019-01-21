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
    public class FoodFiltersController : ApiController
    {
        private FoodPlannerAPIContext db = new FoodPlannerAPIContext();

        // GET: api/FoodFilters
        public IQueryable<FoodFilters> GetFoodFilters()
        {
            return db.FoodFilters;
        }

        // GET: api/FoodFilters/5
        [ResponseType(typeof(FoodFilters))]
        public async Task<IHttpActionResult> GetFoodFilters(int id)
        {
            FoodFilters foodFilters = await db.FoodFilters.FindAsync(id);
            if (foodFilters == null)
            {
                return NotFound();
            }

            return Ok(foodFilters);
        }

        // PUT: api/FoodFilters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFoodFilters(int id, FoodFilters foodFilters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foodFilters.ID)
            {
                return BadRequest();
            }

            db.Entry(foodFilters).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodFiltersExists(id))
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

        // POST: api/FoodFilters
        [ResponseType(typeof(FoodFilters))]
        public async Task<IHttpActionResult> PostFoodFilters(FoodFilters foodFilters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FoodFilters.Add(foodFilters);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = foodFilters.ID }, foodFilters);
        }

        // DELETE: api/FoodFilters/5
        [ResponseType(typeof(FoodFilters))]
        public async Task<IHttpActionResult> DeleteFoodFilters(int id)
        {
            FoodFilters foodFilters = await db.FoodFilters.FindAsync(id);
            if (foodFilters == null)
            {
                return NotFound();
            }

            db.FoodFilters.Remove(foodFilters);
            await db.SaveChangesAsync();

            return Ok(foodFilters);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoodFiltersExists(int id)
        {
            return db.FoodFilters.Count(e => e.ID == id) > 0;
        }
    }
}