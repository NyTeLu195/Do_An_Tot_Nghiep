using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Do_An_Tot_Nghiep.Entity;
using Do_An_Tot_Nghiep.Model;
using System.Security.Cryptography;
using System.Text;

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
        public async Task<ActionResult<ResponseGridModel>> GetTeacherEntity(GetTeacherQueries request)
        {
            ResponseGridModel response = new ResponseGridModel();

            try
            {
                List<TeacherGridReponseDTO> listTeacher = _context.TeacherEntity.Where(x => x.IsDeleted != true
                                                                                           && (x.FisrtName.Contains(request.Name != null ? request.Name : x.FisrtName)
                                                                                           || (x.LastName.Contains(request.Name != null ? request.Name : x.LastName))
                                                                                           || x.UserName.Contains(request.TeacherUserName != null ? request.TeacherUserName : x.UserName)))
                                                                                           .Select(x => new TeacherGridReponseDTO
                                                                                           {
                                                                                               Id = x.Id,
                                                                                               UserName = x.UserName,
                                                                                               Address = x.Address,
                                                                                               Age = x.Age,
                                                                                               BirthDay = x.BirthDate,
                                                                                               FullName = x.FisrtName + " " + x.LastName,
                                                                                               Phone = x.Phone,
                                                                                           }
                                                                                           ).ToList();
                response.Data = listTeacher;
                response.Total = listTeacher.Count;
            }
            catch (Exception ex)
            {
                return null;
            }
           


            return response;
        }

        // GET: api/TeacherEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel>> GetTeacherById(Guid id)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                TeacherReponseDTO objTeacher = _context.TeacherEntity.Where(x => x.IsDeleted != true&& x.Id == id)
                                                                                           .Select(x => new TeacherReponseDTO
                                                                                           {
                                                                                               Id = x.Id,
                                                                                               UserName = x.UserName,
                                                                                               Address = x.Address,
                                                                                               Age = x.Age,
                                                                                               BirthDay = x.BirthDate,
                                                                                               FisrtName = x.FisrtName,
                                                                                               LastName= x.LastName,
                                                                                               Phone = x.Phone,
                                                                                           }
                                                                                           ).FirstOrDefault();
                if(objTeacher == null)
                {
                    return new ResponseModel
                    {
                        isSuccess = false,
                        message = "Không tìm thấy giáo viên"
                    };
                }    
                else
                {
                    response.data = objTeacher;
                    response.isSuccess = true;
                }    
             
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }



            return response;
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
        // POST: api/TeacherEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> CreateOrUpdateTeacher(CreateOrUpdateTeacherCommand request)
        {

            ResponseModel responseModel = new ResponseModel()
            {
                isSuccess = false,
            };
            try
            {
                var lastTeacher = _context.TeacherEntity.OrderByDescending(x => x.DateCreated).FirstOrDefault();
                var checkduplicate = _context.TeacherEntity.Where(x => x.UserName == request.UserName && x.IsDeleted != true).ToList();
                if (checkduplicate == null || checkduplicate.Count == 0)
                {
                    if (request.Id != null && request.Id != Guid.Empty)
                    {
                        var objTeacher = _context.TeacherEntity.Where(x => x.Id == request.Id && x.IsDeleted != true).FirstOrDefault();
                        if (objTeacher != null)
                        {
                            objTeacher.Address = request.Address;
                            objTeacher.Age = DateTime.Now.Year - request.BirthDay.Year;
                            objTeacher.BirthDate = request.BirthDay;
                            objTeacher.DateUpdate = DateTime.Now;
                            objTeacher.FisrtName = request.FisrtName;
                            objTeacher.LastName = request.LastName;
                            objTeacher.Phone = request.Phone;
                            objTeacher.UserName = request.UserName;
                            objTeacher.Password = GetHash(request.Password);
                            _context.TeacherEntity.Update(objTeacher);
                            responseModel.data = objTeacher;
                        }

                    }
                    else
                    {
                        TeacherEntity TeacherEntity = new TeacherEntity()
                        {

                            Address = request.Address,
                            Status = null,
                            IsDeleted = null,
                            Id = new Guid(),
                            Age = DateTime.Now.Year - request.BirthDay.Year,
                            BirthDate = request.BirthDay,
                            Code = lastTeacher != null ? lastTeacher.Code + 1 : 1,
                            DateCreated = DateTime.Now,
                            DateUpdate = DateTime.Now,
                            FisrtName = request.FisrtName,
                            LastName = request.LastName,
                            Phone = request.Phone,
                            UserName = request.UserName,
                            Password = GetHash(request.Password),
                            UserCreataID = request.UserLoginID,
                            UserUpdateID = request.UserLoginID,

                        };
                        _context.TeacherEntity.Add(TeacherEntity);
                        responseModel.data = TeacherEntity;
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

                responseModel.message = ex.Message;
                return responseModel;
            }

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
