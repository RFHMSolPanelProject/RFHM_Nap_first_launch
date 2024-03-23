// CustomerController.cs
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
    public class ProjectPackageController : ControllerBase
    {
        private readonly SolContext _context;

        public ProjectPackageController(SolContext context)
        {
            _context = context;
        }

        // GET: api/ProjectPackage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectPackage>>> GetProjectPackages()
        {
            return await _context.ProjectPackages.ToListAsync();
        }

        // GET: api/ProjectPackage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectPackage>> GetProjectPackage(string id)
        {
            var projectPackage = await _context.ProjectPackages.FindAsync(id);

            if (projectPackage == null)
            {
                return NotFound();
            }

            return projectPackage;
        }

        // PUT: api/ProjectPackage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectPackage(string id, ProjectPackage projectPackage)
        {
            if (id != projectPackage.PackageID)
            {
                return BadRequest();
            }

            _context.Entry(projectPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectPackageExists(id))
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

        // POST: api/ProjectPackage
        [HttpPost]
        public async Task<ActionResult<ProjectPackage>> PostProjectPackage(ProjectPackage projectPackage)
        {
            _context.ProjectPackages.Add(projectPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProjectPackage), new { id = projectPackage.PackageID }, projectPackage);
        }

        // DELETE: api/ProjectPackage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectPackage(string id)
        {
            var projectPackage = await _context.ProjectPackages.FindAsync(id);
            if (projectPackage == null)
            {
                return NotFound();
            }

            _context.ProjectPackages.Remove(projectPackage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectPackageExists(string id)
        {
            return _context.ProjectPackages.Any(e => e.PackageID == id);
        }
    }
}




