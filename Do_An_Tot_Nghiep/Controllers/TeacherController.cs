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
    public class TeacherController : ControllerBase
    {
        private readonly EduManageContext _context;

        public TeacherController(EduManageContext context)
        {
            _context = context;
        }

        // GET: api/TeacherEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherEntity>>> GetTeacherEntity()
        {
            return await _context.TeacherEntity.ToListAsync();
        }

        // GET: api/TeacherEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherEntity>> GetTeacherEntity(Guid id)
        {
            var teacherEntity = await _context.TeacherEntity.FindAsync(id);

            if (teacherEntity == null)
            {
                return NotFound();
            }

            return teacherEntity;
        }

        // PUT: api/TeacherEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherEntity(Guid id, TeacherEntity teacherEntity)
        {
            if (id != teacherEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacherEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherEntityExists(id))
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

        // POST: api/TeacherEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherEntity>> PostTeacherEntity(TeacherEntity teacherEntity)
        {
            _context.TeacherEntity.Add(teacherEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacherEntity", new { id = teacherEntity.Id }, teacherEntity);
        }

        // DELETE: api/TeacherEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherEntity(Guid id)
        {
            var teacherEntity = await _context.TeacherEntity.FindAsync(id);
            if (teacherEntity == null)
            {
                return NotFound();
            }

            _context.TeacherEntity.Remove(teacherEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherEntityExists(Guid id)
        {
            return _context.TeacherEntity.Any(e => e.Id == id);
        }
    }
}
