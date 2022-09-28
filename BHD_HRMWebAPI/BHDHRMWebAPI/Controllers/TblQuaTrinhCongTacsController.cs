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
    public class TblQuaTrinhCongTacsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblQuaTrinhCongTacsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblQuaTrinhCongTacs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblQuaTrinhCongTac>>> GetTblQuaTrinhCongTac()
        {
            return await _context.TblQuaTrinhCongTac.ToListAsync();
        }

        // GET: api/TblQuaTrinhCongTacs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblQuaTrinhCongTac>> GetTblQuaTrinhCongTac(int id)
        {
            var tblQuaTrinhCongTac = await _context.TblQuaTrinhCongTac.FindAsync(id);

            if (tblQuaTrinhCongTac == null)
            {
                return NotFound();
            }

            return tblQuaTrinhCongTac;
        }

        // PUT: api/TblQuaTrinhCongTacs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblQuaTrinhCongTac(int id, TblQuaTrinhCongTac tblQuaTrinhCongTac)
        {
            if (id != tblQuaTrinhCongTac.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblQuaTrinhCongTac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuaTrinhCongTacExists(id))
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

        // POST: api/TblQuaTrinhCongTacs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblQuaTrinhCongTac>> PostTblQuaTrinhCongTac(TblQuaTrinhCongTac tblQuaTrinhCongTac)
        {
            _context.TblQuaTrinhCongTac.Add(tblQuaTrinhCongTac);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblQuaTrinhCongTac", new { id = tblQuaTrinhCongTac.Id }, tblQuaTrinhCongTac);
        }

        // DELETE: api/TblQuaTrinhCongTacs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblQuaTrinhCongTac>> DeleteTblQuaTrinhCongTac(int id)
        {
            var tblQuaTrinhCongTac = await _context.TblQuaTrinhCongTac.FindAsync(id);
            if (tblQuaTrinhCongTac == null)
            {
                return NotFound();
            }

            _context.TblQuaTrinhCongTac.Remove(tblQuaTrinhCongTac);
            await _context.SaveChangesAsync();

            return tblQuaTrinhCongTac;
        }

        private bool TblQuaTrinhCongTacExists(int id)
        {
            return _context.TblQuaTrinhCongTac.Any(e => e.Id == id);
        }
    }
}
