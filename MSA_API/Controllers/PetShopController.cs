using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace MSA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetShopController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public PetShopController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/PetShop
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var petShops = _context.PetShops.ToList();
                if (petShops == null || petShops.Count == 0)
                {
                    return NotFound("No pet shops found.");
                }

                return Ok(petShops);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving pet shops: {ex.Message}");
            }
        }

        // GET: api/PetShop/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var petShop = _context.PetShops.FirstOrDefault(ps => ps.Id == id);
            if (petShop == null)
            {
                return NotFound("Pet shop not found.");
            }

            return Ok(petShop);
        }

        // POST: api/PetShop
        [HttpPost]
        public IActionResult Post([FromForm] PetShopModel newPetShop, [FromForm] IFormFile image)
        {
            if (newPetShop == null)
            {
                return BadRequest("Invalid request data.");
            }

            try
            {
                if (image != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        image.CopyTo(memoryStream);
                        newPetShop.PetShopImage = memoryStream.ToArray();
                    }
                }

                _context.PetShops.Add(newPetShop);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Get), new { id = newPetShop.Id }, newPetShop);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding pet shop: {ex.Message}");
            }
        }

        // PUT: api/PetShop/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] PetShopModel updatedPetShop, [FromForm] IFormFile image)
        {
            var petShop = _context.PetShops.FirstOrDefault(ps => ps.Id == id);
            if (petShop == null)
            {
                return NotFound("Pet shop not found.");
            }

            try
            {
                petShop.PetShopName = updatedPetShop.PetShopName;

                if (image != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        image.CopyTo(memoryStream);
                        petShop.PetShopImage = memoryStream.ToArray();
                    }
                }

                _context.SaveChanges();

                return Ok(petShop);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating pet shop: {ex.Message}");
            }
        }

        // DELETE: api/PetShop/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var petShop = _context.PetShops.FirstOrDefault(ps => ps.Id == id);
            if (petShop == null)
            {
                return NotFound("Pet shop not found.");
            }

            try
            {
                _context.PetShops.Remove(petShop);
                _context.SaveChanges();

                return Ok("Pet shop deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting pet shop: {ex.Message}");
            }
        }
    }
}
