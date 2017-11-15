using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PetHealthServicePrototype.Models;

namespace PetHealthServicePrototype.Controllers
{   
    public class PetsController : ApiController
    {
        private PetHealthServiceEntities db = new PetHealthServiceEntities();

        // GET: api/Pets
        public IQueryable<Pet> GetPet()
        {
            return db.Pet;
        }

        // GET: api/Pets/5
        [ResponseType(typeof(Pet))]
        public IHttpActionResult GetPet(int id)
        {
            Pet pet = db.Pet.Find(id);
            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        // PUT: api/Pets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPet(int id, Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pet.PetId)
            {
                return BadRequest();
            }

            db.Entry(pet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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

        // POST: api/Pets
        [ResponseType(typeof(Pet))]
        public IHttpActionResult PostPet(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pet.Add(pet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PetExists(pet.PetId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pet.PetId }, pet);
        }

        // DELETE: api/Pets/5
        [ResponseType(typeof(Pet))]
        public IHttpActionResult DeletePet(int id)
        {
            Pet pet = db.Pet.Find(id);
            if (pet == null)
            {
                return NotFound();
            }

            db.Pet.Remove(pet);
            db.SaveChanges();

            return Ok(pet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetExists(int id)
        {
            return db.Pet.Count(e => e.PetId == id) > 0;
        }
    }
}