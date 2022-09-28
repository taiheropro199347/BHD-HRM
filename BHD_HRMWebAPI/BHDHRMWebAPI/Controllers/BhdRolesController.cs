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
    public class BhdRolesController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public BhdRolesController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/BhdRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BhdRoles>>> GetBhdRoles()
        {
            return await _context.BhdRoles.ToListAsync();
        }

        // GET: api/BhdRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BhdRoles>> GetBhdRoles(int id)
        {
            var bhdRoles = await _context.BhdRoles.FindAsync(id);

            if (bhdRoles == null)
            {
                return NotFound();
            }

            return bhdRoles;
        }

        // PUT: api/BhdRoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBhdRoles(int id, BhdRoles bhdRoles)
        {
            if (id != bhdRoles.Id)
            {
                return BadRequest();
            }

            _context.Entry(bhdRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BhdRolesExists(id))
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

        // POST: api/BhdRoles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BhdRoles>> PostBhdRoles(BhdRoles bhdRoles)
        {
            _context.BhdRoles.Add(bhdRoles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBhdRoles", new { id = bhdRoles.Id }, bhdRoles);
        }

        // DELETE: api/BhdRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BhdRoles>> DeleteBhdRoles(int id)
        {
            var bhdRoles = await _context.BhdRoles.FindAsync(id);
            if (bhdRoles == null)
            {
                return NotFound();
            }

            _context.BhdRoles.Remove(bhdRoles);
            await _context.SaveChangesAsync();

            return bhdRoles;
        }

        private bool BhdRolesExists(int id)
        {
            return _context.BhdRoles.Any(e => e.Id == id);
        }
    }
}
