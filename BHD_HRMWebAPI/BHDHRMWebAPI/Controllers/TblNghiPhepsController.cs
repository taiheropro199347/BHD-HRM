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
    public class TblNghiPhepsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblNghiPhepsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblNghiPheps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblNghiPhep>>> GetTblNghiPhep()
        {
            return await _context.TblNghiPhep.ToListAsync();
        }

        // GET: api/TblNghiPheps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblNghiPhep>> GetTblNghiPhep(string id)
        {
            var tblNghiPhep = await _context.TblNghiPhep.FindAsync(id);

            if (tblNghiPhep == null)
            {
                return NotFound();
            }

            return tblNghiPhep;
        }

        // PUT: api/TblNghiPheps/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblNghiPhep(string id, TblNghiPhep tblNghiPhep)
        {
            if (id != tblNghiPhep.MaPhieu)
            {
                return BadRequest();
            }

            _context.Entry(tblNghiPhep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblNghiPhepExists(id))
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

        // POST: api/TblNghiPheps
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblNghiPhep>> PostTblNghiPhep(TblNghiPhep tblNghiPhep)
        {
            _context.TblNghiPhep.Add(tblNghiPhep);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblNghiPhepExists(tblNghiPhep.MaPhieu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblNghiPhep", new { id = tblNghiPhep.MaPhieu }, tblNghiPhep);
        }

        // DELETE: api/TblNghiPheps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblNghiPhep>> DeleteTblNghiPhep(string id)
        {
            var tblNghiPhep = await _context.TblNghiPhep.FindAsync(id);
            if (tblNghiPhep == null)
            {
                return NotFound();
            }

            _context.TblNghiPhep.Remove(tblNghiPhep);
            await _context.SaveChangesAsync();

            return tblNghiPhep;
        }

        private bool TblNghiPhepExists(string id)
        {
            return _context.TblNghiPhep.Any(e => e.MaPhieu == id);
        }
    }
}
