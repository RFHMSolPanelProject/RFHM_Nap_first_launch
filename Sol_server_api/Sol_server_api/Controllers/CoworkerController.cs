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
    public class CoworkerController : ControllerBase
    {
        private readonly SolContext _context;

        public CoworkerController(SolContext context)
        {
            _context = context;
        }

        // GET: api/Coworker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coworker>>> GetCoworkers()
        {
            return await _context.Coworkers.ToListAsync();
        }

        // GET: api/Coworker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coworker>> GetCoworker(string id)
        {
            var coworker = await _context.Coworkers.FindAsync(id);

            if (coworker == null)
            {
                return NotFound();
            }

            return coworker;
        }

        // PUT: api/Coworker/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoworker(string id, Coworker coworker)
        {
            if (id != coworker.CoworkerID)
            {
                return BadRequest();
            }

            _context.Entry(coworker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoworkerExists(id))
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

        // POST: api/Coworker
        [HttpPost]
        public async Task<ActionResult<Coworker>> PostCoworker(Coworker coworker)
        {
            _context.Coworkers.Add(coworker);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCoworker), new { id = coworker.CoworkerID }, coworker);
        }

        // DELETE: api/Coworker/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoworker(string id)
        {
            var coworker = await _context.Coworkers.FindAsync(id);
            if (coworker == null)
            {
                return NotFound();
            }

            _context.Coworkers.Remove(coworker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoworkerExists(string id)
        {
            return _context.Coworkers.Any(e => e.CoworkerID == id);
        }
    }
}
