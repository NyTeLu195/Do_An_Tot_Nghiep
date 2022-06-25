﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace EduManage.Domain.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public Guid StudentID { get; set; }
        public string History { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public Guid UserCreataID { get; set; }
        public Guid UserUpdateID { get; set; }


    }
}
