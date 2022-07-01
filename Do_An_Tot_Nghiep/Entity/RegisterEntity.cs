using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Do_An_Tot_Nghiep.Entity
{
    public class RegisterEntity
    {
        public Guid Id { get; set; }
        public Guid ClassRoomID { get; set; }
        public ClassroomEntity ClassroomEntity { get; set; }
        public int Semester { get; set; }
        public string Status { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public Guid UserCreataID { get; set; }
        public Guid UserUpdateID { get; set; }

        List<RegisterDetailEntity> registerDetailEntities { get; set; }


    }
}
