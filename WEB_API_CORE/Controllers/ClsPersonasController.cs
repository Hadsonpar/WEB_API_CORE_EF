using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_CORE.Models;

namespace WEB_API_CORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClsPersonasController : ControllerBase
    {
        private readonly ClsPersonaContext _context;

        public ClsPersonasController(ClsPersonaContext context)
        {
            _context = context;
        }

        // GET: api/ClsPersonas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClsPersona>>> GetClsPersonas()
        {
            return await _context.ClsPersonas.ToListAsync();
        }

        // GET: api/ClsPersonas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClsPersona>> GetClsPersona(long id)
        {
            var clsPersona = await _context.ClsPersonas.FindAsync(id);

            if (clsPersona == null)
            {
                return NotFound();
            }

            return clsPersona;
        }

        // PUT: api/ClsPersonas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClsPersona(long id, ClsPersona clsPersona)
        {
            if (id != clsPersona.id)
            {
                return BadRequest();
            }

            _context.Entry(clsPersona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClsPersonaExists(id))
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

        // POST: api/ClsPersonas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ClsPersona>> PostClsPersona(ClsPersona clsPersona)
        {
            _context.ClsPersonas.Add(clsPersona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClsPersona", new { id = clsPersona.id }, clsPersona);
        }

        // DELETE: api/ClsPersonas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClsPersona>> DeleteClsPersona(long id)
        {
            var clsPersona = await _context.ClsPersonas.FindAsync(id);
            if (clsPersona == null)
            {
                return NotFound();
            }

            _context.ClsPersonas.Remove(clsPersona);
            await _context.SaveChangesAsync();

            return clsPersona;
        }

        private bool ClsPersonaExists(long id)
        {
            return _context.ClsPersonas.Any(e => e.id == id);
        }
    }
}
