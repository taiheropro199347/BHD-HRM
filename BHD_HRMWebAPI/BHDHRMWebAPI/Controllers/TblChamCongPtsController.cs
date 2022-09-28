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
    public class TblChamCongPtsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblChamCongPtsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblChamCongPts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblChamCongPt>>> GetTblChamCongPt()
        {
            return await _context.TblChamCongPt.ToListAsync();
        }

        // GET: api/TblChamCongPts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblChamCongPt>> GetTblChamCongPt(string id)
        {
            var tblChamCongPt = await _context.TblChamCongPt.FindAsync(id);

            if (tblChamCongPt == null)
            {
                return NotFound();
            }

            return tblChamCongPt;
        }

        // PUT: api/TblChamCongPts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblChamCongPt(string id, TblChamCongPt tblChamCongPt)
        {
            if (id != tblChamCongPt.CardNumber)
            {
                return BadRequest();
            }

            _context.Entry(tblChamCongPt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblChamCongPtExists(id))
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

        // POST: api/TblChamCongPts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblChamCongPt>> PostTblChamCongPt(TblChamCongPt tblChamCongPt)
        {
            _context.TblChamCongPt.Add(tblChamCongPt);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblChamCongPtExists(tblChamCongPt.CardNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblChamCongPt", new { id = tblChamCongPt.CardNumber }, tblChamCongPt);
        }

        // DELETE: api/TblChamCongPts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblChamCongPt>> DeleteTblChamCongPt(string id)
        {
            var tblChamCongPt = await _context.TblChamCongPt.FindAsync(id);
            if (tblChamCongPt == null)
            {
                return NotFound();
            }

            _context.TblChamCongPt.Remove(tblChamCongPt);
            await _context.SaveChangesAsync();

            return tblChamCongPt;
        }

        private bool TblChamCongPtExists(string id)
        {
            return _context.TblChamCongPt.Any(e => e.CardNumber == id);
        }
    }
}
