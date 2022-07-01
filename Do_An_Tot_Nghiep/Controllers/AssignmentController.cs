using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Do_An_Tot_Nghiep.Entity;
using Do_An_Tot_Nghiep.Model;

namespace Do_An_Tot_Nghiep.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly EduManageContext _context;

        public AssignmentController(EduManageContext context)
        {
            _context = context;
        }

        // GET: api/Assignment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentEntity>>> GetAssignmentEntity()
        {
            return await _context.AssignmentEntity.ToListAsync();
        }

        // GET: api/Assignment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentEntity>> GetAssignmentEntity(Guid id)
        {
            var assignmentEntity = await _context.AssignmentEntity.FindAsync(id);

            if (assignmentEntity == null)
            {
                return NotFound();
            }

            return assignmentEntity;
        }

        // PUT: api/Assignment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignmentEntity(Guid id, AssignmentEntity assignmentEntity)
        {
            if (id != assignmentEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignmentEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentEntityExists(id))
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

        // POST: api/Assignment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssignmentEntity>> PostAssignmentEntity(AssignmentEntity assignmentEntity)
        {
            _context.AssignmentEntity.Add(assignmentEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignmentEntity", new { id = assignmentEntity.Id }, assignmentEntity);
        }

        // DELETE: api/Assignment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignmentEntity(Guid id)
        {
            var assignmentEntity = await _context.AssignmentEntity.FindAsync(id);
            if (assignmentEntity == null)
            {
                return NotFound();
            }

            _context.AssignmentEntity.Remove(assignmentEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignmentEntityExists(Guid id)
        {
            return _context.AssignmentEntity.Any(e => e.Id == id);
        }
    }
}
