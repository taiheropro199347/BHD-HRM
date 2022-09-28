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
    public class ThietlapthuesController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public ThietlapthuesController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/Thietlapthues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thietlapthue>>> GetThietlapthue()
        {
            return await _context.Thietlapthue.ToListAsync();
        }

        // GET: api/Thietlapthues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thietlapthue>> GetThietlapthue(int id)
        {
            var thietlapthue = await _context.Thietlapthue.FindAsync(id);

            if (thietlapthue == null)
            {
                return NotFound();
            }

            return thietlapthue;
        }

        // PUT: api/Thietlapthues/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThietlapthue(int id, Thietlapthue thietlapthue)
        {
            if (id != thietlapthue.Id)
            {
                return BadRequest();
            }

            _context.Entry(thietlapthue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThietlapthueExists(id))
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

        // POST: api/Thietlapthues
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Thietlapthue>> PostThietlapthue(Thietlapthue thietlapthue)
        {
            _context.Thietlapthue.Add(thietlapthue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThietlapthue", new { id = thietlapthue.Id }, thietlapthue);
        }

        // DELETE: api/Thietlapthues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Thietlapthue>> DeleteThietlapthue(int id)
        {
            var thietlapthue = await _context.Thietlapthue.FindAsync(id);
            if (thietlapthue == null)
            {
                return NotFound();
            }

            _context.Thietlapthue.Remove(thietlapthue);
            await _context.SaveChangesAsync();

            return thietlapthue;
        }

        private bool ThietlapthueExists(int id)
        {
            return _context.Thietlapthue.Any(e => e.Id == id);
        }
    }
}
