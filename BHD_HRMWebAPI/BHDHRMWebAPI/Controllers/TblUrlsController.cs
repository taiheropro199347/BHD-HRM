using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BHDHRMWebAPI.Models;
using System.Web;

namespace BHDHRMWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblUrlsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblUrlsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblUrls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUrl>>> GetTblUrl()
        {
            return await _context.TblUrl.ToListAsync();
        }
        // GET: api/Users/5
        [HttpGet("GetEmail/{id}")]
        public async Task<ActionResult<TblUrl>> GetUser(string id)
        {
            var email = await _context.TblUrl.Where(t=>t.Email==id).FirstOrDefaultAsync();

            if (email == null)
            {
                return null;
            }

            return email;
        }
        // GET: api/TblUrls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUrl>> GetTblUrl(string id)
        {
            var tblUrl = await _context.TblUrl.Where(t=>t.Url==HttpUtility.UrlDecode(id)).FirstOrDefaultAsync() ;

            if (tblUrl == null)
            {
                return NotFound();
            }

            return tblUrl;
        }

        // PUT: api/TblUrls/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUrl(int id, TblUrl tblUrl)
        {
            if (id != tblUrl.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblUrl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUrlExists(id))
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

        // POST: api/TblUrls
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblUrl>> PostTblUrl(TblUrl tblUrl)
        {
            _context.TblUrl.Add(tblUrl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUrl", new { id = tblUrl.Id }, tblUrl);
        }

        // DELETE: api/TblUrls/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblUrl>> DeleteTblUrl(int id)
        {
            var tblUrl = await _context.TblUrl.FindAsync(id);
            if (tblUrl == null)
            {
                return NotFound();
            }

            _context.TblUrl.Remove(tblUrl);
            await _context.SaveChangesAsync();

            return tblUrl;
        }

        private bool TblUrlExists(int id)
        {
            return _context.TblUrl.Any(e => e.Id == id);
        }
    }
}
