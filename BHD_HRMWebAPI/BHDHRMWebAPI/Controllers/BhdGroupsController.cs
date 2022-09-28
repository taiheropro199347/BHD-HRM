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
    public class BhdGroupsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public BhdGroupsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/BhdGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BhdGroup>>> GetBhdGroup()
        {
            return await _context.BhdGroup.ToListAsync();
        }

        // GET: api/BhdGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BhdGroup>> GetBhdGroup(int id)
        {
            var bhdGroup = await _context.BhdGroup.FindAsync(id);

            if (bhdGroup == null)
            {
                return NotFound();
            }

            return bhdGroup;
        }

        // PUT: api/BhdGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBhdGroup(int id, BhdGroup bhdGroup)
        {
            if (id != bhdGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(bhdGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BhdGroupExists(id))
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

        // POST: api/BhdGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BhdGroup>> PostBhdGroup(BhdGroup bhdGroup)
        {
            _context.BhdGroup.Add(bhdGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBhdGroup", new { id = bhdGroup.Id }, bhdGroup);
        }

        // DELETE: api/BhdGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BhdGroup>> DeleteBhdGroup(int id)
        {
            var bhdGroup = await _context.BhdGroup.FindAsync(id);
            if (bhdGroup == null)
            {
                return NotFound();
            }

            _context.BhdGroup.Remove(bhdGroup);
            await _context.SaveChangesAsync();

            return bhdGroup;
        }

        private bool BhdGroupExists(int id)
        {
            return _context.BhdGroup.Any(e => e.Id == id);
        }
    }
}
