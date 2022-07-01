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
    public class ViolationHistoryController : ControllerBase
    {
        private readonly EduManageContext _context;

        public ViolationHistoryController(EduManageContext context)
        {
            _context = context;
        }

        // GET: api/ViolationHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViolationHistoryEntity>>> GetViolationHistoryEntity()
        {
            return await _context.ViolationHistoryEntity.ToListAsync();
        }

        // GET: api/ViolationHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViolationHistoryEntity>> GetViolationHistoryEntity(Guid id)
        {
            var violationHistoryEntity = await _context.ViolationHistoryEntity.FindAsync(id);

            if (violationHistoryEntity == null)
            {
                return NotFound();
            }

            return violationHistoryEntity;
        }

        // PUT: api/ViolationHistory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViolationHistoryEntity(Guid id, ViolationHistoryEntity violationHistoryEntity)
        {
            if (id != violationHistoryEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(violationHistoryEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViolationHistoryEntityExists(id))
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

        // POST: api/ViolationHistory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ViolationHistoryEntity>> PostViolationHistoryEntity(ViolationHistoryEntity violationHistoryEntity)
        {
            _context.ViolationHistoryEntity.Add(violationHistoryEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViolationHistoryEntity", new { id = violationHistoryEntity.Id }, violationHistoryEntity);
        }

        // DELETE: api/ViolationHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViolationHistoryEntity(Guid id)
        {
            var violationHistoryEntity = await _context.ViolationHistoryEntity.FindAsync(id);
            if (violationHistoryEntity == null)
            {
                return NotFound();
            }

            _context.ViolationHistoryEntity.Remove(violationHistoryEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViolationHistoryEntityExists(Guid id)
        {
            return _context.ViolationHistoryEntity.Any(e => e.Id == id);
        }
    }
}
