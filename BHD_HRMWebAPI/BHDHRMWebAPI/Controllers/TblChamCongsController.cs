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
    public class TblChamCongsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblChamCongsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblChamCongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblChamCong>>> GetTblChamCong()
        {
            return await _context.TblChamCong.ToListAsync();
        }

        // GET: api/TblChamCongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblChamCong>> GetTblChamCong(string id)
        {
            var tblChamCong = await _context.TblChamCong.FindAsync(id);

            if (tblChamCong == null)
            {
                return NotFound();
            }

            return tblChamCong;
        }

        // PUT: api/TblChamCongs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblChamCong(string id, TblChamCong tblChamCong)
        {
            if (id != tblChamCong.CardNumber)
            {
                return BadRequest();
            }

            _context.Entry(tblChamCong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblChamCongExists(id))
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

        // POST: api/TblChamCongs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblChamCong>> PostTblChamCong(TblChamCong tblChamCong)
        {
            _context.TblChamCong.Add(tblChamCong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblChamCongExists(tblChamCong.CardNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblChamCong", new { id = tblChamCong.CardNumber }, tblChamCong);
        }

        // DELETE: api/TblChamCongs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblChamCong>> DeleteTblChamCong(string id)
        {
            var tblChamCong = await _context.TblChamCong.FindAsync(id);
            if (tblChamCong == null)
            {
                return NotFound();
            }

            _context.TblChamCong.Remove(tblChamCong);
            await _context.SaveChangesAsync();

            return tblChamCong;
        }

        private bool TblChamCongExists(string id)
        {
            return _context.TblChamCong.Any(e => e.CardNumber == id);
        }
    }
}
