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
    public class TblLuongKhacsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblLuongKhacsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblLuongKhacs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLuongKhac>>> GetTblLuongKhac()
        {
            return await _context.TblLuongKhac.ToListAsync();
        }

        // GET: api/TblLuongKhacs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLuongKhac>> GetTblLuongKhac(int id)
        {
            var tblLuongKhac = await _context.TblLuongKhac.FindAsync(id);

            if (tblLuongKhac == null)
            {
                return NotFound();
            }

            return tblLuongKhac;
        }

        // PUT: api/TblLuongKhacs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLuongKhac(int id, TblLuongKhac tblLuongKhac)
        {
            if (id != tblLuongKhac.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblLuongKhac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLuongKhacExists(id))
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

        // POST: api/TblLuongKhacs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblLuongKhac>> PostTblLuongKhac(TblLuongKhac tblLuongKhac)
        {
            _context.TblLuongKhac.Add(tblLuongKhac);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblLuongKhac", new { id = tblLuongKhac.Id }, tblLuongKhac);
        }

        // DELETE: api/TblLuongKhacs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblLuongKhac>> DeleteTblLuongKhac(int id)
        {
            var tblLuongKhac = await _context.TblLuongKhac.FindAsync(id);
            if (tblLuongKhac == null)
            {
                return NotFound();
            }

            _context.TblLuongKhac.Remove(tblLuongKhac);
            await _context.SaveChangesAsync();

            return tblLuongKhac;
        }

        private bool TblLuongKhacExists(int id)
        {
            return _context.TblLuongKhac.Any(e => e.Id == id);
        }
    }
}
