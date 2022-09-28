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
    public class TblTangCasController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblTangCasController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblTangCas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTangCa>>> GetTblTangCa()
        {
            return await _context.TblTangCa.ToListAsync();
        }

        // GET: api/TblTangCas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTangCa>> GetTblTangCa(string id)
        {
            var tblTangCa = await _context.TblTangCa.FindAsync(id);

            if (tblTangCa == null)
            {
                return NotFound();
            }

            return tblTangCa;
        }

        // PUT: api/TblTangCas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTangCa(string id, TblTangCa tblTangCa)
        {
            if (id != tblTangCa.CardNumber)
            {
                return BadRequest();
            }

            _context.Entry(tblTangCa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTangCaExists(id))
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

        // POST: api/TblTangCas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblTangCa>> PostTblTangCa(TblTangCa tblTangCa)
        {
            _context.TblTangCa.Add(tblTangCa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblTangCaExists(tblTangCa.CardNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblTangCa", new { id = tblTangCa.CardNumber }, tblTangCa);
        }

        // DELETE: api/TblTangCas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblTangCa>> DeleteTblTangCa(string id)
        {
            var tblTangCa = await _context.TblTangCa.FindAsync(id);
            if (tblTangCa == null)
            {
                return NotFound();
            }

            _context.TblTangCa.Remove(tblTangCa);
            await _context.SaveChangesAsync();

            return tblTangCa;
        }

        private bool TblTangCaExists(string id)
        {
            return _context.TblTangCa.Any(e => e.CardNumber == id);
        }
    }
}
