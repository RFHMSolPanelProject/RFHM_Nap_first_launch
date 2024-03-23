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
    public class PersonalDataController : ControllerBase
    {
        private readonly SolContext _context;

        public PersonalDataController(SolContext context)
        {
            _context = context;
        }

        // GET: api/PersonalData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalData>>> GetPersonalDatas()
        {
            return await _context.PersonalDatas.ToListAsync();
        }

        // GET: api/PersonalData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalData>> GetPersonalData(string id)
        {
            var personalData = await _context.PersonalDatas.FindAsync(id);

            if (personalData == null)
            {
                return NotFound();
            }

            return personalData;
        }

        // PUT: api/PersonalData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalData(string id, PersonalData personalData)
        {
            if (id != personalData.TelNumber)
            {
                return BadRequest();
            }

            _context.Entry(personalData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalDataExists(id))
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

        // POST: api/PersonalData
        [HttpPost]
        public async Task<ActionResult<PersonalData>> PostPersonalData(PersonalData personalData)
        {
            _context.PersonalDatas.Add(personalData);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonalData), new { id = personalData.TelNumber }, personalData);
        }

        // DELETE: api/PersonalData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalData(string id)
        {
            var personalData = await _context.PersonalDatas.FindAsync(id);
            if (personalData == null)
            {
                return NotFound();
            }

            _context.PersonalDatas.Remove(personalData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalDataExists(string id)
        {
            return _context.PersonalDatas.Any(e => e.TelNumber == id);
        }
    }
}
