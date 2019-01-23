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
        [ResponseType(typeof(IQueryable<AllergensDTO>))]
        public async Task<IHttpActionResult> GetAllergens()
        {
            var result = await (from r in db.Allergens
                         select new AllergensDTO()
                         {
                             ID = r.ID,
                             Name = r.Name,
                             Recipes = (from s in r.Recipes select s.Id).AsEnumerable().ToList()
                         }).ToListAsync();

            return Ok(result);
        }

        // GET: api/Allergens/5
        [ResponseType(typeof(AllergensDTO))]
        public async Task<IHttpActionResult> GetAllergens(int id)
        {
            AllergensDTO result = await (from r in db.Allergens
                                         where r.ID == id
                                         select new AllergensDTO()
                                         {
                                             ID = r.ID,
                                             Name = r.Name,
                                             Recipes = (from s in r.Recipes select s.Id).AsEnumerable().ToList()
                                         }).FirstAsync();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Allergens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAllergens(int id, AllergensDTO allergensDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != allergensDTO.ID)
            {
                return BadRequest();
            }

            var compare = allergensDTO.Recipes.Select(i => db.Recipes.Find(i)).ToList();

            var allergens = db.Allergens.Where(a => a.ID == id).First();

            allergens.Name = allergensDTO.Name;

            var deleted = allergens.Recipes.AsQueryable().Except(compare.AsQueryable()).ToList();

            var added = compare.AsQueryable().Except(allergens.Recipes.AsQueryable()).ToList();

            deleted.ForEach(d => allergens.Recipes.Remove(d));

            foreach(Recipes r in added)
            {
                if (r == null)
                {
                    NotFound(); 
                }
                if (db.Entry(r).State == EntityState.Detached)
                    db.Recipes.Attach(r);

                allergens.Recipes.Add(r);
            }

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
        [ResponseType(typeof(AllergensDTO))]
        public async Task<IHttpActionResult> PostAllergens(AllergensDTO allergensDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedRecipies = allergensDTO.Recipes.Select(i => db.Recipes.Find(i)).ToList();

            if(addedRecipies.Contains(null))
            {
                return NotFound();
            }

            Allergens allergens = new Allergens()
            {
                Name = allergensDTO.Name,
                Recipes = addedRecipies
            };

            db.Allergens.Add(allergens);
            await db.SaveChangesAsync();

            var x =  CreatedAtRoute("DefaultApi", new { id = allergens.ID }, allergens);

            allergensDTO.ID = allergens.ID;

            return Ok(allergensDTO);

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

            AllergensDTO result = (new AllergensDTO()
            {
                ID = allergens.ID,
                Name = allergens.Name,
                Recipes = (from s in allergens.Recipes select s.Id).AsEnumerable().ToList()
            });

            db.Allergens.Remove(allergens);
            await db.SaveChangesAsync();

            return Ok(result);
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