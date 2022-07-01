using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Do_An_Tot_Nghiep.Model
{
    public class AddHomeroomTeacherCommand
    {
        public Guid TeacherID { get; set; }
        public Guid ClassroomID { get; set; }
        public Guid UserLoginID { get; set; }

    }
}
 