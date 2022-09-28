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
    public class TblQuaTrinhCongViecNewsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblQuaTrinhCongViecNewsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblQuaTrinhCongViecNews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblQuaTrinhCongViecNew>>> GetTblQuaTrinhCongViecNew()
        {
            return await _context.TblQuaTrinhCongViecNew.ToListAsync();
        }

        // GET: api/TblQuaTrinhCongViecNews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblQuaTrinhCongViecNew>> GetTblQuaTrinhCongViecNew(int id)
        {
            var tblQuaTrinhCongViecNew = await _context.TblQuaTrinhCongViecNew.FindAsync(id);

            if (tblQuaTrinhCongViecNew == null)
            {
                return NotFound();
            }

            return tblQuaTrinhCongViecNew;
        }

        // PUT: api/TblQuaTrinhCongViecNews/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblQuaTrinhCongViecNew(int id, TblQuaTrinhCongViecNew tblQuaTrinhCongViecNew)
        {
            if (id != tblQuaTrinhCongViecNew.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblQuaTrinhCongViecNew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuaTrinhCongViecNewExists(id))
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

        // POST: api/TblQuaTrinhCongViecNews
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblQuaTrinhCongViecNew>> PostTblQuaTrinhCongViecNew(TblQuaTrinhCongViecNew tblQuaTrinhCongViecNew)
        {
            _context.TblQuaTrinhCongViecNew.Add(tblQuaTrinhCongViecNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblQuaTrinhCongViecNew", new { id = tblQuaTrinhCongViecNew.Id }, tblQuaTrinhCongViecNew);
        }

        // DELETE: api/TblQuaTrinhCongViecNews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblQuaTrinhCongViecNew>> DeleteTblQuaTrinhCongViecNew(int id)
        {
            var tblQuaTrinhCongViecNew = await _context.TblQuaTrinhCongViecNew.FindAsync(id);
            if (tblQuaTrinhCongViecNew == null)
            {
                return NotFound();
            }

            _context.TblQuaTrinhCongViecNew.Remove(tblQuaTrinhCongViecNew);
            await _context.SaveChangesAsync();

            return tblQuaTrinhCongViecNew;
        }

        private bool TblQuaTrinhCongViecNewExists(int id)
        {
            return _context.TblQuaTrinhCongViecNew.Any(e => e.Id == id);
        }
    }
}
