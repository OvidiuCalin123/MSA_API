using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace MSA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CitiesController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Cities
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cities = _context.Cities.ToList();
                if (cities == null || cities.Count == 0)
                {
                    return NotFound("No cities found.");
                }

                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving cities: {ex.Message}");
            }
        }

        // GET: api/Cities/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
            {
                return NotFound("City not found.");
            }

            return Ok(city);
        }

        // POST: api/Cities
        [HttpPost]
        public IActionResult Post([FromBody] CityModel newCity)
        {
            if (newCity == null)
            {
                return BadRequest("Invalid request data.");
            }

            try
            {
                _context.Cities.Add(newCity);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Get), new { id = newCity.Id }, newCity);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding city: {ex.Message}");
            }
        }

        // PUT: api/Cities/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CityModel updatedCity, [FromForm] IFormFile image)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
            {
                return NotFound("City not found.");
            }

            try
            {
                city.CityName = updatedCity.CityName;

                if (image != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        image.CopyTo(memoryStream);
                        updatedCity.CityImage = memoryStream.ToArray();
                    }
                }

                _context.SaveChanges();

                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating city: {ex.Message}");
            }
        }

        // DELETE: api/Cities/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
            {
                return NotFound("City not found.");
            }

            try
            {
                _context.Cities.Remove(city);
                _context.SaveChanges();

                return Ok("City deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting city: {ex.Message}");
            }
        }
    }
}
