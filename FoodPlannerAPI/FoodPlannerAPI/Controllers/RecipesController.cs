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
    public class RecipesController : ApiController
    {
        private FoodPlannerAPIContext db = new FoodPlannerAPIContext();

        // GET: api/Recipes
        public IQueryable<Recipes> GetRecipes()
        {
            return db.Recipes;
        }

        // GET: api/Recipes/5
        [ResponseType(typeof(Recipes))]
        public async Task<IHttpActionResult> GetRecipes(int id)
        {
            Recipes Recipes = await db.Recipes.FindAsync(id);
            if (Recipes == null)
            {
                return NotFound();
            }

            return Ok(Recipes);
        }

        // PUT: api/Recipes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRecipes(int id, Recipes Recipes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Recipes.Id)
            {
                return BadRequest();
            }

            db.Entry(Recipes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipesExists(id))
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

        // POST: api/Recipes
        [ResponseType(typeof(Recipes))]
        public async Task<IHttpActionResult> PostRecipes(Recipes Recipes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recipes.Add(Recipes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = Recipes.Id }, Recipes);
        }

        // DELETE: api/Recipes/5
        [ResponseType(typeof(Recipes))]
        public async Task<IHttpActionResult> DeleteRecipes(int id)
        {
            Recipes Recipes = await db.Recipes.FindAsync(id);
            if (Recipes == null)
            {
                return NotFound();
            }

            db.Recipes.Remove(Recipes);
            await db.SaveChangesAsync();

            return Ok(Recipes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipesExists(int id)
        {
            return db.Recipes.Count(e => e.Id == id) > 0;
        }
    }
}