using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace MSA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AnimalController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var animals = _context.Animals.ToList();
                if (animals == null || animals.Count == 0)
                {
                    return NotFound("No animals found.");
                }

                return Ok(animals);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving animals: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return NotFound("Animal not found.");
            }

            return Ok(animal);
        }

        [HttpPost]
        public IActionResult Post([FromForm] AnimalModel newAnimal, [FromForm] IFormFile animalImage)
        {
            if (newAnimal == null)
            {
                return BadRequest("Invalid animal data.");
            }

            try
            {
                if (animalImage != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        animalImage.CopyTo(memoryStream);
                        newAnimal.AnimalImage = memoryStream.ToArray();
                    }
                }

                _context.Animals.Add(newAnimal);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Get), new { id = newAnimal.Id }, newAnimal);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding animal: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] AnimalModel updatedAnimal, [FromForm] IFormFile animalImage)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return NotFound("Animal not found.");
            }

            try
            {
                animal.AnimalName = updatedAnimal.AnimalName;
                animal.Type = updatedAnimal.Type;
                animal.Available = updatedAnimal.Available;
                animal.Price = updatedAnimal.Price;
                animal.ContactNumber = updatedAnimal.ContactNumber;
                animal.Description = updatedAnimal.Description;
                animal.Age = updatedAnimal.Age;
                animal.Breed = updatedAnimal.Breed;
                animal.Gender = updatedAnimal.Gender;

                if (animalImage != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        animalImage.CopyTo(memoryStream);
                        animal.AnimalImage = memoryStream.ToArray();
                    }
                }

                _context.SaveChanges();

                return Ok(animal);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating animal: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return NotFound("Animal not found.");
            }

            try
            {
                _context.Animals.Remove(animal);
                _context.SaveChanges();
                return Ok("Animal deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting animal: {ex.Message}");
            }
        }
    }
}
