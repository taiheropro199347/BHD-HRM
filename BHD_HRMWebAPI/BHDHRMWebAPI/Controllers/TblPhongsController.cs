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
    public class TblPhongsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblPhongsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblPhongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPhong>>> GetTblPhong()
        {
            return await _context.TblPhong.Include(t=>t.TblCongTy).ToListAsync();
        }

        // GET: api/TblPhongs/5
        [HttpGet("GetDepmbyComp/{id}")]
        public async Task<ActionResult<IEnumerable<TblPhong>>> GetDepmbyComp(string id)

        {
            var tblPhong = await _context.TblPhong.Where(t => t.IdcongTy == int.Parse(id)).ToListAsync();

            if (tblPhong == null)
            {
                return NotFound();
            }

            return tblPhong;
        }

        // GET: api/TblPhongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPhong>> GetTblPhong(string id)
        {
            var tblPhong = await _context.TblPhong.Where(t=>t.Id==id).FirstAsync();

            if (tblPhong == null)
            {
                return NotFound();
            }

            return tblPhong;
        }

        // PUT: api/TblPhongs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPhong(string id, TblPhong tblPhong)
        {
            if (id != tblPhong.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblPhong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPhongExists(id))
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

        // POST: api/TblPhongs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblPhong>> PostTblPhong(TblPhong tblPhong)
        {
            _context.TblPhong.Add(tblPhong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblPhongExists(tblPhong.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblPhong", new { id = tblPhong.Id }, tblPhong);
        }

        // DELETE: api/TblPhongs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblPhong>> DeleteTblPhong(string id)
        {
            var tblPhong = await _context.TblPhong.Where(t=>t.Id==id).FirstAsync();
            if (tblPhong == null)
            {
                return NotFound();
            }

            _context.TblPhong.Remove(tblPhong);
            await _context.SaveChangesAsync();

            return tblPhong;
        }

        private bool TblPhongExists(string id)
        {
            return _context.TblPhong.Any(e => e.Id == id);
        }
    }
}
