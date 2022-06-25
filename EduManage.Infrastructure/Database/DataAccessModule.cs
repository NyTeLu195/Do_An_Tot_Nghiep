using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using EduManage.Core.Infrastructure.Database;
using EduManage.Core.Infrastructure.SeedWork;
using EduManage.Domain;
using EduManage.Infrastructure.Data.Repositories;

namespace EduManage.Infrastructure.Database
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly string _databaseConnectionString;

        public DataAccessModule(string databaseConnectionString)
        {
            this._databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Sys_UserInfoRepository>()
                .As<ISys_UserInfoRepository>()
                .InstancePerLifetimeScope();

           
            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<DigitalSignatureContext>();
                    dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);
                    dbContextOptionsBuilder
                        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    return new DigitalSignatureContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<BaseDbContext>()
                .InstancePerLifetimeScope();
        }
    }
}