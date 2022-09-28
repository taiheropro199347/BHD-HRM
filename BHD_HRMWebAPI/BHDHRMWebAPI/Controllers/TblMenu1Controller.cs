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
    public class TblMenu1Controller : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblMenu1Controller(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblMenu1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMenu1>>> GetTblMenu1()
        {
            return await _context.TblMenu1.ToListAsync();
        }

        // GET: api/TblMenu1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblMenu1>> GetTblMenu1(string id)
        {
            var tblMenu1 = await _context.TblMenu1.FindAsync(id);

            if (tblMenu1 == null)
            {
                return NotFound();
            }

            return tblMenu1;
        }

        // PUT: api/TblMenu1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMenu1(string id, TblMenu1 tblMenu1)
        {
            if (id != tblMenu1.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblMenu1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMenu1Exists(id))
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

        // POST: api/TblMenu1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblMenu1>> PostTblMenu1(TblMenu1 tblMenu1)
        {
            _context.TblMenu1.Add(tblMenu1);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblMenu1Exists(tblMenu1.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblMenu1", new { id = tblMenu1.Id }, tblMenu1);
        }

        // DELETE: api/TblMenu1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblMenu1>> DeleteTblMenu1(string id)
        {
            var tblMenu1 = await _context.TblMenu1.FindAsync(id);
            if (tblMenu1 == null)
            {
                return NotFound();
            }

            _context.TblMenu1.Remove(tblMenu1);
            await _context.SaveChangesAsync();

            return tblMenu1;
        }

        private bool TblMenu1Exists(string id)
        {
            return _context.TblMenu1.Any(e => e.Id == id);
        }
    }
}
