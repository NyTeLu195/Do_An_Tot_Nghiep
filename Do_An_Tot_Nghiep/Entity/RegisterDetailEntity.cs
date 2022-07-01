using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Do_An_Tot_Nghiep.Entity
{
    public class RegisterDetailEntity
    {
        public Guid Id { get; set; }
        public Guid RegisterID { get; set; }
        public RegisterEntity RegisterEntity { get; set; }
        public DateTime Date { get; set; }
        public Guid AssignmentID { get; set; }
        public AssignmentEntity AssignmentEntity { get; set; }
        public float Scores { get; set; }
        public string Status { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public Guid UserCreataID { get; set; }
        public Guid UserUpdateID { get; set; }



    }
}
