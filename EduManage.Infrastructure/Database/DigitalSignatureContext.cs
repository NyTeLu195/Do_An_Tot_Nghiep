using Microsoft.EntityFrameworkCore;
using VNR.Core.Infrastructure.Database;
using VNR.DigitalSignature.Domain.Entities;

namespace VNR.DigitalSignature.Infrastructure.Database
{
    public class DigitalSignatureContext : BaseDbContext
    {
        public DigitalSignatureContext(DbContextOptions<DigitalSignatureContext> options)
         : base(options)
        {

        }
        public DbSet<Sys_UserInfo> Sys_UserInfos { get; set; }
        public DbSet<Sys_ConfigSignature> Sys_ConfigSignatures { get; set; }
        public DbSet<Sys_ConfigSignatureDetail> Sys_ConfigSignatureDetails { get; set; }
        public DbSet<Sys_SignData> Sys_SignDatas { get; set; }
        public DbSet<Sys_SignDataDetail> Sys_SignDataDetails { get; set; }
        public DbSet<Sys_SignContractData> Sys_SignContractData { get; set; }
        public DbSet<Sys_SignContractDataDetail> Sys_SignContractDataDetail { get; set; }
        public DbSet<Sys_Ref> Sys_Refs { get; set; }
        public DbSet<Sys_Event> Sys_Events { get; set; }
        public DbSet<Sys_SignatureHistory> Sys_SignatureHistorys { get; set; }
        
    }
}
