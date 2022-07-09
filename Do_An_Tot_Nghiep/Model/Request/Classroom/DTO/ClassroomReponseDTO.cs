using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Do_An_Tot_Nghiep.Model
{
    public class ClassroomReponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string TeacherName { get; set; }
        public int TotalNumberStudent { get; set; }
        public int Grade { get; set; }
        public string Status { get; set; }
    }
}
