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
    public class TblMenusController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblMenusController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblMenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMenu>>> GetTblMenu()
        {
            return await _context.TblMenu.ToListAsync();
        }

        // GET: api/TblMenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblMenu>> GetTblMenu(string id)
        {
            var tblMenu = await _context.TblMenu.FindAsync(id);

            if (tblMenu == null)
            {
                return NotFound();
            }

            return tblMenu;
        }

        // PUT: api/TblMenus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMenu(string id, TblMenu tblMenu)
        {
            if (id != tblMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMenuExists(id))
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

        // POST: api/TblMenus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblMenu>> PostTblMenu(TblMenu tblMenu)
        {
            _context.TblMenu.Add(tblMenu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblMenuExists(tblMenu.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblMenu", new { id = tblMenu.Id }, tblMenu);
        }

        // DELETE: api/TblMenus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblMenu>> DeleteTblMenu(string id)
        {
            var tblMenu = await _context.TblMenu.FindAsync(id);
            if (tblMenu == null)
            {
                return NotFound();
            }

            _context.TblMenu.Remove(tblMenu);
            await _context.SaveChangesAsync();

            return tblMenu;
        }

        private bool TblMenuExists(string id)
        {
            return _context.TblMenu.Any(e => e.Id == id);
        }
    }
}
