using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets.ToList();
        }


        [HttpPost]
        public Pet Post(Pet Pets)
        {
            _context.Add(Pets);
            _context.SaveChanges();

            return Pets;
       
        }

         [HttpPut("{id}")]
    public Pet Put(int id, Pet Pets) 
    {
        // Our DB context needs to know the id of the bread to update
        Pets.id = id;

        // Tell the DB context about our updated bread object
        _context.Update(Pets);

        // ...and save the bread object to the database
        _context.SaveChanges();

        // Respond back with the created bread object
        return Pets;
    }
    [HttpDelete("{id}")]
    public void Delete(int id) 
    {
        // Our DB context needs to know the id of the bread to update
        Pet pets = _context.Pet.Find(id);

        // Tell the DB context about our updated bread object
        _context.Pet.Remove(pets);

        // ...and save the bread object to the database
        _context.SaveChanges();
        
    }
    }
}
