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
    public class TblLogPointsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblLogPointsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblLogPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLogPoint>>> GetTblLogPoint()
        {
            return await _context.TblLogPoint.ToListAsync();
        }

        // GET: api/TblLogPoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLogPoint>> GetTblLogPoint(int id)
        {
            var tblLogPoint = await _context.TblLogPoint.FindAsync(id);

            if (tblLogPoint == null)
            {
                return NotFound();
            }

            return tblLogPoint;
        }

        // PUT: api/TblLogPoints/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLogPoint(int id, TblLogPoint tblLogPoint)
        {
            if (id != tblLogPoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblLogPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLogPointExists(id))
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

        // POST: api/TblLogPoints
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblLogPoint>> PostTblLogPoint(TblLogPoint tblLogPoint)
        {
            _context.TblLogPoint.Add(tblLogPoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblLogPoint", new { id = tblLogPoint.Id }, tblLogPoint);
        }

        // DELETE: api/TblLogPoints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblLogPoint>> DeleteTblLogPoint(int id)
        {
            var tblLogPoint = await _context.TblLogPoint.FindAsync(id);
            if (tblLogPoint == null)
            {
                return NotFound();
            }

            _context.TblLogPoint.Remove(tblLogPoint);
            await _context.SaveChangesAsync();

            return tblLogPoint;
        }

        private bool TblLogPointExists(int id)
        {
            return _context.TblLogPoint.Any(e => e.Id == id);
        }
    }
}
