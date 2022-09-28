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
    public class TblPhucLoisController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblPhucLoisController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblPhucLois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPhucLoi>>> GetTblPhucLoi()
        {
            return await _context.TblPhucLoi.ToListAsync();
        }

        // GET: api/TblPhucLois/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPhucLoi>> GetTblPhucLoi(int id)
        {
            var tblPhucLoi = await _context.TblPhucLoi.FindAsync(id);

            if (tblPhucLoi == null)
            {
                return NotFound();
            }

            return tblPhucLoi;
        }

        // PUT: api/TblPhucLois/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPhucLoi(int id, TblPhucLoi tblPhucLoi)
        {
            if (id != tblPhucLoi.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblPhucLoi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPhucLoiExists(id))
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

        // POST: api/TblPhucLois
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblPhucLoi>> PostTblPhucLoi(TblPhucLoi tblPhucLoi)
        {
            _context.TblPhucLoi.Add(tblPhucLoi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblPhucLoiExists(tblPhucLoi.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblPhucLoi", new { id = tblPhucLoi.Id }, tblPhucLoi);
        }

        // DELETE: api/TblPhucLois/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblPhucLoi>> DeleteTblPhucLoi(int id)
        {
            var tblPhucLoi = await _context.TblPhucLoi.FindAsync(id);
            if (tblPhucLoi == null)
            {
                return NotFound();
            }

            _context.TblPhucLoi.Remove(tblPhucLoi);
            await _context.SaveChangesAsync();

            return tblPhucLoi;
        }

        private bool TblPhucLoiExists(int id)
        {
            return _context.TblPhucLoi.Any(e => e.Id == id);
        }
    }
}
