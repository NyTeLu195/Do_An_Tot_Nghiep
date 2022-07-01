using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Tot_Nghiep.Model
{
    public class ResponseModel
    {
        public bool isSuccess { get; set; }
        public object data { get; set; }
        public object data2 { get; set; }
        public object data3 { get; set; }
        public string message { get; set; }
    }
}
