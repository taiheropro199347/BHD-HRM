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
    public class TblQuaTrinhDaoTaosController : ControllerBase
    {
        private readonly BHDHRMContext _context;

        public TblQuaTrinhDaoTaosController(BHDHRMContext context)
        {
            _context = context;
        }

        // GET: api/TblQuaTrinhDaoTaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblQuaTrinhDaoTao>>> GetTblQuaTrinhDaoTao()
        {
            return await _context.TblQuaTrinhDaoTao.ToListAsync();
        }

        // GET: api/TblQuaTrinhDaoTaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblQuaTrinhDaoTao>> GetTblQuaTrinhDaoTao(int id)
        {
            var tblQuaTrinhDaoTao = await _context.TblQuaTrinhDaoTao.FindAsync(id);

            if (tblQuaTrinhDaoTao == null)
            {
                return NotFound();
            }

            return tblQuaTrinhDaoTao;
        }

        // PUT: api/TblQuaTrinhDaoTaos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblQuaTrinhDaoTao(int id, TblQuaTrinhDaoTao tblQuaTrinhDaoTao)
        {
            if (id != tblQuaTrinhDaoTao.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblQuaTrinhDaoTao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuaTrinhDaoTaoExists(id))
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

        // POST: api/TblQuaTrinhDaoTaos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblQuaTrinhDaoTao>> PostTblQuaTrinhDaoTao(TblQuaTrinhDaoTao tblQuaTrinhDaoTao)
        {
            _context.TblQuaTrinhDaoTao.Add(tblQuaTrinhDaoTao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblQuaTrinhDaoTao", new { id = tblQuaTrinhDaoTao.Id }, tblQuaTrinhDaoTao);
        }

        // DELETE: api/TblQuaTrinhDaoTaos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblQuaTrinhDaoTao>> DeleteTblQuaTrinhDaoTao(int id)
        {
            var tblQuaTrinhDaoTao = await _context.TblQuaTrinhDaoTao.FindAsync(id);
            if (tblQuaTrinhDaoTao == null)
            {
                return NotFound();
            }

            _context.TblQuaTrinhDaoTao.Remove(tblQuaTrinhDaoTao);
            await _context.SaveChangesAsync();

            return tblQuaTrinhDaoTao;
        }

        private bool TblQuaTrinhDaoTaoExists(int id)
        {
            return _context.TblQuaTrinhDaoTao.Any(e => e.Id == id);
        }
    }
}
