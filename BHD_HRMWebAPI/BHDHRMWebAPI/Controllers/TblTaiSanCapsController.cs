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
    public class TblTaiSanCapsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblTaiSanCapsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblTaiSanCaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTaiSanCap>>> GetTblTaiSanCap()
        {
            return await _context.TblTaiSanCap.ToListAsync();
        }

        // GET: api/TblTaiSanCaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTaiSanCap>> GetTblTaiSanCap(int id)
        {
            var tblTaiSanCap = await _context.TblTaiSanCap.FindAsync(id);

            if (tblTaiSanCap == null)
            {
                return NotFound();
            }

            return tblTaiSanCap;
        }

        // PUT: api/TblTaiSanCaps/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTaiSanCap(int id, TblTaiSanCap tblTaiSanCap)
        {
            if (id != tblTaiSanCap.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblTaiSanCap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTaiSanCapExists(id))
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

        // POST: api/TblTaiSanCaps
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblTaiSanCap>> PostTblTaiSanCap(TblTaiSanCap tblTaiSanCap)
        {
            _context.TblTaiSanCap.Add(tblTaiSanCap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTaiSanCap", new { id = tblTaiSanCap.Id }, tblTaiSanCap);
        }

        // DELETE: api/TblTaiSanCaps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblTaiSanCap>> DeleteTblTaiSanCap(int id)
        {
            var tblTaiSanCap = await _context.TblTaiSanCap.FindAsync(id);
            if (tblTaiSanCap == null)
            {
                return NotFound();
            }

            _context.TblTaiSanCap.Remove(tblTaiSanCap);
            await _context.SaveChangesAsync();

            return tblTaiSanCap;
        }

        private bool TblTaiSanCapExists(int id)
        {
            return _context.TblTaiSanCap.Any(e => e.Id == id);
        }
    }
}
