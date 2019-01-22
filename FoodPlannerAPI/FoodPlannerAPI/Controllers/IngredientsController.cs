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
    public class IngredientsController : ApiController
    {
        private FoodPlannerAPIContext db = new FoodPlannerAPIContext();

        // GET: api/Ingredients
        public IQueryable<IngredientsDTO> GetIngredients()
        {
            var result =  from i in db.Ingredients
                   select new IngredientsDTO()
                   {
                       Id = i.Id,
                       Ingredient = i.Ingredient,
                       Recipe = i.Recipe.Id
                   };

            return result;
        }

        // GET: api/Ingredients/5
        [ResponseType(typeof(Ingredients))]
        public async Task<IHttpActionResult> GetIngredients(int id)
        {
            Ingredients ingredients = await db.Ingredients.FindAsync(id);
            if (ingredients == null)
            {
                return NotFound();
            }

            return Ok(ingredients);
        }

        // PUT: api/Ingredients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIngredients(int id, Ingredients ingredients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredients.Id)
            {
                return BadRequest();
            }

            db.Entry(ingredients).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientsExists(id))
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

        // POST: api/Ingredients
        [ResponseType(typeof(Ingredients))]
        public async Task<IHttpActionResult> PostIngredients(Ingredients ingredients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ingredients.Add(ingredients);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ingredients.Id }, ingredients);
        }

        // DELETE: api/Ingredients/5
        [ResponseType(typeof(Ingredients))]
        public async Task<IHttpActionResult> DeleteIngredients(int id)
        {
            Ingredients ingredients = await db.Ingredients.FindAsync(id);
            if (ingredients == null)
            {
                return NotFound();
            }

            db.Ingredients.Remove(ingredients);
            await db.SaveChangesAsync();

            return Ok(ingredients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredientsExists(int id)
        {
            return db.Ingredients.Count(e => e.Id == id) > 0;
        }
    }
}