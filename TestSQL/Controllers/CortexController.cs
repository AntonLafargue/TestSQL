using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestSQL.Models;
using TestSQL.TestSQL.Data;

namespace TestSQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CortexController : ControllerBase
    {
        private readonly Context _context;
        public CortexController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cortex>>> GetValues()
        {
            var values = await _context.Cortex.ToListAsync();
            if (values != null)
            {
                return values;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Cortex>> Post_Values(Cortex cortex)
        {
            _context.Cortex.Add(cortex);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetValues", new { id = cortex.id }, cortex);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cortex>> Delete_values(int id)
        {
            var values = await _context.Cortex.FindAsync(id);
            if (values == null)
            {
                return NotFound();
            }
            _context.Cortex.Remove(values);
            await _context.SaveChangesAsync();
            return values;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put_Values(int id, Cortex cortex)
        {
            if (id != cortex.id)
            {
                return BadRequest();
            }

            _context.Entry(cortex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValuesExists(id))
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

        private bool ValuesExists(int id)
        {
            return _context.Cortex.Any(x => x.id == id);
        }
    }
}
