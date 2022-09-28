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
    public class TblTrocaptrachnhiemsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblTrocaptrachnhiemsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblTrocaptrachnhiems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTrocaptrachnhiem>>> GetTblTrocaptrachnhiem()
        {
            return await _context.TblTrocaptrachnhiem.ToListAsync();
        }

        // GET: api/TblTrocaptrachnhiems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTrocaptrachnhiem>> GetTblTrocaptrachnhiem(int id)
        {
            var tblTrocaptrachnhiem = await _context.TblTrocaptrachnhiem.FindAsync(id);

            if (tblTrocaptrachnhiem == null)
            {
                return NotFound();
            }

            return tblTrocaptrachnhiem;
        }

        // PUT: api/TblTrocaptrachnhiems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTrocaptrachnhiem(int id, TblTrocaptrachnhiem tblTrocaptrachnhiem)
        {
            if (id != tblTrocaptrachnhiem.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblTrocaptrachnhiem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTrocaptrachnhiemExists(id))
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

        // POST: api/TblTrocaptrachnhiems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblTrocaptrachnhiem>> PostTblTrocaptrachnhiem(TblTrocaptrachnhiem tblTrocaptrachnhiem)
        {
            _context.TblTrocaptrachnhiem.Add(tblTrocaptrachnhiem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTrocaptrachnhiem", new { id = tblTrocaptrachnhiem.Id }, tblTrocaptrachnhiem);
        }

        // DELETE: api/TblTrocaptrachnhiems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblTrocaptrachnhiem>> DeleteTblTrocaptrachnhiem(int id)
        {
            var tblTrocaptrachnhiem = await _context.TblTrocaptrachnhiem.FindAsync(id);
            if (tblTrocaptrachnhiem == null)
            {
                return NotFound();
            }

            _context.TblTrocaptrachnhiem.Remove(tblTrocaptrachnhiem);
            await _context.SaveChangesAsync();

            return tblTrocaptrachnhiem;
        }

        private bool TblTrocaptrachnhiemExists(int id)
        {
            return _context.TblTrocaptrachnhiem.Any(e => e.Id == id);
        }
    }
}
