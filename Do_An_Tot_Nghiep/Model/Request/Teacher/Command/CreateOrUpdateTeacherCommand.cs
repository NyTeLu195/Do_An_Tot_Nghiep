using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Do_An_Tot_Nghiep.Model
{
    public class CreateOrUpdateTeacherCommand
    {
        public Guid? Id { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserLoginID { get; set; }
    }
}
