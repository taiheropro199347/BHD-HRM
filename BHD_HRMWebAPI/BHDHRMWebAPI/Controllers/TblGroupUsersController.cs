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
    public class TblGroupUsersController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblGroupUsersController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblGroupUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblGroupUser>>> GetTblGroupUser()
        {
            return await _context.TblGroupUser.ToListAsync();
        }

        // GET: api/TblGroupUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblGroupUser>> GetTblGroupUser(string id)
        {
            var tblGroupUser = await _context.TblGroupUser.FindAsync(id);

            if (tblGroupUser == null)
            {
                return NotFound();
            }

            return tblGroupUser;
        }

        // PUT: api/TblGroupUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblGroupUser(string id, TblGroupUser tblGroupUser)
        {
            if (id != tblGroupUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblGroupUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblGroupUserExists(id))
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

        // POST: api/TblGroupUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblGroupUser>> PostTblGroupUser(TblGroupUser tblGroupUser)
        {
            _context.TblGroupUser.Add(tblGroupUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblGroupUserExists(tblGroupUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblGroupUser", new { id = tblGroupUser.Id }, tblGroupUser);
        }

        // DELETE: api/TblGroupUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblGroupUser>> DeleteTblGroupUser(string id)
        {
            var tblGroupUser = await _context.TblGroupUser.FindAsync(id);
            if (tblGroupUser == null)
            {
                return NotFound();
            }

            _context.TblGroupUser.Remove(tblGroupUser);
            await _context.SaveChangesAsync();

            return tblGroupUser;
        }

        private bool TblGroupUserExists(string id)
        {
            return _context.TblGroupUser.Any(e => e.Id == id);
        }
    }
}
