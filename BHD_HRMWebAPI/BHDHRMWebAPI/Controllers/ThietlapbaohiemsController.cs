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
    public class ThietlapbaohiemsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public ThietlapbaohiemsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/Thietlapbaohiems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thietlapbaohiem>>> GetThietlapbaohiem()
        {
            return await _context.Thietlapbaohiem.ToListAsync();
        }

        // GET: api/Thietlapbaohiems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thietlapbaohiem>> GetThietlapbaohiem(int id)
        {
            var thietlapbaohiem = await _context.Thietlapbaohiem.FindAsync(id);

            if (thietlapbaohiem == null)
            {
                return NotFound();
            }

            return thietlapbaohiem;
        }

        // PUT: api/Thietlapbaohiems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThietlapbaohiem(int id, Thietlapbaohiem thietlapbaohiem)
        {
            if (id != thietlapbaohiem.Id)
            {
                return BadRequest();
            }

            _context.Entry(thietlapbaohiem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThietlapbaohiemExists(id))
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

        // POST: api/Thietlapbaohiems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Thietlapbaohiem>> PostThietlapbaohiem(Thietlapbaohiem thietlapbaohiem)
        {
            _context.Thietlapbaohiem.Add(thietlapbaohiem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThietlapbaohiem", new { id = thietlapbaohiem.Id }, thietlapbaohiem);
        }

        // DELETE: api/Thietlapbaohiems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Thietlapbaohiem>> DeleteThietlapbaohiem(int id)
        {
            var thietlapbaohiem = await _context.Thietlapbaohiem.FindAsync(id);
            if (thietlapbaohiem == null)
            {
                return NotFound();
            }

            _context.Thietlapbaohiem.Remove(thietlapbaohiem);
            await _context.SaveChangesAsync();

            return thietlapbaohiem;
        }

        private bool ThietlapbaohiemExists(int id)
        {
            return _context.Thietlapbaohiem.Any(e => e.Id == id);
        }
    }
}
