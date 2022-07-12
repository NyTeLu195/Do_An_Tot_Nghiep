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
        [HttpPost]
        public async Task<ActionResult<ResponseGridModel>> GetClassroom(GetClassroomQueries requests)
        {

            try
            {
                List<ClassroomReponseDTO> listClassroom = _context.ClassroomEntity.Where(x => x.Name.Contains(requests.Name != null ? requests.Name : x.Name) 
                                                                                        && x.Year == (requests.Year != null ? requests.Year : x.Year) 
                                                                                        && x.IsDelete!=true)
                                                                                 .Select(x => new ClassroomReponseDTO()
                                                                                {
                                                                                    Id = x.Id,
                                                                                    Name = x.Name,
                                                                                    Year = x.Year,
                                                                                    Grade = x.Grade,
                                                                                    Status = x.Status,
                                                                                    TotalNumberStudent = x.TotalNumberStudent,
                                                                                    TeacherName = x.TeacherID != Guid.Empty && x.TeacherID != null ? (x.TeacherEntity.FisrtName + x.TeacherEntity.LastName) : ""
                                                                                }).ToList();
                return new ResponseGridModel()
                {
                    Data = listClassroom,
                    Total = listClassroom.Count,
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    

        // GET: api/Classroom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel>> GetClassroomById(Guid id)
        {
            ResponseModel response = new ResponseModel()
            {
                isSuccess = false,
            };
          try
            {
                ClassroomReponseDTO classroomReponseDTO = _context.ClassroomEntity.Where(x => x.Id == id && x.IsDelete!=true).Select(x => new ClassroomReponseDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Year = x.Year,
                    Grade = x.Grade,
                    Status = x.Status,
                    TotalNumberStudent = x.TotalNumberStudent,
                    TeacherName = x.TeacherID != Guid.Empty && x.TeacherID != null ? (x.TeacherEntity.FisrtName + x.TeacherEntity.LastName) : ""
                }).FirstOrDefault();

                if (classroomReponseDTO != null)
                {
                    response.isSuccess = true;
                    response.data = classroomReponseDTO;
                    return response;
                }
                else 
                {
                    response.message = "Không tìm thấy lớp học";
                    return response;
                } 
                    
            }
            catch (Exception ex) 
            {
                response.message=ex.Message;
                return response;
            }
        }

        // PUT: api/Classroom/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
     

        // POST: api/Classroom
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> CreateOrUpdateClassroom(CreateOrUpdateClassroomCommand request)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                isSuccess = false,
            };
            try
            {
                if (request != null)
                {
                    if (request.Id != null && request.Id != Guid.Empty)
                    {
                        var objClassroom = _context.ClassroomEntity.Find(request.Id);
                        if (objClassroom != null)
                        {
                            objClassroom.Name = (request.Grande + request.Key + request.Order);
                            objClassroom.DateUpdate = DateTime.Now;
                            objClassroom.TeacherID = request.TeacherId != null && request.TeacherId != Guid.Empty ? request.TeacherId : Guid.Empty;
                            objClassroom.Year = request.Year;

                            var checkduplicate = _context.ClassroomEntity.Where(x => x.IsDelete != true
                                                                      && x.Name.Contains(objClassroom.Name)
                                                                      && x.Year == objClassroom.Year)
                                                                      .FirstOrDefault();
                            if (checkduplicate == null)
                            {
                                _context.ClassroomEntity.Update(objClassroom);

                                responseModel.isSuccess = true;
                                return responseModel;
                            }
                            else
                            {
                                responseModel.message = "Dữ liệu đã bị trùng";

                            }

                        }
                    }
                    else
                    {
                        ClassroomEntity obj = new ClassroomEntity()
                        {
                            Id = new Guid(),
                            Name = (request.Grande + request.Key + request.Order),
                            Year = request.Year,
                            TeacherID = request.TeacherId != null && request.TeacherId != Guid.Empty ? request.TeacherId : Guid.Empty,
                            UserCreataID = Guid.Empty,
                            UserUpdateID = Guid.Empty,
                            DateCreated = DateTime.Now,
                            DateUpdate = DateTime.Now,
                            TotalNumberStudent = 0
                        };
                        var checkduplicate = _context.ClassroomEntity.Where(x => x.IsDelete != true
                                                                       && x.Name.Contains(obj.Name)
                                                                       && x.Year == obj.Year)
                                                                       .FirstOrDefault();
                        if (checkduplicate == null)
                        {
                            _context.ClassroomEntity.Add(obj);
                            responseModel.isSuccess=true;
                            return responseModel;
                        }
                    
                    }

                }
                else
                {
                    responseModel.message = "Dữ liệu trống";
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                responseModel.message=ex.Message;
                
            }
            
            return responseModel;
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
                        Name = request.Grande + request.Key +( i + 1),
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
                var classroomEntity =  _context.ClassroomEntity.Where(x=> x.Id==request.ClassroomID && x.IsDelete!=true).FirstOrDefault();
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
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> AutoCountTotalStudent(Guid classroomID)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                isSuccess = false,
            };
            try 
            { 
               //int Total = _context.StudentsEntity.CountAsync() 
            }
            catch(Exception ex)
            {

            }


            return responseModel;
        }

        // DELETE: api/Classroom/5
        [HttpPost("{id}")]
        public async Task<ActionResult<ResponseModel>> DeleteClassroomEntity(Guid id)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                isSuccess = false
            };
            try
            {
                var classroomEntity = _context.ClassroomEntity.Where(x => x.Id == id && x.IsDelete != true).FirstOrDefault();
                if (classroomEntity == null)
                {
                    return NotFound();
                }
                classroomEntity.IsDelete = true;
                _context.ClassroomEntity.Update(classroomEntity);
                await _context.SaveChangesAsync();
                responseModel.isSuccess=true;
            }
            catch (Exception ex)
            {
                responseModel.message=ex.Message;
            }
           
            return responseModel;
        }

        private bool ClassroomEntityExists(Guid id)
        {
            return _context.ClassroomEntity.Any(e => e.Id == id);
        }
    }
}
