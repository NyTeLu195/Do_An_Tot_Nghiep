
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Do_An_Tot_Nghiep.Entity
{
    public class ViolationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Score { get; set; }
        public int PenaltyPoint { get; set; }
        public string Status { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public Guid UserCreataID { get; set; }
        public Guid UserUpdateID { get; set; }
        List<ViolationHistoryEntity> violationHistoryEntities { get; set; }

    }
}
