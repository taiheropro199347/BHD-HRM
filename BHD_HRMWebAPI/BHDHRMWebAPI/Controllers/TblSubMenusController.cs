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
    public class TblSubMenusController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblSubMenusController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblSubMenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSubMenu>>> GetTblSubMenu()
        {
            return await _context.TblSubMenu.ToListAsync();
        }

        // GET: api/TblSubMenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSubMenu>> GetTblSubMenu(string id)
        {
            var tblSubMenu = await _context.TblSubMenu.FindAsync(id);

            if (tblSubMenu == null)
            {
                return NotFound();
            }

            return tblSubMenu;
        }

        // PUT: api/TblSubMenus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSubMenu(string id, TblSubMenu tblSubMenu)
        {
            if (id != tblSubMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSubMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSubMenuExists(id))
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

        // POST: api/TblSubMenus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblSubMenu>> PostTblSubMenu(TblSubMenu tblSubMenu)
        {
            _context.TblSubMenu.Add(tblSubMenu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblSubMenuExists(tblSubMenu.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblSubMenu", new { id = tblSubMenu.Id }, tblSubMenu);
        }

        // DELETE: api/TblSubMenus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblSubMenu>> DeleteTblSubMenu(string id)
        {
            var tblSubMenu = await _context.TblSubMenu.FindAsync(id);
            if (tblSubMenu == null)
            {
                return NotFound();
            }

            _context.TblSubMenu.Remove(tblSubMenu);
            await _context.SaveChangesAsync();

            return tblSubMenu;
        }

        private bool TblSubMenuExists(string id)
        {
            return _context.TblSubMenu.Any(e => e.Id == id);
        }
    }
}
