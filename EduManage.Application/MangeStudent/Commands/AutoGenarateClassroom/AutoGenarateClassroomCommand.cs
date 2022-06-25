using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.Application.Models;
using EduManage.Core.Application.Configuration.Commands;
namespace EduManage.Application
{
    public class AutoGenarateClassroomCommand : CommandBase<ResponseModel>
    {
        public int Grande { get; set; }
        public string Key { get; set; }
        public int Year { get; set; }

        public int Total { get; set; }
        public Guid UserID { get; set; }
    }
}
