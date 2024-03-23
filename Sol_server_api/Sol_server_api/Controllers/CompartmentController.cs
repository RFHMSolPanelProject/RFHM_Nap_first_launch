using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sol_server_api.Data;
using Sol_server_api.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_server_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompartmentController : ControllerBase
    {
        private readonly SolContext _context;

        public CompartmentController(SolContext context)
        {
            _context = context;
        }

        // GET: api/Compartment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compartment>>> GetCompartments()
        {
            return await _context.Compartments.ToListAsync();
        }

        // GET: api/Compartment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compartment>> GetCompartment(string id)
        {
            var compartment = await _context.Compartments.FindAsync(id);

            if (compartment == null)
            {
                return NotFound();
            }

            return compartment;
        }

        // PUT: api/Compartment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompartment(string id, Compartment compartment)
        {
            if (id != compartment.CompartmentID)
            {
                return BadRequest();
            }

            _context.Entry(compartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Compartment
        [HttpPost]
        public async Task<ActionResult<Compartment>> PostCompartment(Compartment compartment)
        {
            _context.Compartments.Add(compartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompartment), new { id = compartment.CompartmentID }, compartment);
        }

        // DELETE: api/Compartment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompartment(string id)
        {
            var compartment = await _context.Compartments.FindAsync(id);
            if (compartment == null)
            {
                return NotFound();
            }

            _context.Compartments.Remove(compartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompartmentExists(string id)
        {
            return _context.Compartments.Any(e => e.CompartmentID == id);
        }
    }
}