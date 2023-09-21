using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPetOwners()
        {
            return _context.PetOwners.ToList();
        }

        [HttpPost]
        public PetOwner Post(PetOwner PetOwner)
        {
            // Tell the DB context about our new bread object
            _context.Add(PetOwner);
            // ...and save the bread object to the database
            _context.SaveChanges();

            // Respond back with the created bread object
            return PetOwner;
        }
    }
}
