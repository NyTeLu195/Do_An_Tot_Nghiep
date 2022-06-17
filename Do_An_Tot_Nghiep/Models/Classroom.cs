using System;

namespace Do_An_Tot_Nghiep.Models
{
    public class Classroom
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Year { get; set; }
        
        public Guid HomeroomTeacherID { get; set; }

        public int TotalNumberStudent { get; set; }
        public int Grade { get; set; }

        public string Status { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdate { get; set; }

        public Guid UserCreataID { get; set; }

        public Guid UserUpdateID { get; set; }


    }
}
