
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace EduManage.Domain.Entities
{
    public class Classroom
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Guid? TeacherID { get; set; }
        public Teacher Teacher { get; set; }    
        public int TotalNumberStudent { get; set; }
        public int Grade { get; set; }
        public string Status { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public Guid UserCreataID { get; set; }
        public Guid UserUpdateID { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}
