using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using payback4marvin;
using payback4marvin.Model;

namespace payback4marvin.Controllers
{
    [EnableCors("*")]
    [Route("api/[controller]")]
    [ApiController]
    public class VerbrecherController : ControllerBase
    {
        private readonly PayBackContext _context;
 
        public VerbrecherController(PayBackContext context)
        {
            _context = context;
        }

        // GET: api/Verbrecher
        [HttpGet]
        public async Task<IEnumerable<Verbrecher>> GetVerbrecherDb()
        {
            return await _context.Verbrecher.ToListAsync();
        }

        // GET: api/Verbecher/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVerbrecher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var verbrecher = await _context.Verbrecher.Include(v => v.Vergehen).FirstOrDefaultAsync(v => v.VerbrecherId == id);
            if (verbrecher == null)
            {
                return NotFound();
            }

            return Ok(verbrecher);
        }

        // PUT: api/Verbrecher/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVerbecher([FromRoute] int id, [FromBody] Verbrecher verbrecher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != verbrecher.VerbrecherId)
            {
                return BadRequest();
            }

            _context.Entry(verbrecher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VerbrecherExists(id))
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

        // POST: api/Verbecher
        [HttpPost]
        public async Task<IActionResult> PostVerbrecher(Verbrecher verbrecher)
        {
            _context.Verbrecher.Add(verbrecher);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVerbecher", new { id = verbrecher.VerbrecherId }, verbrecher);
        }

        // DELETE: api/Verbrecher/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVerbrecher(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var verbrecher = await _context.Verbrecher.FindAsync(id);
            if (verbrecher == null)
            {
                return NotFound();
            }

            _context.Verbrecher.Remove(verbrecher);
            await _context.SaveChangesAsync();

            return Ok(verbrecher);
        }

        // /api/Verbrecher/16/Vergehen
        [HttpGet("{verbrecherId}/vergehen")]
        public async Task<ActionResult<IList<Vergehen>>> GetAllVergehen(int verbrecherId)
        {
            return await _context.Vergehen.Where(x => x.VerbrecherId == verbrecherId).ToListAsync();
          //  return await _context.Verbrecher.Where(x => x.VerbrecherId == verbrecherId).SelectMany(x => x.Vergehen).ToListAsync();
        }

        // /api/Verbrecher/16/Vergehen/123
        [HttpGet("{verbrecherId}/vergehen/{vergehenId}")]
        public async Task<ActionResult<Vergehen>> GetVergehen(int verbrecherId, int vergehenId)
        {

            var item = await  _context.Vergehen.FindAsync(vergehenId);
            if(item == null){
                return NotFound();
            }
            return item;
        }

        // /api/Verbrecher/16/Vergehen
        [HttpPost("{verbrecherId}/vergehen")]
        public async Task<IActionResult> PostVergehen(int verbrecherId, Vergehen vergehen)
        {

            _context.Vergehen.Add(vergehen);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVergehen), new { verbrecherId = verbrecherId, vergehenId = vergehen.VergehenId }, vergehen);

        }




        private bool VerbrecherExists(int id)
        {
            return _context.Verbrecher.Any(e => e.VerbrecherId == id);
        }
    }
}