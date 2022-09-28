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
    public class TblTapDoansController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblTapDoansController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblTapDoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTapDoan>>> GetTblTapDoan()
        {
            return await _context.TblTapDoan.ToListAsync();
        }

        // GET: api/TblTapDoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTapDoan>> GetTblTapDoan(string id)
        {
            var tblTapDoan = await _context.TblTapDoan.FindAsync(id);

            if (tblTapDoan == null)
            {
                return NotFound();
            }

            return tblTapDoan;
        }

        // PUT: api/TblTapDoans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTapDoan(string id, TblTapDoan tblTapDoan)
        {
            if (id != tblTapDoan.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblTapDoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTapDoanExists(id))
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

        // POST: api/TblTapDoans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblTapDoan>> PostTblTapDoan(TblTapDoan tblTapDoan)
        {
            _context.TblTapDoan.Add(tblTapDoan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblTapDoanExists(tblTapDoan.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblTapDoan", new { id = tblTapDoan.Id }, tblTapDoan);
        }

        // DELETE: api/TblTapDoans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblTapDoan>> DeleteTblTapDoan(string id)
        {
            var tblTapDoan = await _context.TblTapDoan.FindAsync(id);
            if (tblTapDoan == null)
            {
                return NotFound();
            }

            _context.TblTapDoan.Remove(tblTapDoan);
            await _context.SaveChangesAsync();

            return tblTapDoan;
        }

        private bool TblTapDoanExists(string id)
        {
            return _context.TblTapDoan.Any(e => e.Id == id);
        }
    }
}
