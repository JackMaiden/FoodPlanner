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
    public class MealTypesController : ApiController
    {
        private FoodPlannerAPIContext db = new FoodPlannerAPIContext();

        // GET: api/MealTypes
        public IQueryable<MealTypesDTO> GetMealTypes()
        {
            var result =   from r in db.MealTypes
                           select new MealTypesDTO()
                           {
                               ID = r.ID,
                               Name = r.Name,
                               Recipes = (from s in r.Recipes select s.Id).AsEnumerable().ToList()
                           };

            return result;
        }

        // GET: api/MealTypes/5
        [ResponseType(typeof(MealTypes))]
        public async Task<IHttpActionResult> GetMealTypes(int id)
        {
            MealTypes mealTypes = await db.MealTypes.FindAsync(id);
            if (mealTypes == null)
            {
                return NotFound();
            }

            return Ok(mealTypes);
        }

        // PUT: api/MealTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMealTypes(int id, MealTypes mealTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mealTypes.ID)
            {
                return BadRequest();
            }

            db.Entry(mealTypes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealTypesExists(id))
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

        // POST: api/MealTypes
        [ResponseType(typeof(MealTypes))]
        public async Task<IHttpActionResult> PostMealTypes(MealTypes mealTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MealTypes.Add(mealTypes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mealTypes.ID }, mealTypes);
        }

        // DELETE: api/MealTypes/5
        [ResponseType(typeof(MealTypes))]
        public async Task<IHttpActionResult> DeleteMealTypes(int id)
        {
            MealTypes mealTypes = await db.MealTypes.FindAsync(id);
            if (mealTypes == null)
            {
                return NotFound();
            }

            db.MealTypes.Remove(mealTypes);
            await db.SaveChangesAsync();

            return Ok(mealTypes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MealTypesExists(int id)
        {
            return db.MealTypes.Count(e => e.ID == id) > 0;
        }
    }
}