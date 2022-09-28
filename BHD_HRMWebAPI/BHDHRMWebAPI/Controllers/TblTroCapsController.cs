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
    public class TblTroCapsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblTroCapsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblTroCaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTroCap>>> GetTblTroCap()
        {
            return await _context.TblTroCap.ToListAsync();
        }

        // GET: api/TblTroCaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTroCap>> GetTblTroCap(int id)
        {
            var tblTroCap = await _context.TblTroCap.FindAsync(id);

            if (tblTroCap == null)
            {
                return NotFound();
            }

            return tblTroCap;
        }

        // PUT: api/TblTroCaps/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTroCap(int id, TblTroCap tblTroCap)
        {
            if (id != tblTroCap.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblTroCap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTroCapExists(id))
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

        // POST: api/TblTroCaps
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblTroCap>> PostTblTroCap(TblTroCap tblTroCap)
        {
            _context.TblTroCap.Add(tblTroCap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTroCap", new { id = tblTroCap.Id }, tblTroCap);
        }

        // DELETE: api/TblTroCaps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblTroCap>> DeleteTblTroCap(int id)
        {
            var tblTroCap = await _context.TblTroCap.FindAsync(id);
            if (tblTroCap == null)
            {
                return NotFound();
            }

            _context.TblTroCap.Remove(tblTroCap);
            await _context.SaveChangesAsync();

            return tblTroCap;
        }

        private bool TblTroCapExists(int id)
        {
            return _context.TblTroCap.Any(e => e.Id == id);
        }
    }
}
