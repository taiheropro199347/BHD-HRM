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
    public class TblHopDongsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblHopDongsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblHopDongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblHopDong>>> GetTblHopDong()
        {
            return await _context.TblHopDong.ToListAsync();
        }

        // GET: api/TblHopDongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblHopDong>> GetTblHopDong(int id)
        {
            var tblHopDong = await _context.TblHopDong.FindAsync(id);

            if (tblHopDong == null)
            {
                return NotFound();
            }

            return tblHopDong;
        }

        // PUT: api/TblHopDongs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblHopDong(int id, TblHopDong tblHopDong)
        {
            if (id != tblHopDong.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblHopDong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblHopDongExists(id))
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

        // POST: api/TblHopDongs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblHopDong>> PostTblHopDong(TblHopDong tblHopDong)
        {
            _context.TblHopDong.Add(tblHopDong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblHopDong", new { id = tblHopDong.Id }, tblHopDong);
        }

        // DELETE: api/TblHopDongs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblHopDong>> DeleteTblHopDong(int id)
        {
            var tblHopDong = await _context.TblHopDong.FindAsync(id);
            if (tblHopDong == null)
            {
                return NotFound();
            }

            _context.TblHopDong.Remove(tblHopDong);
            await _context.SaveChangesAsync();

            return tblHopDong;
        }

        private bool TblHopDongExists(int id)
        {
            return _context.TblHopDong.Any(e => e.Id == id);
        }
    }
}
