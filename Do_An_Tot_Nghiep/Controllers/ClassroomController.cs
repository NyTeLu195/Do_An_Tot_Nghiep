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
    public class ClassroomController : ControllerBase
    {
        private readonly EduManageContext _context;

        public ClassroomController(EduManageContext context)
        {
            _context = context;
        }

        // GET: api/Classroom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassroomEntity>>> GetClassroomEntity()
        {
            return await _context.ClassroomEntity.ToListAsync();
        }

        // GET: api/Classroom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassroomEntity>> GetClassroomEntity(Guid id)
        {
            var classroomEntity = await _context.ClassroomEntity.FindAsync(id);

            if (classroomEntity == null)
            {
                return NotFound();
            }

            return classroomEntity;
        }

        // PUT: api/Classroom/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassroomEntity(Guid id, ClassroomEntity classroomEntity)
        {
            if (id != classroomEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(classroomEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomEntityExists(id))
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

        // POST: api/Classroom
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassroomEntity>> PostClassroomEntity(ClassroomEntity classroomEntity)
        {
            _context.ClassroomEntity.Add(classroomEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassroomEntity", new { id = classroomEntity.Id }, classroomEntity);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> AutoGenerateClassroom(AutoGenerateClassroomCommand request)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                isSuccess = false,
            };
            try
            {
                for (int i = 0; i < request.Total; i++)
                {

                    ClassroomEntity obj = new ClassroomEntity()
                    {
                        Id = new Guid(),
                        Grade = request.Grande,
                        Name = request.Grande + request.Key + i + 1,
                        Year = request.Year,
                        UserCreataID = request.UserID,
                        UserUpdateID = request.UserID,
                        DateCreated = DateTime.Now,
                        DateUpdate = DateTime.Now,
                        TotalNumberStudent = 0
                    };
                    var checkduplicate = _context.ClassroomEntity.Where(x => x.IsDelete != true 
                                                                        && x.Name.Contains(obj.Name) 
                                                                        && x.Year == obj.Year)
                                                                        .FirstOrDefault();
                    if (checkduplicate != null)
                    {
                        continue;
                    }
                    else
                    {
                        _context.ClassroomEntity.Add(obj);
                    }

                };

                await _context.SaveChangesAsync();
                responseModel.isSuccess = true;
            }
            catch (Exception ex)
            {
                responseModel.message = ex.Message;
            }

            return responseModel;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> AddHomeroomTeacher(AddHomeroomTeacherCommand request)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                isSuccess = false,
            };
            try
            {
                var classroomEntity = await _context.ClassroomEntity.FindAsync(request.ClassroomID);
                if (classroomEntity == null)
                {
                    classroomEntity.TeacherID = request.TeacherID;
                    _context.ClassroomEntity.Update(classroomEntity);
                }
                await _context.SaveChangesAsync();
                responseModel.isSuccess = true;
            }
            catch (Exception ex)
            {
                responseModel.message = ex.Message;
            }

            return responseModel;
        }


        // DELETE: api/Classroom/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroomEntity(Guid id)
        {
            var classroomEntity = await _context.ClassroomEntity.FindAsync(id);
            if (classroomEntity == null)
            {
                return NotFound();
            }

            _context.ClassroomEntity.Remove(classroomEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassroomEntityExists(Guid id)
        {
            return _context.ClassroomEntity.Any(e => e.Id == id);
        }
    }
}
