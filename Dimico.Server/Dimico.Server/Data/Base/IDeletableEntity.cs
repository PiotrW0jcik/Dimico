using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dimico.Server.Data.Base
{
    public interface IDeletableEntity : IEntity
    {
         DateTime? DeletedOn { get; set; }

         string DeletedBy { get; set; }

         bool IsDeleted { get; set; }
    }
}
