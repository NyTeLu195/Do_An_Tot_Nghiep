using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Do_An_Tot_Nghiep.Entity;

namespace Do_An_Tot_Nghiep.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ViolationController : ControllerBase
    {
        private readonly EduManageContext _context;

        public ViolationController(EduManageContext context)
        {
            _context = context;
        }

        // GET: api/Violation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViolationEntity>>> GetViolationEntity()
        {
            return await _context.ViolationEntity.ToListAsync();
        }

        // GET: api/Violation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViolationEntity>> GetViolationEntity(Guid id)
        {
            var violationEntity = await _context.ViolationEntity.FindAsync(id);

            if (violationEntity == null)
            {
                return NotFound();
            }

            return violationEntity;
        }

        // PUT: api/Violation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViolationEntity(Guid id, ViolationEntity violationEntity)
        {
            if (id != violationEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(violationEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViolationEntityExists(id))
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

        // POST: api/Violation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ViolationEntity>> PostViolationEntity(ViolationEntity violationEntity)
        {
            _context.ViolationEntity.Add(violationEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViolationEntity", new { id = violationEntity.Id }, violationEntity);
        }

        // DELETE: api/Violation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViolationEntity(Guid id)
        {
            var violationEntity = await _context.ViolationEntity.FindAsync(id);
            if (violationEntity == null)
            {
                return NotFound();
            }

            _context.ViolationEntity.Remove(violationEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViolationEntityExists(Guid id)
        {
            return _context.ViolationEntity.Any(e => e.Id == id);
        }
    }
}
