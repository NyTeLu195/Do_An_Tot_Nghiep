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
    public class RegisterController : ControllerBase
    {
        private readonly EduManageContext _context;

        public RegisterController(EduManageContext context)
        {
            _context = context;
        }

        // GET: api/RegisterEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterEntity>>> GetRegisterEntity()
        {
            return await _context.RegisterEntity.ToListAsync();
        }

        // GET: api/RegisterEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterEntity>> GetRegisterEntity(Guid id)
        {
            var registerEntity = await _context.RegisterEntity.FindAsync(id);

            if (registerEntity == null)
            {
                return NotFound();
            }

            return registerEntity;
        }

        // PUT: api/RegisterEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisterEntity(Guid id, RegisterEntity registerEntity)
        {
            if (id != registerEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(registerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterEntityExists(id))
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

        // POST: api/RegisterEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegisterEntity>> PostRegisterEntity(RegisterEntity registerEntity)
        {
            _context.RegisterEntity.Add(registerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegisterEntity", new { id = registerEntity.Id }, registerEntity);
        }

        // DELETE: api/RegisterEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisterEntity(Guid id)
        {
            var registerEntity = await _context.RegisterEntity.FindAsync(id);
            if (registerEntity == null)
            {
                return NotFound();
            }

            _context.RegisterEntity.Remove(registerEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisterEntityExists(Guid id)
        {
            return _context.RegisterEntity.Any(e => e.Id == id);
        }
    }
}
