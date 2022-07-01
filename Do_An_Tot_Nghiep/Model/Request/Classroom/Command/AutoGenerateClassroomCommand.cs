using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Do_An_Tot_Nghiep.Model
{
    public class AutoGenerateClassroomCommand
    {
        public int Grande { get; set; }
        public string Key { get; set; }
        public int Total { get; set; }
        public int Year { get; set; }
        public Guid UserID { get; set; }

    }
}
