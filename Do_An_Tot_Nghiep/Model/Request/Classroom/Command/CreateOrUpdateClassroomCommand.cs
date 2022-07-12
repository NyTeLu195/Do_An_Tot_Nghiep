using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Do_An_Tot_Nghiep.Model
{
    public class CreateOrUpdateClassroomCommand
    {
        public Guid? Id { get; set; }
        public int Grande { get; set; }
        public string Key { get; set; }
        public int Order { get; set; }
        public Guid? TeacherId { get; set; }
        public int Year { get; set; }

    }
}
 