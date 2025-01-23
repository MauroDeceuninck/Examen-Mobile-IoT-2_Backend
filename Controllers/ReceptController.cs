using Microsoft.AspNetCore.Mvc;
using ReceptenApi.Models;
using System.Collections.Generic;

namespace ReceptenApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptController : ControllerBase
    {
        private static readonly List<Recept> Recepten = new List<Recept>();

        [HttpGet]
        public IActionResult GetRecepten()
        {
            return Ok(Recepten);
        }

        [HttpPost]
        public IActionResult AddRecept([FromBody] Recept recept)
        {
            if (recept == null || string.IsNullOrEmpty(recept.Naam))
            {
                return BadRequest("Ongeldig recept.");
            }

            Recepten.Add(recept);
            return CreatedAtAction(nameof(GetRecepten), recept);
        }
    }
}
