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
    public class RegisterDetailController : ControllerBase
    {
        private readonly EduManageContext _context;

        public RegisterDetailController(EduManageContext context)
        {
            _context = context;
        }

        // GET: api/RegisterDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterDetailEntity>>> GetRegisterDetailEntity()
        {
            return await _context.RegisterDetailEntity.ToListAsync();
        }

        // GET: api/RegisterDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterDetailEntity>> GetRegisterDetailEntity(Guid id)
        {
            var registerDetailEntity = await _context.RegisterDetailEntity.FindAsync(id);

            if (registerDetailEntity == null)
            {
                return NotFound();
            }

            return registerDetailEntity;
        }

        // PUT: api/RegisterDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisterDetailEntity(Guid id, RegisterDetailEntity registerDetailEntity)
        {
            if (id != registerDetailEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(registerDetailEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterDetailEntityExists(id))
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

        // POST: api/RegisterDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegisterDetailEntity>> PostRegisterDetailEntity(RegisterDetailEntity registerDetailEntity)
        {
            _context.RegisterDetailEntity.Add(registerDetailEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegisterDetailEntity", new { id = registerDetailEntity.Id }, registerDetailEntity);
        }

        // DELETE: api/RegisterDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisterDetailEntity(Guid id)
        {
            var registerDetailEntity = await _context.RegisterDetailEntity.FindAsync(id);
            if (registerDetailEntity == null)
            {
                return NotFound();
            }

            _context.RegisterDetailEntity.Remove(registerDetailEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisterDetailEntityExists(Guid id)
        {
            return _context.RegisterDetailEntity.Any(e => e.Id == id);
        }
    }
}
