
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Do_An_Tot_Nghiep.Entity
{
    public class ClassroomEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Guid? TeacherID { get; set; }
        public TeacherEntity TeacherEntity { get; set; }    
        public int TotalNumberStudent { get; set; }
        public int Grade { get; set; }
        public string Status { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public Guid UserCreataID { get; set; }
        public Guid UserUpdateID { get; set; }
        public List<AssignmentEntity> AssignmentEntitys { get; set; }
        public List<RegisterEntity> RegisterEntitys { get; set; }

    }
}
