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
    public class ComponentController : ControllerBase
    {
        private readonly SolContext _context;

        public ComponentController(SolContext context)
        {
            _context = context;
        }

        // GET: api/Component
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponents()
        {
            return await _context.Components.ToListAsync();
        }

        // GET: api/Component/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Component>> GetComponent(string id)
        {
            var component = await _context.Components.FindAsync(id);

            if (component == null)
            {
                return NotFound();
            }

            return component;
        }

        // PUT: api/Component/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Component component)
        {
            if (id != component.ComponentID)
            {
                return BadRequest();
            }

            _context.Entry(component).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentExists(id))
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

        // POST: api/Component
        [HttpPost]
        public async Task<ActionResult<Component>> PostProcess(Component component)
        {
            _context.Components.Add(component);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComponent), new { id = component.ComponentID }, component);
        }

        // DELETE: api/Component/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcess(string id)
        {
            var component = await _context.Components.FindAsync(id);
            if (component == null)
            {
                return NotFound();
            }

            _context.Components.Remove(component);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponentExists(string id)
        {
            return _context.Components.Any(e => e.ComponentID == id);
        }
    }
}