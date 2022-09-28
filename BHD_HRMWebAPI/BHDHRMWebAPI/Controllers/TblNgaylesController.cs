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
    public class TblNgaylesController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblNgaylesController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblNgayles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblNgayle>>> GetTblNgayle()
        {
            return await _context.TblNgayle.ToListAsync();
        }

        // GET: api/TblNgayles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblNgayle>> GetTblNgayle(int id)
        {
            var tblNgayle = await _context.TblNgayle.FindAsync(id);

            if (tblNgayle == null)
            {
                return NotFound();
            }

            return tblNgayle;
        }

        // PUT: api/TblNgayles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblNgayle(int id, TblNgayle tblNgayle)
        {
            if (id != tblNgayle.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblNgayle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblNgayleExists(id))
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

        // POST: api/TblNgayles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblNgayle>> PostTblNgayle(TblNgayle tblNgayle)
        {
            _context.TblNgayle.Add(tblNgayle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblNgayle", new { id = tblNgayle.Id }, tblNgayle);
        }

        // DELETE: api/TblNgayles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblNgayle>> DeleteTblNgayle(int id)
        {
            var tblNgayle = await _context.TblNgayle.FindAsync(id);
            if (tblNgayle == null)
            {
                return NotFound();
            }

            _context.TblNgayle.Remove(tblNgayle);
            await _context.SaveChangesAsync();

            return tblNgayle;
        }

        private bool TblNgayleExists(int id)
        {
            return _context.TblNgayle.Any(e => e.Id == id);
        }
    }
}
