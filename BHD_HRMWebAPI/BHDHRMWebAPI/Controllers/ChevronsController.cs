using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BHDHRMWebAPI.Models;

namespace BHDHRMWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChevronsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public ChevronsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/Chevrons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chevrons>>> GetChevrons()
        {
            return await _context.Chevrons.ToListAsync();
        }

        // GET: api/Chevrons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chevrons>> GetChevrons(int id)
        {
            var chevrons = await _context.Chevrons.FindAsync(id);

            if (chevrons == null)
            {
                return NotFound();
            }

            return chevrons;
        }

        // PUT: api/Chevrons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChevrons(int id, Chevrons chevrons)
        {
            if (id != chevrons.ChevronId)
            {
                return BadRequest();
            }

            _context.Entry(chevrons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChevronsExists(id))
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

        // POST: api/Chevrons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Chevrons>> PostChevrons(Chevrons chevrons)
        {
            _context.Chevrons.Add(chevrons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChevrons", new { id = chevrons.ChevronId }, chevrons);
        }

        // DELETE: api/Chevrons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chevrons>> DeleteChevrons(int id)
        {
            var chevrons = await _context.Chevrons.FindAsync(id);
            if (chevrons == null)
            {
                return NotFound();
            }

            _context.Chevrons.Remove(chevrons);
            await _context.SaveChangesAsync();

            return chevrons;
        }

        private bool ChevronsExists(int id)
        {
            return _context.Chevrons.Any(e => e.ChevronId == id);
        }
    }
}
