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
    public class MyTablesController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public MyTablesController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/MyTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTable>>> GetMyTable()
        {
            return await _context.MyTable.ToListAsync();
        }

        // GET: api/MyTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyTable>> GetMyTable(int id)
        {
            var myTable = await _context.MyTable.FindAsync(id);

            if (myTable == null)
            {
                return NotFound();
            }

            return myTable;
        }

        // PUT: api/MyTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyTable(int id, MyTable myTable)
        {
            if (id != myTable.MytableId)
            {
                return BadRequest();
            }

            _context.Entry(myTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyTableExists(id))
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

        // POST: api/MyTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MyTable>> PostMyTable(MyTable myTable)
        {
            _context.MyTable.Add(myTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MyTableExists(myTable.MytableId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMyTable", new { id = myTable.MytableId }, myTable);
        }

        // DELETE: api/MyTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MyTable>> DeleteMyTable(int id)
        {
            var myTable = await _context.MyTable.FindAsync(id);
            if (myTable == null)
            {
                return NotFound();
            }

            _context.MyTable.Remove(myTable);
            await _context.SaveChangesAsync();

            return myTable;
        }

        private bool MyTableExists(int id)
        {
            return _context.MyTable.Any(e => e.MytableId == id);
        }
    }
}
