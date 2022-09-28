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
    public class TblLuongsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblLuongsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblLuongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLuong>>> GetTblLuong()
        {
            return await _context.TblLuong.ToListAsync();
        }

        // GET: api/TblLuongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLuong>> GetTblLuong(int id)
        {
            var tblLuong = await _context.TblLuong.FindAsync(id);

            if (tblLuong == null)
            {
                return NotFound();
            }

            return tblLuong;
        }

        // PUT: api/TblLuongs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLuong(int id, TblLuong tblLuong)
        {
            if (id != tblLuong.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblLuong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLuongExists(id))
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

        // POST: api/TblLuongs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblLuong>> PostTblLuong(TblLuong tblLuong)
        {
            _context.TblLuong.Add(tblLuong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblLuong", new { id = tblLuong.Id }, tblLuong);
        }

        // DELETE: api/TblLuongs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblLuong>> DeleteTblLuong(int id)
        {
            var tblLuong = await _context.TblLuong.FindAsync(id);
            if (tblLuong == null)
            {
                return NotFound();
            }

            _context.TblLuong.Remove(tblLuong);
            await _context.SaveChangesAsync();

            return tblLuong;
        }

        private bool TblLuongExists(int id)
        {
            return _context.TblLuong.Any(e => e.Id == id);
        }
    }
}
