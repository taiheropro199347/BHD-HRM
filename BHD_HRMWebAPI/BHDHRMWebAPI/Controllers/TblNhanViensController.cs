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
    public class TblNhanViensController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblNhanViensController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblNhanViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblNhanVien>>> GetTblNhanVien()
        {
            return await _context.TblNhanVien.ToListAsync();
        }

        // GET: api/TblNhanViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblNhanVien>> GetTblNhanVien(string id)
        {
            var tblNhanVien = await _context.TblNhanVien.Where(t=>t.Id==int.Parse(id)).FirstAsync();

            if (tblNhanVien == null)
            {
                return NotFound();
            }

            return tblNhanVien;
        }


        // PUT: api/TblNhanViens/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblNhanVien(string id, TblNhanVien tblNhanVien)
        {
            if (id != tblNhanVien.CardNumber)
            {
                return BadRequest();
            }

            _context.Entry(tblNhanVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblNhanVienExists(id))
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
        // GET: api/Users/5
        [HttpGet("GetNhanVienbyStatus/{id}")]
        public async Task<ActionResult<IEnumerable<TblNhanVien>>> GetNhanVienbyStatus(string id)

        {
            var nhanvien = await _context.TblNhanVien.Where(t=>t.TrangThai==id).ToListAsync();

            if (nhanvien == null)
            {
                return NotFound();
            }

            return nhanvien;
        } 

        // POST: api/TblNhanViens
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblNhanVien>> PostTblNhanVien(TblNhanVien tblNhanVien)
        {
            _context.TblNhanVien.Add(tblNhanVien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblNhanVienExists(tblNhanVien.CardNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblNhanVien", new { id = tblNhanVien.CardNumber }, tblNhanVien);
        }

        // DELETE: api/TblNhanViens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblNhanVien>> DeleteTblNhanVien(string id)
        {
            var tblNhanVien = await _context.TblNhanVien.FindAsync(id);
            if (tblNhanVien == null)
            {
                return NotFound();
            }

            _context.TblNhanVien.Remove(tblNhanVien);
            await _context.SaveChangesAsync();

            return tblNhanVien;
        }

        private bool TblNhanVienExists(string id)
        {
            return _context.TblNhanVien.Any(e => e.CardNumber == id);
        }
    }
}
