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
    public class TblEmailConfigsController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblEmailConfigsController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblEmailConfigs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEmailConfig>>> GetTblEmailConfig()
        {
            return await _context.TblEmailConfig.ToListAsync();
        }

        // GET: api/TblEmailConfigs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblEmailConfig>> GetTblEmailConfig(int id)
        {
            var tblEmailConfig = await _context.TblEmailConfig.FindAsync(id);

            if (tblEmailConfig == null)
            {
                return NotFound();
            }

            return tblEmailConfig;
        }

        // PUT: api/TblEmailConfigs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblEmailConfig(int id, TblEmailConfig tblEmailConfig)
        {
            if (id != tblEmailConfig.EmailServerSettingId)
            {
                return BadRequest();
            }

            _context.Entry(tblEmailConfig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmailConfigExists(id))
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

        // POST: api/TblEmailConfigs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblEmailConfig>> PostTblEmailConfig(TblEmailConfig tblEmailConfig)
        {
            _context.TblEmailConfig.Add(tblEmailConfig);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEmailConfig", new { id = tblEmailConfig.EmailServerSettingId }, tblEmailConfig);
        }

        // DELETE: api/TblEmailConfigs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblEmailConfig>> DeleteTblEmailConfig(int id)
        {
            var tblEmailConfig = await _context.TblEmailConfig.FindAsync(id);
            if (tblEmailConfig == null)
            {
                return NotFound();
            }

            _context.TblEmailConfig.Remove(tblEmailConfig);
            await _context.SaveChangesAsync();

            return tblEmailConfig;
        }

        private bool TblEmailConfigExists(int id)
        {
            return _context.TblEmailConfig.Any(e => e.EmailServerSettingId == id);
        }
    }
}
