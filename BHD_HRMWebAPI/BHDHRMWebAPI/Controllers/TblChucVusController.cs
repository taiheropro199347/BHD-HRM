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
    public class TblChucVusController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblChucVusController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblChucVus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblChucVu>>> GetTblChucVu()
        {
            return await _context.TblChucVu.ToListAsync();
        }

        // GET: api/TblChucVus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblChucVu>> GetTblChucVu(string id)
        {
            var tblChucVu = await _context.TblChucVu.FindAsync(id);

            if (tblChucVu == null)
            {
                return NotFound();
            }

            return tblChucVu;
        }

        // PUT: api/TblChucVus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblChucVu(string id, TblChucVu tblChucVu)
        {
            if (id != tblChucVu.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblChucVu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblChucVuExists(id))
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

        // POST: api/TblChucVus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblChucVu>> PostTblChucVu(TblChucVu tblChucVu)
        {
            _context.TblChucVu.Add(tblChucVu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblChucVuExists(tblChucVu.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblChucVu", new { id = tblChucVu.Id }, tblChucVu);
        }

        // DELETE: api/TblChucVus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblChucVu>> DeleteTblChucVu(string id)
        {
            var tblChucVu = await _context.TblChucVu.FindAsync(id);
            if (tblChucVu == null)
            {
                return NotFound();
            }

            _context.TblChucVu.Remove(tblChucVu);
            await _context.SaveChangesAsync();

            return tblChucVu;
        }

        private bool TblChucVuExists(string id)
        {
            return _context.TblChucVu.Any(e => e.Id == id);
        }
    }
}
