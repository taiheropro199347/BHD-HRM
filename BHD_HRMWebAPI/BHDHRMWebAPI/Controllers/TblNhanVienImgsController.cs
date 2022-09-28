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
    public class TblNhanVienImgsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblNhanVienImgsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblNhanVienImgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblNhanVienImg>>> GetTblNhanVienImg()
        {
            return await _context.TblNhanVienImg.ToListAsync();
        }

        // GET: api/TblNhanVienImgs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblNhanVienImg>> GetTblNhanVienImg(int id)
        {
            var tblNhanVienImg = await _context.TblNhanVienImg.FindAsync(id);

            if (tblNhanVienImg == null)
            {
                return NotFound();
            }

            return tblNhanVienImg;
        }

        // PUT: api/TblNhanVienImgs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblNhanVienImg(int id, TblNhanVienImg tblNhanVienImg)
        {
            if (id != tblNhanVienImg.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblNhanVienImg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblNhanVienImgExists(id))
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

        // POST: api/TblNhanVienImgs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblNhanVienImg>> PostTblNhanVienImg(TblNhanVienImg tblNhanVienImg)
        {
            _context.TblNhanVienImg.Add(tblNhanVienImg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblNhanVienImg", new { id = tblNhanVienImg.Id }, tblNhanVienImg);
        }

        // DELETE: api/TblNhanVienImgs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblNhanVienImg>> DeleteTblNhanVienImg(int id)
        {
            var tblNhanVienImg = await _context.TblNhanVienImg.FindAsync(id);
            if (tblNhanVienImg == null)
            {
                return NotFound();
            }

            _context.TblNhanVienImg.Remove(tblNhanVienImg);
            await _context.SaveChangesAsync();

            return tblNhanVienImg;
        }

        private bool TblNhanVienImgExists(int id)
        {
            return _context.TblNhanVienImg.Any(e => e.Id == id);
        }
    }
}
