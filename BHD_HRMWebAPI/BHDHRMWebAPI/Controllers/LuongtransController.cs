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
    public class LuongtransController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public LuongtransController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/Luongtrans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Luongtran>>> GetLuongtran()
        {
            return await _context.Luongtran.ToListAsync();
        }

        // GET: api/Luongtrans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Luongtran>> GetLuongtran(int id)
        {
            var luongtran = await _context.Luongtran.FindAsync(id);

            if (luongtran == null)
            {
                return NotFound();
            }

            return luongtran;
        }

        // PUT: api/Luongtrans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLuongtran(int id, Luongtran luongtran)
        {
            if (id != luongtran.Id)
            {
                return BadRequest();
            }

            _context.Entry(luongtran).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LuongtranExists(id))
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

        // POST: api/Luongtrans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Luongtran>> PostLuongtran(Luongtran luongtran)
        {
            _context.Luongtran.Add(luongtran);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLuongtran", new { id = luongtran.Id }, luongtran);
        }

        // DELETE: api/Luongtrans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Luongtran>> DeleteLuongtran(int id)
        {
            var luongtran = await _context.Luongtran.FindAsync(id);
            if (luongtran == null)
            {
                return NotFound();
            }

            _context.Luongtran.Remove(luongtran);
            await _context.SaveChangesAsync();

            return luongtran;
        }

        private bool LuongtranExists(int id)
        {
            return _context.Luongtran.Any(e => e.Id == id);
        }
    }
}
