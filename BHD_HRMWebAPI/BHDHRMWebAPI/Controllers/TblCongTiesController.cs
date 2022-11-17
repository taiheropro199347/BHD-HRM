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
    public class TblCongTiesController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblCongTiesController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblCongTies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCongTy>>> GetTblCongTy()
        {
            return await _context.TblCongTy.Where(t=>t.HienThi==true).OrderBy(t=>t.SapXep).ToListAsync();
        }

        // GET: api/TblCongTies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCongTy>> GetTblCongTy(string id)
        {
            int _id = int.Parse(id);
            var tblCongTy = await _context.TblCongTy.FindAsync(_id);

            if (tblCongTy == null)
            {
                return NotFound();
            }

            return tblCongTy;
        }

        // PUT: api/TblCongTies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCongTy(int id, TblCongTy tblCongTy)
        {
            if (id != tblCongTy.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCongTy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCongTyExists(id))
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

        // POST: api/TblCongTies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblCongTy>> PostTblCongTy(TblCongTy tblCongTy)
        {
            _context.TblCongTy.Add(tblCongTy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblCongTyExists(tblCongTy.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblCongTy", new { id = tblCongTy.Id }, tblCongTy);
        }

        // DELETE: api/TblCongTies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCongTy>> DeleteTblCongTy(int id)
        {
            var tblCongTy = await _context.TblCongTy.FindAsync(id);
            if (tblCongTy == null)
            {
                return NotFound();
            }

            _context.TblCongTy.Remove(tblCongTy);
            await _context.SaveChangesAsync();

            return tblCongTy;
        }

        private bool TblCongTyExists(int id)
        {
            return _context.TblCongTy.Any(e => e.Id == id);
        }
    }
}
