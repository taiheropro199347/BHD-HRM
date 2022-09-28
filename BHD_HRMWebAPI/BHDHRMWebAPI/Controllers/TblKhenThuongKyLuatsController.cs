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
    public class TblKhenThuongKyLuatsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblKhenThuongKyLuatsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblKhenThuongKyLuats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblKhenThuongKyLuat>>> GetTblKhenThuongKyLuat()
        {
            return await _context.TblKhenThuongKyLuat.ToListAsync();
        }

        // GET: api/TblKhenThuongKyLuats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblKhenThuongKyLuat>> GetTblKhenThuongKyLuat(int id)
        {
            var tblKhenThuongKyLuat = await _context.TblKhenThuongKyLuat.FindAsync(id);

            if (tblKhenThuongKyLuat == null)
            {
                return NotFound();
            }

            return tblKhenThuongKyLuat;
        }

        // PUT: api/TblKhenThuongKyLuats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblKhenThuongKyLuat(int id, TblKhenThuongKyLuat tblKhenThuongKyLuat)
        {
            if (id != tblKhenThuongKyLuat.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblKhenThuongKyLuat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblKhenThuongKyLuatExists(id))
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

        // POST: api/TblKhenThuongKyLuats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblKhenThuongKyLuat>> PostTblKhenThuongKyLuat(TblKhenThuongKyLuat tblKhenThuongKyLuat)
        {
            _context.TblKhenThuongKyLuat.Add(tblKhenThuongKyLuat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblKhenThuongKyLuat", new { id = tblKhenThuongKyLuat.Id }, tblKhenThuongKyLuat);
        }

        // DELETE: api/TblKhenThuongKyLuats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblKhenThuongKyLuat>> DeleteTblKhenThuongKyLuat(int id)
        {
            var tblKhenThuongKyLuat = await _context.TblKhenThuongKyLuat.FindAsync(id);
            if (tblKhenThuongKyLuat == null)
            {
                return NotFound();
            }

            _context.TblKhenThuongKyLuat.Remove(tblKhenThuongKyLuat);
            await _context.SaveChangesAsync();

            return tblKhenThuongKyLuat;
        }

        private bool TblKhenThuongKyLuatExists(int id)
        {
            return _context.TblKhenThuongKyLuat.Any(e => e.Id == id);
        }
    }
}
