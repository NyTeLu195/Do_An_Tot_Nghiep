using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Do_An_Tot_Nghiep.Entity;
using Do_An_Tot_Nghiep.Model;
using Newtonsoft.Json;

namespace Do_An_Tot_Nghiep.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly EduManageContext _context;

        public StudentsController(EduManageContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsEntity>>> GetStudentsEntity()
        {
            return await _context.StudentsEntity.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsEntity>> GetStudentsEntity(Guid id)
        {
            var studentsEntity = await _context.StudentsEntity.FindAsync(id);

            if (studentsEntity == null)
            {
                return NotFound();
            }

            return studentsEntity;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsEntity(Guid id, StudentsEntity studentsEntity)
        {
            if (id != studentsEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentsEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsEntityExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsEntity>> PostStudentsEntity(StudentsEntity studentsEntity)
        {
            _context.StudentsEntity.Add(studentsEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsEntity", new { id = studentsEntity.Id }, studentsEntity);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> PromotedStudent(PromotedStudentCommand request)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                isSuccess = false,
            };
            try 
            {
                if(request.StudentID != null)
                {
                    foreach(var studentid in request.StudentID)
                    {
                        var objstudent= _context.StudentsEntity
                            .Where(x => x.IsDeleted != true && x.Id == studentid)
                            .FirstOrDefault();
                        if (objstudent != null)
                        {
                            objstudent.DateCreated = DateTime.Now;
                            objstudent.DateUpdate = DateTime.Now;
                            if(objstudent.Process!= null)
                            {
                                List<ProcessStudie> processStudie = JsonConvert.DeserializeObject<List<ProcessStudie>>(objstudent.Process);
                                ProcessStudie objProcess = new ProcessStudie()
                                {
                                    ClassroomID = request.ClassroomID,
                                    Time = request.Time,
                                };
                                processStudie.Add(objProcess);
                                objstudent.Process = JsonConvert.SerializeObject(processStudie);
                            }    
                            else
                            {
                                List<ProcessStudie> processStudie = new List<ProcessStudie>();
                                ProcessStudie objProcess = new ProcessStudie()
                                {
                                    ClassroomID = request.ClassroomID,
                                    Time = request.Time,
                                };
                                processStudie.Add(objProcess);
                                objstudent.Process = JsonConvert.SerializeObject(processStudie);
                            }

                            _context.StudentsEntity.Update(objstudent);
                        }    
                        else
                        {
                            continue;
                        }    
                        
                    }   
                    responseModel.isSuccess = true;
                }    
            }
            catch (Exception ex)
            {
                responseModel.isSuccess = false;
                responseModel.message = ex.Message;
            }


            await _context.SaveChangesAsync();

            return responseModel;
        }


        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsEntity(Guid id)
        {
            var studentsEntity = await _context.StudentsEntity.FindAsync(id);
            if (studentsEntity == null)
            {
                return NotFound();
            }

            _context.StudentsEntity.Remove(studentsEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsEntityExists(Guid id)
        {
            return _context.StudentsEntity.Any(e => e.Id == id);
        }
    }
}
