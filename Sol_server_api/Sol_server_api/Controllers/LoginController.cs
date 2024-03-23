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
    public class LoginController : ControllerBase
    {
        private readonly SolContext _context;

        public LoginController(SolContext context)
        {
            _context = context;
        }

        // GET: api/Login
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogins()
        {
            return await _context.Logins.ToListAsync();
        }

        // GET: api//5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(string id)
        {
            var login = await _context.Logins.FindAsync(id);

            if ( login == null)
            {
                return NotFound();
            }

            return login;
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(string id, Login login)
        {
            if (id != login.LoginID)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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

        // POST: api/Login
        [HttpPost]
        public async Task<ActionResult<Login>> PostLogin(Login login)
        {
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLogin), new { id = login.LoginID }, login);
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin(string id)
        {
            var login= await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginExists(string id)
        {
            return _context.Logins.Any(e => e.LoginID == id);
        }
    }
}
