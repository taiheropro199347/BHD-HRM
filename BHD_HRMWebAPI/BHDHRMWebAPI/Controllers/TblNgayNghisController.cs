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
    public class TblNgayNghisController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblNgayNghisController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblNgayNghis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblNgayNghi>>> GetTblNgayNghi()
        {
            return await _context.TblNgayNghi.ToListAsync();
        }

        // GET: api/TblNgayNghis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblNgayNghi>> GetTblNgayNghi(string id)
        {
            var tblNgayNghi = await _context.TblNgayNghi.FindAsync(id);

            if (tblNgayNghi == null)
            {
                return NotFound();
            }

            return tblNgayNghi;
        }

        // PUT: api/TblNgayNghis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblNgayNghi(string id, TblNgayNghi tblNgayNghi)
        {
            if (id != tblNgayNghi.CardNumber)
            {
                return BadRequest();
            }

            _context.Entry(tblNgayNghi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblNgayNghiExists(id))
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

        // POST: api/TblNgayNghis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblNgayNghi>> PostTblNgayNghi(TblNgayNghi tblNgayNghi)
        {
            _context.TblNgayNghi.Add(tblNgayNghi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblNgayNghiExists(tblNgayNghi.CardNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblNgayNghi", new { id = tblNgayNghi.CardNumber }, tblNgayNghi);
        }

        // DELETE: api/TblNgayNghis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblNgayNghi>> DeleteTblNgayNghi(string id)
        {
            var tblNgayNghi = await _context.TblNgayNghi.FindAsync(id);
            if (tblNgayNghi == null)
            {
                return NotFound();
            }

            _context.TblNgayNghi.Remove(tblNgayNghi);
            await _context.SaveChangesAsync();

            return tblNgayNghi;
        }

        private bool TblNgayNghiExists(string id)
        {
            return _context.TblNgayNghi.Any(e => e.CardNumber == id);
        }
    }
}
