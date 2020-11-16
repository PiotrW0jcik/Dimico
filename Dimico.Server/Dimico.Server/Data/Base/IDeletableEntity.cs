using System;

namespace Dimico.Server.Data.Base
{
    public interface IDeletableEntity : IEntity
    {
         DateTime? DeletedOn { get; set; }

         string DeletedBy { get; set; }

         bool IsDeleted { get; set; }
    }
}
