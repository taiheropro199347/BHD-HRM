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
    public class TblSchedulersController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblSchedulersController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblSchedulers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblScheduler>>> GetTblScheduler()
        {
            return await _context.TblScheduler.ToListAsync();
        }

        // GET: api/TblSchedulers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblScheduler>> GetTblScheduler(long id)
        {
            var tblScheduler = await _context.TblScheduler.FindAsync(id);

            if (tblScheduler == null)
            {
                return NotFound();
            }

            return tblScheduler;
        }

        // PUT: api/TblSchedulers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblScheduler(long id, TblScheduler tblScheduler)
        {
            if (id != tblScheduler.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblScheduler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSchedulerExists(id))
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

        // POST: api/TblSchedulers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblScheduler>> PostTblScheduler(TblScheduler tblScheduler)
        {
            _context.TblScheduler.Add(tblScheduler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblScheduler", new { id = tblScheduler.Id }, tblScheduler);
        }

        // DELETE: api/TblSchedulers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblScheduler>> DeleteTblScheduler(long id)
        {
            var tblScheduler = await _context.TblScheduler.FindAsync(id);
            if (tblScheduler == null)
            {
                return NotFound();
            }

            _context.TblScheduler.Remove(tblScheduler);
            await _context.SaveChangesAsync();

            return tblScheduler;
        }

        private bool TblSchedulerExists(long id)
        {
            return _context.TblScheduler.Any(e => e.Id == id);
        }
    }
}
