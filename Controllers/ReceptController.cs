using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptenApi.Models;

namespace ReceptenApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptController : ControllerBase
    {
        private readonly ReceptenDbContext _context;

        public ReceptController(ReceptenDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecepten()
        {
            var recepten = await _context.Recepten.Include(r => r.Ingredienten).ToListAsync();
            return Ok(recepten);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecept(int id)
        {
            var recept = await _context.Recepten.Include(r => r.Ingredienten).FirstOrDefaultAsync(r => r.Id == id + 1);

            if (recept == null)
            {
                return NotFound();
            }

            return Ok(recept);
        }


        [HttpPost]
        public async Task<IActionResult> AddRecept([FromBody] Recept recept)
        {
            if (recept == null)
            {
                return BadRequest("Recept is ongeldig.");
            }

            _context.Recepten.Add(recept);
            await _context.SaveChangesAsync();

            // Ensure that the route name matches the route for GetRecept
            return CreatedAtAction(nameof(GetRecept), new { id = recept.Id }, recept);
        }

    }
}
