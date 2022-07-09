﻿using System;
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
        public async Task<ActionResult<ResponseModel>> CreateStudent(CreateStudentCommand request)
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
                    await _context.SaveChangesAsync();
                    responseModel.isSuccess = true;
                    responseModel.data = studentsEntity;
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
