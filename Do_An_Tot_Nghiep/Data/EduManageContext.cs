using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Do_An_Tot_Nghiep.Entity;

    public class EduManageContext : DbContext
    {
        public EduManageContext (DbContextOptions<EduManageContext> options)
            : base(options)
        {
        }

        public DbSet<Do_An_Tot_Nghiep.Entity.AssignmentEntity> AssignmentEntity { get; set; }

        public DbSet<Do_An_Tot_Nghiep.Entity.AttendanceEntity> AttendanceEntity { get; set; }

        public DbSet<Do_An_Tot_Nghiep.Entity.ClassroomEntity> ClassroomEntity { get; set; }

        public DbSet<Do_An_Tot_Nghiep.Entity.RegisterDetailEntity> RegisterDetailEntity { get; set; }

        public DbSet<Do_An_Tot_Nghiep.Entity.RegisterEntity> RegisterEntity { get; set; }

        public DbSet<Do_An_Tot_Nghiep.Entity.StudentsEntity> StudentsEntity { get; set; }

        public DbSet<Do_An_Tot_Nghiep.Entity.TeacherEntity> TeacherEntity { get; set; }

        public DbSet<Do_An_Tot_Nghiep.Entity.ViolationEntity> ViolationEntity { get; set; }

        public DbSet<Do_An_Tot_Nghiep.Entity.ViolationHistoryEntity> ViolationHistoryEntity { get; set; }
    }
