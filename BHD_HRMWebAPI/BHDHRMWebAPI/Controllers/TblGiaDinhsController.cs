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
    public class TblGiaDinhsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblGiaDinhsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblGiaDinhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblGiaDinh>>> GetTblGiaDinh()
        {
            return await _context.TblGiaDinh.ToListAsync();
        }

        // GET: api/TblGiaDinhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblGiaDinh>> GetTblGiaDinh(int id)
        {
            var tblGiaDinh = await _context.TblGiaDinh.FindAsync(id);

            if (tblGiaDinh == null)
            {
                return NotFound();
            }

            return tblGiaDinh;
        }

        // PUT: api/TblGiaDinhs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblGiaDinh(int id, TblGiaDinh tblGiaDinh)
        {
            if (id != tblGiaDinh.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblGiaDinh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblGiaDinhExists(id))
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

        // POST: api/TblGiaDinhs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblGiaDinh>> PostTblGiaDinh(TblGiaDinh tblGiaDinh)
        {
            _context.TblGiaDinh.Add(tblGiaDinh);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblGiaDinh", new { id = tblGiaDinh.Id }, tblGiaDinh);
        }

        // DELETE: api/TblGiaDinhs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblGiaDinh>> DeleteTblGiaDinh(int id)
        {
            var tblGiaDinh = await _context.TblGiaDinh.FindAsync(id);
            if (tblGiaDinh == null)
            {
                return NotFound();
            }

            _context.TblGiaDinh.Remove(tblGiaDinh);
            await _context.SaveChangesAsync();

            return tblGiaDinh;
        }

        private bool TblGiaDinhExists(int id)
        {
            return _context.TblGiaDinh.Any(e => e.Id == id);
        }
    }
}
