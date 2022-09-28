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
    public class TblQuaTrinhHocTapsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblQuaTrinhHocTapsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblQuaTrinhHocTaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblQuaTrinhHocTap>>> GetTblQuaTrinhHocTap()
        {
            return await _context.TblQuaTrinhHocTap.ToListAsync();
        }

        // GET: api/TblQuaTrinhHocTaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblQuaTrinhHocTap>> GetTblQuaTrinhHocTap(int id)
        {
            var tblQuaTrinhHocTap = await _context.TblQuaTrinhHocTap.FindAsync(id);

            if (tblQuaTrinhHocTap == null)
            {
                return NotFound();
            }

            return tblQuaTrinhHocTap;
        }

        // PUT: api/TblQuaTrinhHocTaps/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblQuaTrinhHocTap(int id, TblQuaTrinhHocTap tblQuaTrinhHocTap)
        {
            if (id != tblQuaTrinhHocTap.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblQuaTrinhHocTap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuaTrinhHocTapExists(id))
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

        // POST: api/TblQuaTrinhHocTaps
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblQuaTrinhHocTap>> PostTblQuaTrinhHocTap(TblQuaTrinhHocTap tblQuaTrinhHocTap)
        {
            _context.TblQuaTrinhHocTap.Add(tblQuaTrinhHocTap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblQuaTrinhHocTap", new { id = tblQuaTrinhHocTap.Id }, tblQuaTrinhHocTap);
        }

        // DELETE: api/TblQuaTrinhHocTaps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblQuaTrinhHocTap>> DeleteTblQuaTrinhHocTap(int id)
        {
            var tblQuaTrinhHocTap = await _context.TblQuaTrinhHocTap.FindAsync(id);
            if (tblQuaTrinhHocTap == null)
            {
                return NotFound();
            }

            _context.TblQuaTrinhHocTap.Remove(tblQuaTrinhHocTap);
            await _context.SaveChangesAsync();

            return tblQuaTrinhHocTap;
        }

        private bool TblQuaTrinhHocTapExists(int id)
        {
            return _context.TblQuaTrinhHocTap.Any(e => e.Id == id);
        }
    }
}
