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
using System.Security.Cryptography;
using System.Text;

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
        public async Task<ActionResult<ResponseGridModel>> GetAllStudents()
        {
            ResponseGridModel response =  new ResponseGridModel();
            try
            {
                List<StudentReponseDTO> listStudents = _context.StudentsEntity
                                                                .Where(x => x.IsDeleted != true)
                                                                .Select(s => new StudentReponseDTO 
                                                                {
                                                                    Id = s.Id,
                                                                    Code = s.Code,
                                                                    FisrtName = s.FisrtName,
                                                                    LastName = s.LastName,
                                                                    Age=s.Age,
                                                                    BirthDate = s.BirthDate,
                                                                    Address = s.Address,
                                                                    Phone = s.Phone,
                                                                    UserName = s.UserName,
                                                                    Role = s.Role,
                                                                    Status = s.Status,
                                                                    Process = s.Process,
                                                                }
                                                                 )
                                                              .ToList();

                return new ResponseGridModel()
                {
                    Data = listStudents,
                    Total = listStudents.Count
                };
            }
            catch (Exception ex)
            {
                return null;
            }
 
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel>> GetStudentByID(Guid StudentID)
        {
            ResponseModel response = new ResponseModel()
            {
                isSuccess = false
            };
            try
            {
                StudentReponseDTO objStudents = _context.StudentsEntity
                                                                .Where(x => x.IsDeleted != true && x.Id== StudentID)
                                                                .Select(s => new StudentReponseDTO
                                                                {
                                                                    Id = s.Id,
                                                                    Code = s.Code,
                                                                    FisrtName = s.FisrtName,
                                                                    LastName = s.LastName,
                                                                    Age = s.Age,
                                                                    BirthDate = s.BirthDate,
                                                                    Address = s.Address,
                                                                    Phone = s.Phone,
                                                                    UserName = s.UserName,
                                                                    Role = s.Role,
                                                                    Status = s.Status,
                                                                    Process = s.Process,
                                                                }
                                                                 )
                                                              .FirstOrDefault();

                if(objStudents == null)
                {
                    response.message = "Không tìm thấy học sinh";
                }
                else
                {
                    response.data = objStudents;
                    response.isSuccess = true;
                }    
              
            
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }

            return response;

        }
        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentsEntity(Guid id, StudentsEntity studentsEntity)
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
        public static string GetHash(string plainText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            // Compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(plainText));
            // Get hash result after compute it
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> CreateorUpdateStudent(CreateorUpdateStudentCommand request)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                isSuccess = false,
            };
            try 
            {


                var lastStudent= _context.StudentsEntity.OrderByDescending(x=>x.DateCreated).FirstOrDefault();
                var checkduplicate = _context.StudentsEntity.Where(x => x.UserName == request.UserName&& x.IsDeleted!= true).ToList();
                if(checkduplicate== null|| checkduplicate.Count==0)
                {
                    if (request.Id != null&& request.Id!= Guid.Empty)
                    { 
                    var objStudent = _context.StudentsEntity.Where(x => x.Id == request.Id && x.IsDeleted != true).FirstOrDefault();
                        if (objStudent != null)
                        {
                            objStudent.Address = request.Address;
                            objStudent.Age = DateTime.Now.Year - request.BirthDate.Year;
                            objStudent.BirthDate = request.BirthDate;
                            objStudent.DateUpdate = DateTime.Now;
                            objStudent.FisrtName = request.FisrtName;
                            objStudent.LastName = request.LastName;
                            objStudent.Phone = request.Phone;
                            objStudent.UserName = request.UserName;
                            objStudent.Password = GetHash(request.Password);
                            _context.StudentsEntity.Update(objStudent);
                            responseModel.data= objStudent;
                        }    

                    }
                    else
                    {
                         StudentsEntity studentsEntity = new StudentsEntity()
                    {

                        Address = request.Address,
                        Process = null, 
                        Status = null,
                        IsDeleted = null,
                        Id = new Guid(),
                        Age =  DateTime.Now.Year - request.BirthDate.Year,
                        BirthDate = request.BirthDate,
                        Code = lastStudent != null ? lastStudent.Code + 1 : 1,
                        DateCreated = DateTime.Now,
                        DateUpdate = DateTime.Now,
                        FisrtName = request.FisrtName,
                        LastName = request.LastName,
                        Phone = request.Phone,
                        UserName = request.UserName,
                        Password = GetHash(request.Password),
                        UserCreataID = request.UserLogin,
                        UserUpdateID = request.UserLogin,

                    };
                    _context.StudentsEntity.Add(studentsEntity);
                     responseModel.data = studentsEntity;
                    }    
                   
                    await _context.SaveChangesAsync();
                    responseModel.isSuccess = true;
                
                }
                else
                {
                    responseModel.message = "UserName đã tồn tại";
                }
                return responseModel;

            }
            catch (Exception ex)
            {

                responseModel.message= ex.Message;
                return responseModel;
            }


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
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> DeleteStudentsEntity(Guid id)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                isSuccess = false
            };
            try 
            {
                var studentsEntity = _context.StudentsEntity.Where(x => x.IsDeleted != true && x.Id == id).FirstOrDefault();
                if (studentsEntity == null)
                {
                    return NotFound();
                }

                studentsEntity.IsDeleted = true;
                _context.StudentsEntity.Update(studentsEntity);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                responseModel.data = ex.Message;
            }
            return responseModel;
        }

        private bool StudentsEntityExists(Guid id)
        {
            return _context.StudentsEntity.Any(e => e.Id == id);
        }
    }
}
