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

        [HttpGet("{index}")]
        public IActionResult GetRecept(int index)
        {
            if (index < 0 || index >= Recepten.Count)
            {
                return NotFound("Recept niet gevonden.");
            }

            return Ok(Recepten[index]);
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
