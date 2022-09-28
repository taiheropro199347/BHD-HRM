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
    public class TblCapbacsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblCapbacsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblCapbacs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCapbac>>> GetTblCapbac()
        {
            return await _context.TblCapbac.ToListAsync();
        }

        // GET: api/TblCapbacs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCapbac>> GetTblCapbac(int id)
        {
            var tblCapbac = await _context.TblCapbac.FindAsync(id);

            if (tblCapbac == null)
            {
                return NotFound();
            }

            return tblCapbac;
        }

        // PUT: api/TblCapbacs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCapbac(int id, TblCapbac tblCapbac)
        {
            if (id != tblCapbac.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCapbac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCapbacExists(id))
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

        // POST: api/TblCapbacs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblCapbac>> PostTblCapbac(TblCapbac tblCapbac)
        {
            _context.TblCapbac.Add(tblCapbac);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCapbac", new { id = tblCapbac.Id }, tblCapbac);
        }

        // DELETE: api/TblCapbacs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCapbac>> DeleteTblCapbac(int id)
        {
            var tblCapbac = await _context.TblCapbac.FindAsync(id);
            if (tblCapbac == null)
            {
                return NotFound();
            }

            _context.TblCapbac.Remove(tblCapbac);
            await _context.SaveChangesAsync();

            return tblCapbac;
        }

        private bool TblCapbacExists(int id)
        {
            return _context.TblCapbac.Any(e => e.Id == id);
        }
    }
}
