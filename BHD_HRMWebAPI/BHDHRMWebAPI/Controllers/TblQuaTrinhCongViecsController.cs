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
    public class TblQuaTrinhCongViecsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblQuaTrinhCongViecsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblQuaTrinhCongViecs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblQuaTrinhCongViec>>> GetTblQuaTrinhCongViec()
        {
            return await _context.TblQuaTrinhCongViec.ToListAsync();
        }

        // GET: api/TblQuaTrinhCongViecs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblQuaTrinhCongViec>> GetTblQuaTrinhCongViec(string id)
        {
            var tblQuaTrinhCongViec = await _context.TblQuaTrinhCongViec.FindAsync(id);

            if (tblQuaTrinhCongViec == null)
            {
                return NotFound();
            }

            return tblQuaTrinhCongViec;
        }

        // PUT: api/TblQuaTrinhCongViecs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblQuaTrinhCongViec(string id, TblQuaTrinhCongViec tblQuaTrinhCongViec)
        {
            if (id != tblQuaTrinhCongViec.CardNumber)
            {
                return BadRequest();
            }

            _context.Entry(tblQuaTrinhCongViec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuaTrinhCongViecExists(id))
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

        // POST: api/TblQuaTrinhCongViecs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblQuaTrinhCongViec>> PostTblQuaTrinhCongViec(TblQuaTrinhCongViec tblQuaTrinhCongViec)
        {
            _context.TblQuaTrinhCongViec.Add(tblQuaTrinhCongViec);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblQuaTrinhCongViecExists(tblQuaTrinhCongViec.CardNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblQuaTrinhCongViec", new { id = tblQuaTrinhCongViec.CardNumber }, tblQuaTrinhCongViec);
        }

        // DELETE: api/TblQuaTrinhCongViecs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblQuaTrinhCongViec>> DeleteTblQuaTrinhCongViec(string id)
        {
            var tblQuaTrinhCongViec = await _context.TblQuaTrinhCongViec.FindAsync(id);
            if (tblQuaTrinhCongViec == null)
            {
                return NotFound();
            }

            _context.TblQuaTrinhCongViec.Remove(tblQuaTrinhCongViec);
            await _context.SaveChangesAsync();

            return tblQuaTrinhCongViec;
        }

        private bool TblQuaTrinhCongViecExists(string id)
        {
            return _context.TblQuaTrinhCongViec.Any(e => e.CardNumber == id);
        }
    }
}
