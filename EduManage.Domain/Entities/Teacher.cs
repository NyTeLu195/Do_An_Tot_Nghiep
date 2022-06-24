
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Do_An_Tot_Nghiep.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdate { get; set; }

        public Guid UserCreataID { get; set; }

        public Guid UserUpdateID { get; set; }

        public List<Classroom> Classrooms { get; set; }
        public List<Assignment> Assignments { get; set; }

    }
}
