using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.Core.Domain.Repository;
using EduManage.Domain.Entities;
namespace EduManage.Domain
{
    public class ISys_MangeStudentRepository: IRepository<EduManage.Domain.Entities.Students>
    {
        List<Students> GetListByIds(List<EntityId> listIds);
    }
}
