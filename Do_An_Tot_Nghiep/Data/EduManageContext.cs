using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Do_An_Tot_Nghiep.Models;

public class EduManageContext : DbContext
{
    public EduManageContext(DbContextOptions<EduManageContext> options)
        : base(options)
    {
    }

    public DbSet<Do_An_Tot_Nghiep.Models.Assignment> Assignment { get; set; }

    public DbSet<Do_An_Tot_Nghiep.Models.Attendance> Attendance { get; set; }

    public DbSet<Do_An_Tot_Nghiep.Models.Classroom> Classroom { get; set; }

    public DbSet<Do_An_Tot_Nghiep.Models.Students> Students { get; set; }

    public DbSet<Do_An_Tot_Nghiep.Models.Teacher> Teacher { get; set; }

    public DbSet<Do_An_Tot_Nghiep.Models.Violation> Violation { get; set; }
    public DbSet<Do_An_Tot_Nghiep.Models.ViolationHistory> ViolationHistory { get; set; }

}

