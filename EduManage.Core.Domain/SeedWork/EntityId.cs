using System;

namespace EduManage.Core.Domain.SeedWork
{
    public class EntityId : TypedIdValueBase
    {
        public EntityId(Guid value) : base(value)
        {
        }

        public static explicit operator EntityId(Guid guid) => new EntityId(guid);
    }
}
