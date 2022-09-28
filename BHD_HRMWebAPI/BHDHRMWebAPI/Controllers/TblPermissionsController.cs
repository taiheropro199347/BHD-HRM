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
    public class TblPermissionsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblPermissionsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblPermissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPermissions>>> GetTblPermissions()
        {
            return await _context.TblPermissions.ToListAsync();
        }

        // GET: api/TblPermissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPermissions>> GetTblPermissions(string id)
        {
            var tblPermissions = await _context.TblPermissions.FindAsync(id);

            if (tblPermissions == null)
            {
                return NotFound();
            }

            return tblPermissions;
        }

        // PUT: api/TblPermissions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPermissions(string id, TblPermissions tblPermissions)
        {
            if (id != tblPermissions.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblPermissions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPermissionsExists(id))
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

        // POST: api/TblPermissions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblPermissions>> PostTblPermissions(TblPermissions tblPermissions)
        {
            _context.TblPermissions.Add(tblPermissions);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblPermissionsExists(tblPermissions.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblPermissions", new { id = tblPermissions.Id }, tblPermissions);
        }

        // DELETE: api/TblPermissions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblPermissions>> DeleteTblPermissions(string id)
        {
            var tblPermissions = await _context.TblPermissions.FindAsync(id);
            if (tblPermissions == null)
            {
                return NotFound();
            }

            _context.TblPermissions.Remove(tblPermissions);
            await _context.SaveChangesAsync();

            return tblPermissions;
        }

        private bool TblPermissionsExists(string id)
        {
            return _context.TblPermissions.Any(e => e.Id == id);
        }
    }
}
