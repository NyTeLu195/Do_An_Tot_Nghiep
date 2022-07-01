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
    public class AttendanceController : ControllerBase
    {
        private readonly EduManageContext _context;

        public AttendanceController(EduManageContext context)
        {
            _context = context;
        }

        // GET: api/Attendance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceEntity>>> GetAttendanceEntity()
        {
            return await _context.AttendanceEntity.ToListAsync();
        }

        // GET: api/Attendance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceEntity>> GetAttendanceEntity(Guid id)
        {
            var attendanceEntity = await _context.AttendanceEntity.FindAsync(id);

            if (attendanceEntity == null)
            {
                return NotFound();
            }

            return attendanceEntity;
        }

        // PUT: api/Attendance/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendanceEntity(Guid id, AttendanceEntity attendanceEntity)
        {
            if (id != attendanceEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(attendanceEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceEntityExists(id))
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

        // POST: api/Attendance
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AttendanceEntity>> PostAttendanceEntity(AttendanceEntity attendanceEntity)
        {
            _context.AttendanceEntity.Add(attendanceEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendanceEntity", new { id = attendanceEntity.Id }, attendanceEntity);
        }

        // DELETE: api/Attendance/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendanceEntity(Guid id)
        {
            var attendanceEntity = await _context.AttendanceEntity.FindAsync(id);
            if (attendanceEntity == null)
            {
                return NotFound();
            }

            _context.AttendanceEntity.Remove(attendanceEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendanceEntityExists(Guid id)
        {
            return _context.AttendanceEntity.Any(e => e.Id == id);
        }
    }
}
