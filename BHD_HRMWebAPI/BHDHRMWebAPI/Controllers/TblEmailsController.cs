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
    public class TblEmailsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblEmailsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblEmails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEmail>>> GetTblEmail()
        {
            return await _context.TblEmail.ToListAsync();
        }

        // GET: api/TblEmails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblEmail>> GetTblEmail(int id)
        {
            var tblEmail = await _context.TblEmail.FindAsync(id);

            if (tblEmail == null)
            {
                return NotFound();
            }

            return tblEmail;
        }

        // PUT: api/TblEmails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblEmail(int id, TblEmail tblEmail)
        {
            if (id != tblEmail.EmailServerSettingId)
            {
                return BadRequest();
            }

            _context.Entry(tblEmail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmailExists(id))
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

        // POST: api/TblEmails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblEmail>> PostTblEmail(TblEmail tblEmail)
        {
            _context.TblEmail.Add(tblEmail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEmail", new { id = tblEmail.EmailServerSettingId }, tblEmail);
        }

        // DELETE: api/TblEmails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblEmail>> DeleteTblEmail(int id)
        {
            var tblEmail = await _context.TblEmail.FindAsync(id);
            if (tblEmail == null)
            {
                return NotFound();
            }

            _context.TblEmail.Remove(tblEmail);
            await _context.SaveChangesAsync();

            return tblEmail;
        }

        private bool TblEmailExists(int id)
        {
            return _context.TblEmail.Any(e => e.EmailServerSettingId == id);
        }
    }
}
